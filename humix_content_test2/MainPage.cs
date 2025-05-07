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
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel11.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel11.BackColor = System.Drawing.Color.IndianRed;
        }
    }
}
