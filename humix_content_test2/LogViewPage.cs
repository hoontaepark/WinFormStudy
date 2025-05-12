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
                    textBox1.Text = dialog.SelectedPath;

                    string[] txtFiles = Directory.GetFiles(dialog.SelectedPath, "*.txt");

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
