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
        bool windowCase;
        public WinScanForm(Form1 f1,bool nextWindow)
        {
            this.f1 = f1;
            windowCase = nextWindow;
            scanMobisysTimer.Interval = 60000;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton para volver a superponer la pantalla para el reescaneo de la pieza si aun no se escanea
            //superpose window
            mobiProcess.AddToMobisys(mobisysProcessName);
            scanMobisysTimer.Enabled = true;
            scanMobisysTimer.Tick += new System.EventHandler(OnTimerScanEvent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Vuelve a la pantalla de escaneo de pieza, significa que el usuario ya ingreso la pieza en mobisys correctamente
            if (windowCase) 
            {
                f1.completedContainer = false;
                //f1.estandar = 0;
                ReturnToContainerMenu();
                
            }
            else ReturnToHome();

        }

        private void WinScanForm_Load(object sender, EventArgs e)
        {

        }

        private void OnTimerScanEvent(object source, EventArgs e)
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            //f1.Close();

            Application.OpenForms["WaitScanForm"].Show();
            //f1.StartForeignTimer();
            this.Close();
        }
        private void ReturnToHome()
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            Application.OpenForms["Form1"].Show();
            f1.StartForeignTimer();
            this.Close();
        }

        private void ReturnToContainerMenu()
        {
            if (Form1.conn.State == ConnectionState.Open)
                Form1.conn.Close();
            //f1.Close();

            Application.OpenForms["ContainerIdForm"].Show();
            //f1.StartForeignTimer();
            this.Close();
        }
    }
}
