namespace prodProject
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            GB1 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            BtnDeleteOp = new Button();
            BtnAddOp = new Button();
            GB2 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            BtnDeletePieza = new Button();
            BtnAddPi = new Button();
            BtnReturn = new Button();
            BtnClearDB = new Button();
            label5 = new Label();
            BtnPrinterOpt = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label6 = new Label();
            pictureBox3 = new PictureBox();
            GB1.SuspendLayout();
            GB2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // GB1
            // 
            GB1.Controls.Add(label2);
            GB1.Controls.Add(label1);
            GB1.Controls.Add(BtnDeleteOp);
            GB1.Controls.Add(BtnAddOp);
            GB1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            GB1.Location = new Point(160, 38);
            GB1.Name = "GB1";
            GB1.Size = new Size(529, 378);
            GB1.TabIndex = 0;
            GB1.TabStop = false;
            GB1.Text = "Operadores";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(229, 280);
            label2.Name = "label2";
            label2.Size = new Size(297, 50);
            label2.TabIndex = 3;
            label2.Text = "Eliminar los datos de un operador\r\nexistente en la Base de Datos";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(229, 66);
            label1.Name = "label1";
            label1.Size = new Size(263, 50);
            label1.TabIndex = 2;
            label1.Text = "Añadir los datos de un nuevo \r\noperador  a la Base de Datos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // BtnDeleteOp
            // 
            BtnDeleteOp.BackColor = SystemColors.GradientInactiveCaption;
            BtnDeleteOp.FlatStyle = FlatStyle.Popup;
            BtnDeleteOp.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDeleteOp.Location = new Point(18, 240);
            BtnDeleteOp.Name = "BtnDeleteOp";
            BtnDeleteOp.Size = new Size(180, 126);
            BtnDeleteOp.TabIndex = 1;
            BtnDeleteOp.Text = "Baja de Operador";
            BtnDeleteOp.UseVisualStyleBackColor = false;
            BtnDeleteOp.Click += BtnDeleteOp_Click;
            // 
            // BtnAddOp
            // 
            BtnAddOp.BackColor = SystemColors.GradientInactiveCaption;
            BtnAddOp.FlatStyle = FlatStyle.Popup;
            BtnAddOp.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddOp.Location = new Point(18, 26);
            BtnAddOp.Name = "BtnAddOp";
            BtnAddOp.Size = new Size(180, 126);
            BtnAddOp.TabIndex = 0;
            BtnAddOp.Text = "Alta de Operador";
            BtnAddOp.UseVisualStyleBackColor = false;
            BtnAddOp.Click += BtnAddOp_Click;
            // 
            // GB2
            // 
            GB2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            GB2.Controls.Add(label4);
            GB2.Controls.Add(label3);
            GB2.Controls.Add(BtnDeletePieza);
            GB2.Controls.Add(BtnAddPi);
            GB2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            GB2.Location = new Point(743, 50);
            GB2.Name = "GB2";
            GB2.Size = new Size(507, 378);
            GB2.TabIndex = 1;
            GB2.TabStop = false;
            GB2.Text = "Piezas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(218, 272);
            label4.Name = "label4";
            label4.Size = new Size(274, 50);
            label4.TabIndex = 3;
            label4.Text = "Eliminar los datos de una pieza\r\nde la Base de Datos";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(213, 66);
            label3.Name = "label3";
            label3.Size = new Size(279, 50);
            label3.TabIndex = 2;
            label3.Text = "Agregar los datos de una nueva\r\npieza a la Base de Datos";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnDeletePieza
            // 
            BtnDeletePieza.BackColor = SystemColors.GradientInactiveCaption;
            BtnDeletePieza.FlatStyle = FlatStyle.Popup;
            BtnDeletePieza.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDeletePieza.Location = new Point(18, 232);
            BtnDeletePieza.Name = "BtnDeletePieza";
            BtnDeletePieza.Size = new Size(180, 126);
            BtnDeletePieza.TabIndex = 1;
            BtnDeletePieza.Text = "Baja de pieza";
            BtnDeletePieza.UseVisualStyleBackColor = false;
            BtnDeletePieza.Click += BtnDeletePieza_Click;
            // 
            // BtnAddPi
            // 
            BtnAddPi.BackColor = SystemColors.GradientInactiveCaption;
            BtnAddPi.FlatStyle = FlatStyle.Popup;
            BtnAddPi.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddPi.Location = new Point(18, 26);
            BtnAddPi.Name = "BtnAddPi";
            BtnAddPi.Size = new Size(180, 126);
            BtnAddPi.TabIndex = 0;
            BtnAddPi.Text = "Alta de pieza";
            BtnAddPi.UseVisualStyleBackColor = false;
            BtnAddPi.Click += AddPi_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.Cursor = Cursors.Hand;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(12, 38);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(107, 109);
            BtnReturn.TabIndex = 2;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // BtnClearDB
            // 
            BtnClearDB.BackColor = Color.Orange;
            BtnClearDB.Cursor = Cursors.Hand;
            BtnClearDB.FlatStyle = FlatStyle.Popup;
            BtnClearDB.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BtnClearDB.Location = new Point(18, 32);
            BtnClearDB.Name = "BtnClearDB";
            BtnClearDB.Size = new Size(180, 126);
            BtnClearDB.TabIndex = 3;
            BtnClearDB.Text = "Limpiar Base de Datos";
            BtnClearDB.UseVisualStyleBackColor = false;
            BtnClearDB.Click += BtnClearDB_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(209, 48);
            label5.Name = "label5";
            label5.Size = new Size(283, 75);
            label5.TabIndex = 4;
            label5.Text = "Elimina los registros de revisión \r\nde partes con más de 1 dia de\r\n antigüedad";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BtnPrinterOpt
            // 
            BtnPrinterOpt.BackColor = SystemColors.ControlLight;
            BtnPrinterOpt.BackgroundImage = (Image)resources.GetObject("BtnPrinterOpt.BackgroundImage");
            BtnPrinterOpt.BackgroundImageLayout = ImageLayout.Zoom;
            BtnPrinterOpt.Cursor = Cursors.Hand;
            BtnPrinterOpt.FlatStyle = FlatStyle.Popup;
            BtnPrinterOpt.Location = new Point(18, 39);
            BtnPrinterOpt.Name = "BtnPrinterOpt";
            BtnPrinterOpt.Size = new Size(152, 135);
            BtnPrinterOpt.TabIndex = 9;
            BtnPrinterOpt.UseVisualStyleBackColor = false;
            BtnPrinterOpt.Click += BtnPrinterOpt_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnClearDB);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(160, 445);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(529, 194);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Base de Datos";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(BtnPrinterOpt);
            groupBox2.Location = new Point(743, 445);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(507, 194);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Impresiones";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(176, 73);
            label6.Name = "label6";
            label6.Size = new Size(223, 25);
            label6.TabIndex = 4;
            label6.Text = "Opciones de reimpresión\r\n";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(1118, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(185, 53);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1315, 663);
            ControlBox = false;
            Controls.Add(pictureBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(BtnReturn);
            Controls.Add(GB2);
            Controls.Add(GB1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            Load += AdminForm_Load;
            GB1.ResumeLayout(false);
            GB1.PerformLayout();
            GB2.ResumeLayout(false);
            GB2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GB1;
        private GroupBox GB2;
        private Label label1;
        private Button BtnDeleteOp;
        private Button BtnAddOp;
        private Button BtnDeletePieza;
        private Button BtnAddPi;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button BtnReturn;
        private Button BtnClearDB;
        private Label label5;
        private Button BtnPrinterOpt;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label6;
        private PictureBox pictureBox3;
    }
}