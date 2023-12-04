
using System.Data.SqlClient;


namespace prodProject
{
    public partial class DeletePiezaForm : Form
    {
        AdminForm prevForm;
        DatabaseConnector db = new DatabaseConnector();
        Document doc = new Document();
        public DeletePiezaForm(AdminForm af)
        {
            this.prevForm = af;
            this.FormClosing += new FormClosingEventHandler(DeletePieza_FormClosing);
            InitializeComponent();
        }


        private void BtnDeletePieza_Click(object sender, EventArgs e)
        {
            EliminaPieza();
        }

        /// <summary>
        /// Elimina la pieza especificada de la BD y borra la carpeta de imágenes
        /// </summary>
        private void EliminaPieza()
        {
            if (NotNullTxtBoxData())
            {
                DialogResult dialog = MessageBox.Show("¿Está seguro que desea eliminar PERMANENTEMENTE el registro de la Base de Datos?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    db.EliminaPieza(claveTxtBox.Text);
                    doc.DeleteFolder(claveTxtBox.Text.Substring(2, 7));
                    claveTxtBox.Clear();
                }
            }
        }

        /// <summary>
        /// Verifica que exista texto en las entradas de datos
        /// </summary>
        /// <returns></returns>
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (String.IsNullOrEmpty(claveTxtBox.Text))
                    throw new ArgumentNullException();
                if (claveTxtBox.Text.Length != 11)
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

        /// <summary>
        /// Método para manejar el cerrado de la aplicación incompleto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contiene la información del evento de cerrado de Formulario</param>
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
