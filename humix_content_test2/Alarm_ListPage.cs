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
    public partial class Alarm_ListPage : UserControl
    {

        private DataTable dt = new DataTable();

        public Alarm_ListPage()
        {
            InitializeComponent();
            setGrid();
            dataGridView1.RowPostPaint += DataGridView1_RowPostPaint;
        }

        public void setGrid()
        {

            dt.Columns.Add("AlarmBit", typeof(string));
            dt.Columns.Add("AlarmText", typeof(string));

            for (int i = 0; i < 288; i++)
            {

                string bit = $"D1200.{i + 1}";
                string text = " ";
                dt.Rows.Add(bit, text);
            }

            //DataGridView에 바인딩 
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;




        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            string rowIdx = (e.RowIndex + 1).ToString();

            using (SolidBrush brush = new SolidBrush(grid.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(rowIdx,
                    grid.RowHeadersDefaultCellStyle.Font,
                    brush,
                    e.RowBounds.Location.X + 10,
                    e.RowBounds.Location.Y + 4);  // 위치 조정 가능
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("프로그램을 재시작합니다.", "information",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }
    }
}
