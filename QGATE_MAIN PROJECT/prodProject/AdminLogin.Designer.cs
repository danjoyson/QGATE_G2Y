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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(876, 423);
            label1.Name = "label1";
            label1.Size = new Size(102, 32);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(876, 602);
            label2.Name = "label2";
            label2.Size = new Size(143, 32);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // userTxtBox
            // 
            userTxtBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            userTxtBox.CharacterCasing = CharacterCasing.Upper;
            userTxtBox.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            userTxtBox.Location = new Point(345, 472);
            userTxtBox.Name = "userTxtBox";
            userTxtBox.Size = new Size(1012, 50);
            userTxtBox.TabIndex = 2;
            userTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            passwordTxtBox.CharacterCasing = CharacterCasing.Upper;
            passwordTxtBox.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTxtBox.Location = new Point(345, 653);
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.PasswordChar = '*';
            passwordTxtBox.Size = new Size(1012, 50);
            passwordTxtBox.TabIndex = 3;
            passwordTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // BtnLogin
            // 
            BtnLogin.Anchor = AnchorStyles.None;
            BtnLogin.AutoSize = true;
            BtnLogin.BackColor = Color.Orange;
            BtnLogin.FlatStyle = FlatStyle.Popup;
            BtnLogin.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnLogin.Location = new Point(713, 830);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(418, 191);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "Acceder";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.Cursor = Cursors.Hand;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(12, 12);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(208, 151);
            BtnReturn.TabIndex = 5;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(1354, 23);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(299, 151);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources.login2;
            pictureBox1.Location = new Point(798, 156);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(180, 174);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1678, 1057);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Controls.Add(BtnReturn);
            Controls.Add(BtnLogin);
            Controls.Add(passwordTxtBox);
            Controls.Add(userTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login de configuración";
            Load += AdminLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}