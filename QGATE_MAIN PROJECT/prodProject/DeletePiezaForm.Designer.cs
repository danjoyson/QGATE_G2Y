namespace prodProject
{
    partial class DeletePiezaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeletePiezaForm));
            groupBox1 = new GroupBox();
            label2 = new Label();
            label7 = new Label();
            label6 = new Label();
            label1 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            claveTxtBox = new TextBox();
            label4 = new Label();
            BtnDeletePieza = new Button();
            BtnReturn = new Button();
            pictureBox3 = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(498, 119);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Explicación";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Info;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(-1, 28);
            label2.Name = "label2";
            label2.Size = new Size(500, 63);
            label2.TabIndex = 4;
            label2.Text = "Número de parte (color rojo):\r\n   Consiste en el  código de 13 letras y 2 puntos que permite identificar \r\n   el tipo de pieza de forma única. ";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(864, 135);
            label7.Name = "label7";
            label7.Size = new Size(45, 21);
            label7.TabIndex = 14;
            label7.Text = "---->";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(1045, 95);
            label6.Name = "label6";
            label6.Size = new Size(133, 21);
            label6.TabIndex = 13;
            label6.Text = "Datos a ingresar";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(673, 47);
            label1.Name = "label1";
            label1.Size = new Size(372, 37);
            label1.TabIndex = 9;
            label1.Text = "EJEMPLO DE BAJA DE PIEZA";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(594, 84);
            label5.Name = "label5";
            label5.Size = new Size(158, 21);
            label5.TabIndex = 12;
            label5.Text = "Imagen del manual";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImage = Properties.Resources.DeletePieza;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(528, 116);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(330, 104);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.LightSteelBlue;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(927, 127);
            label3.Name = "label3";
            label3.Size = new Size(368, 31);
            label3.TabIndex = 11;
            label3.Text = "Número de parte:  X296.6806502.83\r\n";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(1065, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(85, 63);
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // claveTxtBox
            // 
            claveTxtBox.Anchor = AnchorStyles.None;
            claveTxtBox.CharacterCasing = CharacterCasing.Upper;
            claveTxtBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            claveTxtBox.Location = new Point(437, 349);
            claveTxtBox.Name = "claveTxtBox";
            claveTxtBox.Size = new Size(666, 39);
            claveTxtBox.TabIndex = 16;
            claveTxtBox.TextChanged += claveTxtBox_TextChanged;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(171, 336);
            label4.Name = "label4";
            label4.Size = new Size(231, 64);
            label4.TabIndex = 17;
            label4.Text = "Número de parte a\r\neliminar";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnDeletePieza
            // 
            BtnDeletePieza.Anchor = AnchorStyles.None;
            BtnDeletePieza.BackColor = Color.Red;
            BtnDeletePieza.FlatStyle = FlatStyle.Popup;
            BtnDeletePieza.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDeletePieza.Location = new Point(507, 583);
            BtnDeletePieza.Name = "BtnDeletePieza";
            BtnDeletePieza.Size = new Size(311, 138);
            BtnDeletePieza.TabIndex = 18;
            BtnDeletePieza.Text = "Eliminar";
            BtnDeletePieza.UseVisualStyleBackColor = false;
            BtnDeletePieza.Click += BtnDeletePieza_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.Anchor = AnchorStyles.None;
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(12, 583);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(129, 112);
            BtnReturn.TabIndex = 19;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(1156, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(139, 63);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // DeletePiezaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1302, 753);
            ControlBox = false;
            Controls.Add(pictureBox3);
            Controls.Add(BtnReturn);
            Controls.Add(BtnDeletePieza);
            Controls.Add(label4);
            Controls.Add(claveTxtBox);
            Controls.Add(pictureBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DeletePiezaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DeletePiezaForm";
            Load += DeletePiezaForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label7;
        private Label label6;
        private Label label1;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label3;
        private PictureBox pictureBox2;
        private TextBox claveTxtBox;
        private Label label4;
        private Button BtnDeletePieza;
        private Button BtnReturn;
        private Label label2;
        private PictureBox pictureBox3;
    }
}