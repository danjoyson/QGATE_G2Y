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
    public partial class SimplePrinterForm : Form
    {
        AdminForm prevForm;


        //Constructor del formulario
        public SimplePrinterForm(AdminForm prevForm)
        {
            this.prevForm = prevForm;
            this.FormClosing += new FormClosingEventHandler(SimplePrinter_FormClosing);
            InitializeComponent();
        }

        /// <summary>
        /// Imprime una etiqueta de prueba
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintTest_Click(object sender, EventArgs e)
        {
            ZebraLinker zl = new(Form1.printerIP);
            zl.PrintTest(Form1.dpi);
        }

        /// <summary>
        /// Re imprime la ultima etiqueta de caja generada por el sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintLastLabel_Click(object sender, EventArgs e)
        {
            if (Form1.lastZPLCommand == null || Form1.lastZPLCommand == string.Empty)
            {
                this.label1.Visible = true;
            }
            else
            {
                ZebraLinker z = new(Form1.printerIP);
                z.ReprintLabel(Form1.lastZPLCommand);
            }
        }

        /// <summary>
        /// Cierra el menú actual y vuelve al menu anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            prevForm.Show();
            this.Close();
        }

        /// <summary>
        /// Abre el formulario anterior en caso de haber forzado el cierre
        /// de la ventana actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimplePrinter_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }



        private void SimplePrinterForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cierra la ventana actual y abre el menu de impresión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            PrintConfForm nextForm = new(this);
            nextForm.Show();
            this.Hide();
        }
    }
}
