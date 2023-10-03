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

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Constructor del formulario
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public SimplePrinterForm(AdminForm prevForm)
        {
            this.prevForm = prevForm;
            this.FormClosing += new FormClosingEventHandler(SimplePrinter_FormClosing);
            InitializeComponent();

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Botón para imprimir una etiqueta de prueba
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnPrintTest_Click(object sender, EventArgs e)
        {
            ZebraLinker zl = new(Form1.printerIP);
            zl.PrintTest(Form1.dpi);
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Botón para reimprimir la última etiqueta impresa
         * --------------------------------------------------------------------------------------------------------------------------------
         */
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

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Botón de retorno al formulario inicial
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            prevForm.Show();
            this.Close();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método para manejar el cerrado de la aplicación incompleto.
         * Si se cierra el formulario, se retorna al usuario al formulario anterior.
         * --------------------------------------------------------------------------------------------------------------------------------
        */
        private void SimplePrinter_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }



        private void SimplePrinterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
