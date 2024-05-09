using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Comparacion2024
{
	public partial class FrmEstacion : Form
	{
		public FrmEstacion()
		{
			InitializeComponent();
		}


		private void btnGuardar_Click(object sender, EventArgs e)
		{
			string nombreEstacion = txtNombreEstacion.Text;
			// Especifica la ruta donde quieres guardar el archivo
			string filePath = "nombreEstacion.txt";

			// Guarda el nombre en el archivo
			File.WriteAllText(filePath, nombreEstacion);

			MessageBox.Show("Nombre de Estacion Guardado");
			// Opcional: Cerrar la forma después de guardar
			this.Close();
		}

		private void FrmEstacion_Load(object sender, EventArgs e)
		{
			CenterToScreen();
		}
	}
}
