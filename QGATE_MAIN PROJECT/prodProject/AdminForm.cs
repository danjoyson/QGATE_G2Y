﻿using System.ComponentModel;
using System.Data.SqlClient;

namespace prodProject
{
    public partial class AdminForm : Form
    {

        DatabaseConnector db = new DatabaseConnector();
        public IComponent contrato { get; set; }
        private int estandarContainer;
        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Constructor del formulario.
         * Asigna un evento al cerrado del formulario.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        public AdminForm()
        {
            this.FormClosing += new FormClosingEventHandler(AdminForm_FormClosing);
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de retorno.
         * Regresa al usuario a la pantalla de inicio.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            ReturnHome();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método de retorno a la pantalla de inicio.
         * 1. Vuelve visible la pantalla de inicio.
         * 2. Cierra el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void ReturnHome()
        {

            Application.OpenForms["ContainerIdForm"].Show();
            this.Hide();
            this.Close();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de "Alta de operador"
         * 1. Crea una instancia del siguiente formulario.
         * 2. Vuelve invisible el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnAddOp_Click(object sender, EventArgs e)
        {
            AddOperadorForm nextForm = new(this);
            nextForm.Show();
            this.Hide();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de "Baja de operador"
         * 1. Crea una instancia del siguiente formulario.
         * 2. Vuelve invisible el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnDeleteOp_Click(object sender, EventArgs e)
        {
            DeleteOperadorForm nextForm = new(this);
            nextForm.Show();
            this.Hide();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de "Alta de pieza"
         * 1. Crea una instancia del siguiente formulario.
         * 2. Vuelve invisible el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void AddPi_Click(object sender, EventArgs e)
        {
            AddPiezaForm nextForm = new(this);
            nextForm.Show();
            this.Hide();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de "Baja de pieza"
         * 1. Crea una instancia del siguiente formulario.
         * 2. Vuelve invisible el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnDeletePieza_Click(object sender, EventArgs e)
        {
            DeletePiezaForm nextForm = new(this);
            nextForm.Show();
            this.Hide();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Función para eliminar de la Base de Datos aquellos registros de revisión de partes mayores a 1 día de antigüedad.
         * 1. Muestra un mensaje de advertencia.
         * 2. Elimina todos aquellos registros de la tabla Operador_Pieza mayores a 1 día de antigüedad.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnClearDB_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Está seguro que desea ejecutar esta acción PERMANENTE? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                db.VaciarDb();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método para manejar el cerrado de la aplicación incompleto.
         * Si se cierra la aplicación, retorna al usuario al formulario de inicio.
         * --------------------------------------------------------------------------------------------------------------------------------
       */
        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms["ContainerIdForm"].Show();
        }

        /*
         * --------------------------------------------------------------------------------------------------------------------------------
         * Método llamado al hacer clic sobre el botón de "Baja de pieza"
         * 1. Crea una instancia del siguiente formulario.
         * 2. Vuelve invisible el formulario actual.
         * --------------------------------------------------------------------------------------------------------------------------------
         */
        private void BtnPrinterOpt_Click(object sender, EventArgs e)
        {
            SimplePrinterForm nextForm = new(this);
            nextForm.Show();
            this.Hide();
        }

        public int SetEstandarCount(int idCountry)
        {
            int piezasContainer = 0;
            switch (idCountry)
            {
                //Índice 0 corresponde a México
                case 0:
                    piezasContainer = 4;
                    break;
                //Índice 1 corresponde a China
                case 1:
                    piezasContainer = 35;
                    break;
            }
            return piezasContainer;
        }
    }
}
