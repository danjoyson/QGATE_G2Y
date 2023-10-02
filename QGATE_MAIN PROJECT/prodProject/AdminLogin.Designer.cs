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
            label1 = new Label();
            label2 = new Label();
            userTxtBox = new TextBox();
            passwordTxtBox = new TextBox();
            BtnLogin = new Button();
            BtnReturn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(274, 73);
            label1.Name = "label1";
            label1.Size = new Size(102, 32);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(244, 236);
            label2.Name = "label2";
            label2.Size = new Size(143, 32);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // userTxtBox
            // 
            userTxtBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            userTxtBox.CharacterCasing = CharacterCasing.Upper;
            userTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            userTxtBox.Location = new Point(152, 108);
            userTxtBox.Name = "userTxtBox";
            userTxtBox.Size = new Size(327, 43);
            userTxtBox.TabIndex = 2;
            userTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            passwordTxtBox.CharacterCasing = CharacterCasing.Upper;
            passwordTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTxtBox.Location = new Point(152, 283);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.PasswordChar = '*';
            passwordTxtBox.Size = new Size(327, 43);
            passwordTxtBox.TabIndex = 3;
            passwordTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnLogin
            // 
            BtnLogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnLogin.BackColor = Color.Khaki;
            BtnLogin.FlatStyle = FlatStyle.Popup;
            BtnLogin.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnLogin.Location = new Point(230, 406);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(174, 103);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "Acceder";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.Cursor = Cursors.Hand;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(12, 12);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(94, 93);
            BtnReturn.TabIndex = 5;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 521);
            ControlBox = false;
            Controls.Add(BtnReturn);
            Controls.Add(BtnLogin);
            Controls.Add(passwordTxtBox);
            Controls.Add(userTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AdminLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login de configuración";
            Load += AdminLogin_Load;
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
    }
}