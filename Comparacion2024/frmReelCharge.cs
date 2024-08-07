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

        string connectionString = "Server=NGNAB001; Database=DBLoginMPM;User Id=hornosUser; Password=Conti123;";
        private frmMain main;
        private DataTable datatable;
        private string[] numerosDeParte;

        private string nomEs;
        frmAddReel frmagregarreel = new frmAddReel();

        ClsComparaciones comp = new ClsComparaciones();
        ClsTelegram tel = new ClsTelegram();
        private ClsConex conexion;
        string Pasta1, Pasta2, Stencil, slot, Resul = "X";
        string[] mensajeEscanear = {"Volver a Escanear Pasta1","Volver a Escanear Pasta2","Volver a Escanear Stencil"};
        int numpasta;
        int []num1 = {0,0,0,0};
        int contadormensaje; 
        byte []PastValues = {1,1,1,1};
        bool encontrado = false;
        public bool ComparacionPasta1Correcta { get; private set; }
        public bool ComparacionPasta2Correcta { get; private set; }
        public bool ComparacionStencilCorrecta { get; private set; }
        int[] cambio = { 3,3,3,3};
        private bool bypass;
        public frmReelCharge(DataTable dataTable, string[] numerosdeparte, frmMain m,string nombreest,bool by,int num)
        {
            this.numpasta = num;
            this.datatable = dataTable;
            this.numerosDeParte = numerosdeparte;
            this.main = m;
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
            CenterFormOnScreen();
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
			// Reiniciar valores de comparaciones antes de realizar nuevas comparaciones
			//CompService.Instance.ComparacionPasta1Correcta = false;
			//CompService.Instance.ComparacionPasta2Correcta = false;
			//CompService.Instance.ComparacionStencilCorrecta = false;
			bool reelExists = VerificarReelExistente(txtReelID.Text);

			if (reelExists)
			{
                if (txtFeeder.Text != "" && txtReelUserID.Text != "" && txtReelID.Text != "")
                {
                   


                    string numpart = EnviarNumeroParte(txtReelID.Text);

                    if (numerosDeParte.Length >= 2)
                    {
                        Pasta1 = numerosDeParte[0];
                        Pasta2 = "";
                        Stencil = numerosDeParte[1];
                    }

                    if (numerosDeParte.Length >= 3)
                    {
                        Pasta1 = numerosDeParte[0];
                        Pasta2 = numerosDeParte[1];
                        Stencil = numerosDeParte[2];
                    }
                    if (datatable.Rows.Count > 0)
                    {

                        // Filtra las filas del DataTable por el número de slot ingresado
                        DataRow[] filasFiltradas = datatable.Select("Slot = '" + slot + "'");

                        // Verifica si se encontraron filas con el número de slot especificado
                        if (filasFiltradas.Length > 0)
                            {
                            // Itera sobre las filas filtradas
                            foreach (DataRow fila in filasFiltradas)
                            {
                                // Obtiene el número de parte de la fila actual
                                string numeroDeParteGrid = fila["Part No"].ToString();

                                // Verifica si el número de parte coincide con el ingresado por el usuario
                                if (numeroDeParteGrid == numpart)
                                {
                                    

                                    if (Convert.ToInt32(slot) == 1)
                                    {
                                        Resul = "Comparacion de Pasta 1 - CORRECTA";
                                        CompService.Instance.ComparacionPasta1Correcta = true;
                                        /*comparacionStencilCorrecta = true;*/ // Actualiza el estado de la comparación del stencil
                                    }
									if (Convert.ToInt32(slot) == 2)
									{
                                        Resul = "Comparacion de Pasta 2 - CORRECTA";
                                        CompService.Instance.ComparacionPasta2Correcta = true;
                                    }
									if (Convert.ToInt32(slot) == 3)
									{
                                        Resul = "Comparacion de Stencil - CORRECTA";
                                        CompService.Instance.ComparacionStencilCorrecta = true;
                                    }                                  
                                    main.RegistrarAccion(Resul);                                                                   
                                    encontrado = true; // Actualiza la variable bandera para indicar que se encontró una coincidencia
                                    FrmCorrect frm = new FrmCorrect(isStencil(txtReelID.Text),this);
                                    frm.Show();
                                    break; // Sale del bucle ya que se encontró una coincidencia
                                }
                            }

                            // Verifica si después de la iteración no se encontró ninguna coincidencia
                            if (!encontrado)
                            {
                                if (Convert.ToInt32(slot) == 1)
                                {
                                    Resul = "Comparacion de Pasta 1 - INCORRECTA";
                                    CompService.Instance.ComparacionPasta1Correcta = false;
                                    /*comparacionStencilCorrecta = true;*/ // Actualiza el estado de la comparación del stencil
                                }
                                if (Convert.ToInt32(slot) == 2)
                                {
                                    Resul = "Comparacion de Pasta 2 - INCORRECTA";
                                    CompService.Instance.ComparacionPasta2Correcta = false;
                                }
                                if (Convert.ToInt32(slot) == 3)
                                {
                                    Resul = "Comparacion de Stencil - INCORRECTA";
                                    CompService.Instance.ComparacionStencilCorrecta = false;
                                }
                                main.RegistrarAccion(Resul);
                                FrmIncorrect frm = new FrmIncorrect(isStencil(txtReelID.Text),this);
                                frm.Show();
                             //   MessageBox.Show(mensajeEscanear[contadormensaje]);
                                //this.Close();
                                tel.Telegram(txtReelUserID.Text, nomEs, Pasta1, Pasta2, Stencil); // Llama al método Telegram ya que ninguna fila cumplió con la condición
                            }
                        }
                        else
                        {
                            // Si no se encontraron filas con el número de slot especificado
                            //MessageBox.Show("No se encontraron datos para el Feeder Detectado.");
                        }
                    }
                    else
                    {
                        // Si no hay datos en el DataGridView
                        MessageBox.Show("No hay datos en el DataGridView.");
                    }
                    comp.AgregarComparaciones(Convert.ToInt32(txtReelUserID.Text), nomEs, Pasta1, Pasta2, Stencil, DateTime.Now, Resul);
                    VaciarCampos();
                }
            } 
			else if(txtFeeder.Text == "" && txtReelUserID.Text == "" && txtReelID.Text == "")
			{
               
			}
			else
			{
                frmagregarreel.Show();
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
                                Comp();
                                cambio[i] = 1;
                                num1[i] = 0;
                            }
                        }
                        else if (data[i] == 1 && cambio[i] == 1 && num1[i] == 0)
                        {
                            //if (i == 0)
                            //{
                            //    CompService.Instance.ComparacionPasta1Correcta = false;
                            //}
                            //if (i == 1)
                            //{
                            //    CompService.Instance.ComparacionPasta2Correcta = false;
                            //}
                            //if (i == 2)
                            //{
                            //    CompService.Instance.ComparacionStencilCorrecta = false;
                            //}

                            //await ShowMessageAsync(mensajeEscanear[i]);
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
            if (e.KeyCode == Keys.Enter)
            {
                txtReelID.Focus();
            }
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
            if (e.KeyCode == Keys.Enter)
            {
				if (bypass == true)
				{
                    Comp();
                }
               
            }
        }
       
        private string EnviarNumeroParte(string reelID)
        {
            string a;
            

            try
            {
				if (isStencil(reelID))
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
                throw;
            }
           
        }
      

        private void frmReelCharge_FormClosed(object sender, FormClosedEventArgs e)
        {
            //main.OnDataRead -= UpdateLabelBasedOnData;
        }

        private void frmReelCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            //main.ValuesChanged -= FormOrigin_ValuesChanged;
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
            if (e.KeyCode == Keys.Enter)
            {
                txtFeeder.Focus();
            }
        }
        public void VaciarCampos()
		{
            txtReelUserID.Text = "";
            txtReelID.Text = "";
		}
		private void txtReelID_TextChanged(object sender, EventArgs e)
		{
			
        }
        public bool isStencil(string id)
		{
            bool stencil = false;
            try
			{
                
            if (id.Substring(0,2) == "ST")
            {
                stencil = true;
            }
            else if (id.Contains("@"))
            {
              stencil = false;
            }
            else
            {
					ShowMessageAsync("ID Imposible de identificar como pasta o stencil");
				}
            
			}
			catch (Exception ex)
			{
                //Console.WriteLine("Error:" + ex);
				//throw;
			}
            return stencil;
        }

		private void checkDisableLabel_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
