using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Comparacion2024
{
    public partial class frmAddReel : Form
    {
        //private frmMain forma = new frmMain();
        public frmAddReel()
        {
            InitializeComponent();
			//this.frmCrudReel = crud;
		}
        string connectionString = "Server=NGNAB001; Database=DBLoginMPM;User Id=hornosUser; Password=Conti123;";
        private void frmAddReel_Load(object sender, EventArgs e)
        {
            CenterFormOnScreen();
            txtSupplierP.ReadOnly = true;
            txtDateCode.ReadOnly = true;
            txtValue1.ReadOnly = true;
            txtValue2.ReadOnly = true;
            txtUserID.MaxLength = 8;
 
            if (checkContinuous.Checked == true)
            {
                btnNextUP.Enabled = false;
            }
            else
            {
                btnNextUP.Enabled = true;
            }
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
        public bool isStencil(string id)
        {
            bool stencil = false;
            try
            {
                
                if (id.Substring(0, 2) == "ST")
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

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error:" + ex);
                //throw;
            }
            return stencil;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            
            bool reelExists = VerificarReelExistente(txtReelID.Text);
            string NoUsuario = txtUserID.Text;
            string reelID = txtReelID.Text;
          
            int cant;
          
            ClsStenciles newstencil = new ClsStenciles();
            ClsPastas newpasta = new ClsPastas();
            try
            {
                if (reelExists)
                {
                    MessageBox.Show("El ReelID ya existe");
                }
                else
                {
					
                    if (txtPartNo.Text == "" || txtPartNo.Text == null)
                    {
                        MessageBox.Show("Ingrese el numero de parte");
                    }
                    else
                    {
                        if (txtUserID.Text.Length == 8)
                        {
                            string numerosinprefijo = txtPartNo.Text;
                            if (txtPartNo.Text.Length == 14 && txtPartNo.Text.StartsWith("P"))
                            {
                                numerosinprefijo = txtPartNo.Text.Substring(1);
                            }
							
                            if (txtQuantity.Text == "")
					            {
                                    cant = 0;
					            }
							else
							{
                                cant = Convert.ToInt32(txtQuantity.Text);
							}
							if (isStencil(txtReelID.Text))
							{
                                if (newstencil.AgregarStencil(NoUsuario, reelID, numerosinprefijo, cant))
                                {
                                    // Éxito: el usuario se creó correctamente
                                    MessageBox.Show("Stencil agregado exitosamente");


                                    //frmCrudReel.Actualizardgv();



                                }
                            }
							else if(isStencil(txtReelID.Text) == false)
							{
                                if (newpasta.AgregarPasta(NoUsuario, reelID, numerosinprefijo, cant))
                                {
                                    // Éxito: el usuario se creó correctamente
                                    MessageBox.Show("Pasta agregada exitosamente");
                                    //frmCrudReel.Actualizardgv();



                                }
                            }
                                
							else
							{
								MessageBox.Show("Error al agregar el reel, verifique los datos");
							}


						}
                        else
                        {
                            MessageBox.Show("El numero de empleado tiene menos o mas de 8 caracteres");
                        }
                    }
                }
               
               
              
            }
            catch (Exception ex)
            {
                // Fallo: no se pudo crear el Reel
                MessageBox.Show("Error al agregar el Reel: " + ex);
                //throw;
            }
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

        private void checkContinuous_CheckedChanged(object sender, EventArgs e)
        {
            if (checkContinuous.Checked == true)
            {
                btnNextUP.Enabled = false;
            }
            else
            {
                btnNextUP.Enabled = true;
            }
        }

		private void txtReelID_TextChanged(object sender, EventArgs e)
		{
			if (isStencil(txtReelID.Text))
			{
                txtQuantity.ReadOnly = false;
            }
			else
			{
              
                txtQuantity.ReadOnly = true;
            }
		}
	}
}
