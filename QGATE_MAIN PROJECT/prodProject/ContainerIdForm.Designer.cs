﻿namespace prodProject
{
    partial class ContainerIdForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainerIdForm));
            pictureBox3 = new PictureBox();
            label1 = new Label();
            containerTxtBox = new TextBox();
            btnContainer = new Button();
            containerIdMessage = new Label();
            label2 = new Label();
            comboBoxEstandar = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Dock = DockStyle.Top;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(1302, 78);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 22;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(124, 126);
            label1.Name = "label1";
            label1.Size = new Size(198, 45);
            label1.TabIndex = 23;
            label1.Text = "Container ID";
            // 
            // containerTxtBox
            // 
            containerTxtBox.Anchor = AnchorStyles.None;
            containerTxtBox.CharacterCasing = CharacterCasing.Upper;
            containerTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            containerTxtBox.Location = new Point(413, 126);
            containerTxtBox.MaxLength = 400;
            containerTxtBox.Name = "containerTxtBox";
            containerTxtBox.Size = new Size(667, 43);
            containerTxtBox.TabIndex = 24;
            containerTxtBox.TextAlign = HorizontalAlignment.Center;
            containerTxtBox.TextChanged += containerTxtBox_TextChanged;
            // 
            // btnContainer
            // 
            btnContainer.Anchor = AnchorStyles.None;
            btnContainer.BackColor = Color.Lime;
            btnContainer.Cursor = Cursors.Hand;
            btnContainer.FlatAppearance.BorderColor = Color.Chartreuse;
            btnContainer.FlatAppearance.BorderSize = 10;
            btnContainer.FlatStyle = FlatStyle.Popup;
            btnContainer.Font = new Font("Calibri", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnContainer.Location = new Point(562, 406);
            btnContainer.Name = "btnContainer";
            btnContainer.Size = new Size(228, 157);
            btnContainer.TabIndex = 25;
            btnContainer.Text = "Comenzar";
            btnContainer.UseVisualStyleBackColor = false;
            btnContainer.Click += btnContainer_Click;
            // 
            // containerIdMessage
            // 
            containerIdMessage.AutoSize = true;
            containerIdMessage.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            containerIdMessage.Location = new Point(341, 172);
            containerIdMessage.Name = "containerIdMessage";
            containerIdMessage.Size = new Size(0, 32);
            containerIdMessage.TabIndex = 26;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(154, 269);
            label2.Name = "label2";
            label2.Size = new Size(141, 45);
            label2.TabIndex = 27;
            label2.Text = "Estandar";
            // 
            // comboBoxEstandar
            // 
            comboBoxEstandar.Anchor = AnchorStyles.None;
            comboBoxEstandar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstandar.DropDownWidth = 140;
            comboBoxEstandar.Font = new Font("Arial Narrow", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEstandar.FormattingEnabled = true;
            comboBoxEstandar.ItemHeight = 33;
            comboBoxEstandar.Items.AddRange(new object[] { "México", "China" });
            comboBoxEstandar.Location = new Point(492, 275);
            comboBoxEstandar.Name = "comboBoxEstandar";
            comboBoxEstandar.Size = new Size(513, 41);
            comboBoxEstandar.TabIndex = 28;
            comboBoxEstandar.SelectedIndexChanged += comboBoxEstandar_SelectedIndexChanged;
            // 
            // ContainerIdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1302, 668);
            Controls.Add(comboBoxEstandar);
            Controls.Add(label2);
            Controls.Add(containerIdMessage);
            Controls.Add(btnContainer);
            Controls.Add(containerTxtBox);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ContainerIdForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ContainerIdForm";
            WindowState = FormWindowState.Maximized;
            Load += ContainerIdForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox3;
        private Label label1;
        private TextBox containerTxtBox;
        private Button btnContainer;
        private Label containerIdMessage;
        private Label label2;
        private ComboBox comboBoxEstandar;
    }
}