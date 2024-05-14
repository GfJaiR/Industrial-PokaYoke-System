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
       
        string connectionString = "Server=NGL0121W\\SQLEXPRESS01; Database=DBLoginMPM;Integrated Security=true";
        private frmMain main;
        private DataTable datatable;
        private string[] numerosDeParte;

        private string nomEs;
        frmAddReel frmagregarreel = new frmAddReel();
       
        ClsComparaciones comp = new ClsComparaciones();
        ClsTelegram tel = new ClsTelegram();
        private ClsConex conexion;
        string Pasta1, Pasta2, Stencil, slot, Resul = "X";
        int num0 = 0;
        int num1 = 0;
        byte PastValues = 255;
        bool encontrado = false;
        private bool comparacionPastaCorrecta = false;
        private bool comparacionStencilCorrecta = false;
       
        private bool bypass;
        public frmReelCharge(DataTable dataTable, string[] numerosdeparte, frmMain m,string nombreest,bool by)
        {
            this.datatable = dataTable;
            this.numerosDeParte = numerosdeparte;
            this.main = m;
            this.nomEs = nombreest;
            this.bypass = by;
            InitializeComponent();
            this.main.DataUpdated += MainForm_DataUpdated;
            SubscribeToValuesChanged();
            conexion = new ClsConex();
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        // En la forma receptora
        private void Form2_Load(object sender, EventArgs e)
        {
           
            CenterFormOnScreen();
            //main.OnDataRead += UpdateLabelBasedOnData;
          
           
            txtReelUserID.MaxLength = 8;
           
        }
        public void Comp()
        {

			if (isStencil(txtReelID.Text) == true)
			{
                main.RegistrarAccion("Comparacion de Stencil");
            }
			else
			{
                main.RegistrarAccion("Comparacion de Pasta");
            }
               

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
                    DataRow[] filasFiltradas = datatable.Select("Slot = '" + txtFeeder.Text + "'");

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
                                Resul = "OK";
                            if (isStencil(txtReelID.Text) == true)
                            {
                              
                                comparacionStencilCorrecta = true; // Actualiza el estado de la comparación del stencil
                            }
                            else
                            {
                              
                                comparacionPastaCorrecta = true; // Actualiza el estado de la comparación de la pasta
                            }   
                            encontrado = true; // Actualiza la variable bandera para indicar que se encontró una coincidencia
                                FrmCorrect frm = new FrmCorrect(isStencil(txtReelID.Text));
                                frm.ShowDialog();
                                break; // Sale del bucle ya que se encontró una coincidencia
                            }
                        }

                        // Verifica si después de la iteración no se encontró ninguna coincidencia
                        if (!encontrado)
                        {
                        if (isStencil(txtReelID.Text) == true)
                        {
                          
                            comparacionStencilCorrecta = false; // Actualiza el estado si la comparación falla
                        }
                        else
                        {
                           
                            comparacionPastaCorrecta = false; // Actualiza el estado si la comparación falla
                        }
                        FrmIncorrect frm = new FrmIncorrect(isStencil(txtReelID.Text));
                            frm.ShowDialog();
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

           
			
        }
        public void SubscribeToValuesChanged()
        {

            main.ValuesChanged += FormOrigin_ValuesChanged;
        }
        private void MainForm_DataUpdated(byte[] data)
        {
			//Actualiza la interfaz de usuario o realiza procesamientos mediante los valores de la lista con cada byte

			
		}
        private void FormOrigin_ValuesChanged(byte[] newValues)
        {
           
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() => FormOrigin_ValuesChanged(newValues)));
                }
                catch (ObjectDisposedException)
                {

                    return;
                }
                return;
            }
           
               
            

            // Verifica si la forma está visible y no minimizada.
            if (this.Visible && this.WindowState != FormWindowState.Minimized)
            {
                Thread.Sleep(5000);
                if (PastValues == 4 || PastValues == 20 || PastValues == 12 || PastValues == 28)
                {
                    if (newValues[0] == 0 || newValues[0] == 16 || newValues[0] == 8 || newValues[0] == 24)
                    { num0 = 0; }


                }
                if (newValues[0] == 0 || newValues[0] == 16 || newValues[0] == 8 || newValues[0] == 24)
                {
                    slot = "1";
                    txtFeeder.Text = "1";
                    if (num0 == 0)
                    {
						if (bypass == true)
						{

						}
						else
						{
                            Comp();
                        }
                        
                        num0 = 1;
                    }
                }

                if (PastValues == 8 || PastValues == 24 || PastValues == 12 || PastValues == 28)
                {
                    if (newValues[0] == 4 || newValues[0] == 0 || newValues[0] == 16 || newValues[0] == 20)
                    {
                        num1 = 0;
                    }

                }
                if (newValues[0] == 4 || newValues[0] == 0 || newValues[0] == 16 || newValues[0] == 20)
                {
                    txtFeeder.Text = "3";
                    slot = "3";
                    if (num1 == 0)
                    {
						if (bypass == true)
						{
                            
                        }
						else
						{
                            Comp();
                        }
                       
                        num1 = 1;
                    }

                }
                else
                {
                    txtFeeder.Text = "";
                    slot = "";
                }
                PastValues = newValues[0];
            }
        }
        public bool VerificarResultados()
        {
            if (comparacionPastaCorrecta && comparacionStencilCorrecta)
            {
                // Ambas comparaciones son correctas, proceder con los siguientes pasos.
                // Implementa aquí lo que debería ocurrir si la verificación es correcta.
                return true;
            }
            else
            {
                // Manejar el caso donde alguna de las comparaciones es incorrecta.
                return false;
            }
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
            
            try
            {
                string numeroParte;
                SqlConnection connection = new SqlConnection(connectionString);

                string query = "SELECT PartNo FROM Reels WHERE ReelID = @ReelID";
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
            main.ValuesChanged -= FormOrigin_ValuesChanged;
        }

        private void btnOkUp_Click(object sender, EventArgs e)
        {
            if (bypass == true)
            {
                Comp();
            }
        }
   //     public void Comparaciones()
   //     {
			//try
			//{
   //             reelnum = EnviarNumeroParte(txtReelID.Text);

   //             //Verificar si el ReelID existe en la base de datos

   //             bool reelExists = VerificarReelExistente(txtReelID.Text);
   //             if (reelExists)
   //             {

   //                 frmConfirmar frmconf = new frmConfirmar(datatable, Convert.ToInt32(txtReelUserID.Text), numerosDeParte, reelnum, main, nomEs, isStencil(txtReelID.Text));
   //                 frmconf.ShowDialog();
   //             }
   //             else
   //             {
   //                 // Abre otro formulario para dar de alta el Reel/Pasta
   //                 AbrirFormularioAltaReel();
   //             }
   //         }
			//catch (Exception)
			//{
   //             MessageBox.Show("Error, verifique los datos: ");
             
			//}
           
            
   //     }
        private void txtReelUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFeeder.Focus();
            }
        }

		private void txtReelID_TextChanged(object sender, EventArgs e)
		{
			
        }
        public bool isStencil(string id)
		{
			try
			{
                 bool stencil = false;
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
                MessageBox.Show("ID Imposible de identificar como pasta o stencil");
            }
            return stencil;
			}
			catch (Exception)
			{

				throw;
			}
           
        }

		private void checkDisableLabel_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
