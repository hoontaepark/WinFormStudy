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
    public partial class savePop : Form
    {
        public savePop()
        {
            InitializeComponent();
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

        private void savePop_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String code = comboBox1.Text;

            textBox3.Text = code;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            

            if (btn != null)
            {
                MessageBox.Show("MES보고완료.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
