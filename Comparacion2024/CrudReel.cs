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
    public partial class CrudReel : Form
    {
        DataView datav = new DataView();
        string connectionString = "Server=NGL0121W\\SQLEXPRESS01; Database=DBLoginMPM;Integrated Security=true";
        DataSet dataSet = new DataSet();
        public CrudReel()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

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

        private void CrudReel_Load(object sender, EventArgs e)
        {
            CenterFormOnScreen();    
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Reels";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dataSet, "Reels");
            dgvReel.DataSource = dataSet.Tables["Reels"];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             SqlConnection connection = new SqlConnection(connectionString);
            DialogResult dr = MessageBox.Show("Estas seguro de eliminar el reel seleccionado?",
                      "Mood Test", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    try
                    {
                        if (dgvReel.SelectedCells.Count > 0)
                        {
                            int rowIndex = dgvReel.SelectedCells[0].RowIndex;
                            string Reelid = Convert.ToString(dgvReel.Rows[rowIndex].Cells["ReelID"].Value);

                            // Ejecutar la consulta DELETE de forma segura
                            string deleteQuery = "DELETE FROM Reels WHERE ReelID = @Reelid";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@Reelid", Reelid);

                            connection.Open();
                            deleteCommand.ExecuteNonQuery();
                            connection.Close();

                            // Actualizar el DataGridView
                            string query = "SELECT * FROM Reels";
                            // Limpiar el DataTable antes de cargar datos
                            dataSet.Tables["Reels"].Clear();

                            // Cargar datos en el DataTable
                            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                            adapter.Fill(dataSet, "Reels");

                            // Actualizar el DataGridView
                            dgvReel.DataSource = dataSet.Tables["Reels"];
                        }
                        MessageBox.Show("Reel eliminado");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: ");
                      
                    }

                    break;
                case DialogResult.No:
                    break;
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAddReel forma = new frmAddReel();
            forma.ShowDialog();
        }
        public void Actualizardgv()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                // Actualizar el DataGridView
                string query = "SELECT * FROM Reels";
                // Limpiar el DataTable antes de cargar datos
                dataSet.Tables["Reels"].Clear();

                // Cargar datos en el DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataSet, "Reels");

                // Actualizar el DataGridView
                dgvReel.DataSource = dataSet.Tables["Reels"];
            }
            catch (Exception)
            {

            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            // Actualizar el DataGridView
            string query = "SELECT * FROM Reels";
            // Limpiar el DataTable antes de cargar datos
            dataSet.Tables["Reels"].Clear();

            // Cargar datos en el DataTable
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dataSet, "Reels");

            // Actualizar el DataGridView
            dgvReel.DataSource = dataSet.Tables["Reels"];
        }

        private void dgvReel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReel.DataSource = dataSet.Tables["Reels"];
        }

		private void btnModificar_Click(object sender, EventArgs e)
		{
            if (dgvReel.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReel.SelectedCells[0].RowIndex;
                string registroID = dgvReel.Rows[rowIndex].Cells["RegistroID"].Value.ToString();

                frmEditar formEditar = new frmEditar();
                formEditar.RegistroID = registroID;
                formEditar.ShowDialog(); // Muestra el formulario como un diálogo modal.

                //Actualizardgv();
            }
        }

		private void txtBusqueda_TextChanged(object sender, EventArgs e)
		{

            try
            {
                // Asegúrate de tener la tabla "Usuarios" en el DataSet
                if (dataSet.Tables.Contains("Reels"))
                {
                    // Utiliza el DataView que ya has creado
                    datav = new DataView(dataSet.Tables["Reels"]);

                    // Aplica el filtro al DataView
                    datav.RowFilter = $"PartNo LIKE '%{txtBusqueda.Text}%'";

                    // Vincula el DataView actualizado al DataGridView
                    dgvReel.DataSource = datav;
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
    }
}