namespace prodProject
{
    partial class AddOperadorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOperadorForm));
            NumOpTxtBox = new TextBox();
            NameOpTxtBox = new TextBox();
            SurnameOpTxtBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            BtnAddOperator = new Button();
            BtnReturn = new Button();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // NumOpTxtBox
            // 
            NumOpTxtBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            NumOpTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            NumOpTxtBox.Location = new Point(764, 346);
            NumOpTxtBox.Name = "NumOpTxtBox";
            NumOpTxtBox.Size = new Size(798, 43);
            NumOpTxtBox.TabIndex = 0;
            // 
            // NameOpTxtBox
            // 
            NameOpTxtBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            NameOpTxtBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            NameOpTxtBox.Location = new Point(764, 457);
            NameOpTxtBox.Name = "NameOpTxtBox";
            NameOpTxtBox.Size = new Size(798, 39);
            NameOpTxtBox.TabIndex = 1;
            // 
            // SurnameOpTxtBox
            // 
            SurnameOpTxtBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            SurnameOpTxtBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            SurnameOpTxtBox.Location = new Point(764, 580);
            SurnameOpTxtBox.Name = "SurnameOpTxtBox";
            SurnameOpTxtBox.Size = new Size(798, 39);
            SurnameOpTxtBox.TabIndex = 2;
            SurnameOpTxtBox.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(236, 343);
            label1.Name = "label1";
            label1.Size = new Size(340, 50);
            label1.TabIndex = 3;
            label1.Text = "Número de operador";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(290, 446);
            label2.Name = "label2";
            label2.Size = new Size(273, 50);
            label2.TabIndex = 4;
            label2.Text = "Primer nombre";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(290, 568);
            label3.Name = "label3";
            label3.Size = new Size(273, 51);
            label3.TabIndex = 5;
            label3.Text = "Primer apellido";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackgroundImage = Properties.Resources.OpIcon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(958, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(381, 137);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // BtnAddOperator
            // 
            BtnAddOperator.Anchor = AnchorStyles.Bottom;
            BtnAddOperator.BackColor = Color.Green;
            BtnAddOperator.FlatStyle = FlatStyle.Popup;
            BtnAddOperator.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddOperator.ForeColor = SystemColors.ButtonHighlight;
            BtnAddOperator.Location = new Point(648, 815);
            BtnAddOperator.Name = "BtnAddOperator";
            BtnAddOperator.Size = new Size(473, 169);
            BtnAddOperator.TabIndex = 7;
            BtnAddOperator.Text = "Agregar";
            BtnAddOperator.UseVisualStyleBackColor = false;
            BtnAddOperator.Click += BtnAddOperator_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.AutoSize = true;
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.Cursor = Cursors.Hand;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(25, 12);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(222, 137);
            BtnReturn.TabIndex = 8;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(1517, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(247, 137);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(585, 226);
            label4.Name = "label4";
            label4.Size = new Size(673, 50);
            label4.TabIndex = 10;
            label4.Text = "Datos de operador";
            // 
            // AddOperadorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1796, 1057);
            ControlBox = false;
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(BtnReturn);
            Controls.Add(BtnAddOperator);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SurnameOpTxtBox);
            Controls.Add(NameOpTxtBox);
            Controls.Add(NumOpTxtBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddOperadorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir nuevo operador";
            Load += AddOperadorForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NumOpTxtBox;
        private TextBox NameOpTxtBox;
        private TextBox SurnameOpTxtBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private Button BtnAddOperator;
        private Button BtnReturn;
        private PictureBox pictureBox2;
        private Label label4;
    }
}