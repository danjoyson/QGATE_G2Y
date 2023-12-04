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

        /// <summary>
        /// Cosntructor de la clase form4 
        /// </summary>
        /// <param name="unblockCode"></param>
        /// <param name="f1"></param>
        public Form4_Blocker(string unblockCode, Form1 f1)
        {
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

        /// <summary>
        /// Controla el evento del boton desbloquear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            }
        }

        /// <summary>
        ///  Reenvía el email con el código de bloqueo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
