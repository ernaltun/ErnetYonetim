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
            using (SqlCommand komut = new SqlCommand("INSERT INTO Works (AracPlaka, AracSofor, CıkısNoktası, TeslimatNoktası, Tarih) VALUES (@AracPlaka, @AracSofor, @CikisNoktasi, @TeslimatNoktasi, @Tarih)", baglan))
            {
                komut.Parameters.AddWithValue("@AracPlaka", textBox1.Text);
                komut.Parameters.AddWithValue("@AracSofor", textBox2.Text);
                komut.Parameters.AddWithValue("@CikisNoktasi", textBox3.Text);
                komut.Parameters.AddWithValue("@TeslimatNoktasi", textBox4.Text);
                komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value);

                komut.ExecuteNonQuery();
            }
            baglan.Close() ;
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

    }

}
