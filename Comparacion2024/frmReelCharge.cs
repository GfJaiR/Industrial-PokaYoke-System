using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Sealevel;
using System.Data.SqlClient;
using System.Threading;
namespace Comparacion2024
{
    public partial class frmReelCharge : Form
    {
        private bool keyAlreadyProcessed = false;
        private bool keyAlreadyProcessed2 = false;
        string connectionString = "Server=NGNAB001; Database=DBLoginMPM;User Id=hornosUser; Password=Conti123;";
        private frmMain main;
        private DataTable datatable;
        private string[] numerosDeParte;
        bool? esStencil;
        private string nomEs;
       

        ClsComparaciones comp = new ClsComparaciones();
        ClsTelegram tel = new ClsTelegram();
        private ClsConex conexion;
        string Pasta1, Pasta2, Stencil, slot, Resul;
        string[] mensajeEscanear = {"Volver a Escanear Pasta1","Volver a Escanear Pasta2","Volver a Escanear Stencil"};
        int numpasta;
        int []num1 = {0,0,0,0};
        int contadormensaje;
        int? rol;
        byte []PastValues = {1,1,1,1};
        bool encontrado = false;
        public bool ComparacionPasta1Correcta { get; private set; }
        public bool ComparacionPasta2Correcta { get; private set; }
        public bool ComparacionStencilCorrecta { get; private set; }
        int[] cambio = { 3,3,3,3};
        private bool bypass;
        public frmReelCharge(DataTable dataTable, string[] numerosdeparte, frmMain m,string nombreest,bool by,int num,int? id)
        {
            this.numpasta = num;
            this.datatable = dataTable;
            this.numerosDeParte = numerosdeparte;
            this.main = m;
            this.rol = id;
            this.nomEs = nombreest;
            this.bypass = by;
            InitializeComponent();
			if (!bypass)
			{
				this.main.DataUpdated += MainForm_DataUpdated;
			}
			//SubscribeToValuesChanged();
			conexion = new ClsConex();
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        // En la forma receptora
        private void Form2_Load(object sender, EventArgs e)
        {
            txtReelUserID.Focus();
            txtFeeder.TabStop = false;
            CenterFormOnScreen();
            txtFeeder.ReadOnly = true;
            //main.OnDataRead += UpdateLabelBasedOnData;
          
           
            txtReelUserID.MaxLength = 8;
           
        }
        private bool VerificarReelExistente(string reelID)
        {
             bool reelExists = false;
    SqlConnection connection = new SqlConnection(connectionString);
    try
    {
        string query = @"
            SELECT COUNT(*) 
            FROM (
                SELECT ReelID FROM Stenciles WHERE ReelID = @ReelID
                UNION ALL
                SELECT ReelID FROM Pastas WHERE ReelID = @ReelID
            ) AS CombinedResult";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@ReelID", reelID);

        connection.Open();
        int count = (int)cmd.ExecuteScalar();

        reelExists = (count > 0);
    }
    catch (Exception ex)
    {
        // Maneja cualquier excepción que pueda ocurrir al conectarse a la base de datos
        MessageBox.Show("Error al verificar el ReelID en la base de datos: " + ex.Message);
    }
    finally
    {
        connection.Close();
    }

    return reelExists;
        }
        public void Comp()
        {
            try
            {

                if (CamposValidos())
                {
					if (txtReelID.Text.Substring(txtReelID.Text.Length - 1) != "A")
					{
                        MessageBox.Show($"El numero de empleado no concuerda con el formato requerido: 123456A", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        VaciarCampos();
                    }
					else
					{
                        if (esStencil != null)
                        {
                            if (VerificarReelExistente(txtReelID.Text))
                            {
                                ProcesarStencil();
                            }
                            else
                            {
                                ManejarReelNoExistente();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Error, el ID No se puede identificar como pasta o stencil\nasegurese de haber escaneado el codigo correcto (MatLabel)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            VaciarCampos();
                        }
                    }
					
                   
                }

                else
                {
                    MessageBox.Show("Todos los campos son obligatorios. (Numero de Empleado y ReelID)");
                    VaciarCampos();
                }
            }
            catch (Exception ex)
            {
                //Logger.LogError("Error en el método Comp: " + ex.Message);
            //    MessageBox.Show("Error:" + ex.ToString());
            }
        }

        private bool CamposValidos()
        {
            return !string.IsNullOrEmpty(txtFeeder.Text) &&
                   !string.IsNullOrEmpty(txtReelUserID.Text) &&
                   !string.IsNullOrEmpty(txtReelID.Text);
        }

        private void ProcesarStencil()
        {
            string numpart = EnviarNumeroParte(txtReelID.Text);
            AsignarPastas(numerosDeParte);

            if (datatable.Rows.Count > 0)
            {
                ProcesarComparaciones(numpart);
            }
            else
            {
                MessageBox.Show("No hay datos en el DataGridView.");
            }
        }
        private void AsignarPastas(string[] numerosDeParte)
        {
            if (numerosDeParte.Length >= 2)
            {
                Pasta1 = numerosDeParte[0];
                Pasta2 = numerosDeParte.Length >= 3 ? numerosDeParte[1] : "";
                Stencil = numerosDeParte.Length >= 3 ? numerosDeParte[2] : numerosDeParte[1];
            }
        }
        private void ProcesarComparaciones(string numpart)
        {
            bool encontrado = false;

            foreach (DataRow fila in datatable.Select("Slot = '" + slot + "'"))
            {
                string numeroDeParteGrid = fila["Part No"].ToString();

                if (numeroDeParteGrid == numpart)
                {
                    ActualizarResultadoPorSlot();
                    FrmCorrect frm = new FrmCorrect(esStencil, this);
                    
                    frm.Show();
                    
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                MostrarResultadoIncorrecto();
                FrmIncorrect frm = new FrmIncorrect(esStencil, this);
                frm.Show();
             
            }

            comp.AgregarComparaciones(Convert.ToInt32(txtReelUserID.Text), nomEs, Pasta1, Pasta2, Stencil, DateTime.Now, Resul);
         
        }
        private void ActualizarResultadoPorSlot()
        {
            switch (Convert.ToInt32(slot))
            {
                case 1:
                    Resul = "Comparacion de Pasta 1 - CORRECTA";
                    CompService.Instance.ComparacionPasta1Correcta = true;
                    break;
                case 2:
                    Resul = "Comparacion de Pasta 2 - CORRECTA";
                    CompService.Instance.ComparacionPasta2Correcta = true;
                    break;
                case 3:
                    Resul = "Comparacion de Stencil - CORRECTA";
                    CompService.Instance.ComparacionStencilCorrecta = true;
                    break;
            }
            main.RegistrarAccion(Resul);
        }
        private void MostrarResultadoIncorrecto()
        {
            switch (Convert.ToInt32(slot))
            {
                case 1:
                    Resul = "Comparacion de Pasta 1 - INCORRECTA";
                    CompService.Instance.ComparacionPasta1Correcta = false;
                    break;
                case 2:
                    Resul = "Comparacion de Pasta 2 - INCORRECTA";
                    CompService.Instance.ComparacionPasta2Correcta = false;
                    break;
                case 3:
                    Resul = "Comparacion de Stencil - INCORRECTA";
                    CompService.Instance.ComparacionStencilCorrecta = false;
                    break;
            }
            main.RegistrarAccion(Resul);
        }
        private void ManejarReelNoExistente()
        {
			try
			{
                if (esStencil == true)
                {
                    MessageBox.Show("Es necesario dar de alta el stencil para continuar, llame a un ingeniero.");
                }
                else if (rol == 1 && esStencil == true)
                {
                    frmAddReel frmagregarreel = new frmAddReel(txtReelUserID.Text, txtReelID.Text);
                    frmagregarreel.Show();
                }
                else
                {
                    // Agregar la pasta automáticamente si no es un stencil y el reel no existe y procesarla
                    string partno = txtReelID.Text.Length >= 13 ? txtReelID.Text.Substring(0, 13) : txtReelID.Text;
                    new ClsPastas().AgregarPasta(txtReelUserID.Text, txtReelID.Text, partno, 0, 0);
                    ProcesarStencil();
                }
            }
			catch (Exception ex)
			{
                MessageBox.Show("Error:" + ex.ToString());
			
			}
           
        }
		//public void SubscribeToValuesChanged()
		//{

		//    main.ValuesChanged += FormOrigin_ValuesChanged;
		//}
		private void MainForm_DataUpdated(byte[] data)
		{
			if (bypass)
			{
				// Si bypass es verdadero, desuscribirse del evento y salir del método
				return;
			}
			else
			{
				// Actualiza la interfaz de usuario o realiza procesamientos mediante los valores de la lista con cada byte
				if (this.InvokeRequired)
				{
					try
					{
						this.Invoke(new Action(() => MainForm_DataUpdated(data)));
					}
					catch (ObjectDisposedException)
					{
						return;
					}
					return;
				}

				if (this.Visible && this.WindowState != FormWindowState.Minimized)
				{
					for (int i = 0; i < 3; i++)
					{
						contadormensaje = i;
						if (data[i] == 0 && PastValues[i] == 1)
						{
							cambio[i] = 0;
							PastValues[i] = data[i];
						}
						if (data[i] == 1 && PastValues[i] == 0)
						{
							cambio[i] = 1;
							PastValues[i] = data[i];
						}

						if (data[i] == 0)
						{
							slot = Convert.ToString(i + 1);
							txtFeeder.Text = Convert.ToString(i + 1);

							if (cambio[i] == 0)
							{
								// Cerrar el formulario de espera
								if (this.Tag is Form waitForm)
								{
									waitForm.Close();
									this.Tag = null; // Limpiar la referencia al formulario de espera
								}
								Comp();
								txtReelUserID.Focus();
								cambio[i] = 1;
								num1[i] = 0;
							}
						}
						else if (data[i] == 1 && cambio[i] == 1 && num1[i] == 0)
						{

							num1[i] = 1;
						}
					}
				}
			}
		}
		private Task ShowMessageAsync(string message)
        {
            return Task.Run(() =>
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => MessageBox.Show(message)));
                }
                else
                {
                    MessageBox.Show(message);
                }
            });
        }
        private void ComboLabelID_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("Slot [1] en Estacion [Tianjin]", "Numero de Parte En El Programa Actual", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CenterFormOnScreen()
        {
            // Obtener el tamaño de la pantalla
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Calcular la posición para centrar el formulario
            int formWidth = this.Width;
            int formHeight = this.Height;

            int posX = (screenWidth - formWidth) / 2;
            int posY = (screenHeight - formHeight) / 2;

            // Establecer la posición del formulario
            this.Location = new System.Drawing.Point(posX, posY);
        }

     

      

        private void txtFeeder_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    txtReelID.Focus();
            //}
        }

        private void txtNumPartComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOkUp_Click(sender, e);
            }
        }

        private void txtReelID_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Tab && txtReelID.Text == null)
			{
                txtReelID.Focus();
			}
			else
			{
             
                if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && !keyAlreadyProcessed2)
                {
                    keyAlreadyProcessed2 = true; // Marca que ya se ha procesado una tecla válida
                    e.SuppressKeyPress = true; // Previene la acción por defecto de la tecla
                    if (bypass == true)
                    {
                        Comp();
                    }
				else if (CamposValidos())
					{
                        if (VerificarReelExistente(txtReelID.Text) == true)
                        {
                            FrmStandby waitForm = new FrmStandby();
                            waitForm.Show();

                            // Guardar el formulario de espera para cerrarlo después
                            this.Tag = waitForm;
                        }
                        else
                        {
                            ManejarReelNoExistente();
                        }

                    }
					else
					{
                        MessageBox.Show($"Hay Campos Sin Llenar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				
                    
                }
            }
          
        }
       
        private string EnviarNumeroParte(string reelID)
        {
            string a;

            bool? result = esStencil;
            try
            {
				if (result ==true)
				{
                    a = "Stenciles"; 
				}
				else
				{
                    a = "Pastas";
				}
                string numeroParte;
                SqlConnection connection = new SqlConnection(connectionString);

                string query = "SELECT PartNo FROM " + a + " WHERE ReelID = @ReelID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ReelID", reelID);

                connection.Open();
                numeroParte = (string)cmd.ExecuteScalar();
                return numeroParte;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el numero de parte: " + ex);
				return null;
			}
           
        }
      

        private void frmReelCharge_FormClosed(object sender, FormClosedEventArgs e)
        {
			//main.OnDataRead -= UpdateLabelBasedOnData;
		}

        private void frmReelCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
			////main.ValuesChanged -= FormOrigin_ValuesChanged;
			main.DataUpdated -= MainForm_DataUpdated;
		}

        private void btnOkUp_Click(object sender, EventArgs e)
        {
			if (bypass == true)
			{
				Comp();
			}
			
		}
 
        private void txtReelUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab) && !keyAlreadyProcessed)
            {
                keyAlreadyProcessed = true; // Marca que ya se ha procesado una tecla válida
                e.SuppressKeyPress = true; // Previene la acción por defecto de la tecla
                txtReelID.Focus(); // Cambia el foco al siguiente control
            }

        }

		private void frmReelCharge_TextChanged(object sender, EventArgs e)
		{

		}

		private void txtReelUserID_KeyPress(object sender, KeyPressEventArgs e)
		{
            // Verifica si el carácter presionado es alfanumérico
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es alfanumérico o una tecla de control, cancela el evento
                e.Handled = true;
            }
        }

		private void txtReelID_KeyPress(object sender, KeyPressEventArgs e)
		{
            // Verifica si el carácter presionado es alfanumérico o el símbolo especial @
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && !char.IsControl(e.KeyChar))
            {
                // Si no es alfanumérico, @ o una tecla de control, cancela el evento
                e.Handled = true;
            }
        }

		private void txtReelUserID_KeyUp(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                keyAlreadyProcessed = false; // Resetea la variable al soltar la tecla
            }
        }

		private void txtReelID_KeyUp(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                keyAlreadyProcessed2 = false; // Resetea la variable al soltar la tecla
            }
        }

		public void VaciarCampos()
		{
            txtReelUserID.Text = "";
            txtReelID.Text = "";
            txtReelUserID.Focus();
		}
		private void txtReelID_TextChanged(object sender, EventArgs e)
		{
			if (txtReelID.Text.Contains("@"))
			{
                esStencil = false;
			}
			else if (txtReelID.Text.Length >= 2 && txtReelID.Text.StartsWith("ST"))
			{
                esStencil = true;
			}
			else
			{
                esStencil = null;
			}
			if (bypass == true)
			{
                if (txtReelID.Text.Contains("@"))
                {
                    if (numerosDeParte.Length == 2)
                    {
                        slot = "1";

                        txtFeeder.Text = "1";
                    }
                   else if (numerosDeParte.Length == 3)
					{
						if (CompService.Instance.ComparacionPasta1Correcta == true)
						{
							slot = "2";

							txtFeeder.Text = "2";
						}
						else if (CompService.Instance.ComparacionPasta2Correcta == true)
						{
							slot = "1";

							txtFeeder.Text = "1";
						}
						else if (CompService.Instance.ComparacionPasta1Correcta == false && CompService.Instance.ComparacionPasta2Correcta == false)
						{
							slot = "1";

							txtFeeder.Text = "1";
						}
					}


                }
				else
				{
                    
                        slot = "3";
                        txtFeeder.Text = "3";
                    
                }
                
            }
           
        }
        public bool? isStencil(string id)
        {
			
                if (id.Substring(0, 2) == "ST")
                {
                    return true; // Es stencil
                }
                else if (id.Contains("@"))
                {
                    return false; // Es pasta
                }
                else
                {
                    ShowMessageAsync("No se puede identificar como pasta o stencil");
                    return null;
                     // No se puede identificar como stencil ni pasta
                }
            
			

           
        }
        private void checkDisableLabel_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
