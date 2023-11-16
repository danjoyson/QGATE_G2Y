namespace prodProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            opeTxtBox = new TextBox();
            label1 = new Label();
            btn1 = new Button();
            label2 = new Label();
            piezaTxtBox = new TextBox();
            BtnOpChange = new Button();
            messageLabel = new Label();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // opeTxtBox
            // 
            opeTxtBox.Anchor = AnchorStyles.None;
            opeTxtBox.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            opeTxtBox.Location = new Point(427, 292);
            opeTxtBox.Name = "opeTxtBox";
            opeTxtBox.Size = new Size(731, 54);
            opeTxtBox.TabIndex = 0;
            opeTxtBox.TextAlign = HorizontalAlignment.Center;
            opeTxtBox.TextChanged += OpeTxtBox_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(656, 217);
            label1.Name = "label1";
            label1.Size = new Size(252, 33);
            label1.TabIndex = 1;
            label1.Text = "Número de operador";
            label1.Click += label1_Click;
            // 
            // btn1
            // 
            btn1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn1.BackColor = Color.Green;
            btn1.Cursor = Cursors.Hand;
            btn1.FlatAppearance.BorderColor = Color.Chartreuse;
            btn1.FlatAppearance.BorderSize = 10;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.Font = new Font("Calibri", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btn1.ForeColor = SystemColors.ButtonHighlight;
            btn1.Location = new Point(1067, 694);
            btn1.Name = "btn1";
            btn1.Size = new Size(334, 232);
            btn1.TabIndex = 2;
            btn1.Text = "Comenzar";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += btn1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(667, 448);
            label2.Name = "label2";
            label2.Size = new Size(207, 33);
            label2.TabIndex = 3;
            label2.Text = "Etiqueta de pieza";
            label2.Click += label2_Click;
            // 
            // piezaTxtBox
            // 
            piezaTxtBox.Anchor = AnchorStyles.None;
            piezaTxtBox.CharacterCasing = CharacterCasing.Upper;
            piezaTxtBox.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            piezaTxtBox.Location = new Point(427, 514);
            piezaTxtBox.MaxLength = 40;
            piezaTxtBox.Name = "piezaTxtBox";
            piezaTxtBox.Size = new Size(731, 54);
            piezaTxtBox.TabIndex = 4;
            piezaTxtBox.TextAlign = HorizontalAlignment.Center;
            piezaTxtBox.TextChanged += PiezaTxtBox_TextChanged;
            // 
            // BtnOpChange
            // 
            BtnOpChange.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnOpChange.BackColor = Color.Gold;
            BtnOpChange.Cursor = Cursors.Hand;
            BtnOpChange.FlatStyle = FlatStyle.Popup;
            BtnOpChange.Font = new Font("Calibri", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            BtnOpChange.Location = new Point(225, 694);
            BtnOpChange.Name = "BtnOpChange";
            BtnOpChange.Size = new Size(328, 232);
            BtnOpChange.TabIndex = 5;
            BtnOpChange.Text = "Borrar texto";
            BtnOpChange.UseVisualStyleBackColor = false;
            BtnOpChange.Click += BtnOpChange_Click;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.Location = new Point(448, 311);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(0, 23);
            messageLabel.TabIndex = 7;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Dock = DockStyle.Top;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(1539, 129);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1539, 1057);
            Controls.Add(pictureBox3);
            Controls.Add(messageLabel);
            Controls.Add(BtnOpChange);
            Controls.Add(piezaTxtBox);
            Controls.Add(label2);
            Controls.Add(btn1);
            Controls.Add(label1);
            Controls.Add(opeTxtBox);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "  Inicio";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox opeTxtBox;
        private Label label1;
        private Button btn1;
        private Label label2;
        private TextBox piezaTxtBox;
        private Button BtnOpChange;
        private Label messageLabel;
        private PictureBox pictureBox3;
    }
}