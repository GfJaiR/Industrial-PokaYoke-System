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
        private frmMain forma;
        DataView datav = new DataView();
        string connectionString = "Server=NGNAB001; Database=DBLoginMPM;User Id=hornosUser; Password=Conti123;";
        string currentTable = "Stenciles"; // Variable para rastrear la tabla actual
        DataSet dataSet = new DataSet();
       
        public CrudReel(frmMain form)
        {
            this.forma = form;
        
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
             string query = txtQuery.Text.Trim();

            if (IsSelectQuery(query))
            {
                ExecuteQuery(query);
            }
            else
            {
                MessageBox.Show("Solo se permiten consultas de tipo SELECT.", "Consulta no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool IsSelectQuery(string query)
        {
            // Verifica que la consulta comience con "SELECT"
            return query.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase);
        }

        private void ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvReel.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al ejecutar la consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CrudReel_Load(object sender, EventArgs e)
        {
            CenterFormOnScreen();
            dgvReel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReel.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvReel.DefaultCellStyle.Font = new Font("Arial", 12);
            LoadTable("Stenciles");
        }
        private void LoadTable(string tableName)
        {
            currentTable = tableName;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"SELECT * FROM {tableName}";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            if (dataSet.Tables.Contains(tableName))
            {
                dataSet.Tables[tableName].Clear();
            }
            adapter.Fill(dataSet, tableName);
            dgvReel.DataSource = dataSet.Tables[tableName];
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            DialogResult dr = MessageBox.Show("Estas seguro de eliminar el registro seleccionado?", "Mood Test", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    try
                    {
                        if (dgvReel.SelectedCells.Count > 0)
                        {
                            int rowIndex = dgvReel.SelectedCells[0].RowIndex;
                            string idColumnName = currentTable == "Stenciles" ? "RegistroID" : "RegristroID";
                            string recordId = Convert.ToString(dgvReel.Rows[rowIndex].Cells[idColumnName].Value);

                            string deleteQuery = $"DELETE FROM {currentTable} WHERE {idColumnName} = @RecordId";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@RecordId", recordId);

                            connection.Open();
                            deleteCommand.ExecuteNonQuery();
                            connection.Close();

                            LoadTable(currentTable);

                            MessageBox.Show("Registro eliminado");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    break;
                case DialogResult.No:
                    break;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAddReel forma = new frmAddReel("","");
            forma.ShowDialog();
        }
        public void Actualizardgv()
        {
            try
            {
                LoadTable(currentTable);
            }
            catch (Exception)
            {
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            LoadTable(currentTable);
        }

        private void dgvReel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReel.DataSource = dataSet.Tables[currentTable];
        }

		private void btnModificar_Click(object sender, EventArgs e)
		{
            if (dgvReel.SelectedCells.Count > 0)
            {
                int rowIndex = dgvReel.SelectedCells[0].RowIndex;
                string idColumnName = currentTable == "Stenciles" ? "RegistroID" : "RegistroID";
                string recordId = dgvReel.Rows[rowIndex].Cells[idColumnName].Value.ToString();

                frmEditar formEditar = new frmEditar(forma, currentTable,this);
                formEditar.RegistroID = recordId;
                formEditar.ShowDialog();

                //Actualizardgv();
            }
        }

		private void txtBusqueda_TextChanged(object sender, EventArgs e)
		{

            try
            {
                if (dataSet.Tables.Contains(currentTable))
                {
                    datav = new DataView(dataSet.Tables[currentTable]);
                    datav.RowFilter = $"PartNo LIKE '%{txtBusqueda.Text}%'";
                    dgvReel.DataSource = datav;
                }
                else
                {
                    MessageBox.Show("La tabla no está presente en el DataSet.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

		private void btnCargarPasta_Click(object sender, EventArgs e)
		{
            LoadTable("Pastas");
        }

		private void btnCargarStenciles_Click(object sender, EventArgs e)
		{
            LoadTable("Stenciles");
        }
	}
}