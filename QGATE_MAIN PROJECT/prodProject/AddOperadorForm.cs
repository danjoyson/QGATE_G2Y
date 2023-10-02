using System.Data.SqlClient;


namespace prodProject
{
    public partial class AddOperadorForm : Form
    {
        AdminForm prevForm;

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
                InsertDbRecord();
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
         *  Función de conexión al servidor de SQL y query DML INSERT INTO para ingresar un registro nuevo a la tabla Operador
         *  Recibe el dmlStatement: INSERT INTO
         *  1. Se conecta a la Base de Datos y envía la consulta de inserción formada de forma parametrizada.
         *  2. En caso de alguna excepción, muestra un mensaje en pantalla.
         *  --------------------------------------------------------------------------------------------------------------------------------
         */
        private void InsertDbRecord()
        {
            try
            {
                try
                {
                    Form1.conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                string query = "INSERT INTO Operador VALUES(@numOperador, @nombre, @apellido);";

                SqlCommand cmd = new SqlCommand(query, Form1.conn);
                cmd.Parameters.Add(new SqlParameter("@numOperador", NumOpTxtBox.Text));
                cmd.Parameters.Add(new SqlParameter("@nombre", NameOpTxtBox.Text));
                cmd.Parameters.Add(new SqlParameter("@apellido", SurnameOpTxtBox.Text));
                cmd.ExecuteNonQuery();
                Form1.conn.Close();
                MessageBox.Show("Registro guardado exitosamente");
            }
            catch (SqlException sqlEx)
            {
                Form1.conn.Close();
                if (sqlEx.Number == 2627) //Error de duplicado de Primary Key
                {
                    Form1.conn.Close();
                    MessageBox.Show("Ocurrió un error al tratar de guardar el registro: El número de Operador ya existe en la Base de Datos.");
                }
                else
                {
                    Form1.conn.Close();
                    MessageBox.Show("Ocurrió un error al tratar de guardar el registro: " + sqlEx.Number);
                }
            }
            catch (Exception ex)
            {
                Form1.conn.Close();
                MessageBox.Show("Ocurrió un error al tratar de guardar el registro: " + ex.Message);
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