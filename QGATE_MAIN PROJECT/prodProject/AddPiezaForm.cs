using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace prodProject
{
    public partial class AddPiezaForm : Form
    {
        private AdminForm prevForm;
        DatabaseConnector db = new DatabaseConnector();
        Document dc = new Document();
        private int id;
        private string imagesPath;
        Pieza p = new Pieza();

        /// <summary>
        /// Inicializa las vistas del formulario
        /// </summary>
        /// <param name="af"></param>
        public AddPiezaForm(AdminForm af)
        {
            this.prevForm = af;
            this.FormClosing += new FormClosingEventHandler(AddPieza_FormClosing);
            InitializeComponent();
            imageFile.Enabled = false;
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

        /// <summary>
        /// Boton para agregar pieza a BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddPi_Click(object sender, EventArgs e)
        {
            if (NotNullTxtBoxData())
            {
                this.id = db.GetIdPieza();
                if (this.id != -1)
                {
                    SetPiezaInfo();
                    db.InsertaPieza(p);
                    if (dc.PptxToImage(imagesPath, ClaveTxtBox.Text.Substring(2, 7)))
                        ClearTxtBox();
                    else
                        MessageBox.Show("Hubo un problema al agregar las imagenes, debe agregarlas en la carpeta de la aplicación de forma manual para el correcto funcionamiento del programa. Procedimiento del manual de usuario.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Asigna los datos introducidos por el usuario a la instancia de la clase pieza
        /// </summary>
        private void SetPiezaInfo()
        {
            p.id = this.id;
            p.descripcion = DescrTxtBox.Text;
            p.claveComp = ClaveTxtBox.Text.Substring(2,7);
            p.inicioCadena = ClaveTxtBox.Text.Substring(0, 1);
            p.finCadena = ClaveTxtBox.Text.Substring(ClaveTxtBox.Text.Length - 2, 2);
            p.pasos =Int16.Parse(txtPasos.Text);
            p.puntoReescaneo = Int16.Parse(txtReescaneo.Text);
        }
        /// <summary>
        /// Limpia los inputs en los que el usuario introdujo datos
        /// </summary>
        private void ClearTxtBox()
        {
            ClaveTxtBox.Clear();
            DescrTxtBox.Clear();
            txtPasos.Clear();
            txtReescaneo.Clear();
            imageFile.Clear();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnToPreviousForm();
        }

        /// <summary>
        /// Cierra el formulario actual y abre el anterior
        /// </summary>
        private void ReturnToPreviousForm()
        {
            this.Hide();
            prevForm.Show();
            this.Close();
        }
 
        /// <summary>
        /// Verifica que las entradas de datos no se encuentren vacías cuando se trata de agregar un registro
        /// </summary>
        /// <returns></returns>

        private bool NotNullTxtBoxData()
        {
            try
            {
                if (String.IsNullOrEmpty(ClaveTxtBox.Text) || String.IsNullOrEmpty(DescrTxtBox.Text))
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

        /// <summary>
        /// Abre el formulario anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPieza_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }

        private void ClaveTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            imagesPath = dc.getPath();
            if (String.IsNullOrEmpty(imagesPath))
                MessageBox.Show("Debe de introducirse una dirección válida");
            else
                imageFile.Text = Path.GetFileName(imagesPath);

        }
    }
}
