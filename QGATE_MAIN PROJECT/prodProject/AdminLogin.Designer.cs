namespace prodProject
{
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            label1 = new Label();
            label2 = new Label();
            userTxtBox = new TextBox();
            passwordTxtBox = new TextBox();
            BtnLogin = new Button();
            BtnReturn = new Button();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(456, 152);
            label1.Name = "label1";
            label1.Size = new Size(102, 32);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(440, 320);
            label2.Name = "label2";
            label2.Size = new Size(143, 32);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // userTxtBox
            // 
            userTxtBox.Anchor = AnchorStyles.None;
            userTxtBox.CharacterCasing = CharacterCasing.Upper;
            userTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            userTxtBox.Location = new Point(254, 187);
            userTxtBox.Name = "userTxtBox";
            userTxtBox.Size = new Size(512, 43);
            userTxtBox.TabIndex = 2;
            userTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Anchor = AnchorStyles.None;
            passwordTxtBox.CharacterCasing = CharacterCasing.Upper;
            passwordTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTxtBox.Location = new Point(254, 366);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.PasswordChar = '*';
            passwordTxtBox.Size = new Size(512, 43);
            passwordTxtBox.TabIndex = 3;
            passwordTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnLogin
            // 
            BtnLogin.Anchor = AnchorStyles.None;
            BtnLogin.AutoSize = true;
            BtnLogin.BackColor = Color.Khaki;
            BtnLogin.FlatStyle = FlatStyle.Popup;
            BtnLogin.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnLogin.Location = new Point(409, 575);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(174, 103);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "Acceder";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.Anchor = AnchorStyles.None;
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.Cursor = Cursors.Hand;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(12, 12);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(133, 113);
            BtnReturn.TabIndex = 5;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(704, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(235, 93);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 690);
            ControlBox = false;
            Controls.Add(pictureBox3);
            Controls.Add(BtnReturn);
            Controls.Add(BtnLogin);
            Controls.Add(passwordTxtBox);
            Controls.Add(userTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login de configuración";
            Load += AdminLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox userTxtBox;
        private TextBox passwordTxtBox;
        private Button BtnLogin;
        private Button BtnReturn;
        private PictureBox pictureBox3;
    }
}