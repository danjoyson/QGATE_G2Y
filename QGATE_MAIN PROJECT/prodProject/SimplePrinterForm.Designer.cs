namespace prodProject
{
    partial class SimplePrinterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimplePrinterForm));
            BtnPrintTest = new Button();
            BtnPrintLastLabel = new Button();
            BtnReturn = new Button();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // BtnPrintTest
            // 
            BtnPrintTest.Anchor = AnchorStyles.None;
            BtnPrintTest.BackColor = Color.SteelBlue;
            BtnPrintTest.FlatStyle = FlatStyle.Popup;
            BtnPrintTest.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            BtnPrintTest.ForeColor = SystemColors.ButtonFace;
            BtnPrintTest.Location = new Point(262, 270);
            BtnPrintTest.Name = "BtnPrintTest";
            BtnPrintTest.Size = new Size(978, 110);
            BtnPrintTest.TabIndex = 0;
            BtnPrintTest.Text = "Impresión de prueba";
            BtnPrintTest.UseVisualStyleBackColor = false;
            BtnPrintTest.Click += BtnPrintTest_Click;
            // 
            // BtnPrintLastLabel
            // 
            BtnPrintLastLabel.Anchor = AnchorStyles.None;
            BtnPrintLastLabel.BackColor = Color.SteelBlue;
            BtnPrintLastLabel.FlatStyle = FlatStyle.Popup;
            BtnPrintLastLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            BtnPrintLastLabel.ForeColor = SystemColors.Window;
            BtnPrintLastLabel.Location = new Point(262, 587);
            BtnPrintLastLabel.Name = "BtnPrintLastLabel";
            BtnPrintLastLabel.Size = new Size(978, 111);
            BtnPrintLastLabel.TabIndex = 1;
            BtnPrintLastLabel.Text = "Reimprimir última etiqueta impresa";
            BtnPrintLastLabel.UseVisualStyleBackColor = false;
            BtnPrintLastLabel.Click += BtnPrintLastLabel_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.Cursor = Cursors.Hand;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(42, 22);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(192, 148);
            BtnReturn.TabIndex = 3;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(450, 886);
            label1.Name = "label1";
            label1.Size = new Size(534, 32);
            label1.TabIndex = 4;
            label1.Text = "No se ha realizado una impresión previa todavía.";
            label1.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(1221, 27);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(281, 156);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.SteelBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(262, 428);
            button1.Name = "button1";
            button1.Size = new Size(978, 112);
            button1.TabIndex = 21;
            button1.Text = "Configurar impresora";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // SimplePrinterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1544, 1061);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            Controls.Add(BtnReturn);
            Controls.Add(BtnPrintLastLabel);
            Controls.Add(BtnPrintTest);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SimplePrinterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SimplePrinterForm";
            WindowState = FormWindowState.Maximized;
            Load += SimplePrinterForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnPrintTest;
        private Button BtnPrintLastLabel;
        private Button BtnReturn;
        private Label label1;
        private PictureBox pictureBox3;
        private Button button1;
    }
}