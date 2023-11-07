namespace prodProject
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
            BtnSettings = new Button();
            estandarLabel = new Label();
            configEstandar = new GroupBox();
            setEstandar = new Button();
            comboBoxEstandar = new ComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            configEstandar.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Enabled = false;
            pictureBox3.Location = new Point(1128, 23);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(287, 153);
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
            label1.Location = new Point(199, 296);
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
            containerTxtBox.Location = new Point(476, 302);
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
            btnContainer.BackColor = Color.Green;
            btnContainer.Cursor = Cursors.Hand;
            btnContainer.FlatAppearance.BorderColor = Color.Chartreuse;
            btnContainer.FlatAppearance.BorderSize = 10;
            btnContainer.FlatStyle = FlatStyle.Popup;
            btnContainer.Font = new Font("Calibri", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnContainer.ForeColor = SystemColors.ButtonHighlight;
            btnContainer.Location = new Point(619, 635);
            btnContainer.Name = "btnContainer";
            btnContainer.Size = new Size(256, 171);
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
            label2.Location = new Point(464, 394);
            label2.Name = "label2";
            label2.Size = new Size(141, 45);
            label2.TabIndex = 27;
            label2.Text = "Estandar";
            // 
            // BtnSettings
            // 
            BtnSettings.BackColor = SystemColors.ControlLight;
            BtnSettings.BackgroundImage = Properties.Resources.settings;
            BtnSettings.BackgroundImageLayout = ImageLayout.Zoom;
            BtnSettings.Cursor = Cursors.Hand;
            BtnSettings.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 192);
            BtnSettings.FlatStyle = FlatStyle.Popup;
            BtnSettings.Location = new Point(23, 12);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Size = new Size(249, 181);
            BtnSettings.TabIndex = 29;
            BtnSettings.Text = " ";
            BtnSettings.UseVisualStyleBackColor = false;
            BtnSettings.Click += BtnSettings_Click;
            // 
            // estandarLabel
            // 
            estandarLabel.Anchor = AnchorStyles.None;
            estandarLabel.AutoSize = true;
            estandarLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            estandarLabel.ForeColor = Color.Red;
            estandarLabel.Location = new Point(708, 394);
            estandarLabel.Name = "estandarLabel";
            estandarLabel.Size = new Size(164, 50);
            estandarLabel.TabIndex = 30;
            estandarLabel.Text = "Estandar";
            // 
            // configEstandar
            // 
            configEstandar.Anchor = AnchorStyles.None;
            configEstandar.Controls.Add(setEstandar);
            configEstandar.Controls.Add(comboBoxEstandar);
            configEstandar.Location = new Point(506, 451);
            configEstandar.Name = "configEstandar";
            configEstandar.Size = new Size(422, 100);
            configEstandar.TabIndex = 31;
            configEstandar.TabStop = false;
            configEstandar.Text = "Configurar Estandar";
            // 
            // setEstandar
            // 
            setEstandar.BackColor = Color.LightBlue;
            setEstandar.FlatStyle = FlatStyle.Popup;
            setEstandar.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            setEstandar.Location = new Point(291, 13);
            setEstandar.Name = "setEstandar";
            setEstandar.Size = new Size(125, 81);
            setEstandar.TabIndex = 6;
            setEstandar.Text = "OK";
            setEstandar.UseVisualStyleBackColor = false;
            setEstandar.Click += setEstandar_Click;
            // 
            // comboBoxEstandar
            // 
            comboBoxEstandar.Anchor = AnchorStyles.None;
            comboBoxEstandar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEstandar.DropDownWidth = 140;
            comboBoxEstandar.Font = new Font("Arial Narrow", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxEstandar.FormattingEnabled = true;
            comboBoxEstandar.ItemHeight = 42;
            comboBoxEstandar.Items.AddRange(new object[] { "México", "China" });
            comboBoxEstandar.Location = new Point(20, 22);
            comboBoxEstandar.Name = "comboBoxEstandar";
            comboBoxEstandar.Size = new Size(265, 50);
            comboBoxEstandar.TabIndex = 29;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = SystemColors.GradientInactiveCaption;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(1238, 815);
            button1.Name = "button1";
            button1.Size = new Size(155, 102);
            button1.TabIndex = 32;
            button1.Text = "Configurar Estandar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ContainerIdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 943);
            Controls.Add(button1);
            Controls.Add(configEstandar);
            Controls.Add(estandarLabel);
            Controls.Add(BtnSettings);
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
            configEstandar.ResumeLayout(false);
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
        private Button BtnSettings;
        private Label estandarLabel;
        private GroupBox configEstandar;
        private Button setEstandar;
        private ComboBox comboBoxEstandar;
        private Button button1;
    }
}