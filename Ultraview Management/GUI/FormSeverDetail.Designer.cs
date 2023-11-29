namespace Ultraview_Management.GUI
{
    partial class FormSeverDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSeverDetail));
            button2 = new Button();
            textBoxPassword = new TextBox();
            label3 = new Label();
            textBoxUsername = new TextBox();
            label2 = new Label();
            button1 = new Button();
            textBoxName = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(234, 106);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(82, 68);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(227, 23);
            textBoxPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 71);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 13;
            label3.Text = "Password:";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(82, 37);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(227, 23);
            textBoxUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 40);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 11;
            label2.Text = "Username:";
            // 
            // button1
            // 
            button1.Location = new Point(153, 106);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(82, 6);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(227, 23);
            textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 8;
            label1.Text = "Name:";
            // 
            // FormSeverDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 138);
            Controls.Add(button2);
            Controls.Add(textBoxPassword);
            Controls.Add(label3);
            Controls.Add(textBoxUsername);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormSeverDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Sever Detail";
            Load += FormSeverDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private TextBox textBoxPassword;
        private Label label3;
        private TextBox textBoxUsername;
        private Label label2;
        private Button button1;
        private TextBox textBoxName;
        private Label label1;
    }
}