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
using System.Data.Sql;
using Ude;

namespace Comparacion2024
{
  
    public partial class FrmManageUsers : Form
    {
        int? id;
        DataView datav = new DataView();
        private ClsConex conexion;
        private string nombreusuario;
        // Establecer la cadena de conexión
        string connectionString = "Server=NGL0121W\\SQLEXPRESS01; Database=DBLoginMPM;Integrated Security=true";
        DataSet dataSet = new DataSet();

        public FrmManageUsers(int? idUsuario,string nombreus)
        {
            this.nombreusuario = nombreus;
            InitializeComponent();
            conexion = new ClsConex();
            id = idUsuario;


        }
      
        private void btnCreate_Click(object sender, EventArgs e)
        {
            HashHelper help = new HashHelper();
            SqlConnection connection = new SqlConnection(connectionString);
            if (txtUsername.Text == "" || txtContrasena.Text == "")
            {
                MessageBox.Show("Favor de llenar correctamente los campos");
            }
            else
            {
                try
                {
                    if (txtContrasena.Text == txtConfirmarContrasena.Text)
                    {
                        // Crear un nuevo usuario
                        string nombreUsuarioNuevo = txtUsername.Text;
                        string contraseñaNueva = txtContrasena.Text;

                        UsuarioManager usuarioManager = new UsuarioManager();

                        bool esAdministrador = chkAdm.Checked;

                        if (usuarioManager.AgregarUsuario(nombreUsuarioNuevo, contraseñaNueva, esAdministrador))
                        {
                            // Éxito: el usuario se creó correctamente
                            MessageBox.Show("Usuario creado exitosamente");
                            // Actualizar el DataGridView
                            string query = "SELECT * FROM Usuarios";
                            // Limpiar el DataTable antes de cargar datos
                            dataSet.Tables["Usuarios"].Clear();

                            // Cargar datos en el DataTable
                            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                            adapter.Fill(dataSet, "Usuarios");

                            // Actualizar el DataGridView
                            dgvUsuarios.DataSource = dataSet.Tables["Usuarios"];
                        }
                        else
                        {
                            // Fallo: no se pudo crear el usuario
                            MessageBox.Show("Error al crear el usuario");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Las contrasenas no coinciden ");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
           
            
        }
        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            CenterFormOnScreen();
            // Crear la conexión
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Usuarios";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dataSet, "Usuarios");
            dgvUsuarios.DataSource = dataSet.Tables["Usuarios"];
       

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
        private void chkAdm_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            // Crear la conexión
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                if (dgvUsuarios.SelectedCells.Count > 0)
                {
                    int rowIndex = dgvUsuarios.SelectedCells[0].RowIndex;
                    int userId = Convert.ToInt32(dgvUsuarios.Rows[rowIndex].Cells["ID"].Value);

                    // Ejecutar la consulta DELETE
                    string deleteQuery = $"DELETE FROM Usuarios WHERE ID = {userId}";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);

                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();

                    // Actualizar el DataGridView
                    string query = "SELECT * FROM Usuarios";
                    // Limpiar el DataTable antes de cargar datos
                    dataSet.Tables["Usuarios"].Clear();

                    // Cargar datos en el DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dataSet, "Usuarios");

                    // Actualizar el DataGridView
                    dgvUsuarios.DataSource = dataSet.Tables["Usuarios"];
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(" Error: " + ex);
            }
            
            
        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {

            try
            {
                // Asegúrate de tener la tabla "Usuarios" en el DataSet
                if (dataSet.Tables.Contains("Usuarios"))
                {
                    // Utiliza el DataView que ya has creado
                    datav = new DataView(dataSet.Tables["Usuarios"]);

                    // Aplica el filtro al DataView
                    datav.RowFilter = $"NombreUsuario LIKE '%{txtBuscarUsuario.Text}%'";

                    // Vincula el DataView actualizado al DataGridView
                    dgvUsuarios.DataSource = datav;
                }
                else
                {
                    MessageBox.Show("La tabla 'Usuarios' no está presente en el DataSet.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }

        private void pantallaDeInicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain forma = new frmMain(id,nombreusuario);
            this.Hide();
            forma.Show();
        }
    }

}
