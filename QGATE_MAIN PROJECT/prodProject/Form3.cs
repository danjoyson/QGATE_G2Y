using System.Data;
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
        DatabaseConnector db = new DatabaseConnector();
        private EmailWarner emailW; //objeto de la clase que se encarga de enviar los emails
        private string textEtiqueta;
        private System.Timers.Timer buttonsTimer = new(3000); //timer de bloqueo de botón OK (duración inicial, luego cambia)
        private System.Timers.Timer NOKTimer = new(60000); //timer para el Punto 10. Si pasan 60 segundos, se presionará NOK automáticamente.
        private bool timerP9Flag = false;                   //En realidad funciona para el P10.
        private System.Timers.Timer AFKTimer = new(60000); //Timer de 1 minuto. Al terminar este timer, se devuelve al formulario de inicio. (AFK)
        private ProcessManipulation mobisys = new ProcessManipulation();
        private bool waitScanFlag = false;
        private int nextWindowForm = -1;
        ZebraLinker z;
        private System.Windows.Forms.Timer scanMobisysTimer = new System.Windows.Forms.Timer();

        public Form3(Form1 f1)
        {
            scanMobisysTimer.Interval = 60000;
            waitScanFlag = false;
            nextWindowForm = -1;
            this.f1 = f1;
            z = new ZebraLinker(Form1.printerIP);
            if (SetImage())
            {
                this.FormClosing += new FormClosingEventHandler(Form3_FormClosing);
                this.serial = 0;

                emailW = new();

                buttonsTimer.AutoReset = true;
                buttonsTimer.Elapsed += new ElapsedEventHandler(EnableButtons);
                buttonsTimer.Start();

                NOKTimer.AutoReset = true;
                NOKTimer.Elapsed += new ElapsedEventHandler(TimerP9Elapsed_NOK);

                AFKTimer.AutoReset = false;
                AFKTimer.Elapsed += new ElapsedEventHandler(AFKReturn);
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                InitializeComponent();
                this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);
                txtEtiqueta.TextChanged += txtEtiqueta_TextChanged;
                this.BtnOK.Enabled = false;
                this.Show();
                AFKTimer.Start();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Actualiza la imagen que se asigna como background del formulario
        /// </summary>
        /// <returns></returns>
        private bool SetImage()
        {
            try
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\images\" + Form1.piezaText + @"\" + Form1.piezaText + "_S" + Form1.formSlideCont + ".JPG");
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error. Revise que las imágenes de los formularios se encuentren en la carpeta correcta.");
                ReturnToHome();
                return false;
            }
            return true;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            SetButtonOkAction();
        }

        /// <summary>
        /// Controla la acción al presionarse el boton OK
        /// </summary>
        private void SetButtonOkAction()
        {
            Form1.consecutveNOKCounter = 0; //Reinicia el contador de NOKs consecutivos
            //int remainFormsTillRESCAN;
            if (Form1.formSlideCont == Form1.pasoRescaneo - 1)
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
            }
            else
            {
                if (Form1.formSlideCont == Form1.pasoRescaneo && Form1.formSlideCont == Form1.numPasos)
                {
                    if (this.txtEtiqueta.Text.Equals(Form1.etiqueta))
                    {
                        timerP9Flag = true; //Cambia a true la bandera, para evitar que se imprima la etiqueta NOK al terminar el timer
                        NOKTimer.Stop();
                        Form1.formSlideCont++;
                        HideControls();
                        textEtiqueta = this.txtEtiqueta.Text;
                        this.txtEtiqueta.Text = string.Empty;
                        Form1.conatadorPiezas++;
                        ActivateButtonTimer();
                        if (f1.completedContainer) nextWindowForm = 0;
                        else nextWindowForm = 1;
                        if (Form1.conatadorPiezas == Form1.estandar)
                        {
                            generaRegistro(textEtiqueta);
                            f1.completedContainer = true;
                            Form1.estandar = 0;
                            Form1.conatadorPiezas = 0;
                            this.Hide();
                            ReturnToContainerMenu();
                        }
                        else
                        {
                            generaRegistro(textEtiqueta);
                            this.Hide();
                            ReturnToHome();

                        }
                    }
                    else
                    {
                        this.txtEtiqueta.Focus(); //Selecciona automáticamente la caja de texto de re-escaneo de etiqueta
                        SetScrenMessage("La etiqueta no coincide.");
                        txtEtiqueta.Text = string.Empty;
                    }
                }
                else
                {
                    if (Form1.formSlideCont == Form1.numPasos)
                    {
                        Form1.consecutveNOKCounter = 0;//reinicia el contador de NOKs cada que sale una pieza con todos sus puntos OK
                        AFKTimer.Stop();
                        generaRegistro(textEtiqueta);
                        this.Hide();
                        ReturnToHome();
                    }
                    else
                    {
                        if (Form1.pasoRescaneo == Form1.formSlideCont)
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

                                if (SetImage())
                                {
                                    ActivateButtonTimer();
                                }
                            }
                            else
                            {
                                this.txtEtiqueta.Focus(); //Selecciona automáticamente la caja de texto de re-escaneo de etiqueta
                                SetScrenMessage("La etiqueta no coincide.");
                                txtEtiqueta.Text = string.Empty;
                            }
                        }
                        else
                        {
                            AFKTimer.Stop();
                            Form1.formSlideCont++;
                            if (this.txtEtiqueta.Visible)
                            {
                                this.txtEtiqueta.Visible = false;
                                this.pictureBox1.Visible = false;
                            }
                            if (SetImage())
                            {
                                ActivateButtonTimer();
                            }
                        }

                    }
                }
            }
        }

        private void ActivateButtonTimer()
        {
            SetButtonsTimerDuration();
            buttonsTimer.Start();
            this.BtnOK.Enabled = false;
            AFKTimer.Start();
        }
        /// <summary>
        /// Asigna el valor y la posición del mensaje que se 
        /// muestra en pantalla
        /// </summary>
        private void SetScrenMessage(string message)
        {
            messageLabel.Text = message;
            messageLabel.Location = new Point(txtEtiqueta.Location.X + messageLabel.Width, txtEtiqueta.Location.Y + txtEtiqueta.Height);
        }
        /// <summary>
        /// Oculta los imputs que no son utilizados en la pantalla actual
        /// </summary>
        private void HideControls()
        {
            this.txtEtiqueta.Visible = false;
            this.pictureBox1.Visible = false;
            this.messageLabel.Visible = false;
        }
        /*
            Metodo post escaneo de etiqueta este debe ejecutarse despues de que se presiona el boton ok en el paso de reescaneo, envia registro a BD y lanza la pantalla de mobisys
         */
        
        public void generaRegistro(string text)
        {
            Form1.consecutveNOKCounter = 0;//reinicia el contador de NOKs cada que sale una pieza con todos sus puntos OK
            AFKTimer.Stop();

            if (InsertaDbRecord())
            {
                //Se comento para no enviar a impresión al momento de hacer pruebas
                //callPrinter(); //Print box label
                mobisys.HideShowProcess(text);
            }
            else
            {
                ReturnToHome();
            }
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

        /// <summary>
        /// Asigna el tiempo definido para el punto de inspección correspondiente
        /// </summary>
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

        /// <summary>
        /// Habilita el boton OK despues de que se cumple el tiempo de espera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableButtons(object sender, ElapsedEventArgs e)
        {
            this.BtnOK.Enabled = true;
            buttonsTimer.Stop();
        }

        //Función que controla los eventos al pulsar el botón NOK.
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

            if (GenerateSerial())
            {
                if (InsertaDbRecord())
                {
                    if (this.serial >= 3 || Form1.consecutveNOKCounter == 3) //Si la misma etiqueta ha dado 3 NOK o si 3 piezas cualquiera seguidas dan 1 NOK cada una
                    {
                        if (!z.printOkNokLabelZPL(Form1.dpi))
                            AutoClosingMessageBox.Show("Impresion de etiqueta NOK", "Impresion de etiqueta", 1000);
                        this.blockAppClosing = true;
                        BlockApp();
                        this.Close();
                    }
                    else
                    {
                        if (!z.printOkNokLabelZPL(Form1.dpi))
                            AutoClosingMessageBox.Show("Impresion de etiqueta NOK", "Impresion de etiqueta", 1000);                     
                        emailW.SendNOKWarning();
                        ReturnToHome();
                    }
                }
                else
                {
                    ReturnToHome();
                }

            }
        }

        /*
        * Función que controla los eventos cuando se termina el timer del punto 10
        * 1. Llama al método para buscar el último serial de la pieza y le asigna uno nuevo.
        * 2. Después llama al método para guardar el registro en la Base de Datos.
        * 5. En caso de que el serial sea menor a 3, manda una notificación de NOK mediante el EmailWarner.
        */
        private void TimerP9Elapsed_NOK(object sender, EventArgs e)
        {
            if (timerP9Flag == false) //Si no se ha presionado OK
            {
                this.Hide();
                if (GenerateSerial())
                {
                    if (InsertaDbRecord())
                    {
                        if (this.serial >= 3)
                        {
                            if (!z.printOkNokLabelZPL(Form1.dpi))
                                MessageBox.Show("No se pudo generar la etiqueta de NOK");
                            BlockApp();
                            this.Close();
                        }
                        else
                        {
                            if (!z.printOkNokLabelZPL(Form1.dpi))
                                MessageBox.Show("No se pudo generar la etiqueta de NOK");
                            emailW.SendNOKWarning();
                            ReturnToHome();
                        }
                    }
                    else
                    {
                        ReturnToHome();
                    }
                }
            }
            NOKTimer.Stop();
        }

        /*
       * Función que controla los eventos cuando se termina el timer AFK (Away From Keyboard)
       * 1. Cierra este formulario
       * 2. Regresa al formulario de inicio
       */
        private void AFKReturn(object sender, EventArgs e)
        {

            this.Hide();
            AFKTimer.Stop();
            f1.ClearTextBoxes();
            this.Close(); 

        }

        /// <summary>
        /// Genera un serial para la pieza que se esta inspeccionando
        /// </summary>
        /// <returns>True si genero correctamente el serial</returns>
        private bool GenerateSerial()
        {
            this.serial = db.GenerateDBSerial(Form1.etiqueta);
            if (serial == -2)
            {
                ReturnToHome();
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Inserta en la BD el registro con el resultado de la revision de la pieza
        /// </summary>
        /// <returns> True si la pieza se inserto correctamente en la BD</returns>
        private bool InsertaDbRecord()
        {
            String queryString; 

            queryString = SetReportQueryString();
            if (db.InsertaRegInspeccion(queryString, Form1.etiqueta, this.serial, Form1.opText, Form1.idPiezaCatalog))
                return true;
            else return false;
        }

        private string SetReportQueryString()
        {
            String queryString;
            if (this.serial == 0) //Si la pieza es OK, GUARDA 11 OK'S
            {
                queryString = "INSERT INTO Operador_Pieza VALUES(@numEtiqueta, @serial, @numOperador, @idPieza, @fecha";

                for (int i = 0; i < Form1.numPasos; i++)
                {
                    queryString += ",'OK' ";
                }
                for (int i = Form1.numPasos; i < 11; i++) queryString += ", NULL";
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
            return queryString;
        }

        /*
         * Método para regresar al formulario de inicio e iniciar el timer del formulario inicial.
         * Hecha para evitar repetición de líneas de código.
         * También previene que cualquier conexión con la base de datos se quede abierta.
         */
        private void ReturnToHome()
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            Application.OpenForms["Form1"].Show();
            this.f1.StartForeignTimer();
            this.Close();
        }

        //Metodo cuando para regresar a menu escaneo de Container cuando se completa el contenido de un Container
        private void ReturnToContainerMenu()
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            //f1.Close();

            Application.OpenForms["ContainerIdForm"].Show();
            //f1.StartForeignTimer();
            this.Close();
        }

        // Método de llamado impresión de etiqueta de caja
        private void callPrinter()
        {
            ZebraLinker ZBLinker = new(Form1.printerIP);
            ZBLinker.PrintBoxLabelZPL(Form1.etiqueta, Form1.descripcion, "83", Form1.dpi);
        }

        /// <summary>
        /// Bloquea la aplicación y envia por mail el código de desbloqueo cuando se rechaza 3 veces una pieza
        /// </summary>
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

        // Método para manejar el cerrado de la aplicación incompleto
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.blockAppClosing == false)
            {
                if (Form1.formSlideCont == Form1.pasoRescaneo) //Si se cierra el programa incorrectamente en el punto de reingreso de etiqueta. Para que no lo guarde como NOK necesariamente
                {
                    NOKTimer.Stop();
                }
                if (Application.OpenForms["Form1"].Visible == false && Form1.estandar != Form1.conatadorPiezas && !waitScanFlag)
                    Application.OpenForms["Form1"].Visible = true;
                f1.StartForeignTimer();
            }

        }
    }
}
