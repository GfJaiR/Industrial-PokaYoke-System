using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comparacion2024
{
	public partial class FrmIncorrect : Form
	{
		private bool isStencil;
		public FrmIncorrect(bool stencil)
		{
			this.isStencil = stencil;
			InitializeComponent();
			
		}

		private void FrmIncorrect_Load(object sender, EventArgs e)
		{
			CenterToScreen();
			if (isStencil == true)
			{
				label1.Text = "STENCIL INCORRECTO";
			}
			else
			{
				label1.Text = "PASTA INCORRECTA";
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{

		}
	}
}
