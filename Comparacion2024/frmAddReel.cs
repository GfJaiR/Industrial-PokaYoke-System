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
        public frmAddReel()
        {
            InitializeComponent();
            //this.frmCrudReel = crud;
        }
        string connectionString = "Server=NGL0121W\\SQLEXPRESS01; Database=DBLoginMPM;Integrated Security=true";
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
            // Suponiendo que tienes una conexión a tu base de datos llamada 'conexionBD'
            // y una consulta SQL para verificar si el ReelID existe en una tabla llamada 'Reels'

            bool reelExists = false;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "SELECT COUNT(*) FROM Reels WHERE ReelID = @ReelID";
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
        private void btnOK_Click(object sender, EventArgs e)
        {
            
            bool reelExists = VerificarReelExistente(txtReelID.Text);
            string NoUsuario = txtUserID.Text;
            string reelID = txtReelID.Text;
          
            int cant;
            CrudReel frmreel = new CrudReel();
            ClsReels newreel = new ClsReels();
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
                                if (newreel.AgregarReel(NoUsuario, reelID, numerosinprefijo, cant))
                                {
                                    // Éxito: el usuario se creó correctamente
                                    MessageBox.Show("Reel agregado exitosamente");


                                    //frmCrudReel.Actualizardgv();



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
    }
}
