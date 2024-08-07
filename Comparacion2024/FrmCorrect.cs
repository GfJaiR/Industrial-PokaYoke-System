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
		private frmReelCharge formacomp;
		private bool isStencil;
		public FrmCorrect(bool stencil, frmReelCharge forma)
		{
			this.isStencil = stencil;
			this.formacomp = forma;
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
		//	this.Close();
		}

		private void FrmCorrect_FormClosing(object sender, FormClosingEventArgs e)
		{
			formacomp.VaciarCampos();
		}
	}
}
