namespace prodProject
{
    partial class Form4_Blocker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4_Blocker));
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            BtnUnblock = new Button();
            BtnReSend = new Button();
            messageLabel = new Label();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ScrollBar;
            label1.Font = new Font("Calibri", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(494, 41);
            label1.Name = "label1";
            label1.Size = new Size(501, 90);
            label1.TabIndex = 0;
            label1.Text = "La aplicación se ha bloqueado. \r\nComuníquese con un supervisor.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(318, 193);
            label2.Name = "label2";
            label2.Size = new Size(886, 50);
            label2.TabIndex = 1;
            label2.Text = "Motivo: La misma pieza ha presentado 3 fallas (NOK)";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            textBox1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.ActiveCaptionText;
            textBox1.Location = new Point(573, 481);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(325, 71);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(363, 330);
            label3.Name = "label3";
            label3.Size = new Size(774, 130);
            label3.TabIndex = 3;
            label3.Text = "Ingrese el código de desbloqueo \r\nenviado por correo";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Click += label3_Click;
            // 
            // BtnUnblock
            // 
            BtnUnblock.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnUnblock.BackColor = Color.ForestGreen;
            BtnUnblock.FlatStyle = FlatStyle.Popup;
            BtnUnblock.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnUnblock.ForeColor = SystemColors.ButtonHighlight;
            BtnUnblock.Location = new Point(1127, 733);
            BtnUnblock.Name = "BtnUnblock";
            BtnUnblock.Size = new Size(312, 243);
            BtnUnblock.TabIndex = 4;
            BtnUnblock.Text = "Desbloquear";
            BtnUnblock.UseVisualStyleBackColor = false;
            BtnUnblock.Click += BtnUnblock_Click;
            // 
            // BtnReSend
            // 
            BtnReSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnReSend.BackColor = Color.SteelBlue;
            BtnReSend.FlatStyle = FlatStyle.Popup;
            BtnReSend.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            BtnReSend.ForeColor = SystemColors.ButtonHighlight;
            BtnReSend.Location = new Point(27, 746);
            BtnReSend.Name = "BtnReSend";
            BtnReSend.Size = new Size(332, 230);
            BtnReSend.TabIndex = 5;
            BtnReSend.Text = "Reenviar\r\ncódigo";
            BtnReSend.UseVisualStyleBackColor = false;
            BtnReSend.Click += BtnReSend_Click;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.Location = new Point(618, 560);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(0, 32);
            messageLabel.TabIndex = 6;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(1174, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(265, 97);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // Form4_Blocker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.ScrollBar;
            ClientSize = new Size(1453, 988);
            ControlBox = false;
            Controls.Add(pictureBox3);
            Controls.Add(messageLabel);
            Controls.Add(BtnReSend);
            Controls.Add(BtnUnblock);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form4_Blocker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aplicación Bloqueada";
            WindowState = FormWindowState.Maximized;
            Load += Form4_Blocker_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Button BtnUnblock;
        private Button BtnReSend;
        private Label messageLabel;
        private PictureBox pictureBox3;
    }
}