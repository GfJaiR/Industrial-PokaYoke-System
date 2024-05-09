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
    public partial class FrmLogin : Form
    {
        UsuarioRepository u = new UsuarioRepository();


        
        UsuarioManager usuarioManager = new UsuarioManager();
        public FrmLogin()
        {
            InitializeComponent(); 

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterFormOnScreen();
        }
        private void btnLoginOK_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUserLogin.Text;
            string contraseña = txtPasswordLog.Text;

            if (usuarioManager.AutenticarUsuario(nombreUsuario, contraseña)== true)
            {
                int? idUsuario = u.ObtenerRolIdUsuario(nombreUsuario);
                frmMain frm1 = new frmMain(idUsuario, nombreUsuario);
                FrmManageUsers frm2 = new FrmManageUsers(idUsuario,nombreUsuario);
                this.Hide();
                frm1.ShowDialog();
                
                // Éxito: el usuario se autenticó correctamente
                //MessageBox.Show("Inicio de sesión exitoso");
            }
            else
            {
                // Fallo: las credenciales son incorrectas
                MessageBox.Show("Nombre de usuario o contraseña incorrectos");
            }
        }
        private void txtPasswordLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLoginOK_Click(sender, e);
            }
        }
        private void btnLogCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
