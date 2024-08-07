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
		private frmReelCharge formacomp;
		public FrmIncorrect(bool stencil, frmReelCharge forma)
		{
			this.isStencil = stencil;
			this.formacomp = forma;
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
			//this.Close();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{

		}

		private void FrmIncorrect_FormClosing(object sender, FormClosingEventArgs e)
		{
			formacomp.VaciarCampos();
		}
	}
}
