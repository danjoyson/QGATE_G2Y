using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prodProject
{
    public partial class ContainerIdForm : Form
    {

        private List<string> containersId = new List<string>();
        ProcessManipulation processes = new ProcessManipulation();
        public int Estandar = 0;
        public ContainerIdForm()
        {

            ExecuteAsAdmin("C:\\Program Files (x86)\\Mobisys GmbH\\Mobisys MSB Client\\MobisysClient100.exe");
            InitializeComponent();
            containerIdMessage.Anchor = AnchorStyles.None;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;


        }

        private void btnContainer_Click(object sender, EventArgs e)
        {
            CheckContainerId();
        }

        private void CheckContainerId()
        {
            //Verificar que pasaría si la etiqueta que se introdujo es una etiqueta que ya se introdujo anteriormente o si es una etiqueta mala, no debe permitir continua qgate
            bool flagSuperposicion = false;

            if (containerTxtBox.Text != String.Empty && comboBoxEstandar.SelectedIndex != -1)
            {
                if (containersId.Contains(containerTxtBox.Text))
                    setMessageLabel("Esta etiqueta ya fue escaneada");
                else
                {
                    Estandar = SetEstandarCount(comboBoxEstandar.SelectedIndex);
                    flagSuperposicion = processes.AddToMobisys(containerTxtBox.Text);
                    if (flagSuperposicion)
                        ShowWaitScan(2);
                    else MessageBox.Show("No se encontró la ventana de mobysis");


                }

            }
            else setMessageLabel("Se deben introducir todos los datos");



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
        private int SetEstandarCount(int idCountry)
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
                    piezasContainer = 23;
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
            SecureString pass = SetPass();
            Process proc = new Process();
            proc.StartInfo.FileName = fileName;
            proc.StartInfo.Domain = "";
            proc.StartInfo.UseShellExecute = false;
            //proc.StartInfo.UserName = "qmx-administrator";
            //proc.StartInfo.Password = pass;
            //proc.StartInfo.RedirectStandardError = true;
            //proc.StartInfo.RedirectStandardOutput = true;
            //proc.StartInfo.Verb = "runas";
            //proc.Start();
            Thread.Sleep(1000);
        }

        private SecureString SetPass()
        {
            var pass = new SecureString();
            pass.AppendChar('m');
            pass.AppendChar('X');
            pass.AppendChar('m');
            pass.AppendChar('D');
            pass.AppendChar('C');
            pass.AppendChar('0');
            pass.AppendChar('1');
            pass.AppendChar('\\');
            pass.AppendChar('=');
            pass.AppendChar('Q');
            pass.AppendChar('#');
            pass.AppendChar('M');
            pass.AppendChar('#');
            pass.AppendChar('X');
            String plainStr = new System.Net.NetworkCredential(string.Empty, pass).Password;
            return pass;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEstandar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
