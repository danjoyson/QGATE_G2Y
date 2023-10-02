
using System.Data.SqlClient;


namespace prodProject
{
    public partial class DeleteOperadorForm : Form
    {
        AdminForm prevForm;

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
                    DeleteRegisterFromDB();
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
         * Función de borrado de registro de la Base de Datos
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void DeleteRegisterFromDB()
        {
            try
            {
                Form1.conn.Open();

                string query = "DELETE FROM Operador WHERE numOperador = @value;";

                SqlCommand cmd = new SqlCommand(query, Form1.conn);
                cmd.Parameters.Add(new SqlParameter("@value", numOpTxtBox.Text));
                cmd.ExecuteNonQuery();
                Form1.conn.Close();
                MessageBox.Show("Registro eliminado exitosamente");
            }
            catch (Exception ex)
            {
                Form1.conn.Close();
                MessageBox.Show("Ocurrió un error al tratar de eliminar el registro: " + ex.Message);
            }
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
                if (numOpTxtBox.Text == string.Empty)
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
