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
	public partial class FrmCorrect : Form
	{
		private bool isStencil;
		public FrmCorrect(bool stencil)
		{
			this.isStencil = stencil;
			InitializeComponent();
			
		}

		private void FrmCorrect_Load(object sender, EventArgs e)
		{
			CenterToScreen();
			if (isStencil == true)
			{
				label1.Text = "STENCIL CORRECTO";
			}
			else
			{
				label1.Text = "PASTA CORRECTA";
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
