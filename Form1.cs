using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ErnetYonetim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-PH4GJA1\\SQLEXPRESS;Initial Catalog=Ernet;Integrated Security=True");

        private void verileriGoruntule()
        {
            baglan.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Works", baglan);

            DataTable tabloList = new DataTable();
            da.Fill(tabloList);
            dataGridView1.DataSource = tabloList;
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verileriGoruntule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Works (AracPlaka,AracSofor,CıkısNoktası,TeslimatNoktası,Tarih) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + dateTimePicker1.Value.ToShortDateString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verileriGoruntule();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Works WHERE Id=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", baglan);
            komut.ExecuteNonQuery();
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            baglan.Close();
            verileriGoruntule();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
