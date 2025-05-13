using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace humix_content_test2
{
    public partial class LogViewPage : UserControl
    {
        public LogViewPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "폴더를 선택하세요.";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = dialog.SelectedPath;
                    string[] txtFiles = Directory.GetFiles(dialog.SelectedPath, "*.txt");
                    textBox1.Text = folderPath;

                    gridset(folderPath, txtFiles);
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string fileName = dataGridView2.Rows[e.RowIndex].Cells["File"].Value.ToString();
                string folderPath = dataGridView2.Tag as string;

                if (!string.IsNullOrEmpty(folderPath))
                {
                    string fullPath = Path.Combine(folderPath, fileName);

                    if (File.Exists(fullPath))
                    {
                        textBox4.Text = File.ReadAllText(fullPath);
                    }
                }
            }
        }

        private void gridset(string folderPath, string[] txtFiles)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("No", "No");
            dataGridView2.Columns.Add("File", "File");


            for (int i = 0; i < txtFiles.Length; i++)
            {
                string fileName = Path.GetFileName(txtFiles[i]);
                dataGridView2.Rows.Add(i + 1, fileName);
            }

            dataGridView2.Tag = folderPath;

            if (txtFiles.Length > 0)
            {
                string fileContent = File.ReadAllText(txtFiles[0]);
                textBox4.Text = fileContent;
            }
            else
            {
                textBox4.Text = "txt 파일이 존재하지않습니다.";
            }

        }
        public void panelPaint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p != null)
            {
                Color borderColor = Color.Gray;
                int borderWidth = 1;

                ControlPaint.DrawBorder(
                    e.Graphics,
                    p.ClientRectangle,
                    borderColor, borderWidth, ButtonBorderStyle.Solid,
                    borderColor, borderWidth, ButtonBorderStyle.Solid,
                    borderColor, borderWidth, ButtonBorderStyle.Solid,
                    borderColor, borderWidth, ButtonBorderStyle.Solid
                );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                string fileName = dataGridView2.CurrentRow.Cells["File"].Value.ToString();
                string folderPath = dataGridView2.CurrentRow.Tag as String;

                if (!string.IsNullOrEmpty(folderPath) && !string.IsNullOrEmpty(fileName))
                {
                    string fullPath = Path.Combine(folderPath, fileName);
                    textBox3.Text = fullPath;
                }
                else
                {
                    MessageBox.Show("파일 경로나 파일명이 유효하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("파일을 선택해 주세요", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


    }
}
