namespace prodProject
{
    partial class AddOperadorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOperadorForm));
            NumOpTxtBox = new TextBox();
            NameOpTxtBox = new TextBox();
            SurnameOpTxtBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            BtnAddOperator = new Button();
            BtnReturn = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // NumOpTxtBox
            // 
            NumOpTxtBox.Anchor = AnchorStyles.None;
            NumOpTxtBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            NumOpTxtBox.Location = new Point(584, 167);
            NumOpTxtBox.Name = "NumOpTxtBox";
            NumOpTxtBox.Size = new Size(461, 39);
            NumOpTxtBox.TabIndex = 0;
            // 
            // NameOpTxtBox
            // 
            NameOpTxtBox.Anchor = AnchorStyles.None;
            NameOpTxtBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            NameOpTxtBox.Location = new Point(584, 274);
            NameOpTxtBox.Name = "NameOpTxtBox";
            NameOpTxtBox.Size = new Size(461, 39);
            NameOpTxtBox.TabIndex = 1;
            // 
            // SurnameOpTxtBox
            // 
            SurnameOpTxtBox.Anchor = AnchorStyles.None;
            SurnameOpTxtBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            SurnameOpTxtBox.Location = new Point(584, 397);
            SurnameOpTxtBox.Name = "SurnameOpTxtBox";
            SurnameOpTxtBox.Size = new Size(461, 39);
            SurnameOpTxtBox.TabIndex = 2;
            SurnameOpTxtBox.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(199, 160);
            label1.Name = "label1";
            label1.Size = new Size(339, 50);
            label1.TabIndex = 3;
            label1.Text = "Número de operador";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(218, 267);
            label2.Name = "label2";
            label2.Size = new Size(284, 50);
            label2.TabIndex = 4;
            label2.Text = "Primer nombre";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(218, 390);
            label3.Name = "label3";
            label3.Size = new Size(263, 51);
            label3.TabIndex = 5;
            label3.Text = "Primer apellido";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackgroundImage = Properties.Resources.OpIcon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(526, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(385, 103);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // BtnAddOperator
            // 
            BtnAddOperator.Anchor = AnchorStyles.Bottom;
            BtnAddOperator.BackColor = Color.LimeGreen;
            BtnAddOperator.FlatStyle = FlatStyle.Popup;
            BtnAddOperator.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BtnAddOperator.Location = new Point(467, 559);
            BtnAddOperator.Name = "BtnAddOperator";
            BtnAddOperator.Size = new Size(230, 120);
            BtnAddOperator.TabIndex = 7;
            BtnAddOperator.Text = "Agregar";
            BtnAddOperator.UseVisualStyleBackColor = false;
            BtnAddOperator.Click += BtnAddOperator_Click;
            // 
            // BtnReturn
            // 
            BtnReturn.AutoSize = true;
            BtnReturn.BackgroundImage = Properties.Resources._return;
            BtnReturn.BackgroundImageLayout = ImageLayout.Zoom;
            BtnReturn.Cursor = Cursors.Hand;
            BtnReturn.FlatStyle = FlatStyle.Popup;
            BtnReturn.Location = new Point(3, 2);
            BtnReturn.Name = "BtnReturn";
            BtnReturn.Size = new Size(105, 103);
            BtnReturn.TabIndex = 8;
            BtnReturn.UseVisualStyleBackColor = true;
            BtnReturn.Click += BtnReturn_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(917, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(232, 103);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // AddOperadorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 691);
            ControlBox = false;
            Controls.Add(pictureBox2);
            Controls.Add(BtnReturn);
            Controls.Add(BtnAddOperator);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SurnameOpTxtBox);
            Controls.Add(NameOpTxtBox);
            Controls.Add(NumOpTxtBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddOperadorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Añadir nuevo operador";
            Load += AddOperadorForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NumOpTxtBox;
        private TextBox NameOpTxtBox;
        private TextBox SurnameOpTxtBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private Button BtnAddOperator;
        private Button BtnReturn;
        private PictureBox pictureBox2;
    }
}