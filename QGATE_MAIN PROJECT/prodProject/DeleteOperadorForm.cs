
using System.Data.SqlClient;


namespace prodProject
{
    public partial class DeleteOperadorForm : Form
    {
        AdminForm prevForm;
        DatabaseConnector db = new DatabaseConnector();
        /*
         * ---------------------------------------------------------------------------------------------------------------------------------
         * Constructor del formulario
         * ---------------------------------------------------------------------------------------------------------------------------------
         */
        public DeleteOperadorForm(AdminForm af)
        {
            this.prevForm = af;
            this.FormClosing += new FormClosingEventHandler(DeleteOperador_FormClosing);
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función llamada al hacer click sobre el botón de eliminar. 
         * Hace un Pop-Up de un cuadro de advertencia y si el usuario acepta, llama a la función para eliminar el registro
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (NotNullTxtBoxData())
            {
                DialogResult dialog = MessageBox.Show("¿Está seguro que desea eliminar PERMANENTEMENTE el registro de la Base de Datos?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    db.EliminaOperador(numOpTxtBox.Text);
                    numOpTxtBox.Clear();
                }
            }

        }
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función llamada al hacer click sobre el botón de retorno
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para volver al formulario anterior y cerrar el formulario actual
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void ReturnToPreviousForm()
        {
            this.Hide();
            prevForm.Show();
            this.Close();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         *  Función para revisar que la información de la text box no contengan valores nulos o vacíos.
         *  Retorna true si contiene texto.
         *  --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (String.IsNullOrEmpty(numOpTxtBox.Text) )
                    throw new ArgumentNullException();
                else
                    return true;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Ingrese todos los datos");
                return false;
            }
        }

        /*
           * --------------------------------------------------------------------------------------------------------------------------------
           * Método para manejar el cerrado de la aplicación incorrecto
           * --------------------------------------------------------------------------------------------------------------------------------
       */
        private void DeleteOperador_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void DeleteOperadorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
