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
    public partial class ContainerIdForm : Form
    {

        private List<string> containersId = new List<string>();
        public ContainerIdForm()
        {
            InitializeComponent();
        }

        private void btnContainer_Click(object sender, EventArgs e)
        {
            CheckContainerId();
        }

        private void CheckContainerId()
        {
            //Verificar que pasaría si la etiqueta que se introdujo es una etiqueta que ya se introdujo anteriormente o si es una etiqueta mala, no debe permitir continua qgate
            if (containerTxtBox.Text != String.Empty)
            {
                if (containersId.Contains(containerTxtBox.Text))
                {
                    containerIdMessage.Text = "Esta etiqueta ya fue escaneada";
                    containerIdMessage.Location = new Point(containerTxtBox.Width / 2 - containerIdMessage.Width / 2, 311);
                }
                else StartForms();
            }
            else MessageBox.Show("Se debe introducir la etiqueta de contenedor");

        }
        private void StartForms()
        {
            Form1 f1 = new(this);
            this.Hide();
            f1.StartForeignTimer();

        }

        private void ContainerIdForm_Load(object sender, EventArgs e)
        {

        }

        private void containerTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
