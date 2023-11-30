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

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para validar el login de Administrador. 
         * Recibe un evento invocado al momento que es presionado el botón.
         * Compara el texto ingresado con el usuario y contraseñas guardados.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
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

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de retorno
         * --------------------------------------------------------------------------------------------------------------------------------
         */
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

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de retorno
         * Retorna al usuario a la pantalla de inicio y cierra el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void ReturnHome()
        {
            Application.OpenForms["ContainerIdForm"].Show();
            this.Hide();
            this.Close();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método para manejar el cerrado de la aplicación incorrecto
         * --------------------------------------------------------------------------------------------------------------------------------
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
