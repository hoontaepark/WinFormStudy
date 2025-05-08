using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using humix_content_test2;

namespace humix_Test
{
    public partial class CIM_BaseForm : Form
    {
        MainPage mainPage = new MainPage();
        ConfigPage configPage = new ConfigPage();
        Alarm_ListPage alarmlistPage = new Alarm_ListPage();
        public CIM_BaseForm()
        {
            InitializeComponent();
            LoadContent(mainPage);
        }

       private void LoadContent(UserControl content)
        {
            this.panelContent.Controls.Clear();
            content.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(content);
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CIM_BaseForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("F");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadContent(mainPage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadContent(configPage);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
