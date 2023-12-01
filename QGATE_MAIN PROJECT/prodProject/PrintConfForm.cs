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
    public partial class PrintConfForm : Form
    {
        Printer p = new Printer();
        SimplePrinterForm printerMenu;
        public PrintConfForm(SimplePrinterForm s)
        {
            printerMenu = s;
            InitializeComponent();
            ShowConfig();
            configMenu.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Borra los datos ingresados por los usuarios en los textbox
        /// </summary>
        private void clearInputs()
        {
            ipTextbox.Clear();
            dpiTxtbx.Clear();
            etiquetaTxtbx.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearInputs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkInputs())
            {
                p.SaveConfig();
                ShowConfig();
                clearInputs();
                configMenu.Visible = false;
            }
        }

        /// <summary>
        /// Verifica que se agreguen todos los datos de configuración y los asigna 
        /// en la instancia de clase
        /// </summary>
        /// <returns>True si se asignaron los valores</returns>
        private bool checkInputs()
        {
            if (ipTextbox.Text != string.Empty && dpiTxtbx.Text != string.Empty && etiquetaTxtbx.Text != string.Empty)
            {
                p.IP = ipTextbox.Text;
                p.DPI = Convert.ToInt16(dpiTxtbx.Text);
                p.text = etiquetaTxtbx.Text;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Actualiza los datos de configuración que se muestran en pantalla
        /// </summary>
        private void ShowConfig()
        {
            Printer? currentConf = new Printer();
            currentConf = p.GetConfig();
            if (currentConf != null)
            {
                currIpLabel.Location = new Point(label2.Location.X + 90, label2.Location.Y);
                currIpLabel.ForeColor = Color.Red;
                currIpLabel.Text = currentConf.IP;
                currDpiLabel.Location = new Point(label3.Location.X + 90, label3.Location.Y);
                currDpiLabel.ForeColor = Color.Red;
                currDpiLabel.Text = currentConf.DPI.ToString();
                currLabTxt.Location = new Point((label7.Location.X + 190), label7.Location.Y);
                currLabTxt.ForeColor = Color.Red;
                currLabTxt.Text = currentConf.text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            configMenu.Visible = true;
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnToMenu();
        }

        /// <summary>
        /// Cierra el formulario actual y vuelve al menu  de impresió´n
        /// </summary>
        private void ReturnToMenu()
        {
            this.Hide();
            printerMenu.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
