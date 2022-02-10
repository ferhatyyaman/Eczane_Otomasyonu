using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-24GJBGT\\SQLExpress01;Initial Catalog=ECZANE;Integrated Security=True");


        // hasta listesi
        private void hastaverileri()

        {
            // listView1.Items.Clear();   //silerken üstte veriler kalmasın diye

            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from SATIS", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Hasta_TC"].ToString();
                ekle.SubItems.Add(oku["barkod_id"].ToString());
                ekle.SubItems.Add(oku["ilac_adi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //******************Görüntüle butonu***************
        {
            hastaverileri();
        }

        private void Form2_Load(object sender, EventArgs e) //satıs tablosu
        {

        }

        private void button2_Click(object sender, EventArgs e)//****************kayıt butonu****************
        {
            SqlCommand komut;
            string sorgu = "Insert into SATIS(Hasta_TC,barkod_id,ilac_adi) values (@Hasta_TC,@barkod_id,@ilac_adi)";
            
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@Hasta_TC", textBox1.Text.ToString());
            komut.Parameters.AddWithValue("@barkod_id", textBox2.Text.ToString());
            komut.Parameters.AddWithValue("@ilac_adi", textBox2.Text.ToString());


            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            hastaverileri();

            textBox1.Clear();                   //yazılar yazıldıktan sonra kalan yazıları siler
            textBox2.Clear();
            textBox3.Clear();
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
