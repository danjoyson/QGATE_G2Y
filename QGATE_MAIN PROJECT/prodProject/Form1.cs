using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO.Ports;

namespace prodProject
{
    public partial class Form1 : Form
    {

        ContainerIdForm containerIdMenu;
        Printer p = new Printer();
        static Pieza pz = new Pieza();
        DatabaseConnector db = new DatabaseConnector();
        //Variables est�ticas que contienen la informaci�n de consulta, son est�ticas para permitir su manipulaci�n desde otros formularios
        public static int opText; //Texto del n�mero de operador
        public static string piezaText = ""; //Comparador de clave de pieza (10 caracteres)
        public static string etiqueta = "";  //Texto de etiqueta completo
        //DatabaseConnector connection = new DatabaseConnector();
        public static string inicioDeCadena = ""; //V o X de cadena de pieza
        public static string finDeCadena = ""; //�ltimos 2 d�gitos del identificador de pieza (Obtenido de la base de datos)
        public static int idPiezaCatalog; //Id de la pieza en la base de datos
        public static string descripcion = ""; //Nombre de pieza en la base de datos
        public static int numPasos; //Numero de pasos de revisi�n de la pieza
        public static int pasoRescaneo; //N�mero de paso para el rescaneo de la etiqueta
        public static string claveComp = "";
        public static int formSlideCont = 1; //Contador que maneja qu� imagen del formulario se mostrar�
        public static string printerIP = "";
        public static int dpi = 0; //dpi de la impresora
        public string[] printerData;
        private System.Timers.Timer t = new(120000); //Variable de timer para la funci�n AFK (idle), tiempo en milisegundos | 60000 = 1 minuto. Tiempo en el que se borrar� el n�mero de operador
        private readonly int minRetrabajo = 10; //MINUTOS m que estar� bloqueada la pieza despu�s de un NOK
        public static string lastZPLCommand = ""; //�ltimo comando de impresi�n enviado

        public static int consecutveNOKCounter = 0; //Contador de NOK seguidos
        public bool completedContainer = false;
        // public static int totalSteps; //N�mero de pasos total de revisi�n de la pieza. Obtenido de la base de datos
        public static String connectionString = "";
        public static SqlConnection conn;


        //Variable para conteo de piezas del container
        public static int estandar = 0;
        public static int conatadorPiezas = 0;


        /// <summary>
        /// Constructor de formulario inicializa las variables de la pantalla de inspecci�n
        /// </summary>
        /// <param name="firstMenu">Instancia de menu container</param>
        public Form1(ContainerIdForm firstMenu)
        {
            this.containerIdMenu = firstMenu;
            estandar = ContainerIdForm.Estandar;
            Control.CheckForIllegalCrossThreadCalls = false; //Permite la correcta manipulaci�n de Timers entre formularios. Ya que cada timer funciona en su propio hilo
            CsvReader cr = new();
            SetPrinterConfig(cr);
            connectionString = CsvReader.SetConnectionString();

            if (!String.IsNullOrEmpty(connectionString) && !String.IsNullOrEmpty(printerIP) && dpi != 0)
            {
                connectionString = connectionString + "; Connection Timeout = 30";
                conn = new SqlConnection(connectionString);
                InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                ConfigTimer();
            }
            else
            {
                if (String.IsNullOrEmpty(printerIP))
                    MessageBox.Show("Revise el archivo .csv de configuraci�n de impresora.");
                Process.GetCurrentProcess().Kill();
            }
        }

        /// <summary>
        /// Obtiene los datos de la impresora
        /// </summary>
        /// <param name="cr"></param>
        private void SetPrinterConfig(CsvReader cr)
        {
            try
            {
                printerData = cr.GetPrinterIP();
                if (printerData != null)
                {
                    printerIP = printerData[1];
                    p.IP = printerData[1];
                    dpi = Convert.ToInt32(printerData[2]);
                    p.DPI = dpi;
                }
                else
                {
                    MessageBox.Show("Error al extraer los datos de la impresora");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos de impresora", ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Valida si se puede iniciar con el proceso de inspecci�n de pieza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, EventArgs e)
        {
            t.Stop();
            Cursor.Current = Cursors.WaitCursor;
            if (NotNullTxtBoxData())
            {
                SetDatosPieza();
                if (CheckInputs())
                {
                    SetDatosVariante();

                    switch (db.CheckNotSerialZero(etiqueta))
                    {
                        case -2:
                            t.Start();
                            break;
                        case -1:
                            StartForms();
                            break;
                        case 0:
                            setMessagleLabel("La pieza ya fue liberada sin fallas previamente.");
                            t.Start();
                            break;
                        case 1:
                            if (ValidaReingreso(etiqueta)) StartForms();
                            break;


                    }
                }
            }
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
            Cursor.Current = Cursors.Default;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funci�n de inicio de formularios de revisi�n (Formulario siguiente)
         * 1. Llama al constructor del siguiente formulario y oculta temportalmente el formulario actual.
         * 2. Adem�s limpia el cuadro de texto con la etiqueta para evitar el ingreso incorrecto de datos en la consulta siguiente.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void StartForms()
        {
            messageLabel.Text = "";

            Form2 f2 = new(this);
            this.Hide();
            this.piezaTxtBox.Clear();
        }

        /// <summary>
        /// Asigna los datos para la variante de la pieza ingresada
        /// </summary>
        private void SetDatosVariante()
        {
            claveComp = pz.claveComp;
            idPiezaCatalog = pz.id;
            descripcion = pz.descripcion;
            inicioDeCadena = pz.inicioCadena;
            finDeCadena = pz.finCadena;
            numPasos = pz.pasos;
            pasoRescaneo = pz.puntoReescaneo;
        }

        /// <summary>
        /// Valida que los datos ingresados para inspecci�n sean validos
        /// </summary>
        /// <returns>True si los datos son validos</returns>
        private bool CheckInputs()
        {
            bool checkOperador;
            pz = db.GetPiezaInfo("SELECT", "claveComp, idPieza, descripcion, inicioCadena, finCadena, pasos, puntoReescaneo", "Pieza", "claveComp", piezaText);
            checkOperador = db.CheckOperador("SELECT", "numOperador", "Operador", "numOperador", opeTxtBox.Text);
            if (pz == null)
            {
                piezaTxtBox.Clear();
                t.Start();
                setMessagleLabel("N�mero de pieza no encontrado en la Base de Datos");
                return false;
            }
            if (!checkOperador)
            {
                opeTxtBox.Clear();
                t.Start();
                setMessagleLabel("N�mero de operador no encontrado en la Base de Datos");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Asigna los datos y posici�n que se muestran en el mensaje
        /// </summary>
        /// <param name="message"></param>
        private void setMessagleLabel(string message)
        {
            messageLabel.Text = message;
            messageLabel.Location = new Point(ClientSize.Width / 2 - messageLabel.Width / 2, (ClientSize.Width / 3) - 20);
        }

        /// <summary>
        /// Verifica que una pieza que ya fue revisada cumpla con el tiempo de espera para volver a revisar
        /// </summary>
        /// <param name="etiqueta">Etiqueta de pieza que se desea revisar</param>
        /// <returns></returns>
        private bool ValidaReingreso(string etiqueta)
        {
            DateTime remain;
            remain = db.CheckReingreso(etiqueta);
            TimeSpan span = DateTime.Now.Subtract(remain);
            if (span.TotalMinutes >= this.minRetrabajo)     //Total minutes convierte el timespan a minutos, ejemplo: 1 hora = 60 minutos
            {
                return true;                                //Si ya pas� el tiempo de retrabajo, retorna true
            }
            string remainTime = (this.minRetrabajo - span.TotalMinutes).ToString("0.0");
            setMessagleLabel("Todav�a no se ha cumplido el tiempo de retrabajo de la pieza. \nFaltan: " + remainTime + " minutos");
            return false;
        }
        /// <summary>
        /// Valida que se hayan ingresado todos los datos que solicita el sistema.
        /// </summary>
        /// <returns></returns>
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (String.IsNullOrEmpty(piezaTxtBox.Text) || String.IsNullOrEmpty(opeTxtBox.Text))
                    throw new ArgumentNullException();
                else
                {
                    return true;
                }
            }
            catch (ArgumentNullException)
            {
                setMessagleLabel("Ingrese todos los datos");
                t.Start();
                return false;
            }
            catch (Exception)
            {
                setMessagleLabel("Formato inv�lido");
                t.Stop();
                return false;

            }
        }

        /// <summary>
        /// Asigna los valores de los datos introducidos por el usuario
        /// </summary>
        private void SetDatosPieza()
        {
            opText = int.Parse(opeTxtBox.Text);
            etiqueta = piezaTxtBox.Text;
            piezaText = piezaTxtBox.Text.Substring(2, 7);
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funci�n para bloquear el txtBox del n�mero de operador.
         * Lo convierte a modo de "solo lectura".
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public void BlockNumOp()
        {
            this.opeTxtBox.ReadOnly = true;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funci�n ejecutada al presionar el bot�n "Borrar texto"
         * Habilita la posibilidad de modificar el texto en el textBox del n�mero de Operador y limpia el texto de las 2 cajas.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnOpChange_Click(object sender, EventArgs e)
        {
            this.opeTxtBox.Clear();
            this.opeTxtBox.ReadOnly = false;
            this.piezaTxtBox.Clear();
            this.messageLabel.Text = string.Empty;
        }

        /*
         * ------------------------------------------------------------------------------------------------------------------------------------------
         * Funci�n para configurar el timer AFK(Away From Keyboard) que permitir� detectar cuando se queda inactivo el formulario.
         * Le asigna la funci�n EnableNumOp al evento que suelta el timer al completar un ciclo inicio-fin
         * ------------------------------------------------------------------------------------------------------------------------------------------
         */
        private void ConfigTimer()
        {
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(EnableNumOp);
        }

        /*
         * ------------------------------------------------------------------------------------------------------------------------------------------
         * Permite comenzar el timer desde un formulario externo.
         * Es llamada cada que los formularios OK/NOK son cerrados.
         * ------------------------------------------------------------------------------------------------------------------------------------------
         */
        public void StartForeignTimer()
        {
            t.Start();
        }

        /// <summary>
        /// habilita el input del numero de operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EnableNumOp(object sender, System.Timers.ElapsedEventArgs e)
        {
            EnableNumOp();
            t.Stop();
        }

        public void EnableNumOp()
        {
            this.opeTxtBox.Clear();
            this.opeTxtBox.ReadOnly = false;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funci�n llamada al hacer click sobre el bot�n de configuraci�n
         * Crea el formulario de configuraci�n, lo muestra y esconde temporalmente el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            AdminLogin LoginForm = new();
            this.Hide();
            LoginForm.Show();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funci�n para permitir que el formulario 3, limpie las cajas de texto al estar AFK
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public void ClearTextBoxes()
        {
            this.opeTxtBox.Clear();
            this.piezaTxtBox.Clear();
        }

        private void PiezaTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void OpeTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}