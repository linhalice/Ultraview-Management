using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Diagnostics;

namespace Ultraview_Management.GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (!IsUltraViewerRunning())
                    {
                        StartUltraViewer();
                    }
                    Thread.Sleep(1000);
                }
            });
            thread.IsBackground = true;
            thread.Start();


            List<string> lines = new List<string>();
            try
            {
                lines = File.ReadLines("Data.txt").ToList();
                LoadData();

            }
            catch
            {

            }
            if (dataGridView1.Rows.Count == 0)
            {
                var dialogResult = MessageBox.Show("Có vẻ như bạn chưa có sever nào trong data, thêm một sever mới nào!!!", "Chào mừng!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    AddSever();
                }
            }


        }

        static bool IsUltraViewerRunning()
        {
            // Lấy danh sách các tiến trình có tên "UltraViewer_Desktop.exe"
            Process[] processes = Process.GetProcessesByName("UltraViewer_Desktop");

            // Nếu danh sách có ít nhất một tiến trình, UltraViewer đang chạy
            return processes.Length > 0;
        }

        static void StartUltraViewer()
        {
            // Tạo một tiến trình cmd ẩn
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.RedirectStandardInput = true;

            // Khởi động cmd
            cmdProcess.Start();

            // Gửi lệnh để mở UltraViewer bằng cmd
            cmdProcess.StandardInput.WriteLine($"start \"\" \"{ToolSettings.Default.UltraViewerPath}\"");

            // Đợi 2 giây để UltraViewer khởi động
            Thread.Sleep(2000);

            // Đóng cmd
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.WaitForExit();
            cmdProcess.Close();
        }

        static void ConnectToUltraViewer(string idToConnect, string password = null)
        {
            string command = $"\"{ToolSettings.Default.UltraViewerPath}\" -i:{idToConnect}";

            if (!string.IsNullOrEmpty(password))
            {
                command += $" -p:{password}";
            }

            // Tạo một tiến trình cmd ẩn
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.RedirectStandardInput = true;

            // Khởi động cmd
            cmdProcess.Start();

            // Gửi lệnh để chạy UltraViewer_Desktop.exe
            cmdProcess.StandardInput.WriteLine(command);

            // Đóng cmd
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.WaitForExit();
            cmdProcess.Close();
        }

        static void CloseWindowWithTitleContains(string titleContains)
        {
            Process[] processes = Process.GetProcesses(); // Lấy danh sách tất cả các tiến trình

            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.Contains(titleContains))
                {
                    // Nếu tiêu đề chứa chuỗi cần kiểm tra, tắt cửa sổ
                    process.CloseMainWindow();
                }
            }
        }

        static void CloseProcessByName(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch { }
            }
        }

        private void AddSever()
        {
            try
            {
                FormAddSever formAddSever = new FormAddSever();
                formAddSever.ShowDialog();
                if (formAddSever.submitOk)
                {
                    string name = formAddSever.name;
                    string username = formAddSever.username;
                    string password = formAddSever.password;
                    DataGridViewAddNewRow(name, username, password);
                    SaveData();
                    LoadData();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có một lỗi nào đó đã xảy ra khi add sever!!! \n\n Mã lỗi: {ex.Message}", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditSever(DataGridViewRow row, string name, string username, string password)
        {
            try
            {
                FormSeverDetail formSeverDetail = new FormSeverDetail(name, username, password);
                formSeverDetail.ShowDialog();
                if (formSeverDetail.submitOk)
                {
                    name = formSeverDetail.name;
                    username = formSeverDetail.username;
                    password = formSeverDetail.password;
                    DataGridViewAddEditRow(row, name, username, password);
                    SaveData();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có một lỗi nào đó đã xảy ra khi edit sever!!! \n\n Mã lỗi: {ex.Message}", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SaveData()
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string name = row.Cells[1].Value.ToString();
                    string username = row.Cells[2].Value.ToString();
                    string password = row.Cells[3].Value.ToString();
                    string line = $"{name}|{username}|{password}";
                    lines.Add(line);
                }
                File.WriteAllLines("Data.txt", lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có một lỗi nào đó đã xảy ra khi lưu dữ liệu sever!!! \n\n Mã lỗi: {ex.Message}", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadData()
        {
            List<string> severs = new List<string>();
            try
            {
                severs = File.ReadAllLines("Data.txt").ToList();
                dataGridView1.Rows.Clear();
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
                    DataGridViewAddNewRow(nameInFile, usernameInFile, passwordInFile);
                }
                catch
                {

                }
            }
        }

        private void ConnectSever(string username, string password)
        {
            try
            {
                string windowTitleContains = ") - UltraViewer"; // Chuỗi tiêu đề cần kiểm tra và tắt
                CloseWindowWithTitleContains(windowTitleContains);

                ConnectToUltraViewer(username, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có một lỗi nào đó đã xảy ra khi kết nối sever!!! \n\n Mã lỗi: {ex.Message}", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewAddNewRow(string name, string username, string password)
        {
            try
            {
                int iRow = dataGridView1.Rows.Add();
                dataGridView1.Rows[iRow].Cells[0].Value = iRow + 1;
                dataGridView1.Rows[iRow].Cells[1].Value = name;
                dataGridView1.Rows[iRow].Cells[2].Value = username;
                dataGridView1.Rows[iRow].Cells[3].Value = password;
                dataGridView1.Rows[iRow].Cells["clButtonEdit"].Value = "Edit";
                dataGridView1.Rows[iRow].Cells["clButtonDelete"].Value = "Delete";
                dataGridView1.Rows[iRow].Cells["clButtonConnect"].Value = "Connect";
            }
            catch { }
        }

        private void DataGridViewAddEditRow(DataGridViewRow row, string name, string username, string password)
        {
            try
            {

                row.Cells[1].Value = name;
                row.Cells[2].Value = username;
                row.Cells[3].Value = password;

            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSever();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["clButtonDelete"].Index && e.RowIndex >= 0)
            {
                // Xoá dòng tương ứng với nút được click
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                SaveData();
                LoadData();
            }

            if (e.ColumnIndex == dataGridView1.Columns["clButtonEdit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string name = row.Cells["clName"].Value.ToString();
                string username = row.Cells["clUsername"].Value.ToString();
                string password = row.Cells["clPassword"].Value.ToString();
                EditSever(row, name, username, password);
                SaveData();
                LoadData();
            }

            if (e.ColumnIndex == dataGridView1.Columns["clButtonConnect"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string name = row.Cells["clName"].Value.ToString();
                string username = row.Cells["clUsername"].Value.ToString();
                string password = row.Cells["clPassword"].Value.ToString();
                ConnectSever(username, password);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ToolSettings.Default.UltraViewerPath = textBox1.Text;
            ToolSettings.Default.Save();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string processName = "UltraViewer_Desktop";
            CloseProcessByName(processName);
        }
    }
}
