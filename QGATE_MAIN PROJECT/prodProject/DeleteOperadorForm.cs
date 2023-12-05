
using System.Data.SqlClient;


namespace prodProject
{
    public partial class DeleteOperadorForm : Form
    {
        AdminForm prevForm;
        DatabaseConnector db = new DatabaseConnector();

        public DeleteOperadorForm(AdminForm af)
        {
            this.prevForm = af;
            this.FormClosing += new FormClosingEventHandler(DeleteOperador_FormClosing);
            InitializeComponent();
        }


        /// <summary>
        /// Controla evento de boton eliminar operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        /// <summary>
        /// Cierra el formulario actual y abre el formulario padre
        /// </summary>
        private void ReturnToPreviousForm()
        {
            this.Hide();
            prevForm.Show();
            this.Close();
        }

        /// <summary>
        /// Verifica que se introduzcan los datos solicitados
        /// </summary>
        /// <returns></returns>
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (String.IsNullOrEmpty(numOpTxtBox.Text))
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

        /// <summary>
        /// Muestra el formulario padre en caso de que este se cierre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteOperador_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void DeleteOperadorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
