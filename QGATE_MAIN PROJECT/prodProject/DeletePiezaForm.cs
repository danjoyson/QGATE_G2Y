
using System.Data.SqlClient;


namespace prodProject
{
    public partial class DeletePiezaForm : Form
    {
        AdminForm prevForm;
        DatabaseConnector db = new DatabaseConnector();
        public DeletePiezaForm(AdminForm af)
        {
            this.prevForm = af;
            this.FormClosing += new FormClosingEventHandler(DeletePieza_FormClosing);
            InitializeComponent();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al presionar el botón de eliminar
         * 1. Llama al método para revisar que no haya texto vacío en las cajas de texto.
         * 2. Muestra un mensaje de advertencia.
         * 3. Si se presiona el botón "Yes", llama al método de borrado del registro de la base de datos.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnDeletePieza_Click(object sender, EventArgs e)
        {
            if (NotNullTxtBoxData())
            {
                DialogResult dialog = MessageBox.Show("¿Está seguro que desea eliminar PERMANENTEMENTE el registro de la Base de Datos?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    db.EliminaPieza(claveTxtBox.Text);
                }
            }
        }
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         *  Función para revisar que la información de la text box no contengan valores nulos o vacíos.
         *  También revisa que la longitud del número de parte sea el adecuado, en caso contario mostrará un mensaje de error.
         *  Retorna true si contiene texto.
         *  --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (claveTxtBox.Text == string.Empty)
                    throw new ArgumentNullException();
                if (claveTxtBox.Text.Length != 15)
                    throw new ArgumentException();
                return true;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Ingrese todos los datos");
                return false;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Formato de clave incorrecto");
                return false;
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
         * Función llamada al presionar el botón de retorno
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        /*
           * --------------------------------------------------------------------------------------------------------------------------------
           * Método para manejar el cerrado de la aplicación incompleto
           * --------------------------------------------------------------------------------------------------------------------------------
       */
        private void DeletePieza_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void DeletePiezaForm_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        { 
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void claveTxtBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
