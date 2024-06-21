using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.IO;
using Sealevel;
using System.Threading;
 
namespace Comparacion2024
{
    public partial class frmMain : Form
    {
        public bool ComparacionPastaCorrecta { get; set; }
        public bool ComparacionStencilCorrecta { get; set; }
        private int tiempoTranscurrido = 0;
     
         //Usuario usuario = new Usuario();
        string nombreEstacion;
        string[] numerosDeParteArray;
        Thread Hilo;
        int hola;
        private string nombreusuario;
        bool bypass = false,continuarlectura = true;
        int? num;
        string filePath = "nombreEstacion.txt";
        SqlConnection conexion = new SqlConnection("Server=NGL0121W\\SQLEXPRESS01; Database=DBLoginMPM;Integrated Security=true");
        delegate void UpdateLabelDelegate(string message2);
        UpdateLabelDelegate updateLabel;
        DataTable dataTable = new DataTable();
        SeaMAX sea = new SeaMAX();
        ClsStenciles reel = new ClsStenciles();
        bool EsdeDosPastas = false;
        bool EsdeUnaPasta = false;
        bool pasta1Correcta;
        bool pasta2Correcta;
        bool stencilCorrecta;
      
        public frmMain(int? id, string nomus)
        {
            InitializeComponent();
            pasta1Correcta = CompService.Instance.ComparacionPasta1Correcta;
            pasta2Correcta = CompService.Instance.ComparacionPasta2Correcta;
            stencilCorrecta = CompService.Instance.ComparacionStencilCorrecta;
            updateLabel = new UpdateLabelDelegate(UpdateLabel);
            num = id;
            this.nombreusuario = nomus;
            
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvCarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarga.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvActions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //dgvCarga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCarga.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
			dgvCarga.DefaultCellStyle.Font = new Font("Arial", 12);
            dgvActions.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvActions.DefaultCellStyle.Font = new Font("Arial", 12);
            dgvActions.Columns.Add("Tiempo", "Tiempo");
            dgvActions.Columns.Add("Accion", "Acción");
           
            if (File.Exists(filePath))
            {
               nombreEstacion = File.ReadAllText(filePath);
                // Actualiza el título de la forma principal o el nombre del programa
                this.Text = $"EBT - Estación: {nombreEstacion}";
                label1.Text = $"EBT - Estación: {nombreEstacion}";
            }
            CenterFormOnScreen();

            Hilo = new Thread(InputRead);   
            Hilo.Start();
            SM_Handle();
            if (num == 1)
            {
                administrarUsuariosToolStripMenuItem.Visible = true;
                estacionToolStripMenuItem.Visible = true;
                baseDeDatosToolStripMenuItem.Visible = true;
            }
            else
            {
                estacionToolStripMenuItem.Visible = false;
                administrarUsuariosToolStripMenuItem.Visible = false;
                baseDeDatosToolStripMenuItem.Visible = false;
            }
            //AjustarTamañoDataGridView();
        }
        public bool VerificarResultados()
		{


            if (EsdeDosPastas == true)
            {
                return CompService.Instance.ComparacionPasta1Correcta &&
                       CompService.Instance.ComparacionPasta2Correcta &&
                       CompService.Instance.ComparacionStencilCorrecta;
            }
            else if (EsdeUnaPasta == true)
            {
                return CompService.Instance.ComparacionPasta1Correcta &&
                       CompService.Instance.ComparacionStencilCorrecta;
            }
            else
            {
                return false;
            }
        }
        public void RegistrarAccion(string accion)
        {
            var tiempo = DateTime.Now.ToString();
            dgvActions.Rows.Add(new object[] { tiempo, accion });
        }
        private void UpdateLabel(string message)
        {
            if (lblCiclos.InvokeRequired)
            {
                lblCiclos.Invoke(updateLabel, new object[] { message });
            }
            else
            {
               lblCiclos.Text = message;
            }
        }
        public void UpdateStatusInGrid(int rowIndex, string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, string>(UpdateStatusInGrid), rowIndex, status);
                return;
            }

            // Verificar si el índice de fila está dentro del rango válido
            if (rowIndex >= 0 && rowIndex < dgvCarga.Rows.Count)
            {
                // Actualizar el valor de la celda en la columna "Status" para la fila especificada
                dgvCarga.Rows[rowIndex].Cells["Status"].Value = status;
            }
            else
            {
                //MessageBox.Show("Índice de fila no válido.");
            }
        }
        public int SM_Handle()
        {
            int handle = sea.SM_Open("COM6");
            return handle;
        }
        //public delegate void ValuesChangedEventHandler(byte[] newValues);
        //public event ValuesChangedEventHandler ValuesChanged;
        //public delegate void ChangeEventHandler(bool cambio);
        //public event ChangeEventHandler Change;
        public delegate void DataUpdatedEventHandler(byte[] data);
        public event DataUpdatedEventHandler DataUpdated;
        protected virtual void OnDataUpdated(byte[] data)
        {
            DataUpdated?.Invoke(data);
        }
        public void InputRead()
		{
            //frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass);
            List<byte> collectedValues = new List<byte>();
            byte[] Values1 = { 1, 0, 0, 0, 0, 0, 0, 0 };
           byte[] Values2 = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int start = 0;
            int start1 = 0;
            int numberofchannels = 1;
            int pastvalues = 1;
            int cont = 0;
			while (continuarlectura)
			{
                collectedValues.Clear(); //Limpiar la lista para reemplazar valores 
                for (int h = 0; h < 4; h++)
                {
                    if (start == 4)
                    {
                        start = 0;
                    }
                    try
                    {
                        byte[] Values = new byte[numberofchannels];
                        int readResult = sea.SM_ReadDigitalInputs(start, numberofchannels, Values);
                        if (readResult == 1)
                        {
                            // Procesa los valores solo cuando la lectura es exitosa
                            for (int i = 0; i < numberofchannels; i++)
                            {
                                collectedValues.Add(Values[i]);  // Añade el valor leído a la lista
                            }
                            if (collectedValues.Count >= 4) // Asegúrate de tener suficientes datos para procesar
                            {
                                if (dgvCarga.Rows.Count <= 3)
                                {
                                    EsdeUnaPasta = true;
                                    EsdeDosPastas = false;
                                    OnDataUpdated(collectedValues.ToArray());
                                    UpdateStatusInGrid(0, collectedValues[0] == 0 ? "✔" : "X");
                                    UpdateStatusInGrid(1, collectedValues[2] == 0 ? "✔" : "X");

                                    //lblCiclos.Text = cont.ToString();

                                    // Decide qué conjunto de valores enviar a los outputs digitales
                                    if (collectedValues[3] == 0)
                                    {
                                        Alarma.Stop();
                                    }
                                    else
                                    {
                                        Alarma.Start();
                                    }
                                    if (collectedValues[3] == 0 && pastvalues==1 && collectedValues[0] == 0 && collectedValues[2] == 0  )
									{

                                        Alarma.Stop();
                                       pastvalues = collectedValues[3];
                                        cont++;
                                        updateLabel(cont.ToString());
                                        sea.SM_WriteDigitalOutputs(start1, numberofchannels, Values1);
                                        reel.DisminuirCantidad(ObtenerNumParte());
                                        RefrescarDataGridView();
                                    }
									else
                                    {
                                        Alarma.Start();
                                        sea.SM_WriteDigitalOutputs(start1, numberofchannels, Values2);
                                    }
                                }
                                if (dgvCarga.Rows.Count <= 4)
                                {
                                    EsdeDosPastas = true;
                                    EsdeUnaPasta = false;
                                    OnDataUpdated(collectedValues.ToArray());
                                    UpdateStatusInGrid(0, collectedValues[0] == 0 ? "✔" : "X");
                                    UpdateStatusInGrid(1, collectedValues[1] == 0 ? "✔" : "X");
                                    UpdateStatusInGrid(2, collectedValues[2] == 0 ? "✔" : "X");
									if (collectedValues[3] == 0)
									{
                                        Alarma.Stop();
									}
									else
									{
                                        Alarma.Start();
									}
                                    if (collectedValues[3] == 0 && collectedValues[0] == 0 && collectedValues[2] == 0 && collectedValues[1] == 0 && pastvalues==1 && VerificarResultados())
                                    {
                                        Alarma.Stop();
                                        pastvalues = collectedValues[3];
                                        cont++;
                                        updateLabel(cont.ToString());
                                        sea.SM_WriteDigitalOutputs(start1, numberofchannels, Values1);
                                        reel.DisminuirCantidad(ObtenerNumParte());
                                        RefrescarDataGridView();
                                    }
                                    else
                                    {
                                        //Alarma.Start();
                                        sea.SM_WriteDigitalOutputs(start1, numberofchannels, Values2);
                                    }
                                }
                             
                            }

                            // Más casos y manejo de errores

                            if (collectedValues[3] == 1 && pastvalues == 0)
                            {
                                pastvalues = collectedValues[3];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //manejar o registrar la excepción
                     //MessageBox.Show("Error: " + ex.Message);
                    }
                    start++;
                }
                Thread.Sleep(1000);            
            }
            
        }
	//public event Action<byte[]> OnDataRead;
		//public void InputRead()
		//{



		//    int start = 0;
		//    int numberofchannels = 5;
		//    byte[] Values = new byte[numberofchannels];
		//    byte[] Values1 = { 1, 0, 0, 0, 0, 0, 0, 0 };
		//    byte[] Values2 = { 0, 0, 0, 0, 0, 0, 0, 0 };
		//    bool presente, pasado = false, cambio;
		//    while(continuarlectura)
		//    {

		//        ValuesChanged?.Invoke(Values);

		//        switch (sea.SM_ReadDigitalInputs(start, numberofchannels, Values))
		//        {


		//            case 1:
		//                if (Values[0] % 2 == 0)
		//                {
		//                    // AREA 3 SENSORES CONTANDO LA ALARMA
		//                    if (Values.Length == 5)
		//                    {
		//                        if (Values[0] == 0 || Values[0] == 8 || Values[0] == 4 || Values[0] == 12)
		//                        {
		//                            presente = true;
		//                        }
		//                        else
		//                        { presente = false; }
		//                        if (pasado == false && presente== true) 
		//                        { cambio = true;
		//                            Change?.Invoke(cambio);
		//                        }
		//                        else
		//                        { cambio = false;
		//                            Change?.Invoke(cambio);
		//                        }

		//                        if (Values[0] == 0)
		//                        {
		//                            try
		//                            {
		//                                //UpdateLabel2($" TODOS LOS SENSORES ACTIVOS ");
		//                                UpdateStatusInGrid(0, "✔");
		//                                UpdateStatusInGrid(1, "✔");
		//                                sea.SM_WriteDigitalOutputs(start, numberofchannels, Values2);
		//                                Alarma.Stop();
		//                                frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass);
		//                                if (cambio == true)
		//                                {
		//                                    if (forma.VerificarResultados())
		//                                    {
		//                                        reel.DisminuirCantidad(ObtenerNumParte());
		//                                    }

		//                                }

		//                            }
		//                            catch (Exception)
		//                            {                                       
		//                            }
		//                        }
		//                        if (Values[0] == 16)
		//                        {
		//                            try
		//                            {
		//                                //UpdateLabel2($" TODOS LOS SENSORES ACTIVOS ");
		//                                UpdateStatusInGrid(0, "✔");
		//                                UpdateStatusInGrid(1, "✔");
		//                                sea.SM_WriteDigitalOutputs(start, numberofchannels, Values2);
		//                                Alarma.Start();
		//                                frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass);
		//                                if (cambio == true)
		//                                {
		//                                    if (forma.VerificarResultados())
		//                                    {
		//                                        reel.DisminuirCantidad(ObtenerNumParte());
		//                                    }

		//                                }

		//                            }
		//                            catch (Exception)
		//                            {
		//                            }
		//                        }
		//                        if (Values[0] == 8)
		//                        {
		//                            //UpdateLabel2($" FALTA STENCIL ");                                 
		//                            UpdateStatusInGrid(0, "✔");
		//                            UpdateStatusInGrid(1, "X");
		//                            sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                            Alarma.Stop();

		//                        }
		//                        if (Values[0] == 24)
		//                        {
		//                            //UpdateLabel2($" FALTA STENCIL ");                                  
		//                            UpdateStatusInGrid(0, "✔");
		//                            UpdateStatusInGrid(1, "X");
		//                            sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                            Alarma.Start();
		//                        }
		//                        if (Values[0] == 4)
		//                        {
		//                            //UpdateLabel2($" FALTA PASTA ");                                 
		//                            UpdateStatusInGrid(0, "X");
		//                            UpdateStatusInGrid(1, "✔");
		//                            sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                            Alarma.Stop();
		//                        }
		//                        if (Values[0] == 20)
		//                        {
		//	//UpdateLabel2($" FALTA STENCIL ");
		//	UpdateStatusInGrid(0, "X");
		//	UpdateStatusInGrid(1, "✔");


		//                            Alarma.Stop();
		//                            sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        }
		//                        if (Values[0] == 12)
		//                        {
		//                            //UpdateLabel2($" FALTAN PASTA Y STENCIL ");                                
		//                           UpdateStatusInGrid(0, "X");
		//                            UpdateStatusInGrid(1, "X");
		//                            sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                            Alarma.Stop();
		//                        }
		//                        if (Values[0] == 28)
		//                        {
		//                            //UpdateLabel2($" FALTAN  PASTA Y STENCIL ");                                
		//                            UpdateStatusInGrid(0, "X");
		//                            UpdateStatusInGrid(1, "X");
		//                            sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                            Alarma.Start();
		//                        }
		//                        if (presente == true)
		//                        { pasado = true; }
		//                        else
		//                        { pasado = false; }

		//                    }
		//                }
		//                else
		//                {
		//                    //AREA 4 SENSORES  
		//                    if (Values[0] == 1 || Values[0] == 9 || Values[0] == 5 || Values[0] == 13 || Values[0] == 3 || Values[0] == 11 || Values[0] == 7 || Values[0] == 15)
		//                    {
		//                        presente = true;
		//                    }
		//                    else
		//                    { presente = false; }

		//                    if (pasado == false && presente == true)
		//                    { cambio = true; }
		//                    else
		//                    { cambio = false; }

		//                    if (Values[0] == 1)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA2");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(2, "✔");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Stop();
		//                    }
		//                    if (Values[0] == 17)
		//                    {
		//                        //UpdateLabel2($" TODOS LOS SENSORES ACTIVOS ");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(1, "✔");
		//                        UpdateStatusInGrid(2, "✔");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values2);
		//                        Alarma.Start();
		//                        frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass);
		//                        if (cambio == true)
		//                        {
		//                            if (forma.VerificarResultados())
		//                            {
		//                                reel.DisminuirCantidad(ObtenerNumParte());
		//                            }

		//                        }
		//                    }
		//                    if (Values[0] == 9)
		//                    {
		//                        //UpdateLabel2($" FALTA STENCIL");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(1, "✔");
		//                        UpdateStatusInGrid(2, "X");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Stop();

		//                    }
		//                    if (Values[0] == 25)
		//                    {
		//                        //UpdateLabel2($" FALTA STENCIL ");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(1, "✔");
		//                        UpdateStatusInGrid(2, "X");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Start();
		//                    }
		//                    if (Values[0] == 5)
		//                    {
		//                        try
		//                        {
		//                            //UpdateLabel2($" TODOS LOS SENSORES ACTIVOS ");
		//                            UpdateStatusInGrid(0, "✔");
		//                            UpdateStatusInGrid(1, "✔");
		//                            UpdateStatusInGrid(2, "✔");
		//                            sea.SM_WriteDigitalOutputs(start, numberofchannels, Values2);
		//                            Alarma.Stop();
		//                            frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass);
		//                            if (cambio == true)
		//                            {
		//		if (forma.VerificarResultados())
		//		{
		//                                    reel.DisminuirCantidad(ObtenerNumParte());
		//                                }

		//                            }
		//                        }
		//                        catch (Exception)
		//                        {                                   
		//                        }                              
		//                    }
		//                    if (Values[0] == 21)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA1 ");
		//                        UpdateStatusInGrid(0, "X");
		//                        UpdateStatusInGrid(1, "✔");
		//                        UpdateStatusInGrid(2, "✔");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Start();
		//                    }
		//                    if (Values[0] == 13)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA2 Y STENCIL ");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(2, "X");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Stop();

		//                    }
		//                    if (Values[0] == 29)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA2 Y STENCIL");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(2, "X");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Start();
		//                    }
		//                    if (Values[0] == 3)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA1 Y PASTA2");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(2, "X");

		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Stop();
		//                    }
		//                    if (Values[0] == 19)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA1");

		//                        UpdateStatusInGrid(0, "X");
		//                        UpdateStatusInGrid(1, "✔");
		//                        UpdateStatusInGrid(2, "✔");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Start();
		//                    }
		//                    if (Values[0] == 11)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA Y STENCIL");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(3, "X");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Stop();
		//                    }
		//                    if (Values[0] == 27)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA Y STENCIL");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(0, "✔");
		//                        UpdateStatusInGrid(3, "X");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Start();
		//                    }
		//                    if (Values[0] == 7)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA1 ");
		//                        UpdateStatusInGrid(0, "X");
		//                        UpdateStatusInGrid(1, "✔");
		//                        UpdateStatusInGrid(2, "✔");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Stop();

		//                    }
		//                    if (Values[0] == 23)
		//                    {
		//                        //UpdateLabel2($" FALTA PASTA1 Y PASTA2");
		//                        UpdateStatusInGrid(0, "X");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(2, "✔");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Start();
		//                    }
		//                    if (Values[0] == 15)
		//                    {
		//                        //UpdateLabel2($" FALTAN TODOS LOS SENSORES");
		//                        UpdateStatusInGrid(0, "X");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(2, "X");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Stop();
		//                    }
		//                    if (Values[0] == 24)
		//                    {
		//                        //UpdateLabel2($" FALTAN TODOS LOS SENSORES");
		//                        UpdateStatusInGrid(0, "X");
		//                        UpdateStatusInGrid(1, "X");
		//                        UpdateStatusInGrid(2, "X");
		//                        sea.SM_WriteDigitalOutputs(start, numberofchannels, Values1);
		//                        Alarma.Start();
		//                    }
		//                    if (presente == true)
		//                    { pasado = true; }
		//                    else
		//                    { pasado = false; }

		//                }
		//                break;
		//            case -1:
		//                break;
		//        }
		//        Thread.Sleep(500);
		//    }
		//} 
		public void CargarFormaComparaciones()
        {
            if (dgvCarga.Rows.Count > 0)
            {
                List<string> numerosDeParteList = new List<string>();

                int totalFilas = dgvCarga.Rows.Count;

                // Itera sobre todas las filas, pero solo hasta la tercera fila
                for (int i = 0; i < totalFilas && i < 3; i++)
                {
                    DataGridViewRow fila = dgvCarga.Rows[i];

                    // Verifica si la celda no es nula y tiene un valor
                    if (fila.Cells["Part No"].Value != null)
                    {
                        // Obtén el valor de la celda correspondiente en la columna "Part No"
                        string numeroDeParte = fila.Cells["Part No"].Value.ToString();

                        // Agrega el número de parte a la lista
                        numerosDeParteList.Add(numeroDeParte);
                    }
                }

                // lista a un array 
                numerosDeParteArray = numerosDeParteList.ToArray();

				// Pasa los valores a la forma de comparación
				if (EsdeDosPastas == true)
				{
                    frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass, 2);
                    forma.ShowDialog();
                }
				else if (EsdeUnaPasta == true)
				{
                    frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass, 1);
                    forma.ShowDialog();
                }
               
                //forma.SubscribeToValuesChanged();
               

            }
            else
            {
                MessageBox.Show("No hay datos cargados en el DataGridView.");
            }
        }
        public void RefrescarDataGridView()
        {
            try
            {
                conexion.Open();
                string query = "SELECT PartNo, ReelID, Quantity FROM Reels";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                string lastPartNo = null;
                string lastReelID = null;
                string lastQuantity = null;

                // Leer todas las filas y almacenar la última con cantidad
                while (reader.Read())
                {
                    string partNo = reader["PartNo"].ToString();
                    string reelID = reader["ReelID"].ToString();
                    string quantity = reader["Quantity"].ToString();

                    if (!string.IsNullOrEmpty(quantity) && quantity != "0")
                    {
                        lastPartNo = partNo;
                        lastReelID = reelID;
                        lastQuantity = quantity;
                    }
                }

                reader.Close();

                // Si se encontró una fila con cantidad, actualizar el DataGridView
                if (!string.IsNullOrEmpty(lastQuantity) && lastQuantity != "0")
                {
                    foreach (DataGridViewRow row in dgvCarga.Rows)
                    {
                        if (row.Cells["Part No"].Value.ToString().Equals(lastPartNo))
                        {
                            row.Cells["ReelID"].Value = lastReelID;
                            row.Cells["Quantity"].Value = lastQuantity;
                            break;
                        }
                    }
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al refrescar el DataGridView: " + ex.Message);
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                
                    CargarFormaComparaciones();
                

            }
            if (num == 1)
            {
                if (e.KeyCode == Keys.F3)
                {
                    frmAddReel forma1 = new frmAddReel();
                    forma1.ShowDialog();
                }
            }
            if (num == 1)
            {
                if (e.KeyCode == Keys.F4)
                {
                    CrudReel forma2 = new CrudReel(this);
                    forma2.ShowDialog();
                }
            }
            
        }
       
        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    conexion.Open();

                    Encoding encoding = DetectarCodificacion(openFileDialog1.FileName);
                    string[] lineas = File.ReadAllLines(openFileDialog1.FileName, encoding ?? Encoding.UTF8);

                    dataTable.Clear();
                    dataTable.Columns.Clear();

                    dataTable.Columns.Add("Slot");
                    dataTable.Columns.Add("Fpick");
                    dataTable.Columns.Add("Part No");
                    dataTable.Columns.Add("QT");
                    dataTable.Columns.Add("ReelID");
                    dataTable.Columns.Add("Quantity");
                    dataTable.Columns.Add("Status");

                    foreach (string linea in lineas)
                    {
                        string[] campos = linea.Split(',');

                        if (campos.Length == 4)
                        {
                            for (int i = 0; i < campos.Length; i++)
                            {
                                campos[i] = campos[i].Trim();
                            }

                            // Inicializa reelId y cantidad con valores vacíos
                            string reelId = "Sin dar de alta";
                            string cantidad = "Sin Datos";

                            string query = "SELECT ReelID, Quantity FROM Reels WHERE PartNo = @PartNo";
                            SqlCommand comando = new SqlCommand(query, conexion);
                            comando.Parameters.AddWithValue("@PartNo", campos[2]); // Part No

                            SqlDataReader reader = comando.ExecuteReader();
                            if (reader.Read())
                            {
                                reelId = reader["ReelID"]?.ToString() ?? "Sin dar de alta";
                                cantidad = reader["Quantity"]?.ToString() ?? "Sin Datos";
                            }
                            reader.Close(); // Asegúrate de cerrar el reader después de cada lectura

                            // Agrega los datos al dataTable, incluyendo reelId y cantidad sean o no vacíos
                            dataTable.Rows.Add(new object[] { campos[0], campos[1], campos[2], campos[3], reelId, cantidad, "" });
                        }
                    }

                    conexion.Close();
                    dgvCarga.DataSource = dataTable;
                    this.Text = $"EBT - Estación: {nombreEstacion + "::" + openFileDialog1.FileName}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        public string ObtenerNumParte()
        {
            string ultimoNumeroDeParte = string.Empty; // Inicializa una variable para guardar el último número de parte encontrado

            try
            {
                int totalFilas = dgvCarga.Rows.Count;

                // Recorre hasta las primeras 3 filas o menos, si hay menos de 3 filas en total
                for (int i = 0; i < totalFilas && i < 3; i++)
                {
                    DataGridViewRow fila = dgvCarga.Rows[i];

                    // Verifica si la celda no es nula y tiene un valor
                    if (fila.Cells["Part No"].Value != null)
                    {
                        // Actualiza el último número de parte encontrado
                        ultimoNumeroDeParte = fila.Cells["Part No"].Value.ToString();
                    }
                }
            }
            catch (Exception)
            {
                // Manejo opcional de excepciones
            }

            return ultimoNumeroDeParte; // Retorna el último número de parte encontrad

        }
        private Encoding DetectarCodificacion(string archivo)
        {
            try
            {
                byte[] buffer = new byte[4096];
                using (FileStream fileStream = new FileStream(archivo, FileMode.Open))
                {
                    fileStream.Read(buffer, 0, buffer.Length);
                }

                EncodingDetector detector = new EncodingDetector();
                return detector.DetectEncoding(buffer);
            }
            catch
            {
                return null;
            }
        }
        public void compararToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                CargarFormaComparaciones();
               
          
        }   
        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageUsers forma = new FrmManageUsers(num,nombreusuario);
            forma.ShowDialog();
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

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            //dgvCarga.Width = this.Width - 50;
            //dgvCarga.Height = this.Height - 100;
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvCarga_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void Alarma_Tick(object sender, EventArgs e)
        {
            tiempoTranscurrido += Alarma.Interval;

            // Verificar si han pasado 30 segundos (30,000 milisegundos)
            if (tiempoTranscurrido >= 30000)
            {
				// Mostrar el MessageBox
				

				// Reiniciar el tiempo transcurrido
				tiempoTranscurrido = 0;
            }
        }
        private void StopThread()
        {
            if (Hilo != null && Hilo.IsAlive)
            {
                Hilo.Abort(); // Puedes considerar métodos más seguros para detener el hilo
                Hilo.Join();  // Espera a que el hilo termine antes de continuar
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            
                
          
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
            StopThread();
        
           
        }

		private void estacionToolStripMenuItem_Click(object sender, EventArgs e)
		{
            FrmEstacion FORMA = new FrmEstacion();
            FORMA.ShowDialog();
		}

		private void dgvCarga_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dgvCarga_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
		{

            // Verificar si la celda actual es de la columna "Status"
            if (dgvCarga.Columns[e.ColumnIndex].Name == "Status")
            {
                // Obtener el valor de la celda
                string status = dgvCarga.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Verificar el valor y establecer el color de fondo y el color de texto según el valor
                if (status == "✔")
                {
                    e.CellStyle.BackColor = Color.Green; // Cambiar a color verde para ✔
                    e.CellStyle.ForeColor = Color.Green; // Texto en color verde para mayor visibilidad
                }
                if (status == "X")
                {
                    e.CellStyle.BackColor = Color.White; // Cambiar a color rojo para X
                    e.CellStyle.ForeColor = Color.Red; // Texto en color rojo para mayor visibilidad
                }
                else
                {
                    // Restablecer el color de fondo y el color de texto predeterminados si no coincide con el valor deseado
                    e.CellStyle.BackColor = dgvCarga.DefaultCellStyle.BackColor;
                    e.CellStyle.ForeColor = dgvCarga.DefaultCellStyle.ForeColor;
                }
            }
        }

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void lblBypass_Click(object sender, EventArgs e)
		{

		}

		private void label2_MouseEnter(object sender, EventArgs e)
		{
			if (num == 1)
			{
                label2.Cursor = System.Windows.Forms.Cursors.Hand;
            }
         
        }

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void baseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
		{
            CrudReel frm = new CrudReel(this);
            frm.ShowDialog();
		}

		private void label2_Click(object sender, EventArgs e)
		{
			if (num == 1)
			{
                if (bypass == false)
				{
                  
                    bypass = true;
                    label2.Text = "BYPASS";
                    label2.BackColor = Color.FromArgb(192, 0, 0);
                    lblMonitor.Text = "BYPASS";
                    
                }
				else
				{
                    bypass = false;
                    label2.Text = "HABILITAR";
                    label2.BackColor = Color.FromArgb(64, 64, 64);
                    lblMonitor.Text = "MONITOREANDO";
                }
			}
		}
	}
}
