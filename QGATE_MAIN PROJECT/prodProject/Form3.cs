﻿using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;

namespace prodProject
{
    public partial class Form3 : Form
    {
        private bool blockAppClosing = false;
        private int serial;
        private Form1 f1;
        private EmailWarner emailW; //objeto de la clase que se encarga de enviar los emails
        public string currentProcess;
        private string textEtiqueta;
        private string mobisysProcessName = "MobisysClient100"; //Variable nombre de proceso que debe ser superpuesto al completar una revision de pieza
        private System.Timers.Timer buttonsTimer = new(3000); //timer de bloqueo de botón OK (duración inicial, luego cambia)
        private System.Timers.Timer NOKTimer = new(60000); //timer para el Punto 10. Si pasan 60 segundos, se presionará NOK automáticamente.
        private bool timerP9Flag = false;                   //En realidad funciona para el P10.
        private System.Timers.Timer AFKTimer = new(60000); //Timer de 1 minuto. Al terminar este timer, se devuelve al formulario de inicio. (AFK)

        //Driver necesario para acceder a los procesos del sistema
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        /* 
         * --------------------------------------------------------------------------------------------------------------------------------
         * Constructor del formulario 3 (Con botones OK/NOK)
         * 1. Llama a la función de búsqueda y asignación de imagen. En caso de no haber errores continúa.
         * 2. Crea un nuevo objeto de la clase "EmailWarner"
         * 3. Configura el funcionamiento del timer para los "botones OK", el timer del punto 10 y el timer de inactividad.
         * 4. Inicializa el formulario y lo muestra.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public Form3(Form1 f1)
        {

            if (SetImage())
            {
                this.FormClosing += new FormClosingEventHandler(Form3_FormClosing);
                this.serial = 0;
                this.f1 = f1;
                emailW = new();

                buttonsTimer.AutoReset = true;
                buttonsTimer.Elapsed += new ElapsedEventHandler(EnableButtons);
                buttonsTimer.Start();

                NOKTimer.AutoReset = true;
                NOKTimer.Elapsed += new ElapsedEventHandler(TimerP9Elapsed_NOK);

                AFKTimer.AutoReset = false;
                AFKTimer.Elapsed += new ElapsedEventHandler(AFKReturn);



                InitializeComponent();
                txtEtiqueta.TextChanged += txtEtiqueta_TextChanged;
                this.BtnOK.Enabled = false;
                this.Show();
                AFKTimer.Start();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Busca y cambia la imagen de fondo del formulario.
         * 1. Arma el string que contiene la ruta de la pieza, con los datos ingresados en el txtBox del primer formulario
         * 2. Si no la encuentra manda un mensaje de error y retorna al formulario de inicio.
         * 3. Si no hay error alguno, retorna true
         * 
         * Ejemplo de string Path de imagen 
         * C:\Users\salazard\source\repos\prodProject\prodProject\bin\Debug\net6.0-windows\images\6807101\6807101_S1.JPG
         * 
         * Donde " C:\Users\salazard\source\repos\prodProject\prodProject\bin\Debug\net6.0-windows" equivale al Application.StartupPath
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool SetImage()
        {
            try
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\images2\" + Form1.piezaText + @"\" + Form1.piezaText + "_S" + Form1.formSlideCont + ".JPG");
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error. Revise que las imágenes de los formularios se encuentren en la carpeta correcta.");
                ReturnToHome();
                return false;
            }
            return true;
        }



        /* 
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función que controla los eventos al pulsar el botón OK.
         * 
         * 1. Si el contador de slide es diferente a 11: Aumenta el contador en 1, vuelve invisible el formulario actual, cambia la imagen a 
         *    la slide siguiente de la pieza que se está evaluando, espera a que el timer cambie el valor de la bandera de espera,
         *    lo hace visible de nuevo y resetea el valor de la bandera a false para el funcionamiento de los siguientes formularios.
         *    
         *    También se maneja el timer de bloqueo de botones OK.
         * 
         * 2. Si el contador es igual a 11, esconde el formulario actual.
         * 3. Llama a la función de inserción de registro en la base de datos.
         * 4. En caso de no baber errores, lo notifica y llama al formulario de impresión 
         * 
         * 
         * El timer en realidad es meramente estético, si se omite no afecta al funcionamiento de la aplicación. No obstante, si no se 
         * estuviese o si es muy corto, el cambio de slides parece un efecto visual de glitcheo.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnOK_Click(object sender, EventArgs e)
        {
            Form1.consecutveNOKCounter = 0; //Reinicia el contador de NOKs consecutivos


            /*
             * Podría hacerse un switch de "Tipo de formulario"
             * 
             * Detectar si es OK/NOK normal (1)
             * Si es de tipo 1 slide antes de escaneo de pieza (2)
             * Si es de tipo slide de escaneo (3)
             * Si es de tipo slide final de proceso (4)
             * 
             * Esto serviría en caso de que el total de puntos de inspección de pieza sea diferente para cada una. Y así se seguiría usando un switch
             * en vez de cambiar a if's anidados. Para no alentar el tiempo de ejecución.
             */
            //int remainFormsTillRESCAN;
            
           /* switch (Form1.formSlideCont)
            {
                case 9: //Cambia de formulario y habilita la caja de etiqueta para el punto 10
                    AFKTimer.Stop();
                    Form1.formSlideCont++;
                    //this.Hide();
                    if (SetImage())
                    {
                        SetButtonsTimerDuration();
                        buttonsTimer.Start();
                        this.BtnOK.Enabled = false;

                        this.messageLabel.Visible = true;
                        this.txtEtiqueta.Visible = true;
                        this.pictureBox1.Visible = true;

                        this.txtEtiqueta.Focus(); //Selecciona automáticamente la caja de texto de re-escaneo de etiqueta
                        NOKTimer.Start(); //Comienza el timer de escaneo de etiqueta
                    }


                    break;

                case 10:
                    if (this.txtEtiqueta.Text.Equals(Form1.etiqueta))
                    {
                        timerP9Flag = true; //Cambia a true la bandera, para evitar que se imprima la etiqueta NOK al terminar el timer
                        NOKTimer.Stop();
                        Form1.formSlideCont++;
                        this.txtEtiqueta.Visible = false;
                        this.pictureBox1.Visible = false;
                        this.messageLabel.Visible = false;
                        txtEtiqueta.Text = string.Empty;

                        if (SetImage())
                        {
                            SetButtonsTimerDuration();
                            buttonsTimer.Start();
                            this.BtnOK.Enabled = false;
                            AFKTimer.Start();
                        }
                    }
                    else
                    {
                        this.txtEtiqueta.Focus(); //Selecciona automáticamente la caja de texto de re-escaneo de etiqueta
                        messageLabel.Text = "La etiqueta no coincide.";
                        messageLabel.Location = new Point(txtEtiqueta.Location.X + messageLabel.Width, txtEtiqueta.Location.Y + txtEtiqueta.Height);
                        txtEtiqueta.Text = string.Empty;
                    }
                    break;


                case 11:
                    
                    Form1.consecutveNOKCounter = 0;//reinicia el contador de NOKs cada que sale una pieza con todos sus puntos OK
                    AFKTimer.Stop();
                    if (InsertDbRecord())
                    {
                        callPrinter(); //Print box label
                    }
                    ReturnToHome();
                    break;

                default:
                    AFKTimer.Stop();
                    Form1.formSlideCont++;
                    if (SetImage())
                    {
                        SetButtonsTimerDuration();
                        buttonsTimer.Start();
                        this.BtnOK.Enabled = false;

                        AFKTimer.Start();
                    }
                    break;
            }*/

            if (Form1.formSlideCont==Form1.pasoRescaneo-1)
            {
                AFKTimer.Stop();
                Form1.formSlideCont++;
                //this.Hide();
                if (SetImage())
                {
                    SetButtonsTimerDuration();
                    buttonsTimer.Start();
                    this.BtnOK.Enabled = false;

                    this.messageLabel.Visible = true;
                    this.txtEtiqueta.Visible = true;
                    this.pictureBox1.Visible = true;

                    this.txtEtiqueta.Focus(); //Selecciona automáticamente la caja de texto de re-escaneo de etiqueta
                    NOKTimer.Start(); //Comienza el timer de escaneo de etiqueta
                }
            }else
            {
                if (Form1.formSlideCont == Form1.pasoRescaneo && Form1.formSlideCont==Form1.numPasos )
                {
                    
                    if (this.txtEtiqueta.Text.Equals(Form1.etiqueta))
                    {
                        timerP9Flag = true; //Cambia a true la bandera, para evitar que se imprima la etiqueta NOK al terminar el timer
                        NOKTimer.Stop();
                        Form1.formSlideCont++;
                        this.txtEtiqueta.Visible = false;
                        this.pictureBox1.Visible = false;
                        this.messageLabel.Visible = false;
                        textEtiqueta = this.txtEtiqueta.Text;
                        txtEtiqueta.Text = string.Empty;

                        /*if (SetImage())
                        {
                            SetButtonsTimerDuration();
                            buttonsTimer.Start();
                            this.BtnOK.Enabled = false;
                            AFKTimer.Start();
                        }*/
                        SetButtonsTimerDuration();
                        buttonsTimer.Start();
                        this.BtnOK.Enabled = false;
                        AFKTimer.Start();
                        generaRegistro(textEtiqueta);
                        
                    }
                    else
                    {
                        this.txtEtiqueta.Focus(); //Selecciona automáticamente la caja de texto de re-escaneo de etiqueta
                        messageLabel.Text = "La etiqueta no coincide.";
                        messageLabel.Location = new Point(txtEtiqueta.Location.X + messageLabel.Width, txtEtiqueta.Location.Y + txtEtiqueta.Height);
                        txtEtiqueta.Text = string.Empty;
                    }
                }
                else
                {
                    if (Form1.formSlideCont==Form1.numPasos ) 
                    {
                        Form1.consecutveNOKCounter = 0;//reinicia el contador de NOKs cada que sale una pieza con todos sus puntos OK
                        AFKTimer.Stop();
                        
                        if (InsertDbRecord())
                        {
                            //Se comento para no enviar a impresión al momento de hacer pruebas
                            //callPrinter(); //Print box label
                            MessageBox.Show("Se cumplieron todos los pasos con exito");
                        }
                        ReturnToHome();
                    } 
                    else 
                    { 
                        AFKTimer.Stop();
                        Form1.formSlideCont++;
                        if (SetImage())
                        {
                            SetButtonsTimerDuration();
                            buttonsTimer.Start();
                            this.BtnOK.Enabled = false;

                            AFKTimer.Start();
                        }
                    }
                }
            }
        }

        /*
            Metodo post escaneo de etiqueta este debe ejecutarse despues de que se presiona el boton ok en el paso de reescaneo, envia registro a BD y lanza la pantalla de mobisys
         */

        public void generaRegistro(string text)
        {
            Form1.consecutveNOKCounter = 0;//reinicia el contador de NOKs cada que sale una pieza con todos sus puntos OK
            AFKTimer.Stop();

            if (InsertDbRecord())
            {
                //Se comento para no enviar a impresión al momento de hacer pruebas
                //callPrinter(); //Print box label
                AddToMobisys(text);
                MessageBox.Show("Se cumplieron todos los pasos con exito");
            }
            ReturnToHome();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para prevenir doble chequeo de pieza del escáner en el punto de reescaneo
         * Si detecta que la etiqueta se escaneó otra vez, llimpia la caja de texto
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void txtEtiqueta_TextChanged(object sender, EventArgs e)
        {
            if (txtEtiqueta.Text.Length == 40) //Elegimos 40 ya que vimos que algunas etiquetas superan los 30 caracteres
            {
                txtEtiqueta.Enabled = false;
                txtEtiqueta.Clear();
                txtEtiqueta.Enabled = true;
                //   txtEtiqueta.Focus();
            }
        }



        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * SETTEA EL INTERVALO DEL TIMER DE BOTONES ACORDE A CADA PUNTO, en milisengundos. 
         * Todos manejan un rango de -500 milisegundos para no obstruir o alentar al operador
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void SetButtonsTimerDuration()
        {
            switch (Form1.formSlideCont)
            {
                case 1:
                    buttonsTimer.Interval = 2500;
                    break;

                case 2:
                    buttonsTimer.Interval = 2500;
                    break;

                case 3:
                    buttonsTimer.Interval = 5500;
                    break;

                case 4:
                    buttonsTimer.Interval = 6500;
                    break;

                case 5:
                    buttonsTimer.Interval = 2500;
                    break;

                case 6:
                    buttonsTimer.Interval = 2500;
                    break;

                case 7:
                    buttonsTimer.Interval = 3500;
                    break;

                case 8:
                    buttonsTimer.Interval = 1000;
                    break;

                case 9:
                    buttonsTimer.Interval = 11500;
                    break;

                case 10:
                    buttonsTimer.Interval = 500; //No puede ser cero, ya que genera una excepción
                    break;

                case 11:
                    buttonsTimer.Interval = 3500;
                    break;

                default:
                    buttonsTimer.Interval = 1000;
                    break;
            }
        }




        /* 
         * --------------------------------------------------------------------------------------------------------------------------------
         * Esta función es llamada cada que el Timer de formulario realiza un ciclo de inicio-fin mediante el evento ElapsedEvent.
         * No hace nada de momento.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private static void WaitFunction(object sender, ElapsedEventArgs e)
        {
            
        }

        /* 
         * --------------------------------------------------------------------------------------------------------------------------------
         * Esta función es llamada cada que el Timer de botones realiza un ciclo de inicio-fin mediante el evento ElapsedEvent
         * Habilita el botón OK.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void EnableButtons(object sender, ElapsedEventArgs e)
        {
            this.BtnOK.Enabled = true;
            buttonsTimer.Stop();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función que controla los eventos al pulsar el botón NOK.
         * 
         * 1. Llama al método para buscar el último serial de la pieza y le asigna uno nuevo.
         * 2. Después llama al método para guardar el registro en la Base de Datos.
         * 3. En caso de no haber errores, muestra un formulario de espera mientras envía los correos de notificación.
         * 4. Si el serial es mayor o igual a 3, llama al formulario de bloqueo de la aplicación.
         * 5. Si es el tercer NOK consecutivo, sin importar si son de piezas distintas, también se bloqueará la aplicación.
         * 6. En caso de que el serial sea menor a 3, manda una notificación de NOK mediante el EmailWarner.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnNOK_Click(object sender, EventArgs e)
        {
            AFKTimer.Stop();
            Form1.consecutveNOKCounter++;
            if (Form1.formSlideCont == 10)
            {
                timerP9Flag = true;
                NOKTimer.Stop(); //Para el punto 10. Si es que se presionó el botón antes de que el timer terminara
            }

            this.Hide();

            if (GenerateDBSerial())
            {
                 if (InsertDbRecord())
                 {
                     if (this.serial >= 3 || Form1.consecutveNOKCounter == 3) //Si la misma etiqueta ha dado 3 NOK o si 3 piezas cualquiera seguidas dan 1 NOK cada una
                     {
                        // ZebraLinker z = new ZebraLinker(Form1.printerIP);
                        // z.printOkNokLabelZPL(Form1.dpi);//Impresión de etiqueta NOK

                         this.blockAppClosing = true;
                         BlockApp();
                         this.Close();
                     }
                     else
                     {

                        // ZebraLinker z = new ZebraLinker(Form1.printerIP);
                        // z.printOkNokLabelZPL(Form1.dpi);//Impresión de etiqueta NOK

                         emailW.SendNOKWarning();
                         ReturnToHome();

                     }
                 }

            }
        }

        /*
        * --------------------------------------------------------------------------------------------------------------------------------
        * Función que controla los eventos cuando se termina el timer del punto 10
        * 
        * 1. Llama al método para buscar el último serial de la pieza y le asigna uno nuevo.
        * 2. Después llama al método para guardar el registro en la Base de Datos.
        * 3. En caso de no haber errores, muestra un formulario de espera mientras envía los correos de notificación
        * 4. Si el serial es mayor o igual a 3, llama al formulario de bloqueo de la aplicación
        * 5. En caso de que el serial sea menor a 3, manda una notificación de NOK mediante el EmailWarner.
        * --------------------------------------------------------------------------------------------------------------------------------
        */
        private void TimerP9Elapsed_NOK(object sender, EventArgs e)
        {

            if (timerP9Flag == false) //Si no se ha presionado OK
            {
                this.Hide();

                if (GenerateDBSerial())
                {
                    if (InsertDbRecord())
                    {
                        if (this.serial >= 3)
                        {

                            //ZebraLinker z = new ZebraLinker(Form1.printerIP);
                            //z.printOkNokLabelZPL(Form1.dpi);

                            BlockApp();
                            this.Close();
                        }
                        else
                        {

                            //ZebraLinker z = new ZebraLinker(Form1.printerIP);
                            //z.printOkNokLabelZPL(Form1.dpi);

                            emailW.SendNOKWarning();
                            ReturnToHome();

                        }
                    }
                }

            }
            NOKTimer.Stop();
            //Si se presionó OK, la bandera es true y por ende no hace nada

        }


        /*
       * --------------------------------------------------------------------------------------------------------------------------------
       * Función que controla los eventos cuando se termina el timer AFK (Away From Keyboard)
       * 
       * 1. Cierra este formulario
       * 2. Regresa al formulario de inicio
       * 
       * --------------------------------------------------------------------------------------------------------------------------------
       */
        private void AFKReturn(object sender, EventArgs e)
        {

            this.Hide();
            AFKTimer.Stop();
            f1.ClearTextBoxes();
            this.Close(); //REGRESA EN AUTOMÁTICO AL FORM1

        }


        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para extraer el último serial de la parte, retorna true o false dependiendo de la capacidad de ejecutar la Query
         * 1. Se conecta a la base de datos y hace una consulta de serial con esa etiqueta.
         * 2. Si no hay un serial previo, se le asignará el valor de 1.
         * 3. Si hay un serial previo, se tomará el valor máximo y se le suma 1.
         * 
         * Retorna true en caso de no haber ningún error.
         * Retorna false en caso de alguna excepción.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool GenerateDBSerial()
        {
            String queryString = "SELECT MAX(serial) FROM Operador_Pieza WHERE numEtiqueta = '" + Form1.etiqueta + "';";

            try
            {
                Form1.conn.Open();
                //MessageBox.Show("Connection Granted");

                SqlCommand cmd = new(queryString, Form1.conn);
                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    this.serial = record.GetInt16(0) + 1;
                    Form1.conn.Close();
                }
                return true;
            }
            catch (SqlNullValueException)
            {
                //omitir excepción generada cuando no se encuentra un serial en la DB (ingreso por primera vez, por ende serial = 1)
                this.serial = 1;
                return true;
            }
            catch (Exception e1)
            {
                
                MessageBox.Show("Error generando serial :",e1.Message);
                ReturnToHome();
                return false;
            }
            finally
            {
                Form1.conn.Close();
            }

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         *  Función de conexión al servidor de SQL y query DML INSERT INTO para ingresar un registro nuevo a la tabla Operador_Pieza
         *  Recibe el dmlStatement: INSERT INTO
         *  Trabaja con el insertionQueryString
         *  
         *  Se conecta a la Base de Datos e inserta el registro de inspección.
         *  --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool InsertDbRecord()
        {
            String queryString;

            if (this.serial == 0) //Si la pieza es OK, GUARDA 11 OK'S
            {
                //queryString = "INSERT INTO Operador_Pieza VALUES(@numEtiqueta, @serial, @numOperador, @idPieza, @fecha, 'OK', 'OK', 'OK' , 'OK', 'OK', 'OK', 'OK', 'OK', 'OK', 'OK', 'OK');";
                queryString = "INSERT INTO Operador_Pieza VALUES(@numEtiqueta, @serial, @numOperador, @idPieza, @fecha";
                //Se modifica el query ya que no en todos los casos son 11 OK, depende de el numero de pasos de cada pieza, por eso se hizo dinamico.
                //Prueba temporal por guardar en la misma BD, se colocan los 11 por el numero de campos en la BD actual (Form1.numPasos-1
                
                for (int i = 0; i < Form1.numPasos; i++)
                {
                    queryString += ",'OK' ";
                }
                for (int i=Form1.numPasos;i<11;i++) queryString += ", NULL";
                queryString += ");";

            }
            else //Si la pieza es NOK, guarda n NOK's a partir de donde se haya quedado el contador de slide
            {
                queryString = "INSERT INTO Operador_Pieza VALUES(@numEtiqueta, @serial, @numOperador, @idPieza, @fecha";

                for (int i = 0; i < Form1.formSlideCont - 1; i++)
                {
                    queryString += ",'OK' ";
                }

                queryString += ", 'NOK'";

                //Debe ser el limite del for Form1.numPasos, como prueba se puso 11 para validar en la bd
                for (int j = Form1.formSlideCont + 1; j <= 11; j++)
                {
                    queryString += ", NULL";
                }

                queryString += ");";
            }


            try
            {
                Form1.conn.Open();
                //MessageBox.Show("Connection Granted");
                //MessageBox.Show(queryString);
                SqlCommand cmd = new(queryString, Form1.conn);
                cmd.Parameters.AddWithValue("@numEtiqueta", Form1.etiqueta);
                cmd.Parameters.AddWithValue("@serial", this.serial);
                cmd.Parameters.AddWithValue("@numOperador", Form1.opText);
                cmd.Parameters.AddWithValue("@idPieza", Form1.idPiezaCatalog);
                String formatDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //Fecha y Hora actuales con formato adecuado para SQL server
                cmd.Parameters.AddWithValue("@fecha", formatDateTime);

                cmd.ExecuteNonQuery(); //Ejecuta la consulta de inserción.
                Form1.conn.Close();

                return true;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Error insertando operador-pieza a la bd");
                ReturnToHome();
                return false;
            }

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método para regresar al formulario de inicio e iniciar el timer del formulario inicial.
         * Hecha para evitar repetición de líneas de código.
         * También previene que cualquier conexión con la base de datos se quede abierta.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void ReturnToHome()
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            Application.OpenForms["Form1"].Show();
            f1.StartForeignTimer();
            this.Close();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método de llamado impresión de etiqueta de caja
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void callPrinter()
        {
            ZebraLinker ZBLinker = new(Form1.printerIP);
            ZBLinker.PrintBoxLabelZPL(Form1.etiqueta, Form1.descripcion, "83", Form1.dpi);
        }

        /*
        * --------------------------------------------------------------------------------------------------------------------------------
        * Método de bloqueo de aplicación.
        * 1. Llama al método para generar el código de desbloqueo aleatorio.
        * 2. Muestra el formulario de bloqueo.
        * 3. Envía la notificación de bloqueo junto con el código aleatorio.
        * 
        * Si ocurre algún error al querer enviar el código de bloqueo, se retornará a la pantalla de inicio
        * --------------------------------------------------------------------------------------------------------------------------------
        */
        private void BlockApp()
        {

            string randomCode = emailW.GenerateRandomUnblockCode();
            Form4_Blocker fBlocker = new(randomCode, f1);
            fBlocker.Show();
            fBlocker.Refresh(); //Para evitar bugs de visualización

            Cursor.Current = Cursors.WaitCursor;
            bool flag = emailW.SendBlockedWarning(randomCode);
            if (flag == false)
            {
                ReturnToHome();
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método para manejar el cerrado de la aplicación incompleto
         * --------------------------------------------------------------------------------------------------------------------------------
        */
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.blockAppClosing == false)
            {
                //Se cambio la condición que antes era estatica por la comparación con Form1.pasoReescaneo que es el mismo dato pero sacado de la BD
                if(Form1.formSlideCont == Form1.pasoRescaneo) //Si se cierra el programa incorrectamente en el punto de reingreso de etiqueta. Para que no lo guarde como NOK necesariamente
                {
                    NOKTimer.Stop();
                }
                if (Application.OpenForms["Form1"].Visible == false)
                    Application.OpenForms["Form1"].Visible = true;
                f1.StartForeignTimer();
            }
            
        }

        public void CopyToClipboard(String text)
        {
            try
            {
                Clipboard.SetText(text);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "No se puede copiar el texto");
            }
        }

        public void PasteFromClipboard()
        {
            try
            {
                SendKeys.SendWait("^(v)");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"No se puede pegar el texto");
            }
        }
        private void SuperposeProgram(string procName)
        {
            string processName = procName;
            string mainProcess = "";
            // Buscar el proceso por nombre
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                // Obtener el identificador de la ventana principal del primer proceso encontrado
                IntPtr windowHandle = processes[0].MainWindowHandle;

                if (windowHandle != IntPtr.Zero)
                {

                    // Traer la ventana de Microsoft Teams al frente
                    SetForegroundWindow(windowHandle);
                    //MessageBox.Show("Debería");


                }
                else
                {
                    MessageBox.Show($"La ventana principal de {processName} no se encontró.");
                }
            }
            else
            {
                MessageBox.Show($"{processName} no está en ejecución.");
            }
        }

        private void GetCurrentProcessName()
        {
            Process procesoActual = Process.GetCurrentProcess();
            // Obtener el nombre del proceso
            string nombreDelProceso = procesoActual.ProcessName;
            currentProcess = nombreDelProceso;
            //MessageBox.Show("Nombre del proceso actual: " + nombreDelProceso);

        }

        private void AddToMobisys(string text)
        {
            try
            {
                //EL código del if comentado será implementado para la siguiete modificación
                //Si el if se cumple debe mandar a la pantalla llamada menu Mobisys, sino se cumple continua con el código que esta despues del if 
                //ese código estaría en un else y ahí debe incrementarse el contador de piezas en 1
                //if(Form1.conatadorPiezas==Form1.estandar)
                GetCurrentProcessName();
                CopyToClipboard(text);
                SuperposePid(mobisysProcessName);
                System.Threading.Thread.Sleep(1000);
                PasteFromClipboard();
                System.Threading.Thread.Sleep(1000);
                SuperposeProgram(currentProcess);
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error tratando de añadir a mobisys");
            }
        }


        public static int GetProcessID(string processName)
        {
            int processID = -1; // Valor predeterminado en caso de que no se encuentre el proceso

            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 0)
            {
                // Obtiene el PID del primer proceso con el nombre especificado
                processID = processes[0].Id;
            }
            else
            {
                Console.WriteLine($"No se encontró el proceso con nombre '{processName}'.");
            }

            return processID;
        }

        public static void BringWindowToFrontByPID(int targetPID)
        {
            IntPtr targetWindowHandle = IntPtr.Zero;

            EnumWindows((hWnd, lParam) =>
            {
                int windowPID;
                GetWindowThreadProcessId(hWnd, out windowPID);

                if (windowPID == targetPID)
                {
                    targetWindowHandle = hWnd;
                    return false; // Detener la enumeración
                }

                return true; // Continuar enumerando
            }, IntPtr.Zero);

            if (targetWindowHandle != IntPtr.Zero)
            {
                SetForegroundWindow(targetWindowHandle);
            }
            else
            {
                MessageBox.Show($"No se encontró ninguna ventana para el proceso con PID {targetPID}.");
            }
        }

        private void SuperposePid(string procName)
        {
            int targetProcessPID = -1;
            targetProcessPID = GetProcessID(mobisysProcessName);
            if (targetProcessPID != -1)
            {

                BringWindowToFrontByPID(targetProcessPID);
            }
            else
            {
                MessageBox.Show("The app cant get the PID");
            }
        }

    }
}
