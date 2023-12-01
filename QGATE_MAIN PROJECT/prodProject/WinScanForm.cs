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
    public partial class WinScanForm : Form
    {
        private Form1 f1;
        ProcessManipulation mobiProcess = new ProcessManipulation();
        private string mobisysProcessName = "MobisysClient100"; //Variable nombre de proceso que debe ser superpuesto al completar una revision de pieza
        private System.Windows.Forms.Timer scanMobisysTimer = new System.Windows.Forms.Timer();
        int windowCase = -1;
        public int estandarContainer = -1;
        public WinScanForm(Form1 f1, int nextWindow)
        {
            this.f1 = f1;
            windowCase = nextWindow;
            scanMobisysTimer.Interval = 60000;
            InitializeComponent();
        }

        public WinScanForm(int nextWindow)
        {
            windowCase = nextWindow;
            scanMobisysTimer.Interval = 60000;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        //Boton para volver a superponer la pantalla para el reescaneo de la pieza si aun no se escanea
        private void button2_Click(object sender, EventArgs e)
        {
            mobiProcess.AddToMobisys(mobisysProcessName);
            scanMobisysTimer.Enabled = true;
            scanMobisysTimer.Tick += new System.EventHandler(OnTimerScanEvent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Vuelve a la pantalla de escaneo de pieza, significa que el usuario ya ingreso la pieza en mobisys correctamente
            scanMobisysTimer.Stop();
            switch (windowCase)
            {
                case 0:
                    f1.completedContainer = false;
                    ReturnToContainerMenu();
                    break;
                case 1:
                    ReturnToHome();
                    break;
                case 2:
                    StartFormRevision();
                    break;

            }

        }

        private void WinScanForm_Load(object sender, EventArgs e)
        {

        }

        private void OnTimerScanEvent(object source, EventArgs e)
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            Application.OpenForms["WaitScanForm"].Show();
            this.Close();
        }
        /// <summary>
        /// Cierra el formulario actual y abre el formulario de escaneo de pieza
        /// </summary>
        private void ReturnToHome()
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            Application.OpenForms["Form1"].Show();
            f1.StartForeignTimer();
            this.Close();
        }

        /// <summary>
        /// Cierra el formulario actual y muestra el de escaneo de container ID
        /// </summary>
        private void ReturnToContainerMenu()
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            Application.OpenForms["ContainerIdForm"].Show();
            this.Close();
        }

        private void StartFormRevision()
        {


        }
    }
}
