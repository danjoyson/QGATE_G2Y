﻿namespace prodProject
{
    partial class Form3
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
            BtnOK = new Button();
            BtnNOK = new Button();
            pictureBox1 = new PictureBox();
            txtEtiqueta = new TextBox();
            messageLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // BtnOK
            // 
            BtnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            BtnOK.BackColor = Color.Transparent;
            BtnOK.Cursor = Cursors.Hand;
            BtnOK.FlatStyle = FlatStyle.Popup;
            BtnOK.Location = new Point(58, 601);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(230, 119);
            BtnOK.TabIndex = 0;
            BtnOK.UseVisualStyleBackColor = false;
            BtnOK.Click += BtnOK_Click;
            // 
            // BtnNOK
            // 
            BtnNOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnNOK.BackColor = Color.Transparent;
            BtnNOK.Cursor = Cursors.Hand;
            BtnNOK.FlatStyle = FlatStyle.Popup;
            BtnNOK.Location = new Point(1111, 596);
            BtnNOK.Name = "BtnNOK";
            BtnNOK.Size = new Size(223, 128);
            BtnNOK.TabIndex = 1;
            BtnNOK.UseVisualStyleBackColor = false;
            BtnNOK.Click += BtnNOK_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom;
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Location = new Point(313, 586);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(783, 128);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // txtEtiqueta
            // 
            txtEtiqueta.Anchor = AnchorStyles.Bottom;
            txtEtiqueta.BackColor = Color.PaleGoldenrod;
            txtEtiqueta.BorderStyle = BorderStyle.FixedSingle;
            txtEtiqueta.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            txtEtiqueta.Location = new Point(324, 601);
            txtEtiqueta.MaxLength = 40;
            txtEtiqueta.Name = "txtEtiqueta";
            txtEtiqueta.Size = new Size(760, 54);
            txtEtiqueta.TabIndex = 8;
            txtEtiqueta.TextAlign = HorizontalAlignment.Center;
            txtEtiqueta.Visible = false;
            // 
            // messageLabel
            // 
            messageLabel.Anchor = AnchorStyles.Bottom;
            messageLabel.AutoSize = true;
            messageLabel.BackColor = Color.White;
            messageLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.Location = new Point(438, 658);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(528, 32);
            messageLabel.TabIndex = 9;
            messageLabel.Text = "Seleccione la caja de texto y escanee la etiqueta";
            messageLabel.Visible = false;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1370, 749);
            ControlBox = false;
            Controls.Add(messageLabel);
            Controls.Add(txtEtiqueta);
            Controls.Add(pictureBox1);
            Controls.Add(BtnNOK);
            Controls.Add(BtnOK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Revisión";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnOK;
        private Button BtnNOK;
        private PictureBox pictureBox1;
        private TextBox txtEtiqueta;
        private Label messageLabel;
    }
}