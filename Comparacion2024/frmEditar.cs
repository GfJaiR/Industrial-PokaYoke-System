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
	public partial class frmEditar : Form
	{
        private string originalQuantity;
        private frmMain forma;
        private CrudReel formacrud;
		public string RegistroID { get; set; }
        string connectionString = "Server=NGNAB001; Database=DBLoginMPM;User Id=hornosUser; Password=Conti123;";
        string CurrentTable;
        public frmEditar(frmMain form, string current, CrudReel frm)
		{
            this.formacrud = frm;
            this.forma = form;
            this.CurrentTable = current;
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{

            // Prepara la consulta SQL
            string query = "UPDATE " + CurrentTable + " SET UserID = @UserID, ReelID = @ReelID, PartNo = @PartNo, Quantity = @Quantity, LastQuantitySet = @LastQuantitySet WHERE RegistroID = @RegistroID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Asigna los valores de los TextBox a los parámetros
                    command.Parameters.AddWithValue("@UserID", txtUserID.Text);
                    command.Parameters.AddWithValue("@ReelID", txtReelID.Text);
                    command.Parameters.AddWithValue("@PartNo", txtPartNo.Text);
                    command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    command.Parameters.AddWithValue("@RegistroID", RegistroID);

                    // Verifica si txtQuantity ha cambiado
                    if (txtQuantity.Text != originalQuantity)
                    {
                        command.Parameters.AddWithValue("@LastQuantitySet", originalQuantity);
                    }
                    else
                    {
                        // Si no ha cambiado, mantiene el valor actual de LastQuantitySet en la base de datos
                        string getLastQuantityQuery = "SELECT LastQuantitySet FROM " + CurrentTable + " WHERE RegistroID = @RegistroID";

                        using (SqlCommand getLastQuantityCommand = new SqlCommand(getLastQuantityQuery, connection))
                        {
                            getLastQuantityCommand.Parameters.AddWithValue("@RegistroID", RegistroID);
                            connection.Open();
                            object lastQuantity = getLastQuantityCommand.ExecuteScalar();
                            connection.Close();

                            command.Parameters.AddWithValue("@LastQuantitySet", lastQuantity ?? (object)DBNull.Value);
                        }
                    }

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Datos actualizados correctamente.");
                            formacrud.Actualizardgv();
                            forma.RefrescarDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar los datos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar: " + ex.Message);
                    }
                }
            }
            this.Close(); // Opcionalmente cierra el formulario
        }

		private void frmEditar_Load(object sender, EventArgs e)
		{
            CenterToScreen();
            originalQuantity = txtQuantity.Text;
            CargarDatos();
		}
        private void CargarDatos()
        {
          
            string query = "SELECT UserID, ReelID, PartNo, Quantity FROM " + CurrentTable + " WHERE RegistroID = @RegistroID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RegistroID", RegistroID); // Usa la propiedad RegistroID

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUserID.Text = reader["UserID"].ToString();
                                txtReelID.Text = reader["ReelID"].ToString();
                                txtPartNo.Text = reader["PartNo"].ToString();
                                txtQuantity.Text = reader["Quantity"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Registro no encontrado.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos: " + ex.Message);
                    }
                }
            }
        }

    }
}
