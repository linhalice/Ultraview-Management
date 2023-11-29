using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ultraview_Management.GUI
{
    public partial class FormAddSever : Form
    {
        public FormAddSever()
        {
            InitializeComponent();
        }

        public string name = string.Empty;

        public string username = string.Empty;

        public string password = string.Empty;

        public bool submitOk = false;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            username = textBoxUsername.Text;
            password = textBoxPassword.Text;


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Dữ liệu không hợp lệ!");
                return;
            }

            List<string> severs = new List<string>();
            try
            {
                severs = File.ReadAllLines("Data.txt").ToList();
            }
            catch { }

            foreach (string lineData in severs)
            {
                if (string.IsNullOrEmpty(lineData) || !lineData.Contains("|"))
                {
                    continue;
                }
                var lineDataSplit = lineData.Split('|');
                if (lineDataSplit.Count() < 3)
                {
                    continue;
                }
                try
                {
                    string nameInFile = lineDataSplit[0];
                    string usernameInFile = lineDataSplit[1];
                    string passwordInFile = lineDataSplit[2];

                    if (nameInFile == name || usernameInFile == username)
                    {
                        MessageBox.Show("Không thể thêm một sever mới có thông tin trùng với sever cũ");
                        return;
                    }
                }
                catch
                {

                }
            }

            submitOk = true;
            this.Close();

        }

        private void FormAddSever_Load(object sender, EventArgs e)
        {

        }
    }
}
