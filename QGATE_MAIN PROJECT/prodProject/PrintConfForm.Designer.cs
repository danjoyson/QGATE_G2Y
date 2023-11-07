namespace prodProject
{
    partial class PrintConfForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintConfForm));
            label1 = new Label();
            groupBox1 = new GroupBox();
            currLabTxt = new Label();
            currYLabel = new Label();
            currXLabel = new Label();
            currDpiLabel = new Label();
            currIpLabel = new Label();
            label7 = new Label();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            configMenu = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            dpiTxtbx = new TextBox();
            etiquetaTxtbx = new TextBox();
            ipTextbox = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            pictureBox3 = new PictureBox();
            BtnReturn = new Button();
            groupBox1.SuspendLayout();
            configMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(663, 175);
            label1.Name = "label1";
            label1.Size = new Size(414, 40);
            label1.TabIndex = 0;
            label1.Text = "Configuración de Impresión";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(currLabTxt);
            groupBox1.Controls.Add(currYLabel);
            groupBox1.Controls.Add(currXLabel);
            groupBox1.Controls.Add(currDpiLabel);
            groupBox1.Controls.Add(currIpLabel);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(73, 290);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(705, 272);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuración actual";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // currLabTxt
            // 
            currLabTxt.AutoSize = true;
            currLabTxt.Location = new Point(188, 144);
            currLabTxt.Name = "currLabTxt";
            currLabTxt.Size = new Size(0, 21);
            currLabTxt.TabIndex = 10;
            // 
            // currYLabel
            // 
            currYLabel.AutoSize = true;
            currYLabel.Location = new Point(108, 85);
            currYLabel.Name = "currYLabel";
            currYLabel.Size = new Size(0, 21);
            currYLabel.TabIndex = 9;
            // 
            // currXLabel
            // 
            currXLabel.AutoSize = true;
            currXLabel.Location = new Point(154, 85);
            currXLabel.Name = "currXLabel";
            currXLabel.Size = new Size(0, 21);
            currXLabel.TabIndex = 8;
            // 
            // currDpiLabel
            // 
            currDpiLabel.AutoSize = true;
            currDpiLabel.Location = new Point(62, 60);
            currDpiLabel.Name = "currDpiLabel";
            currDpiLabel.Size = new Size(0, 21);
            currDpiLabel.TabIndex = 7;
            // 
            // currIpLabel
            // 
            currIpLabel.AutoSize = true;
            currIpLabel.Location = new Point(60, 31);
            currIpLabel.Name = "currIpLabel";
            currIpLabel.Size = new Size(0, 21);
            currIpLabel.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 144);
            label7.Name = "label7";
            label7.Size = new Size(120, 21);
            label7.TabIndex = 5;
            label7.Text = "Texto etiqueta";
            label7.Click += label7_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 85);
            label3.Name = "label3";
            label3.Size = new Size(37, 21);
            label3.TabIndex = 1;
            label3.Text = "DPI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 31);
            label2.Name = "label2";
            label2.Size = new Size(25, 21);
            label2.TabIndex = 0;
            label2.Text = "IP";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(369, 745);
            button1.Name = "button1";
            button1.Size = new Size(1073, 135);
            button1.TabIndex = 2;
            button1.Text = "Modificar configuración";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // configMenu
            // 
            configMenu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            configMenu.BackColor = SystemColors.Window;
            configMenu.Controls.Add(button3);
            configMenu.Controls.Add(button2);
            configMenu.Controls.Add(dpiTxtbx);
            configMenu.Controls.Add(etiquetaTxtbx);
            configMenu.Controls.Add(ipTextbox);
            configMenu.Controls.Add(label8);
            configMenu.Controls.Add(label9);
            configMenu.Controls.Add(label10);
            configMenu.Controls.Add(label11);
            configMenu.Controls.Add(label12);
            configMenu.Controls.Add(label13);
            configMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            configMenu.Location = new Point(1057, 290);
            configMenu.Name = "configMenu";
            configMenu.Size = new Size(574, 272);
            configMenu.TabIndex = 3;
            configMenu.TabStop = false;
            configMenu.Text = "Configurar impresión";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 128, 128);
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(18, 183);
            button3.Name = "button3";
            button3.Size = new Size(129, 50);
            button3.TabIndex = 5;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 255, 128);
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(340, 183);
            button2.Name = "button2";
            button2.Size = new Size(116, 50);
            button2.TabIndex = 4;
            button2.Text = "Guardar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // dpiTxtbx
            // 
            dpiTxtbx.BackColor = SystemColors.Control;
            dpiTxtbx.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dpiTxtbx.Location = new Point(144, 69);
            dpiTxtbx.Name = "dpiTxtbx";
            dpiTxtbx.Size = new Size(209, 33);
            dpiTxtbx.TabIndex = 15;
            // 
            // etiquetaTxtbx
            // 
            etiquetaTxtbx.BackColor = SystemColors.Control;
            etiquetaTxtbx.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            etiquetaTxtbx.Location = new Point(144, 122);
            etiquetaTxtbx.Name = "etiquetaTxtbx";
            etiquetaTxtbx.Size = new Size(209, 33);
            etiquetaTxtbx.TabIndex = 14;
            // 
            // ipTextbox
            // 
            ipTextbox.BackColor = SystemColors.Control;
            ipTextbox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ipTextbox.Location = new Point(144, 28);
            ipTextbox.Name = "ipTextbox";
            ipTextbox.Size = new Size(209, 33);
            ipTextbox.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 125);
            label8.Name = "label8";
            label8.Size = new Size(105, 21);
            label8.TabIndex = 11;
            label8.Text = "Texto etiqueta";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(324, 104);
            label9.Name = "label9";
            label9.Size = new Size(0, 21);
            label9.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(213, 104);
            label10.Name = "label10";
            label10.Size = new Size(0, 21);
            label10.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(18, 104);
            label11.Name = "label11";
            label11.Size = new Size(0, 21);
            label11.TabIndex = 8;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(18, 72);
            label12.Name = "label12";
            label12.Size = new Size(34, 21);
            label12.TabIndex = 7;
            label12.Text = "DPI";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(18, 31);
            label13.Name = "label13";
            label13.Size = new Size(23, 21);
            label13.TabIndex = 6;
            label13.Text = "IP";
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(1460, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(269, 110);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            // 
            // BtnReturn
            // 
            BtnReturn.Anchor = AnchorStyles.None;
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.Cursor = Cursors.Hand;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(50, 16);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(216, 150);
            BtnReturn.TabIndex = 22;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // PrintConfForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1755, 1061);
            Controls.Add(BtnReturn);
            Controls.Add(pictureBox3);
            Controls.Add(configMenu);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "PrintConfForm";
            Text = "PrintConfForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            configMenu.ResumeLayout(false);
            configMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label7;
        private Button button1;
        private GroupBox configMenu;
        private TextBox dpiTxtbx;
        private TextBox etiquetaTxtbx;
        private TextBox ipTextbox;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button button3;
        private Button button2;
        private Label currYLabel;
        private Label currXLabel;
        private Label currDpiLabel;
        private Label currIpLabel;
        private PictureBox pictureBox3;
        private Button BtnReturn;
        private Label currLabTxt;
    }
}