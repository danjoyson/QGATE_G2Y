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
            opeTxtBox = new TextBox();
            label1 = new Label();
            btn1 = new Button();
            label2 = new Label();
            piezaTxtBox = new TextBox();
            BtnOpChange = new Button();
            BtnSettings = new Button();
            messageLabel = new Label();
            SuspendLayout();
            // 
            // opeTxtBox
            // 
            opeTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            opeTxtBox.Location = new Point(301, 91);
            opeTxtBox.Name = "opeTxtBox";
            opeTxtBox.Size = new Size(480, 43);
            opeTxtBox.TabIndex = 0;
            opeTxtBox.TextAlign = HorizontalAlignment.Center;
            opeTxtBox.TextChanged += OpeTxtBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(431, 41);
            label1.Name = "label1";
            label1.Size = new Size(252, 33);
            label1.TabIndex = 1;
            label1.Text = "Número de operador";
            label1.Click += label1_Click;
            // 
            // btn1
            // 
            btn1.BackColor = Color.Lime;
            btn1.Cursor = Cursors.Hand;
            btn1.FlatAppearance.BorderColor = Color.Chartreuse;
            btn1.FlatAppearance.BorderSize = 10;
            btn1.FlatStyle = FlatStyle.Popup;
            btn1.Font = new Font("Calibri", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btn1.Location = new Point(749, 424);
            btn1.Name = "btn1";
            btn1.Size = new Size(228, 157);
            btn1.TabIndex = 2;
            btn1.Text = "Comenzar";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += btn1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(448, 219);
            label2.Name = "label2";
            label2.Size = new Size(207, 33);
            label2.TabIndex = 3;
            label2.Text = "Etiqueta de pieza";
            label2.Click += label2_Click;
            // 
            // piezaTxtBox
            // 
            piezaTxtBox.CharacterCasing = CharacterCasing.Upper;
            piezaTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            piezaTxtBox.Location = new Point(206, 265);
            piezaTxtBox.MaxLength = 40;
            piezaTxtBox.Name = "piezaTxtBox";
            piezaTxtBox.Size = new Size(670, 43);
            piezaTxtBox.TabIndex = 4;
            piezaTxtBox.TextAlign = HorizontalAlignment.Center;
            piezaTxtBox.TextChanged += PiezaTxtBox_TextChanged;
            // 
            // BtnOpChange
            // 
            BtnOpChange.BackColor = Color.Yellow;
            BtnOpChange.Cursor = Cursors.Hand;
            BtnOpChange.FlatStyle = FlatStyle.Popup;
            BtnOpChange.Font = new Font("Calibri", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            BtnOpChange.Location = new Point(113, 420);
            BtnOpChange.Name = "BtnOpChange";
            BtnOpChange.Size = new Size(240, 164);
            BtnOpChange.TabIndex = 5;
            BtnOpChange.Text = "Borrar texto";
            BtnOpChange.UseVisualStyleBackColor = false;
            BtnOpChange.Click += BtnOpChange_Click;
            // 
            // BtnSettings
            // 
            BtnSettings.BackColor = SystemColors.ControlLight;
            BtnSettings.BackgroundImage = Properties.Resources.settings;
            BtnSettings.BackgroundImageLayout = ImageLayout.Zoom;
            BtnSettings.Cursor = Cursors.Hand;
            BtnSettings.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 192);
            BtnSettings.FlatStyle = FlatStyle.Popup;
            BtnSettings.Location = new Point(12, 12);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Size = new Size(141, 135);
            BtnSettings.TabIndex = 6;
            BtnSettings.Text = " ";
            BtnSettings.UseVisualStyleBackColor = false;
            BtnSettings.Click += BtnSettings_Click;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1097, 654);
            Controls.Add(messageLabel);
            Controls.Add(BtnSettings);
            Controls.Add(BtnOpChange);
            Controls.Add(piezaTxtBox);
            Controls.Add(label2);
            Controls.Add(btn1);
            Controls.Add(label1);
            Controls.Add(opeTxtBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            Load += Form1_Load;
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
        private Button BtnSettings;
        private Label messageLabel;
    }
}