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
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(771, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(116, 42);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 22;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(33, 125);
            label1.Name = "label1";
            label1.Size = new Size(130, 30);
            label1.TabIndex = 23;
            label1.Text = "Container ID";
            // 
            // containerTxtBox
            // 
            containerTxtBox.CharacterCasing = CharacterCasing.Upper;
            containerTxtBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            containerTxtBox.Location = new Point(169, 116);
            containerTxtBox.MaxLength = 40;
            containerTxtBox.Name = "containerTxtBox";
            containerTxtBox.Size = new Size(670, 43);
            containerTxtBox.TabIndex = 24;
            containerTxtBox.TextAlign = HorizontalAlignment.Center;
            containerTxtBox.TextChanged += containerTxtBox_TextChanged;
            // 
            // btnContainer
            // 
            btnContainer.BackColor = Color.Lime;
            btnContainer.Cursor = Cursors.Hand;
            btnContainer.FlatAppearance.BorderColor = Color.Chartreuse;
            btnContainer.FlatAppearance.BorderSize = 10;
            btnContainer.FlatStyle = FlatStyle.Popup;
            btnContainer.Font = new Font("Calibri", 26.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnContainer.Location = new Point(328, 207);
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
            // ContainerIdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 367);
            Controls.Add(containerIdMessage);
            Controls.Add(btnContainer);
            Controls.Add(containerTxtBox);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Name = "ContainerIdForm";
            Text = "ContainerIdForm";
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
    }
}