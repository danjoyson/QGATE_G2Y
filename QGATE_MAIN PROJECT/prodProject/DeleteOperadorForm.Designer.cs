namespace prodProject
{
    partial class DeleteOperadorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteOperadorForm));
            BtnReturn = new Button();
            label1 = new Label();
            numOpTxtBox = new TextBox();
            BtnDelete = new Button();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // BtnReturn
            // 
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(12, 12);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(346, 170);
            BtnReturn.TabIndex = 0;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(113, 456);
            label1.Name = "label1";
            label1.Size = new Size(265, 60);
            label1.TabIndex = 1;
            label1.Text = "Número de operador a\r\neliminar en Base de Datos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numOpTxtBox
            // 
            numOpTxtBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numOpTxtBox.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            numOpTxtBox.Location = new Point(400, 456);
            numOpTxtBox.Name = "numOpTxtBox";
            numOpTxtBox.Size = new Size(1065, 54);
            numOpTxtBox.TabIndex = 2;
            numOpTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnDelete
            // 
            BtnDelete.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnDelete.BackColor = Color.Red;
            BtnDelete.Cursor = Cursors.Hand;
            BtnDelete.FlatStyle = FlatStyle.Popup;
            BtnDelete.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDelete.ForeColor = SystemColors.ButtonHighlight;
            BtnDelete.Location = new Point(471, 666);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(826, 138);
            BtnDelete.TabIndex = 3;
            BtnDelete.Text = "Eliminar";
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackgroundImage = Properties.Resources.OpIcon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(1007, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 135);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(1303, 31);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(230, 88);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // DeleteOperadorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1545, 1015);
            ControlBox = false;
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(BtnDelete);
            Controls.Add(numOpTxtBox);
            Controls.Add(label1);
            Controls.Add(BtnReturn);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DeleteOperadorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Borrar operador";
            WindowState = FormWindowState.Maximized;
            Load += DeleteOperadorForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnReturn;
        private Label label1;
        private TextBox numOpTxtBox;
        private Button BtnDelete;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
    }
}