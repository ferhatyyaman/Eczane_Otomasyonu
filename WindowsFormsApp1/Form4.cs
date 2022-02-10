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
    public partial class Form4 : Form
    {
        public Form4()  
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-24GJBGT\\SQLExpress01;Initial Catalog=ECZANE;Integrated Security=True"); //sql bağlantısı
        private void button1_Click(object sender, EventArgs e)//***************giriş butonu***************
        {

            try
            {
                baglan.Open();
                string sql = "select * from KULLANİCİ where kullanici_adi=@kullanici_adi AND parola=@parola";
                SqlParameter prmt1 = new SqlParameter("kullanici_adi", textBox1.Text.Trim());
                SqlParameter prmt2 = new SqlParameter("parola", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglan);
                komut.Parameters.Add(prmt1);
                komut.Parameters.Add(prmt2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Form1 ekle = new Form1();
                    ekle.ShowDialog();


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş");


            }







        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut;
            string sorgu = "Insert into KULLANİCİ(ad_soyad,kullanici_adi,parola,parola_tekrar) values (@ad_soyad,@kullanici_adi,@parola,@parola_tekrar)";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@ad_soyad", textBox3.Text.ToString());
            komut.Parameters.AddWithValue("@kullanici_adi", textBox4.Text.ToString());
            komut.Parameters.AddWithValue("@parola", textBox5.Text.ToString());
            komut.Parameters.AddWithValue("@parola_tekrar", textBox6.Text.ToString());

            baglan.Open(); //bağlantıyı açtık
            komut.ExecuteNonQuery(); // CRUD işlemlerinde kullanılıyor  
            baglan.Close(); //bağlantıyı kapattık

            //verilerigoruntule(); //verileri görüntüler

            textBox1.Clear();                   //değerler yazıldıktan sonra kalan yazıları siler
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            
            
            MessageBox.Show("kayıt başarılı başarılı");
            

        }
    }
}

