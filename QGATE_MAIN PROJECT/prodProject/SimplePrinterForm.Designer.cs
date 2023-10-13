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
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // BtnPrintTest
            // 
            BtnPrintTest.BackColor = SystemColors.ActiveCaption;
            BtnPrintTest.FlatStyle = FlatStyle.Popup;
            BtnPrintTest.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnPrintTest.Location = new Point(53, 191);
            BtnPrintTest.Name = "BtnPrintTest";
            BtnPrintTest.Size = new Size(249, 192);
            BtnPrintTest.TabIndex = 0;
            BtnPrintTest.Text = "Impresión de prueba";
            BtnPrintTest.UseVisualStyleBackColor = false;
            BtnPrintTest.Click += BtnPrintTest_Click;
            // 
            // BtnPrintLastLabel
            // 
            BtnPrintLastLabel.BackColor = Color.Khaki;
            BtnPrintLastLabel.FlatStyle = FlatStyle.Popup;
            BtnPrintLastLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnPrintLastLabel.Location = new Point(553, 191);
            BtnPrintLastLabel.Name = "BtnPrintLastLabel";
            BtnPrintLastLabel.Size = new Size(258, 192);
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
            BtnReturn.Location = new Point(12, 12);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(107, 109);
            BtnReturn.TabIndex = 3;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(166, 430);
            label1.Name = "label1";
            label1.Size = new Size(534, 32);
            label1.TabIndex = 4;
            label1.Text = "No se ha realizado una impresión previa todavía.";
            label1.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(595, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(216, 71);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // SimplePrinterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 490);
            ControlBox = false;
            Controls.Add(pictureBox3);
            Controls.Add(label1);
            Controls.Add(BtnReturn);
            Controls.Add(BtnPrintLastLabel);
            Controls.Add(BtnPrintTest);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SimplePrinterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SimplePrinterForm";
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
    }
}