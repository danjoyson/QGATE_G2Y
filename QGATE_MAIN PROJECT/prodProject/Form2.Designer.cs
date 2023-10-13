namespace prodProject
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            BtnNext = new Button();
            SuspendLayout();
            // 
            // BtnNext
            // 
            BtnNext.BackColor = Color.Transparent;
            BtnNext.Cursor = Cursors.Hand;
            BtnNext.FlatStyle = FlatStyle.Popup;
            BtnNext.ForeColor = SystemColors.ActiveCaptionText;
            BtnNext.Location = new Point(92, 590);
            BtnNext.Name = "BtnNext";
            BtnNext.Size = new Size(565, 119);
            BtnNext.TabIndex = 0;
            BtnNext.UseVisualStyleBackColor = false;
            BtnNext.Click += BtnNext_Click;
            // 
            // Form2
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1366, 745);
            ControlBox = false;
            Controls.Add(BtnNext);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            Load += Form2_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnNext;
    }
}