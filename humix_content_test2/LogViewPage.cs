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

                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView2.Columns.Add("No", "No");
                    dataGridView2.Columns.Add("File", "File");


                    for (int i = 0; i < txtFiles.Length; i++)
                    {
                        string fileName = Path.GetFileName(txtFiles[i]);
                        dataGridView2.Rows.Add(i + 1, fileName);
                    }


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
            }
        }

        private void gridset()
        {

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


    }
}
