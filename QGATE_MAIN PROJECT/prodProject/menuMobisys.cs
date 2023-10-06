using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace prodProject
{
    public partial class menuMobisys : Form
    {
        private bool cambioFormularioRealizado = false;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public static String connectionString = "";
        public static SqlConnection conn;
        public int Estandar;
        public int piezasContainer;
        public string numParte;
        public menuMobisys()
        {
            InitializeComponent();
            timer.Interval = 1000; // 1000 ms = 1 segundo
            timer.Tick += Timer_Tick;
            connectionString = CsvReader.SetConnectionString();
            piezasContainer = 0;
            if (connectionString != string.Empty)
            {
                conn = new SqlConnection(connectionString);
            }
            else
            {
                MessageBox.Show("No se pudo realizar la conexión a BD");
            }

            containerIdTxt.TextChanged += containerIdTxt_TextChanged;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void menuMobisys_Load(object sender, EventArgs e)
        {

        }

        private void CheckContainerId()
        {

            if (containerIdTxt.Text != String.Empty)
            {
                StartForms();
            }
            else containerIdMessage.Text = "";


        }

        private void StartForms()
        {
            conn.Close();
            Form1 f1 = new(this);
            this.Hide();
            f1.StartForeignTimer();

        }

        private void containerIdTxt_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Este código se ejecutará después del tiempo especificado en el temporizador
            // Verificar si el TextBox ya no está vacío
            if (!string.IsNullOrWhiteSpace(containerIdTxt.Text) && !cambioFormularioRealizado)
            {
                // Crear una instancia del formulario SecondForm
                if (!validaContainer(containerIdTxt.Text))
                {
                    StartForms();
                    cambioFormularioRealizado = true;
                    containerIdTxt.Text= String.Empty;
                }
                else
                {
                    containerIdMessage.Text = "Este Container ID ya fue escaneado previamente";
                }

                // Opcional: Puedes ocultar o cerrar el formulario actual si es necesario
                // this.Hide(); // Esto ocultaría el formulario actual
                // this.Close(); // Esto cerraría el formulario actual
            }

            // Detener el temporizador después de ejecutar la acción
            timer.Stop();
        }

        private bool validaContainer(string id)
        {
            String queryString = "SELECT * FROM Container WHERE id = '" + id + "';";

            try
            {
                conn.Open();
                //MessageBox.Show("Connection Granted");

                SqlCommand cmd = new(queryString, conn);
                SqlDataReader record = cmd.ExecuteReader();
                if (record.Read())
                {
                    this.numParte = record.GetString(1);
                    conn.Close();
                    return true;
                }
                else
                {
                    return false;
                    conn.Close();
                }

            }
            catch (SqlNullValueException)
            {
                conn.Close();
                return true;
            }
            catch (Exception e1)
            {
                conn.Close();
                MessageBox.Show("Error generando serial :", e1.Message);

                return true;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        //Método para obtener el estandar de piezas por lote correspondiente al numero de pieza
        private int GetEstandar(string claveComp)
        {
            return 0;
        }
    }
}
