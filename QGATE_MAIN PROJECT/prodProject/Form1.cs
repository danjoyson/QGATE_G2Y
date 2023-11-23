using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO.Ports;

namespace prodProject
{
    public partial class Form1 : Form
    {

        ContainerIdForm containerIdMenu;
        WinScanForm winScanForm;
        Printer p = new Printer();
        static Pieza pz  = new Pieza();    
        DatabaseConnector db = new DatabaseConnector();
        //Variables estáticas que contienen la información de consulta, son estáticas para permitir su manipulación desde otros formularios
        public static int opText; //Texto del número de operador
        public static string piezaText = ""; //Comparador de clave de pieza (10 caracteres)
        public static string etiqueta = "";  //Texto de etiqueta completo
        //DatabaseConnector connection = new DatabaseConnector();
        public static string inicioDeCadena = ""; //V o X de cadena de pieza
        public static string finDeCadena = ""; //últimos 2 dígitos del identificador de pieza (Obtenido de la base de datos)
        public static int idPiezaCatalog; //Id de la pieza en la base de datos
        public static string descripcion = ""; //Nombre de pieza en la base de datos
        public static int numPasos; //Numero de pasos de revisión de la pieza
        public static int pasoRescaneo; //Número de paso para el rescaneo de la etiqueta
        public static string claveComp = "";
        public static int formSlideCont = 1; //Contador que maneja qué imagen del formulario se mostrará
        public static string printerIP = "";
        public static int dpi = 0; //dpi de la impresora
        public string[] printerData;
        private System.Timers.Timer t = new(120000); //Variable de timer para la función AFK (idle), tiempo en milisegundos | 60000 = 1 minuto. Tiempo en el que se borrará el número de operador
        private readonly int minRetrabajo = 10; //MINUTOS m que estará bloqueada la pieza después de un NOK
        public static string lastZPLCommand = ""; //último comando de impresión enviado

        public static int consecutveNOKCounter = 0; //Contador de NOK seguidos
        public bool completedContainer = false;
        // public static int totalSteps; //Número de pasos total de revisión de la pieza. Obtenido de la base de datos
        public static String connectionString = "";
        public static SqlConnection conn;


        //Variable para conteo de piezas del container
        public static int estandar = 0;
        public static int conatadorPiezas = 0;

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * 1. Llama a la clase CsvReader para armar el connection string con los datos del archivo DatabaseSettings.
         * 2. Llama a la clase CsvReader para obtener la IP de la impresora Zebra del archivo. Si no obtiene algún valor, cierra la aplicación.
         * 4. Configura inicialmente al timer de inactividad para mantener el número de operador.
         * 5. Asigna el dpi de la impresora zebra.
         * --------------------------------------------------------------------------------------------------------------------------------
         */

        /// <summary>
        /// Constructor de formulario inicializa las variables de la pantalla de inspecció
        /// </summary>
        /// <param name="firstMenu">Instancia de menu container</param>
        public Form1(ContainerIdForm firstMenu)
        {
            this.containerIdMenu = firstMenu;
            estandar = ContainerIdForm.Estandar;
            Control.CheckForIllegalCrossThreadCalls = false; //Permite la correcta manipulación de Timers entre formularios. Ya que cada timer funciona en su propio hilo
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
                /*this.SetStyle(
                    ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.DoubleBuffer, true);*/
                this.Show();
                ConfigTimer();
            }
            else
            {
                if (String.IsNullOrEmpty(printerIP))
                    MessageBox.Show("Revise el archivo .csv de configuración de impresora.");
                Process.GetCurrentProcess().Kill();
            }
        }

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
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener datos de impresora",ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        /* 
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función ejecutada al presionar el botón "Comenzar"
         * 1. Cambia visualmente al cursor com una rueda de carga.
         * 2. Primero llama a la función para revisar que no haya texto vacío.
         * 3. Bloquea el número de operador para no tener que reingresarlo.4536587762
         * 4. Después llama a la función de conexión a la base de datos para revisar la existencia del número de Operador y la Pieza.
         * 5. Extrae los datos de la pieza (claveComp, idPieza, descripción, inicioCadena y finCadena)
         * 5.1 Extrae de la tabla pieza los datos del numero de pasos de revisión y el pasoReescaneo
         * 5. Por último revisa que la pieza no haya sido guardada con serial 0 previamente, es decir, que no haya sido liberada todavía.
         * 6. Si todo se encuentra correctamente, se inicializa el siguiente formulario.
         * 7. En caso de ya haber sido ingresada, muestra un mensaje de error y reinicia el timer de inactividad.
         * --------------------------------------------------------------------------------------------------------------------------------
        */
        private void btn1_Click(object sender, EventArgs e)
        {
            t.Stop();
            Cursor.Current = Cursors.WaitCursor;
            if (NotNullTxtBoxData())
            {
                SetDatosPieza();
                if (CheckDataBase("SELECT", "numOperador", "Operador", "numOperador", opeTxtBox.Text) && CheckDataBase("SELECT", "claveComp, idPieza, descripcion, inicioCadena, finCadena, pasos, puntoReescaneo", "Pieza", "claveComp", piezaText))
                {


                    //getPiezaPartSteps();
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
                            if(ValidaReingreso(etiqueta)) StartForms();
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
         * Función de inicio de formularios de revisión (Formulario siguiente)
         * 1. Llama al constructor del siguiente formulario y oculta temportalmente el formulario actual.
         * 2. Además limpia el cuadro de texto con la etiqueta para evitar el ingreso incorrecto de datos en la consulta siguiente.
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
        /// Verifica que el valor que se inserto exista en la base de datos
        /// </summary>
        /// <param name="dmlStatement"></param>
        /// <param name="attribute"></param>
        /// <param name="table"></param>
        /// <param name="condition"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckDataBase(String dmlStatement, String attribute, String table, String condition, String value)
        {
            String queryString = "" + dmlStatement + " " + attribute + " FROM " + table + " WHERE " + condition + " = @value";

            try
            {
                conn.Open();
                //connection.connectionString = queryString;
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", value));  //Prevención de SQL Injection, mediante Parametrized Queries 

                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    if (attribute.Equals("claveComp, idPieza, descripcion, inicioCadena, finCadena, pasos, puntoReescaneo"))
                    {
                        claveComp = record.GetString(0);
                        idPiezaCatalog = record.GetInt16(1);
                        descripcion = record.GetString(2);
                        inicioDeCadena = record.GetString(3);
                        finDeCadena = record.GetString(4);
                        numPasos = record.GetInt16(5);
                        pasoRescaneo = record.GetInt16(6);
                        //totalSteps = record.GetInt16(5);  Futura implementación para extraer la cantidad de pasos de revisión acorde a cada tipo de pieza
                    }
                    else
                    {
                        BlockNumOp();
                    }
                    conn.Close();
                    return true;
                }
                else
                {

                    if (attribute.Equals("claveComp, idPieza, descripcion, inicioCadena, finCadena, pasos, puntoReescaneo"))
                    {

                        piezaTxtBox.Clear();
                        t.Start();
                        setMessagleLabel("Número de pieza no encontrado en la Base de Datos");
                    }

                    else
                    {
                        opeTxtBox.Clear();
                        t.Start();
                        setMessagleLabel("Número de operador no encontrado en la Base de Datos");
                    }

                    conn.Close();
                    return false;
                }
            }
            catch (Exception e1)
            {
                conn.Close();
                MessageBox.Show(e1.Message);
                t.Start();
                return false;
            }
        }

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
                return true;                                //Si ya pasó el tiempo de retrabajo, retorna true
            }
            string remainTime = (this.minRetrabajo - span.TotalMinutes).ToString("0.0");
            setMessagleLabel("Todavía no se ha cumplido el tiempo de retrabajo de la pieza. \nFaltan: " + remainTime + " minutos");
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
                if (String.IsNullOrEmpty(piezaTxtBox.Text)  || String.IsNullOrEmpty(opeTxtBox.Text))
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
                setMessagleLabel("Formato inválido");
                t.Stop();
                return false;

            }
        }

        private void SetDatosPieza()
        {
            opText = int.Parse(opeTxtBox.Text);
            etiqueta = piezaTxtBox.Text;
            piezaText = piezaTxtBox.Text.Substring(2, 7);
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para bloquear el txtBox del número de operador.
         * Lo convierte a modo de "solo lectura".
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public void BlockNumOp()
        {
            this.opeTxtBox.ReadOnly = true;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función ejecutada al presionar el botón "Borrar texto"
         * Habilita la posibilidad de modificar el texto en el textBox del número de Operador y limpia el texto de las 2 cajas.
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
         * Función para configurar el timer AFK(Away From Keyboard) que permitirá detectar cuando se queda inactivo el formulario.
         * Le asigna la función EnableNumOp al evento que suelta el timer al completar un ciclo inicio-fin
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
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para desbloquear el textBox del número de operador al terminar el timer.  
         * Recibe un evento invocado al momento que el timer cumple un ciclo.
         * Limpia el texto antes de permitir su modificación.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
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
         * Función llamada al hacer click sobre el botón de configuración
         * Crea el formulario de configuración, lo muestra y esconde temporalmente el formulario actual.
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
         * Función para permitir que el formulario 3, limpie las cajas de texto al estar AFK
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