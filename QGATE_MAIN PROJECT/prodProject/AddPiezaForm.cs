using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace prodProject
{
    public partial class AddPiezaForm : Form
    {
        private AdminForm prevForm;
        private int id;

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Constructor del formulario para añadir pieza a la base de datos.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public AddPiezaForm(AdminForm af)
        {
            this.prevForm = af;
            this.FormClosing += new FormClosingEventHandler(AddPieza_FormClosing);
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddPiezaForm_Load(object sender, EventArgs e)
        {

        }

        /*
         * ---------------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al presionar el botón "Agregar".
         * 1. Llama al método para revisar que no haya texto vacío en las cajas de texto.
         * 2. Llama al método para obtener el último ID colocado en la Base de Datos.
         * 3. Llama al método para insertar el registro en la base de datos.
         * ---------------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnAddPi_Click(object sender, EventArgs e)
        {
            if (NotNullTxtBoxData())
            {
                if (GetID())
                {
                    InsertPieceIntoDB();
                }
            }
        }

        /*
         * ---------------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al presionar el botón de retorno.
         * 1. Devuelve al usuario al formulario anterior
         * ---------------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        /*
         * ---------------------------------------------------------------------------------------------------------------------------------------
         * Función para volver al formulario anterior.
         * 1. Esconde el formulario actual.
         * 2. Vuelve visible el formulario anterior.
         * 3. Cierra el formulario actual.
         * ---------------------------------------------------------------------------------------------------------------------------------------
         */
        private void ReturnToPreviousForm()
        {
            this.Hide();
            prevForm.Show();
            this.Close();
        }

        /*
         * ---------------------------------------------------------------------------------------------------------------------------------------
         * Función para obtener el último ID del catalogo de piezas agregado a la base de datos, en caso de no haber piezas se le otoga el ID = 1
         * ---------------------------------------------------------------------------------------------------------------------------------------
         */
        private bool GetID()
        {
            bool flag = false;
            try
            {
                Form1.conn.Open();
                String query = "SELECT MAX (idPieza) FROM Pieza;";
                SqlCommand cmd = new(query, Form1.conn);
                SqlDataReader record = cmd.ExecuteReader();

                if (record.Read())
                {
                    this.id = record.GetInt16(0) + 1;
                }
                flag = true;

            }
            catch (SqlNullValueException)
            {
                //omitir excepción generada cuando no se encuentra una pieza en la DB (ingreso por primera vez, por ende idPieza = 1)
                this.id = 1;
                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de abrir la Base de datos: " + ex.Message);
            }
            finally
            {
                Form1.conn.Close();
            }
            return flag;
        }

        /*
         * -----------------------------------------------------------------------------------------------------------------------------------
         * Función para ingresar la pieza en la Base de Datos.
         * 1. Se forma el string de consulta (query) con los datos necesarios para la base de datos.
         * 2. Se ingresan los valores de forma parametrizada.
         * 3. Se ejecuta la consulta
         * 
         * En caso de haber alguna excepción, como incumplir algura restricción de clave primaria, se mostrará un mensaje de error en pantalla.
         * ----------------------------------------------------------------------------------------------------------------------------------- 
         */
        private void InsertPieceIntoDB()
        {
            try
            {
                Form1.conn.Open();
                string query = "INSERT INTO Pieza VALUES (@idPieza, @descripcion, @claveComp, @inicioCadena, @finCadena , @pasos , @puntoReescaneo);";
                SqlCommand cmd = new(query, Form1.conn);
                cmd.Parameters.AddWithValue("@idPieza", this.id);
                cmd.Parameters.AddWithValue("@descripcion", DescrTxtBox.Text);
                cmd.Parameters.AddWithValue("@claveComp", ClaveTxtBox.Text.Substring(4, 7));
                cmd.Parameters.AddWithValue("@inicioCadena", ClaveTxtBox.Text.Substring(0, 1));
                //Se cambio el numero de inicio de subcadena de fin de cadena para que no truene cuando se meta una cadena distinta, se toma el tamaño de la cadena -2 porque se desea extraer los ultimos 2 caracteres.
                cmd.Parameters.AddWithValue("@finCadena", ClaveTxtBox.Text.Substring(ClaveTxtBox.Text.Length - 2, 2));
                cmd.Parameters.AddWithValue("@pasos", txtPasos.Text);
                cmd.Parameters.AddWithValue("@puntoReescaneo", txtReescaneo.Text);
                cmd.ExecuteNonQuery(); //Ejecución de query

                MessageBox.Show("Pieza guardada correctamente en la base de datos");
                DialogResult dialog = MessageBox.Show("Recuerde agregar las imágenes de la pieza en la carpeta de la aplicación para el correcto funcionamiento del programa. Procedimiento del manual de usuario.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException sqlEx)
            {
                Form1.conn.Close();
                if (sqlEx.Number == 2627 || sqlEx.Number == 2601) //Error de duplicado de Primary Key
                {
                    Form1.conn.Close();
                    MessageBox.Show("Ocurrió un error al tratar de guardar el registro: No se pueden ingresar claves de pieza duplicadas");
                }
                else
                {
                    Form1.conn.Close();
                    MessageBox.Show("Ocurrió un error al tratar de guardar el registro: " + sqlEx.Number);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al insertar el registro en la Base de Datos: " + ex.Message);
            }
            finally
            {
                Form1.conn.Close();
            }

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         *  Función para revisar que la información en las text box no contengan valores nulos o vacíos.
         *  Retorna true si contienen texto.
         *  Retorna false si hay contenido nulo en cualquiera de las dos y lanza un mensaje de error en pantalla.
         *  --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool NotNullTxtBoxData()
        {
            try
            {
                if (ClaveTxtBox.Text == string.Empty || DescrTxtBox.Text == string.Empty)
                    throw new ArgumentNullException();
                if (ClaveTxtBox.Text.Length > 15)
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
         * Método para manejar el cerrado de la aplicación incorrecto.
         * Si se cierra el formulario actual, se devolverá a la pantalla anterior.
         * --------------------------------------------------------------------------------------------------------------------------------
       */
        private void AddPieza_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

    }
}
