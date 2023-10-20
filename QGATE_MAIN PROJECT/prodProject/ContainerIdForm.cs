using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prodProject
{
    public partial class ContainerIdForm : Form
    {

        private List<string> containersId = new List<string>();
        ProcessManipulation processes = new ProcessManipulation();
        public ContainerIdForm()
        {
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            InitializeComponent();
            //Process.Start("C:\\Program Files (x86)\\Mobisys GmbH\\Mobisys MSB Client\\MobisysClient100.exe");
            ExecuteAsAdmin("C:\\Program Files (x86)\\Mobisys GmbH\\Mobisys MSB Client\\MobisysClient100.exe");
        }

        private void btnContainer_Click(object sender, EventArgs e)
        {
            CheckContainerId();
        }

        private void CheckContainerId()
        {
            //Verificar que pasaría si la etiqueta que se introdujo es una etiqueta que ya se introdujo anteriormente o si es una etiqueta mala, no debe permitir continua qgate
            bool flagSuperposicion = false;
            if (containerTxtBox.Text != String.Empty)
            {
                if (containersId.Contains(containerTxtBox.Text))
                    setMessageLabel("Esta etiqueta ya fue escaneada");
                else
                {
                    flagSuperposicion = processes.AddToMobisys(containerTxtBox.Text);
                    if (flagSuperposicion)
                        ShowWaitScan(2);
                    else MessageBox.Show("No se encontró la ventana de mobysis");


                }

            }
            else setMessageLabel("Se debe introducir la etiqueta de contenedor");



        }
        private void StartForms()
        {
            Form1 f1 = new(this);
            this.Hide();
            f1.StartForeignTimer();

        }

        private void setMessageLabel(string message)
        {
            containerIdMessage.Text = message;
            containerIdMessage.Location = new Point(ClientSize.Width / 2 - containerIdMessage.Width / 2, ClientSize.Height / 2 - 25);
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
            wmenu.Show();
            //this.Close();
            //f1.StartForeignTimer();

        }
        public void ExecuteAsAdmin(string fileName)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
