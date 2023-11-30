
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
                SetFormConfig();
                this.Show();
            }
        }

        private void SetFormConfig()
        {
            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer, true);
        }

        /// <summary>
        /// Actualiza imagen de fondo del formulario
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        ///Cambia formulario de punto de inspección
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            closedIncorrectlyFlag = false;
            Form1.formSlideCont++;
            Form3 frm = new(f1);
            Thread.Sleep(200);
            this.Close();
        }

        //Método para manejar el cerrado de la aplicación incompleto

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.closedIncorrectlyFlag == true && Application.OpenForms["Form1"].Visible == false)
                Application.OpenForms["Form1"].Visible = true;
        }

    }
}
