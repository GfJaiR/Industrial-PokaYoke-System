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
    public partial class frmConfirmar : Form
    {
        private int user;
        DataTable datatable;
        private frmMain main;
        private string[] numerosDeParte;
        private string reelnum;
        private string NombreEstacion;
        string Pasta1, Pasta2, Stencil,slot, Resul = "X";
       
        private bool isStencil;

        int num0=0;
        int num1=0;
        byte PastValues=255;
        bool encontrado = false;
        //int? id = 1;
        ClsComparaciones comp = new ClsComparaciones();
      
        public frmConfirmar(DataTable data, int userID, string[] nums, string reel, frmMain m,string nomEst,bool stencil)
        {
            InitializeComponent();
            this.user = userID;       
            this.numerosDeParte = nums;
            this.datatable = data;
            this.reelnum = reel;
            this.main = m;
            this.NombreEstacion = nomEst;
            this.isStencil = stencil;
            SubscribeToValuesChanged();
        }

        private void frmConfirmar_Load(object sender, EventArgs e)
        {
            CenterFormOnScreen();
        }

        public void SubscribeToValuesChanged()
        {
         
            main.ValuesChanged += FormOrigin_ValuesChanged;
        }

        private void FormOrigin_ValuesChanged(byte[] newValues)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new Action(() => FormOrigin_ValuesChanged(newValues)));
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                return;
            }

            if (newValues[0] == 4 || newValues[0] == 20)
            {
                slot = "3";
            }
            else if (newValues[0] == 8 || newValues[0] == 24)
            {
                slot = "1";
            }
            else
            {
                slot = "";
            }


           
            // Verifica si la forma está visible y no minimizada.

           if(this.Visible && this.WindowState != FormWindowState.Minimized)
            {
                if (PastValues == 4 || PastValues == 20 || PastValues == 12 || PastValues == 28)
                {
                    if (newValues[0] == 0 || newValues[0] == 16 || newValues[0] == 8 || newValues[0] == 24)
                    { num0 = 0; }


                }
                if (newValues[0] == 0 || newValues[0] == 16 || newValues[0] == 8 || newValues[0] == 24)
                {

                    if (num0 == 0)
                    {
                        Comparacion();
                        num0 = 1;
                    }
                }

                if (PastValues == 8 || PastValues == 24 || PastValues == 12 || PastValues == 28)
                {
                    if (newValues[0] == 4 || newValues[0] == 0 || newValues[0] == 16 || newValues[0] == 20)
                    {
                        num1 = 0;
                    }

                }
                if (newValues[0] == 4 || newValues[0] == 0 || newValues[0] == 16 || newValues[0] == 20)
                {

                    if (num1 == 0)
                    {
                        //Comparacion();
                        num1 = 1;
                    }

                }
                PastValues = newValues[0];


            }
        }

        private void frmConfirmar_FormClosing(object sender, FormClosingEventArgs e)
        {
           main.ValuesChanged -= FormOrigin_ValuesChanged;
        }

        private void txtConfNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Comparacion();
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
        public void Comparacion()
        {
            string numerosinprefijo = txtConfNum.Text;
            if (txtConfNum.Text.Length == 14 && txtConfNum.Text.StartsWith("P"))
            {
                numerosinprefijo = txtConfNum.Text.Substring(1);
            }


            if (numerosDeParte.Length >= 2)
            {
                Pasta1 = numerosDeParte[0];
                Pasta2 = "";
                Stencil = numerosDeParte[1];
            }

            if (numerosDeParte.Length >= 3)
            {
                Pasta1 = numerosDeParte[0];
                Pasta2 = numerosDeParte[1];
                Stencil = numerosDeParte[2];
            }
            if (datatable.Rows.Count > 0)
            {
                
                // Filtra las filas del DataTable por el número de slot ingresado
                DataRow[] filasFiltradas = datatable.Select("Slot = '" + slot + "'");

                // Verifica si se encontraron filas con el número de slot especificado
                if (filasFiltradas.Length > 0)
                {
                    // Itera sobre las filas filtradas
                    foreach (DataRow fila in filasFiltradas)
                    {
                        // Obtiene el número de parte de la fila actual
                        string numeroDeParteGrid = fila["Part No"].ToString();

                        // Verifica si el número de parte coincide con el ingresado por el usuario
                        if (numeroDeParteGrid == numerosinprefijo && reelnum.ToString() == numerosinprefijo)
                        {
                            Resul = "OK";
                            encontrado = true; // Actualiza la variable bandera para indicar que se encontró una coincidencia
                            FrmCorrect frm = new FrmCorrect(isStencil);
                            frm.ShowDialog();
                            this.Close();
                            break; // Sale del bucle ya que se encontró una coincidencia
                        }
                    }

                    // Verifica si después de la iteración no se encontró ninguna coincidencia
                    if (!encontrado)
                    {
                       FrmIncorrect frm = new FrmIncorrect(isStencil);
                        frm.ShowDialog();
                        //this.Close();
                        Telegram(); // Llama al método Telegram ya que ninguna fila cumplió con la condición
                    }
                }
                else
                {
                    // Si no se encontraron filas con el número de slot especificado
                    //MessageBox.Show("No se encontraron datos para el Feeder Detectado.");
                }
            }
            else
            {
                // Si no hay datos en el DataGridView
                MessageBox.Show("No hay datos en el DataGridView.");
            }
            comp.AgregarComparaciones(user, NombreEstacion, Pasta1, Pasta2, Stencil, DateTime.Now, Resul);

        }
        public void Telegram()
        {
            try
            {
                ClsTelegram Telegram = new ClsTelegram();
                string strIDGrupo = "-1001971222363";
                string MensajeTelegram = "ERROR EN COMPARACION MPM\nNoEmpleado: " + user + "\nPasta1: " + Pasta1 + "\nPasta2: " + Pasta2 + "\nStencil: " + Stencil + "\nLINEA: " + 1 + "\nFECHA: " + DateTime.Now;
                Telegram.sendMessageToTelegram(strIDGrupo, MensajeTelegram);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
