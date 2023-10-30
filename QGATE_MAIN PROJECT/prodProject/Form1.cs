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
        public static int dpi; //dpi de la impresora

        private System.Timers.Timer t = new(60000); //Variable de timer para la funci�n AFK (idle), tiempo en milisegundos | 60000 = 1 minuto. Tiempo en el que se borrar� el n�mero de operador
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

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * 1. Llama a la clase CsvReader para armar el connection string con los datos del archivo DatabaseSettings.
         * 2. Llama a la clase CsvReader para obtener la IP de la impresora Zebra del archivo. Si no obtiene alg�n valor, cierra la aplicaci�n.
         * 4. Configura inicialmente al timer de inactividad para mantener el n�mero de operador.
         * 5. Asigna el dpi de la impresora zebra.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        /// <summary>
        /// Se establece la conexion a la BD y se obtienen los datos de la impresora
        /// </summary>
        /// <param name="waitMenu">Instancia de formulario anterior de la cual resive el estandar de contened0r</param>
        public Form1(WinScanForm waitMenu)
        {
            this.winScanForm = waitMenu;
            Control.CheckForIllegalCrossThreadCalls = false; //Permite la correcta manipulaci�n de Timers entre formularios. Ya que cada timer funciona en su propio hilo
            estandar = waitMenu.estandarContainer;
            CsvReader cr = new();
            printerIP = cr.GetPrinterIP();
            connectionString = CsvReader.SetConnectionString();
            if (connectionString != string.Empty && printerIP != string.Empty)
            {
                conn = new SqlConnection(connectionString);
                InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                ConfigTimer();
                dpi = 203;
            }
            else
            {
                if (printerIP == string.Empty)
                    MessageBox.Show("Revise el archivo .csv de configuraci�n de impresora.");
                Process.GetCurrentProcess().Kill();
            }
        }


        public Form1(ContainerIdForm firstMenu)
        {
            this.containerIdMenu = firstMenu;
            estandar = firstMenu.Estandar;
            Control.CheckForIllegalCrossThreadCalls = false; //Permite la correcta manipulaci�n de Timers entre formularios. Ya que cada timer funciona en su propio hilo
            CsvReader cr = new();
            printerIP = cr.GetPrinterIP();
            connectionString = CsvReader.SetConnectionString();
            if (connectionString != string.Empty && printerIP != string.Empty)
            {
                connectionString = connectionString + "; Connection Timeout = 30";
                conn = new SqlConnection(connectionString);
                InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Show();
                ConfigTimer();
                dpi = 600;
            }
            else
            {
                if (printerIP == string.Empty)
                    MessageBox.Show("Revise el archivo .csv de configuraci�n de impresora.");
                Process.GetCurrentProcess().Kill();
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
         * Funci�n ejecutada al presionar el bot�n "Comenzar"
         * 1. Cambia visualmente al cursor com una rueda de carga.
         * 2. Primero llama a la funci�n para revisar que no haya texto vac�o.
         * 3. Bloquea el n�mero de operador para no tener que reingresarlo.
         * 4. Despu�s llama a la funci�n de conexi�n a la base de datos para revisar la existencia del n�mero de Operador y la Pieza.
         * 5. Extrae los datos de la pieza (claveComp, idPieza, descripci�n, inicioCadena y finCadena)
         * 5.1 Extrae de la tabla pieza los datos del numero de pasos de revisi�n y el pasoReescaneo
         * 5. Por �ltimo revisa que la pieza no haya sido guardada con serial 0 previamente, es decir, que no haya sido liberada todav�a.
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
                if (CheckDataBase("SELECT", "numOperador", "Operador", "numOperador", opeTxtBox.Text) && CheckDataBase("SELECT", "claveComp, idPieza, descripcion, inicioCadena, finCadena, pasos, puntoReescaneo", "Pieza", "claveComp", piezaText))
                {

                    //getPiezaPartSteps();
                    if (CheckNotSerialZero())
                    {

                        //int estandarPieza = 0;
                        //estandarPieza = db.GetEstandarPieza(claveComp);
                        //if (estandarPieza != estandar) setMessagleLabel("Esta pieza no corresponde al estandar actual");
                        //else 
                        StartForms();



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
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         *  Funci�n de conexi�n al servidor de SQL y consultas DML SELECT para revisar que exista cierto atributo en la BD.
         *  --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool CheckDataBase(String dmlStatement, String attribute, String table, String condition, String value)
        {
            String queryString = "" + dmlStatement + " " + attribute + " FROM " + table + " WHERE " + condition + " = @value";

            try
            {
                conn.Open();
                //MessageBox.Show("Connection Granted");
                //connection.connectionString = queryString;
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", value));  //Prevenci�n de SQL Injection, mediante Parametrized Queries 

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
                        //totalSteps = record.GetInt16(5);  Futura implementaci�n para extraer la cantidad de pasos de revisi�n acorde a cada tipo de pieza
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

                    if (attribute.Equals("claveComp, idPieza, descripcion, inicioCadena, finCadena"))
                    {

                        piezaTxtBox.Clear();
                        t.Start();
                        setMessagleLabel("N�mero de pieza no encontrado en la Base de Datos");
                    }

                    else
                    {
                        opeTxtBox.Clear();
                        t.Start();
                        setMessagleLabel("N�mero de operador no encontrado en la Base de Datos");
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
            messageLabel.Location = new Point(ClientSize.Width / 2 - messageLabel.Width / 2, 311);
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funci�n para verificar que la pieza no haya sido guardada con serial igual a cero previamente, es decir que no haya sido 
         * liberada todav�a.
         * Retorna false en caso de que ya exista esa etiqueta con serial cero (Ya ha sido liberada) o si no ha cumplido el tiempo de retrabajo.
         * Retorna true en caso de que la etiqueta no haya tenido serial cero o si ya ha cumplido el tiempo de retrabajo.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool CheckNotSerialZero()
        {
            String queryString = "SELECT MIN(serial) FROM Operador_Pieza WHERE numEtiqueta = @value";
            try
            {
                conn.Open();
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", etiqueta));  //Prevenci�n de SQL Injection, mediante Parametrized Queries 
                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    if (record.GetInt16(0) == 0)
                    {
                        setMessagleLabel("La pieza ya fue liberada sin fallas previamente.");
                        t.Start();
                        return false;
                    }
                }
                conn.Close();
                return CheckReingreso(); //Llama a la funci�n para revisar el tiempo de reingreso de la pieza

            }
            catch (SqlNullValueException)
            {
                //omitir excepci�n generada cuando no se encuentra un serial en la DB (ingreso por primera vez, por ende no necesita revisar reingreso)
                conn.Close();
                return true;
            }

            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
                t.Start();
                return false;
            }

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funci�n para verificar que la pieza con NOK no sea reingresada dentro de X minutos (tiempo que dura el retrabajo).
         * Retorna false en caso de que no haya pasado el tiempo necesario.
         * Retorna true en caso de que haya cumplido el tiempo necesario.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool CheckReingreso()
        {
            String queryString = "SELECT MAX(fecha) FROM Operador_Pieza WHERE numEtiqueta = @value";
            try
            {
                conn.Open();
                SqlCommand cmd = new(queryString, conn);
                cmd.Parameters.Add(new SqlParameter("@value", etiqueta));  //Prevenci�n de SQL Injection, mediante consultas parametrizadas 
                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    DateTime dateRead = record.GetDateTime(0);       //Fecha y hora del �ltimo NOK de la pieza
                    TimeSpan span = DateTime.Now.Subtract(dateRead);
                    if (span.TotalMinutes >= this.minRetrabajo)     //Total minutes convierte el timespan a minutos, ejemplo: 1 hora = 60 minutos
                    {
                        return true;                                //Si ya pas� el tiempo de retrabajo, retorna true
                    }
                    string remain = (this.minRetrabajo - span.TotalMinutes).ToString("0.0");
                    setMessagleLabel("Todav�a no se ha cumplido el tiempo de retrabajo de la pieza. \nFaltan: " + remain + " minutos");
                }

                return false; //Si no ha cumplido el tiempo de retrabajo, retorna false
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show(e.Message);
                return false;
            }

        }
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         *  Funci�n para revisar que la informaci�n en las text box no contengan valores nulos o vac�os.
         *  --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (piezaTxtBox.Text == string.Empty || opeTxtBox.Text == string.Empty)
                    throw new ArgumentNullException();
                else
                {
                    opText = int.Parse(opeTxtBox.Text);
                    etiqueta = piezaTxtBox.Text;
                    piezaText = piezaTxtBox.Text.Substring(2, 7);
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
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Funci�n para desbloquear el textBox del n�mero de operador al terminar el timer.  
         * Recibe un evento invocado al momento que el timer cumple un ciclo.
         * Limpia el texto antes de permitir su modificaci�n.
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