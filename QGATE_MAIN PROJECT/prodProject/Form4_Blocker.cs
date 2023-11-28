using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prodProject
{
    public partial class Form4_Blocker : Form
    {
        private string unblockCode;
        private Form1 f1;
        private System.Timers.Timer t = new(10000); //timer para evitar el spameo del boton de reenviar codigo
        private EmailWarner emailW;

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Constructor del formulario, se le asigna el string con el código de desbloqueo. 
         * Y recibe el una instancia del Form1 para poder reiniciar el timer AFK del inicio.
         * 
         * Se asigna las credenciales del correo emisor de notificaciones ---> Podría leerlos desde algún archivo de texto
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public Form4_Blocker(string unblockCode, Form1 f1)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.unblockCode = unblockCode;
            emailW = new();
            Shown += ConfigTimer;
            this.f1 = f1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Blocker_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función llamada al hacer click sobre el botón de desbloquear.
         * 1. Si los campos están vacíos, suelta un mensaje de notificación.
         * 2. Si el código es incorrecto, muestra un mensaje de error.
         * 3. Si el código de desbloqueo es correcto, devuelve al usuario al formulario de inicio.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnUnblock_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(this.unblockCode))
            {
                messageLabel.Text = ""; //limpia el texto
                Application.OpenForms["Form1"].Show();
                f1.StartForeignTimer();
                this.Close();
            }
            else
            {
                messageLabel.Text = "Código incorrecto";
                messageLabel.Location = new Point(textBox1.Location.X + messageLabel.Width / 4, 560);
                //ClientSize.Width / 2 - messageLabel.Width / 2
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función llamada al hacer click sobre el botón de reenviar.
         * 1. Reenvía el email con el código de bloqueo.
         * 2. Reinicia el timer para prevenir el spam del botón.
         * 3. Bloquea el botón de reenvío.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnReSend_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            emailW.SendBlockedWarning(this.unblockCode);
            Cursor.Current = Cursors.Default;
            t.Start();
            messageLabel.Text = "Código reenviado";
            messageLabel.Location = new Point(textBox1.Location.X + messageLabel.Width / 4, 560);
            BtnReSend.Enabled = false;
        }

        /// <summary>
        /// Define las acciones del timer del boton 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigTimer(Object sender, EventArgs e)
        {
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(EnableBtn);
        }

        /// <summary>
        /// Habilita el boton para enviar nuevamente el código de desbloqueo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EnableBtn(object sender, System.Timers.ElapsedEventArgs e)
        {
            BtnReSend.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
