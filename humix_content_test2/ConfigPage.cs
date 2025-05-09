using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace humix_content_test2
{
    public partial class ConfigPage : UserControl
    {
        public ConfigPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (btn.Text == "ON")
                {
                    btn.Text = "OFF";
                    btn.BackColor = Color.Black;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.Text = "ON";
                    btn.BackColor = Color.FromArgb(128, 255, 128);
                    btn.ForeColor = Color.Black;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String check = button1.Text;
            savePop save = new savePop();

            if (check == "ON")
            {
                save.ShowDialog();
            }
            else
            {
                MessageBox.Show("OFF입니다. ON상태로 변경하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string pwd = textBox2.Text;
            string pwd2 = textBox3.Text;
            Console.WriteLine(pwd);
            Console.WriteLine(pwd2);

            String checkOk = checkPwd(pwd, pwd2);

            if (checkOk != null)
            {
                MessageBox.Show("Save Complelte !!!", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else
            //{
            //    MessageBox.Show("Save Fail !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private string checkPwd(String pwd, String pwd2)
        {
            string checkpwd = pwd;
            string checkpwd2 = pwd2;
            string checkok = "ok";

            if (string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Password에 비밀번호를 입력해주세요 !!!", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }else if(string.IsNullOrEmpty(pwd2))
            {
                MessageBox.Show("Password Confirm에 비밀번호를 입력해주세요 !!!", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }else if(pwd != pwd2)
            {
                MessageBox.Show("비밀번호가 다릅니다 !!!", "information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                return checkok;
            }
        }
    }
}
