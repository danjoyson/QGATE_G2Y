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
            BtnReturn = new Button();
            label1 = new Label();
            numOpTxtBox = new TextBox();
            BtnDelete = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BtnReturn
            // 
            BtnReturn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(12, 12);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(118, 113);
            BtnReturn.TabIndex = 0;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(48, 188);
            label1.Name = "label1";
            label1.Size = new Size(239, 50);
            label1.TabIndex = 1;
            label1.Text = "Número de operador a\r\neliminar en Base de Datos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numOpTxtBox
            // 
            numOpTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numOpTxtBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            numOpTxtBox.Location = new Point(329, 192);
            numOpTxtBox.Name = "numOpTxtBox";
            numOpTxtBox.Size = new Size(433, 39);
            numOpTxtBox.TabIndex = 2;
            numOpTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnDelete
            // 
            BtnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnDelete.BackColor = Color.Red;
            BtnDelete.Cursor = Cursors.Hand;
            BtnDelete.FlatStyle = FlatStyle.Popup;
            BtnDelete.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnDelete.Location = new Point(317, 343);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(218, 106);
            BtnDelete.TabIndex = 3;
            BtnDelete.Text = "Eliminar";
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackgroundImage = Properties.Resources.OpIcon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(721, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(110, 119);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // DeleteOperadorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 466);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(BtnDelete);
            Controls.Add(numOpTxtBox);
            Controls.Add(label1);
            Controls.Add(BtnReturn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "DeleteOperadorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Borrar operador";
            Load += DeleteOperadorForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnReturn;
        private Label label1;
        private TextBox numOpTxtBox;
        private Button BtnDelete;
        private PictureBox pictureBox1;
    }
}