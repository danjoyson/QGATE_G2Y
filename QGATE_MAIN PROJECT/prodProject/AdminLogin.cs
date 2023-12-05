using System;

namespace prodProject
{
    public partial class AdminLogin : Form
    {
        private bool correctExitFlag = false;

        public AdminLogin()
        {
            this.FormClosing += new FormClosingEventHandler(AdminLogin_FormClosing);
            InitializeComponent();
        }

        /// <summary>
        /// Valida el login de Administrador. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (userTxtBox.Text.Equals("ADMIN") && passwordTxtBox.Text.Equals("QGATEADMIN123"))
            {
                correctExitFlag = true;
                NextForm();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos.");
            }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnHome();
        }

        private void NextForm()
        {
            AdminForm AF = new();
            AF.Show();
            this.Close();
        }

        /// <summary>
        /// Retorna al usuario a la pantalla de inicio y cierra el formulario actual.
        /// </summary>
        private void ReturnHome()
        {
            Application.OpenForms["ContainerIdForm"].Show();
            this.Hide();
            this.Close();
        }

        /*
         * Método para manejar el cerrado de la aplicación incorrecto
         */
        private void AdminLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (correctExitFlag == false)
                Application.OpenForms["ContainerIdForm"].Show();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
