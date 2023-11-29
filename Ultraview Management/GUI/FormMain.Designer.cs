namespace Ultraview_Management.GUI
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            dataGridView1 = new DataGridView();
            clIndex = new DataGridViewTextBoxColumn();
            clName = new DataGridViewTextBoxColumn();
            clUsername = new DataGridViewTextBoxColumn();
            clPassword = new DataGridViewTextBoxColumn();
            clButtonEdit = new DataGridViewButtonColumn();
            clButtonDelete = new DataGridViewButtonColumn();
            clButtonConnect = new DataGridViewButtonColumn();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clIndex, clName, clUsername, clPassword, clButtonEdit, clButtonDelete, clButtonConnect });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(713, 299);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // clIndex
            // 
            clIndex.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            clIndex.HeaderText = "Index";
            clIndex.Name = "clIndex";
            clIndex.ReadOnly = true;
            clIndex.Width = 61;
            // 
            // clName
            // 
            clName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clName.HeaderText = "Name";
            clName.Name = "clName";
            clName.ReadOnly = true;
            // 
            // clUsername
            // 
            clUsername.HeaderText = "Username";
            clUsername.Name = "clUsername";
            clUsername.ReadOnly = true;
            // 
            // clPassword
            // 
            clPassword.HeaderText = "Password";
            clPassword.Name = "clPassword";
            clPassword.ReadOnly = true;
            // 
            // clButtonEdit
            // 
            clButtonEdit.HeaderText = "";
            clButtonEdit.Name = "clButtonEdit";
            clButtonEdit.ReadOnly = true;
            clButtonEdit.Resizable = DataGridViewTriState.True;
            clButtonEdit.SortMode = DataGridViewColumnSortMode.Automatic;
            clButtonEdit.Width = 80;
            // 
            // clButtonDelete
            // 
            clButtonDelete.HeaderText = "";
            clButtonDelete.Name = "clButtonDelete";
            clButtonDelete.ReadOnly = true;
            clButtonDelete.Resizable = DataGridViewTriState.True;
            clButtonDelete.SortMode = DataGridViewColumnSortMode.Automatic;
            clButtonDelete.Width = 80;
            // 
            // clButtonConnect
            // 
            clButtonConnect.HeaderText = "";
            clButtonConnect.Name = "clButtonConnect";
            clButtonConnect.ReadOnly = true;
            clButtonConnect.Resizable = DataGridViewTriState.True;
            clButtonConnect.SortMode = DataGridViewColumnSortMode.Automatic;
            clButtonConnect.Width = 80;
            // 
            // button1
            // 
            button1.Location = new Point(650, 323);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 329);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 2;
            label1.Text = "UltraViewer Path:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(113, 324);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(376, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "C:\\Program Files (x86)\\UltraViewer\\UltraViewer_Desktop.exe";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 358);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ultraview Management";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn clIndex;
        private DataGridViewTextBoxColumn clName;
        private DataGridViewTextBoxColumn clUsername;
        private DataGridViewTextBoxColumn clPassword;
        private DataGridViewButtonColumn clButtonEdit;
        private DataGridViewButtonColumn clButtonDelete;
        private DataGridViewButtonColumn clButtonConnect;
    }
}