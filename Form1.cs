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
		SqlConnection baglan = new SqlConnection("Data Source=ITEA\\SQLEXPRESS;Initial Catalog=Ernet;Integrated Security=True");

		private void verileriGoruntule()
		{
			listView1.Items.Clear();
			baglan.Open();
			SqlCommand komut = new SqlCommand("SELECT * FROM Works", baglan);
			SqlDataReader oku = komut.ExecuteReader();

			while (oku.Read())
			{
				ListViewItem ekle = new ListViewItem();
				ekle.SubItems.Add(oku["AracPlaka"].ToString());
				ekle.SubItems.Add(oku["AracSofor"].ToString());
				ekle.SubItems.Add(oku["CikisNokta"].ToString());
				ekle.SubItems.Add(oku["VarisNokta"].ToString());
				ekle.Text = oku["Tarih"].ToString();

				listView1.Items.Add(ekle);
			}

			baglan.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			verileriGoruntule();
		}



		private void tabPage1_Click(object sender, EventArgs e)
		{

		}

		
	}
}
