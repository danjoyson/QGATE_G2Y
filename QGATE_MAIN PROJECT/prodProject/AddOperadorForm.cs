using System.Data.SqlClient;


namespace prodProject
{
    public partial class AddOperadorForm : Form
    {
        AdminForm prevForm;
        DatabaseConnector db = new DatabaseConnector();
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Constructor del formulario de Alta de operador
         * Recibe el formulario previo (AdminForm) y asigna una función de manejo de cierre del formulario.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public AddOperadorForm(AdminForm af)
        {
            this.prevForm = af;
            this.FormClosing += new FormClosingEventHandler(AddOperador_FormClosing);
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón "Agregar".
         * 1. Revisa que las cajas de texto no contengan texto vacío.
         * 2. Llama al método para insertar el registro en la base de datos.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnAddOperator_Click(object sender, EventArgs e)
        {
            if (NotNullTxtBoxData())
            {
                db.InsertaOperador(NumOpTxtBox.Text, NameOpTxtBox.Text, SurnameOpTxtBox.Text);
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de retorno.
         * 1. Regresa al usuario al formulario anterior.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        private void ReturnToPreviousForm()
        {
            prevForm.Show();
            this.Hide();
            this.Close();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         *  Método para revisar que las cajas de texto no contengan valores nulos o vacíos.
         *  
         *  Retorna true si contienen texto.
         *  Retorna false si hay contenido nulo en cualquiera de las dos y lanza un mensaje de error en pantalla.
         *  --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (NumOpTxtBox.Text == string.Empty || NameOpTxtBox.Text == string.Empty || SurnameOpTxtBox.Text == string.Empty)
                    throw new ArgumentNullException();
                else
                    return true;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Ingrese todos los datos");
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Formato no válido. " + e.Message);
                return false;
            }
        }
        /*
           * --------------------------------------------------------------------------------------------------------------------------------
           * Método para manejar el cerrado de la aplicación incompleto
           * --------------------------------------------------------------------------------------------------------------------------------
       */
        private void AddOperador_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }


        private void AddOperadorForm_Load(object sender, EventArgs e)
        {
        }
    }
}