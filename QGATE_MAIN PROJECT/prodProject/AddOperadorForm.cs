using System.Data.SqlClient;


namespace prodProject
{
    public partial class AddOperadorForm : Form
    {
        AdminForm prevForm;
        DatabaseConnector db = new DatabaseConnector();
        Operador op = new Operador();

        /// <summary>
        /// Constructor de la clase, inicializa las vistas del formulario
        /// </summary>
        /// <param name="af">Instancia del formulario anterior </param>
        public AddOperadorForm(AdminForm af)
        {
            this.prevForm = af;
            this.FormClosing += new FormClosingEventHandler(AddOperador_FormClosing);
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }


        private void BtnAddOperator_Click(object sender, EventArgs e)
        {
            if (NotNullTxtBoxData())
            {
                SetDatosOperador();
                db.InsertaOperador(op);
                ClearInputs();
            }
        }

        /// <summary>
        /// Asigna datos introducidos por usuario a instancia de clase operador
        /// </summary>
        private void SetDatosOperador()
        {
            op.numOperador = NumOpTxtBox.Text;
            op.nombre = NameOpTxtBox.Text;
            op.apellido = SurnameOpTxtBox.Text;
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        /// <summary>
        /// Cierra el formulario actual y muestra el previo
        /// </summary>
        private void ReturnToPreviousForm()
        {
            prevForm.Show();
            this.Hide();
            this.Close();
        }

        /// <summary>
        /// Limpia los inputs de datos de usuario
        /// </summary>
        private void ClearInputs()
        {
            NumOpTxtBox.Clear();
            NameOpTxtBox.Clear();
            SurnameOpTxtBox.Clear();
        }

        /// <summary>
        /// Valida que los campos de datos hayan sido llenados correctamente
        /// </summary>
        /// <returns>True si los datos ingresados son validos</returns>
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (String.IsNullOrEmpty(NumOpTxtBox.Text) || String.IsNullOrEmpty(NameOpTxtBox.Text)  || String.IsNullOrEmpty(SurnameOpTxtBox.Text))
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

        /// <summary>
        /// Muestra el formulario anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOperador_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }


        private void AddOperadorForm_Load(object sender, EventArgs e)
        {
        }
    }
}