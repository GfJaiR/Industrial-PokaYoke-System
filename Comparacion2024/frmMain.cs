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
using System.Management;
using System.IO.Ports;
 
namespace Comparacion2024
{
    public partial class frmMain : Form
    {
        private ManagementEventWatcher usbWatcher;
        private bool isDeviceConnected = false; // Variable para controlar el estado de conexión
        private string connectedPort = null; // Mantener el puerto COM conectado
        public bool ComparacionPastaCorrecta { get; set; }
        public bool ComparacionStencilCorrecta { get; set; }
        private int tiempoTranscurrido = 0;
        string nombreEstacion;
        string[] numerosDeParteArray;
        Thread Hilo;
        private string nombreusuario;
        bool bypass = false, continuarlectura = true;
        int? num;
        string filePath = "nombreEstacion.txt";
        SqlConnection conexion = new SqlConnection("Server=NGNAB001; Database=DBLoginMPM;User Id=hornosUser; Password=Conti123;");
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
        private bool deviceConnected = false;
        private int handle = -1;
        private System.Windows.Forms.Timer retryTimer;
        private CancellationTokenSource cancellationTokenSource; // token para cancelar el hilo de inputread
        private ManagementEventWatcher arrivalWatcher;
        private ManagementEventWatcher removalWatcher;
        private string currentPort = string.Empty;
        private readonly object connectionLock = new object();
        public frmMain(int? id, string nomus)
        {
            InitializeComponent();
            InitializeDeviceWatcher();
            dgvActions.CellFormatting += dgvActions_CellFormatting;
            pasta1Correcta = CompService.Instance.ComparacionPasta1Correcta;
            pasta2Correcta = CompService.Instance.ComparacionPasta2Correcta;
            stencilCorrecta = CompService.Instance.ComparacionStencilCorrecta;
            updateLabel = new UpdateLabelDelegate(UpdateLabel);
            num = id;
            this.bypass = false;
            this.nombreusuario = nomus;

            picturePasta1.Paint += PictureBox_Paint;
                picturePasta2.Paint += PictureBox_Paint;
                pictureStencil.Paint += PictureBox_Paint;

            // Initialize and start the timer
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000; // 1 second
            updateTimer.Tick += updateTimer_Tick;
            updateTimer.Start();

        }


        private void StopRetryTimer()
        {
            if (retryTimer != null)
            {
                retryTimer.Stop();
                retryTimer.Dispose();
                retryTimer = null;
            }
        }

        private void StopUpdateTimer()
        {
            if (updateTimer != null)
            {
                updateTimer.Stop();
                updateTimer.Dispose();
                updateTimer = null;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DetectAndConnect();
            // Verificación inicial de la conexión del dispositivo
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
            dgvActions.Columns.Add("Accion", "Accion");
           
            if (File.Exists(filePath))
            {
               nombreEstacion = File.ReadAllText(filePath);
                // Actualiza el título de la forma principal o el nombre del programa
                this.Text = $"EBT - Estación: {nombreEstacion}";
                label1.Text = $"EBT - Estación: {nombreEstacion}";
            }
            CenterFormOnScreen();

            
           
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
        private void InitializeDeviceWatcher()
        {
            // Watch for device arrivals
            arrivalWatcher = new ManagementEventWatcher();
            arrivalWatcher.EventArrived += new EventArrivedEventHandler(DeviceArrived);
            arrivalWatcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            arrivalWatcher.Start();

            // Watch for device removals
            removalWatcher = new ManagementEventWatcher();
            removalWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemoved);
            removalWatcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            removalWatcher.Start();
        }

        private void DeviceArrived(object sender, EventArrivedEventArgs e)
        {
            Task.Run(() =>
            {
                string[] ports = GetSeaLevelPorts();
                if (ports.Length > 0)
                {
                    DetectAndConnect();
                }
            });
        }

        private void DeviceRemoved(object sender, EventArrivedEventArgs e)
        {
            Task.Run(() =>
            {
                string[] ports = GetSeaLevelPorts();
                if (ports.Length == 0 && deviceConnected)
                {
                    lock (connectionLock)
                    {
                        deviceConnected = false;
                        StopInputReadThread();
                        CloseHandle();
                       // UpdateLabel("Microcontrolador desconectado.");
                    }
                }
            });
        }

        private void DetectAndConnect()
        {
            lock (connectionLock)
            {
                StopInputReadThread();
                CloseHandle();

                string[] ports = GetSeaLevelPorts();

                foreach (string port in ports)
                {
                    try
                    {
                        handle = sea.SM_Open(port);
                        if (handle >= 0)
                        {
                            deviceConnected = true;
                            currentPort = port;
                          //  UpdateLabel($"Conectado a {port}");
                            StartInputReadThread();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                      //  UpdateLabel($"Error al intentar conectar con {port}: {ex.Message}");
                    }
                }

                if (!deviceConnected)
                {
                  //  UpdateLabel("No se pudo conectar a ningún puerto.");
                    StartRetryTimer();
                }
            }
        }

        private void StartInputReadThread()
        {
            cancellationTokenSource = new CancellationTokenSource(); // Inicializar aquí
            CancellationToken token = cancellationTokenSource.Token;
            Hilo = new Thread(() => InputRead(token));
            Hilo.Start();
        }

        private void StopInputReadThread()
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                // Aquí en lugar de Join, usaremos un bucle de espera para evitar el bloqueo de la UI
                while (Hilo != null && Hilo.IsAlive)
                {
                    Application.DoEvents();
                }
                cancellationTokenSource = null;
            }
        }

        private string[] GetSeaLevelPorts()
        {
            List<string> seaLevelPorts = new List<string>();

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'"))
            {
                foreach (var device in searcher.Get())
                {
                    string name = device.GetPropertyValue("Name").ToString();
                    string portName = name.Substring(name.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
                    if (name.Contains("SeaIO")) // nombre específico del dispositivo SeaLevel
                    {
                        seaLevelPorts.Add(portName);
                    }
                }
            }

            return seaLevelPorts.ToArray();
        }

        private void StartRetryTimer()
        {
            if (retryTimer == null)
            {
                retryTimer = new System.Windows.Forms.Timer();
                retryTimer.Interval = 5000; // Intentar cada 5 segundos
                retryTimer.Tick += (s, e) => DetectAndConnect();
            }
            retryTimer.Start();
        }
        private void CloseHandle()
        {
            if (handle >= 0)
            {
                sea.SM_Close();
                handle = -1;
            }
        }
        private void StopAndReleaseWatcher(ManagementEventWatcher watcher)
        {
            if (watcher != null)
            {
                watcher.Stop();
                watcher.EventArrived -= new EventArrivedEventHandler(DeviceArrived);
                watcher.EventArrived -= new EventArrivedEventHandler(DeviceRemoved);
                watcher.Dispose();
            }
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
        public async void InputRead(CancellationToken token)
		{
          
            //frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass);
            List<byte> collectedValues = new List<byte>();
            List<byte> previousValues = new List<byte> { 0, 0, 0, 0 }; // guardar valores anteriores para verificar cambios

            byte[] Values1 = { 1, 0, 0, 0, 0, 0, 0, 0 };
           byte[] Values2 = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int start = 0;
            int start1 = 0;
            int numberofchannels = 1;
            int pastvalues = 1;
            int cont = 0;

			while (!token.IsCancellationRequested)
			{
				if (deviceConnected && handle >= 0)
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
                            if (readResult >= 0)
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
										if (collectedValues[0] == 1 && collectedValues[0] != previousValues[0])
										{
                                            CompService.Instance.ComparacionPasta1Correcta = false;
                                            await ShowMessageAsync("Pasta1 Retirada, Es necesario volver a escanear");
                                        }
                                        UpdateStatusInGrid(1, collectedValues[2] == 0 ? "✔" : "X");
                                        if (collectedValues[2] == 1 && collectedValues[2] != previousValues[2])
                                        {
                                            CompService.Instance.ComparacionStencilCorrecta = false;
                                            await ShowMessageAsync("Stencil Retirado, Es necesario volver a escanear");
                                        }
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
                                        if (collectedValues[3] == 0 && pastvalues == 1 && collectedValues[0] == 0 && collectedValues[2] == 0)
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
                                        if (collectedValues[0] == 1 && collectedValues[0] != previousValues[0])
                                        {
                                            CompService.Instance.ComparacionPasta1Correcta = false;
                                            await ShowMessageAsync("Pasta1 Retirada, Es necesario volver a escanearla");
                                        }
                                        UpdateStatusInGrid(1, collectedValues[1] == 0 ? "✔" : "X");
                                        if (collectedValues[1] == 1 && collectedValues[1] != previousValues[1])
                                        {
                                            CompService.Instance.ComparacionPasta2Correcta = false;
                                            await ShowMessageAsync("Pasta2 Retirada, Es necesario volver a escanearla");
                                        }
                                        UpdateStatusInGrid(2, collectedValues[2] == 0 ? "✔" : "X");
                                        if (collectedValues[2] == 1 && collectedValues[2] != previousValues[2])
                                        {
                                            CompService.Instance.ComparacionStencilCorrecta = false;
                                            await ShowMessageAsync("Stencil Retirado, Es necesario volver a escanearlo");
                                        }
                                        if (collectedValues[3] == 0 && collectedValues[3] != previousValues[3])
                                        {
                                            Alarma.Stop();
                                        }
                                        else
                                        {
                                            Alarma.Start();
                                        }
                                        if (collectedValues[3] == 0 && collectedValues[0] == 0 && collectedValues[2] == 0 && collectedValues[1] == 0 && pastvalues == 1 && VerificarResultados())
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

                                    // Guardar los valores actuales como previos para la próxima iteración
                                    previousValues = new List<byte>(collectedValues);
                                }

                                // Más casos y manejo de errores

                                if (collectedValues[3] == 1 && pastvalues == 0)
                                {
                                    pastvalues = collectedValues[3];
                                }
                            }
							else if (readResult == -8)
							{
                                if (deviceConnected == true)
                                {
                                   // UpdateLabel("Error CRC, reiniciando...");
                                  await Task.Run(() => DetectAndConnect());
                                }
								return;
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
            
        }
        private async Task ShowMessageAsync(string message)
        {
            var context = SynchronizationContext.Current;
            if (context == null)
            {
                context = new SynchronizationContext();
                SynchronizationContext.SetSynchronizationContext(context);
            }
            await Task.Run(() =>
            {
                context.Send(_ => MessageBox.Show(message), null);
            });
        }

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
                    forma.Show();
                }
				else if (EsdeUnaPasta == true)
				{
                    frmReelCharge forma = new frmReelCharge(dataTable, numerosDeParteArray, this, nombreEstacion, bypass, 1);
                    forma.Show();
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

                // Diccionario para almacenar los datos de Pastas
                Dictionary<string, (string reelID, string quantity)> datosPastas = new Dictionary<string, (string reelID, string quantity)>();

                // Query para la tabla Pastas
                string queryPastas = "SELECT PartNo, ReelID, Quantity FROM Pastas";
                SqlCommand comandoPastas = new SqlCommand(queryPastas, conexion);
                SqlDataReader readerPastas = comandoPastas.ExecuteReader();

                while (readerPastas.Read())
                {
                    string partNo = readerPastas["PartNo"].ToString();
                    string reelID = readerPastas["ReelID"].ToString();
                    string quantity = readerPastas["Quantity"].ToString();
                    datosPastas[partNo] = (reelID, quantity);
                }

                readerPastas.Close();

                // Variable para almacenar los datos de Stenciles
                (string partNo, string reelID, string quantity) datosStencil = (null, null, null);

                // Query para la tabla Stenciles
                string queryStenciles = "SELECT PartNo, ReelID, Quantity FROM Stenciles";
                SqlCommand comandoStenciles = new SqlCommand(queryStenciles, conexion);
                SqlDataReader readerStenciles = comandoStenciles.ExecuteReader();

                if (readerStenciles.Read())
                {
                    datosStencil.partNo = readerStenciles["PartNo"].ToString();
                    datosStencil.reelID = readerStenciles["ReelID"].ToString();
                    datosStencil.quantity = readerStenciles["Quantity"].ToString();
                }

                readerStenciles.Close();
                conexion.Close();

                // Actualizar filas de Pastas en el DataGridView
                foreach (DataGridViewRow row in dgvCarga.Rows)
                {
                    if (row.Cells["Part No"].Value != null)
                    {
                        string partNo = row.Cells["Part No"].Value.ToString();

                        if (datosPastas.ContainsKey(partNo))
                        {
                            var datos = datosPastas[partNo];
                            if (row.Cells["ReelID"].Value.ToString() != datos.reelID)
                                row.Cells["ReelID"].Value = datos.reelID;
                            if (row.Cells["Quantity"].Value.ToString() != datos.quantity)
                                row.Cells["Quantity"].Value = datos.quantity;
                        }
                        else if (partNo == datosStencil.partNo)
                        {
                            if (row.Cells["ReelID"].Value.ToString() != datosStencil.reelID)
                                row.Cells["ReelID"].Value = datosStencil.reelID;
                            if (row.Cells["Quantity"].Value.ToString() != datosStencil.quantity)
                                row.Cells["Quantity"].Value = datosStencil.quantity;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
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
                    forma1.Show();
                }
            }
            if (num == 1)
            {
                if (e.KeyCode == Keys.F4)
                {
                    CrudReel forma2 = new CrudReel(this);
                    forma2.Show();
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

                    int totalRows = lineas.Length;
                    int initialRows = Math.Min(totalRows - 1, 2); // Al menos una fila se tomará de Stenciles
                    int currentRow = 0;

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

                            string query;
                            if (currentRow < initialRows)
                            {
                                // Obtener datos de la tabla Pastas para las primeras filas
                                query = "SELECT ReelID, Quantity FROM Pastas WHERE PartNo = @PartNo";
                            }
                            else
                            {
                                // Obtener datos de la tabla Stenciles para las últimas filas
                                query = "SELECT ReelID, Quantity FROM Stenciles WHERE PartNo = @PartNo";
                            }

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
                            currentRow++;
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
            forma.Show();
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
    
       
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            StopInputReadThread();
            CloseHandle();
            StopAndReleaseWatcher(arrivalWatcher);
            StopAndReleaseWatcher(removalWatcher);
            StopRetryTimer();
            StopUpdateTimer();

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();

        }

		private void estacionToolStripMenuItem_Click(object sender, EventArgs e)
		{
            FrmEstacion FORMA = new FrmEstacion();
            FORMA.Show();
		}

		private void dgvCarga_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dgvCarga_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
		{
            // Verificar si la celda actual es de la columna "Status"
            if (dgvCarga.Columns[e.ColumnIndex].Name == "Status")
            {
                // Verificar si la fila actual no está vacía
                if (dgvCarga.Rows[e.RowIndex].IsNewRow)
                {
                    return; // Si es una fila nueva (vacía), salir del método
                }

                // Obtener el valor de la celda
                string status = dgvCarga.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Verificar el valor y establecer el color de fondo y el color de texto según el valor
                if (status == "X")
                {
                    e.CellStyle.BackColor = Color.LightCoral; // Cambiar a color rojo para X
                    e.CellStyle.ForeColor = Color.Black; // Texto en color negro para mayor visibilidad
                }
                else
                {
                    e.CellStyle.BackColor = Color.LimeGreen; // Cambiar a color verde para ✔
                    e.CellStyle.ForeColor = Color.Black; // Texto en color negro para mayor visibilidad
                }
                //else
                //{
                //    // Restablecer el color de fondo y el color de texto predeterminados si no coincide con el valor deseado
                //    e.CellStyle.BackColor = dgvCarga.DefaultCellStyle.BackColor;
                //    e.CellStyle.ForeColor = dgvCarga.DefaultCellStyle.ForeColor;
                //}
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
            frm.Show();
		}

		private void dgvActions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
            if (dgvActions.Columns[e.ColumnIndex].Name == "Accion")
            {
                string accion = e.Value as string;
                if (accion != null)
                {
                    if (accion.Contains("INCORRECTA"))
                    {
                        e.CellStyle.BackColor = Color.LightCoral ;
                    }
                    else if (accion.Contains("CORRECTA"))
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.White; // Color por defecto
                    }
                }
            }
        }

		private void updateTimer_Tick(object sender, EventArgs e)
		{
            // Update the state of the comparisons
            pasta1Correcta = CompService.Instance.ComparacionPasta1Correcta;
            pasta2Correcta = CompService.Instance.ComparacionPasta2Correcta;
            stencilCorrecta = CompService.Instance.ComparacionStencilCorrecta;

            // Invalidate the PictureBoxes to trigger a repaint
            picturePasta1.Invalidate();
            picturePasta2.Invalidate();
            pictureStencil.Invalidate();
        }
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            bool isCorrect = false;

            if (pictureBox == picturePasta1)
                isCorrect = pasta1Correcta;
            else if (pictureBox == picturePasta2)
                isCorrect = pasta2Correcta;
            else if (pictureBox == pictureStencil)
                isCorrect = stencilCorrecta;

            // Draw the circle
            DrawCircle(e.Graphics, pictureBox.ClientRectangle, isCorrect);
        }
        private void DrawCircle(Graphics graphics, Rectangle rectangle, bool isCorrect)
        {
            int diameter = Math.Min(rectangle.Width, rectangle.Height) - 10;
            int x = (rectangle.Width - diameter) / 2;
            int y = (rectangle.Height - diameter) / 2;

            Color fillColor = isCorrect ? Color.Green : Color.Red;
            Color borderColor = Color.Black;

            using (SolidBrush brush = new SolidBrush(fillColor))
            using (Pen pen = new Pen(borderColor, 2))
            {
                graphics.FillEllipse(brush, x, y, diameter, diameter);
                graphics.DrawEllipse(pen, x, y, diameter, diameter);
            }
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
