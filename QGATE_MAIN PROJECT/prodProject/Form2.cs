
namespace prodProject
{
    public partial class Form2 : Form
    {

        private Form1 f1;
        bool closedIncorrectlyFlag; //Será true en caso de que haya sido cerrado mediante Alt+F4 o cerrando la aplicación en la barra de tarea
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función Constructor de formulario de Slide inicial de parte
         * 1. Se resetea el contador de slide. (Para controlar qué imagen le corresponde a cada pantalla)
         * 2. Se llama a la función SetImage(), en caso de no haber error continúa.
         * 3. Inicializa el formulario
         * 
         * Se envía el objeto de formulario 1 para poder transmitírselo al siguiente formulario
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public Form2(Form1 f1)
        {
            Form1.formSlideCont = 0; //Se resetea el contador de los formularios
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
            if (SetImage())
            {

                closedIncorrectlyFlag = true; //Temporalmente true. Cambia a false en el método para cambiar al siguiente formulario
                this.f1 = f1;

                InitializeComponent();
                this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.Show();
            }
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Busca y cambia la imagen de fondo del formulario. Si no la encuentra en la carpeta, manda un mensaje de error y retorna al 
         * formulario de inicio.
         * 
         * Retorna true en caso de no haber ningún error.
         * Retorna false en caso de capturar una excepción, lanza un mensaje de error y devuelve al usuario al primer formulario.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private bool SetImage()
        {
            try
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\images\" + Form1.piezaText + @"\" + Form1.piezaText + "_S" + Form1.formSlideCont + ".JPG");
            }
            catch (Exception)
            {
                Application.OpenForms["Form1"].Show();
                MessageBox.Show("Ocurrió un error. Revise que las imágenes de los formularios se encuentren en la carpeta correcta.");
                this.Close();
                return false;
            }
            return true;
        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función que se acciona al presionar el botón "Entendido"
         * 1. Aumenta el contador de slide.
         * 2. Instancía un nuevo formulario con la plantilla de 2 botones OK/NOK (Form3)
         * 3. Finalmente cierra el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnNext_Click(object sender, EventArgs e)
        {
            closedIncorrectlyFlag = false;
            Form1.formSlideCont++;
            Form3 frm = new(f1);
            Thread.Sleep(200);
            this.Close();
        }

        /*
          * --------------------------------------------------------------------------------------------------------------------------------
          * Método para manejar el cerrado de la aplicación incompleto
          * En caso de que no haya sido cerrado para mostrar el siguiente formulario, es decir, que haya sido cerrado mediante Alt+F4 o cerrando
          * la aplicación en la barra de tareas, devuelve al usuario al formulario inicial.
          * --------------------------------------------------------------------------------------------------------------------------------
       */
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.closedIncorrectlyFlag == true && Application.OpenForms["Form1"].Visible == false)
                Application.OpenForms["Form1"].Visible = true;
        }

    }
}
