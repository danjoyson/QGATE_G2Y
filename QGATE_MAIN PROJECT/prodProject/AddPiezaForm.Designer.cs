namespace prodProject
{
    partial class AddPiezaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPiezaForm));
            BtnReturn = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            pictureBox2 = new PictureBox();
            label8 = new Label();
            label9 = new Label();
            ClaveTxtBox = new TextBox();
            DescrTxtBox = new TextBox();
            BtnAddPi = new Button();
            label10 = new Label();
            txtPasos = new TextBox();
            label11 = new Label();
            txtReescaneo = new TextBox();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // BtnReturn
            // 
            BtnReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(27, 12);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(169, 159);
            BtnReturn.TabIndex = 0;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(880, 179);
            label1.Name = "label1";
            label1.Size = new Size(369, 37);
            label1.TabIndex = 1;
            label1.Text = "EJEMPLO DE ALTA DE PIEZA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImage = Properties.Resources.addPieza;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(711, 268);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(330, 104);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.LightSteelBlue;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1119, 268);
            label3.Name = "label3";
            label3.Size = new Size(363, 60);
            label3.TabIndex = 4;
            label3.Text = "Número de parte: X296.6806502.83\r\nDescripción:  Hybrid OP BFS LHD\r\n";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Info;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(0, 107);
            label4.Name = "label4";
            label4.Size = new Size(269, 42);
            label4.TabIndex = 5;
            label4.Text = "Descripción (color amarillo):\r\n   Es el nombre descriptivo de la pieza\r\n";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(202, 193);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(503, 179);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Explicación";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Info;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(-1, 26);
            label2.Name = "label2";
            label2.Size = new Size(500, 63);
            label2.TabIndex = 3;
            label2.Text = "Número de parte (color rojo):\r\n   Consiste en el  código de 13 letras y 2 puntos que permite identificar \r\n   el tipo de pieza de forma única. ";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(807, 240);
            label5.Name = "label5";
            label5.Size = new Size(158, 21);
            label5.TabIndex = 6;
            label5.Text = "Imagen del manual";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(1238, 240);
            label6.Name = "label6";
            label6.Size = new Size(133, 21);
            label6.TabIndex = 7;
            label6.Text = "Datos a ingresar";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(1056, 300);
            label7.Name = "label7";
            label7.Size = new Size(45, 21);
            label7.TabIndex = 8;
            label7.Text = "---->";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(1290, 24);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(162, 127);
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(376, 433);
            label8.Name = "label8";
            label8.Size = new Size(211, 32);
            label8.TabIndex = 10;
            label8.Text = "Número de parte";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(438, 512);
            label9.Name = "label9";
            label9.Size = new Size(149, 32);
            label9.TabIndex = 11;
            label9.Text = "Descripción";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClaveTxtBox
            // 
            ClaveTxtBox.Anchor = AnchorStyles.None;
            ClaveTxtBox.CharacterCasing = CharacterCasing.Upper;
            ClaveTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ClaveTxtBox.Location = new Point(620, 433);
            ClaveTxtBox.Name = "ClaveTxtBox";
            ClaveTxtBox.Size = new Size(633, 43);
            ClaveTxtBox.TabIndex = 12;
            ClaveTxtBox.TextChanged += ClaveTxtBox_TextChanged;
            // 
            // DescrTxtBox
            // 
            DescrTxtBox.Anchor = AnchorStyles.None;
            DescrTxtBox.CharacterCasing = CharacterCasing.Upper;
            DescrTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            DescrTxtBox.Location = new Point(620, 512);
            DescrTxtBox.Name = "DescrTxtBox";
            DescrTxtBox.Size = new Size(633, 43);
            DescrTxtBox.TabIndex = 13;
            // 
            // BtnAddPi
            // 
            BtnAddPi.Anchor = AnchorStyles.None;
            BtnAddPi.BackColor = Color.Orange;
            BtnAddPi.Cursor = Cursors.Hand;
            BtnAddPi.FlatStyle = FlatStyle.Popup;
            BtnAddPi.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddPi.Location = new Point(698, 841);
            BtnAddPi.Name = "BtnAddPi";
            BtnAddPi.Size = new Size(375, 162);
            BtnAddPi.TabIndex = 14;
            BtnAddPi.Text = "Agregar pieza";
            BtnAddPi.UseVisualStyleBackColor = false;
            BtnAddPi.Click += BtnAddPi_Click;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(376, 592);
            label10.Name = "label10";
            label10.Size = new Size(215, 32);
            label10.TabIndex = 15;
            label10.Text = "Número de pasos";
            // 
            // txtPasos
            // 
            txtPasos.Anchor = AnchorStyles.None;
            txtPasos.CharacterCasing = CharacterCasing.Upper;
            txtPasos.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtPasos.Location = new Point(620, 589);
            txtPasos.Name = "txtPasos";
            txtPasos.Size = new Size(633, 43);
            txtPasos.TabIndex = 16;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(253, 678);
            label11.Name = "label11";
            label11.Size = new Size(361, 32);
            label11.TabIndex = 17;
            label11.Text = "Número de paso de reescaneo";
            // 
            // txtReescaneo
            // 
            txtReescaneo.Anchor = AnchorStyles.None;
            txtReescaneo.CharacterCasing = CharacterCasing.Upper;
            txtReescaneo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtReescaneo.Location = new Point(620, 671);
            txtReescaneo.Name = "txtReescaneo";
            txtReescaneo.Size = new Size(633, 39);
            txtReescaneo.TabIndex = 18;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(1458, 24);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(240, 127);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(620, 725);
            button1.Name = "button1";
            button1.Size = new Size(286, 58);
            button1.TabIndex = 20;
            button1.Text = "Save Images";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddPiezaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1710, 1061);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(pictureBox3);
            Controls.Add(txtReescaneo);
            Controls.Add(label11);
            Controls.Add(txtPasos);
            Controls.Add(label10);
            Controls.Add(BtnAddPi);
            Controls.Add(DescrTxtBox);
            Controls.Add(ClaveTxtBox);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(pictureBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(BtnReturn);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddPiezaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir pieza";
            Load += AddPiezaForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnReturn;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label7;
        private PictureBox pictureBox2;
        private Label label8;
        private Label label9;
        private TextBox ClaveTxtBox;
        private TextBox DescrTxtBox;
        private Button BtnAddPi;
        private Label label10;
        private TextBox txtPasos;
        private Label label11;
        private TextBox txtReescaneo;
        private PictureBox pictureBox3;
        private Button button1;
    }
}