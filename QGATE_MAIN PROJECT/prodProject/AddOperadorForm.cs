﻿using System.Data.SqlClient;


namespace prodProject
{
    public partial class AddOperadorForm : Form
    {
        AdminForm prevForm;
        DatabaseConnector db = new DatabaseConnector();
        /*
         * Constructor del formulario de Alta de operador
         * Recibe el formulario previo (AdminForm) y asigna una función de manejo de cierre del formulario.
         */
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
                db.InsertaOperador(NumOpTxtBox.Text, NameOpTxtBox.Text, SurnameOpTxtBox.Text);
                ClearInputs();
            }
        }

        /*
         * Método llamado al hacer clic sobre el botón de retorno.
         * 1. Regresa al usuario al formulario anterior.
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

        //Método para manejar el cerrado de la aplicación incompleto
        private void AddOperador_FormClosing(object sender, FormClosingEventArgs e)
        {
            prevForm.Show();
        }


        private void AddOperadorForm_Load(object sender, EventArgs e)
        {
        }
    }
}