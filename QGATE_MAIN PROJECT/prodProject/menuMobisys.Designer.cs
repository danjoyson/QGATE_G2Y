namespace prodProject
{
    partial class menuMobisys
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            containerIdTxt = new TextBox();
            label7 = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            V1 = new DataGridViewTextBoxColumn();
            label8 = new Label();
            containerIdMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(0, -1);
            button1.Name = "button1";
            button1.Size = new Size(144, 45);
            button1.TabIndex = 0;
            button1.Text = "ESC";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(644, -1);
            button2.Name = "button2";
            button2.Size = new Size(152, 45);
            button2.TabIndex = 1;
            button2.Text = "USER";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Blue;
            button3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.Control;
            button3.Location = new Point(141, -1);
            button3.Name = "button3";
            button3.Size = new Size(506, 45);
            button3.TabIndex = 2;
            button3.Text = "AMBIENTE";
            button3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 47);
            label1.Name = "label1";
            label1.Size = new Size(796, 47);
            label1.TabIndex = 3;
            label1.Text = "Escaneo de Contador\r\nCounter scan";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 117);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 4;
            label2.Text = "Container ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(343, 163);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 5;
            label3.Text = "Material cliente";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 163);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 6;
            label4.Text = "Material";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(12, 224);
            label5.Name = "label5";
            label5.Size = new Size(129, 20);
            label5.TabIndex = 7;
            label5.Text = "Mat. de embalaje";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(322, 224);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 8;
            label6.Text = "Cantidad";
            label6.Click += label6_Click;
            // 
            // containerIdTxt
            // 
            containerIdTxt.Location = new Point(150, 114);
            containerIdTxt.Name = "containerIdTxt";
            containerIdTxt.Size = new Size(229, 23);
            containerIdTxt.TabIndex = 9;
            containerIdTxt.TextChanged += containerIdTxt_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(12, 270);
            label7.Name = "label7";
            label7.Size = new Size(119, 20);
            label7.TabIndex = 10;
            label7.Text = "Componente ID";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(150, 267);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(341, 23);
            textBox2.TabIndex = 11;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { V1 });
            dataGridView1.Location = new Point(12, 311);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(479, 268);
            dataGridView1.TabIndex = 12;
            // 
            // V1
            // 
            V1.HeaderText = "Componente";
            V1.Name = "V1";
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ActiveBorder;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(0, 582);
            label8.Name = "label8";
            label8.Size = new Size(796, 20);
            label8.TabIndex = 13;
            label8.Text = "Scan box";
            // 
            // containerIdMessage
            // 
            containerIdMessage.AutoSize = true;
            containerIdMessage.Location = new Point(232, 140);
            containerIdMessage.Name = "containerIdMessage";
            containerIdMessage.Size = new Size(0, 15);
            containerIdMessage.TabIndex = 14;
            // 
            // menuMobisys
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(794, 603);
            Controls.Add(containerIdMessage);
            Controls.Add(label8);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(containerIdTxt);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "menuMobisys";
            Text = "menuMobisys";
            Load += menuMobisys_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox containerIdTxt;
        private Label label7;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn V1;
        private Label label8;
        private Label containerIdMessage;
    }
}