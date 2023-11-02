using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace prodProject
{
    public partial class ContainerIdForm : Form, IComponent
    {

        private List<string> containersId = new List<string>();
        ProcessManipulation processes = new ProcessManipulation();
        private static System.Timers.Timer timer;
        int estandarContainer { get; }
        public static int Estandar = 4;

        public ContainerIdForm()
        {
            Thread runMobi = new Thread(new ThreadStart(RunMobisys));
            //runMobi.Start();
            //RunMobisys();
            InitializeComponent();
            estandarLabel.Text = "México";
            containerIdMessage.Anchor = AnchorStyles.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            timer = new System.Timers.Timer(24 * 60 * 60 * 1000);
            timer.Elapsed += BorrarLista;
            timer.Start();

        }

        private void btnContainer_Click(object sender, EventArgs e)
        {
            CheckContainerId();
        }

        private void CheckContainerId()
        {
            //Verificar que pasaría si la etiqueta que se introdujo es una etiqueta que ya se introdujo anteriormente o si es una etiqueta mala, no debe permitir continua qgate
            bool flagSuperposicion = false;
            int mobisysId = 0;
            if (containerTxtBox.Text != String.Empty)
            {
                if (containersId.Contains(containerTxtBox.Text))
                    setMessageLabel("Esta etiqueta ya fue escaneada");
                else
                {
                    containersId.Add(containerTxtBox.Text);
                    //Estandar = SetEstandarCount(comboBoxEstandar.SelectedIndex);
                    SetEstandarLable(Estandar);
                    //flagSuperposicion = processes.AddToMobisys(containerTxtBox.Text);
                    mobisysId = processes.GetProcessID(processes.porcName);
                    if (mobisysId > 0)
                    {
                        flagSuperposicion = processes.HideShowProcess(containerTxtBox.Text);


                        containerTxtBox.Text = "";
                        if (flagSuperposicion)
                            StartFormRevision();
                        else MessageBox.Show("No se pudo ingresar los datos en Mobisys");
                    }
                    else
                    {
                        if (containersId.Count > 0)
                            containersId.RemoveAt(containersId.Count - 1);
                        MessageBox.Show("No se encontro la ventana de mobisys, verifica que se encuentre abierta la aplicación");
                    }

                }

            }
            else setMessageLabel("Se deben introducir todos los datos");



        }

        private void SetEstandarLable(int estandar)
        {
            switch (estandar) { 
                case 4:
                estandarLabel.Text = "México";
                break;
            case 35:
                estandarLabel.Text = "China";
                break;
            }
        }

        private void StartFormRevision()
        {
            Form1 f1 = new(this);
            this.Hide();
            f1.StartForeignTimer();

        }
        private void StartForms()
        {
            Form1 f1 = new(this);
            this.Hide();
            f1.StartForeignTimer();

        }
        /// <summary>
        /// Devuelve el número de piesas por container id para el pais seleccionado
        /// </summary>
        /// <param name="idCountry"> Indice que corresponde al pais seleccionado en estandar</param>
        public int SetEstandarCount(int idCountry)
        {
            int piezasContainer = 0;
            switch (idCountry)
            {
                //Índice 0 corresponde a México
                case 0:
                    piezasContainer = 4;
                    break;
                //Índice 1 corresponde a China
                case 1:
                    piezasContainer = 35;
                    break;
            }
            return piezasContainer;
        }

        private void setMessageLabel(string message)
        {
            containerIdMessage.Text = message;
            containerIdMessage.Location = new Point(ClientSize.Width / 2 - containerIdMessage.Width / 2, ClientSize.Height / 2 + 40);
        }
        private void ContainerIdForm_Load(object sender, EventArgs e)
        {
        }

        private void containerTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ShowWaitScan(int nextWindow)
        {
            containerTxtBox.Clear();
            this.Hide();
            WinScanForm wmenu = new WinScanForm(nextWindow);
            wmenu.estandarContainer = Estandar;
            wmenu.Show();
            //this.Close();
            //f1.StartForeignTimer();

        }
        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.Arguments = "";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            Thread.Sleep(1000);
        }

        public void RunMobisys()
        {
            ExecuteAsAdmin("C:\\Program Files (x86)\\Mobisys GmbH\\Mobisys MSB Client\\MobisysClient100.exe");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEstandar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearList(object state)
        {
            // Vaciar la lista
            containersId.Clear();
            Console.WriteLine("Lista vaciada después de un día.");
        }

        private void BorrarLista(object sender, ElapsedEventArgs e)
        {
            // Borra la lista
            containersId.Clear();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            AdminLogin LoginForm = new();
            //LoginForm.contrato = this;
            this.Hide();
            LoginForm.Show();
        }
    }
}
