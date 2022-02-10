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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-24GJBGT\\SQLExpress01;Initial Catalog=ECZANE;Integrated Security=True"); //sql bağlantısı
        private void verilerigoruntule() // verileri görüntülemek metod oluşturduk

        {
            listView1.Items.Clear();   //silerken üstte veriler kalmasın diye kullandık

            baglan.Open(); //bağlantıyı açtık
            SqlCommand komut = new SqlCommand("select *from İLAC",baglan); //verileri görüntülemek için yazılan komut
            SqlDataReader oku = komut.ExecuteReader(); //verileri okutuyoruz
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ilac_id"].ToString();
                ekle.SubItems.Add(oku["ilac_adi"].ToString());
                ekle.SubItems.Add(oku["barkod_id"].ToString());
                ekle.SubItems.Add(oku["ATC_id"].ToString());
                ekle.SubItems.Add(oku["firma_id"].ToString());          
                ekle.SubItems.Add(oku["recete_turu"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["raf_id"].ToString());
                ekle.SubItems.Add(oku["stok_adedi"].ToString());
                ekle.SubItems.Add(oku["form_id"].ToString());

                listView1.Items.Add(ekle);  
            }
            baglan.Close(); //bağlantıyı kapattık
        }
        private void button1_Click(object sender, EventArgs e) //*****************görüntüle butonu******************
        {
            verilerigoruntule();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // ************kaydetme butonu**************
        {

            // SqlCommand komut = new SqlCommand("Insert into İLAC(ilac_id,ilac_adi,barkod,ATC_id,firma_id,recete_turu,fiyat,raf_id,stok_adedi)values('" + textBox1.Text.ToString() + "' , '" + textBox2.Text.ToString() + "' , '" + textBox3.Text.ToString() + "' , '" + textBox4.Text.ToString() + "' , '" + textBox5.Text.ToString() + "' , '" + textBox6.Text.ToString() + "' , '" + textBox7.Text.ToString() + "' , '" + textBox8.Text.ToString() + "' , '" + textBox9.Text.ToString() + "'", baglan);  //girilen değerleri ekliyoruz
            SqlCommand komut;
            string sorgu="Insert into İLAC(ilac_id,ilac_adi,barkod_id,ATC_id,firma_id,recete_turu,fiyat,raf_id,stok_adedi,form_id) values (@ilac_id,@ilac_adi,@barkod_id,@ATC_id,@firma_id,@recete_turu,@fiyat,@raf_id,@stok_adedi,@form_id)";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@ilac_id", textBox1.Text.ToString());
            komut.Parameters.AddWithValue("@ilac_adi", textBox2.Text.ToString());
            komut.Parameters.AddWithValue("@barkod_id", textBox3.Text.ToString());
            komut.Parameters.AddWithValue("@ATC_id", textBox4.Text.ToString());
            komut.Parameters.AddWithValue("@firma_id", textBox5.Text.ToString());
            komut.Parameters.AddWithValue("@recete_turu", textBox6.Text.ToString());
            komut.Parameters.AddWithValue("@fiyat", textBox7.Text.ToString());
            komut.Parameters.AddWithValue("@raf_id", textBox8.Text.ToString());
            komut.Parameters.AddWithValue("@stok_adedi", textBox9.Text.ToString());
            komut.Parameters.AddWithValue("@form_id", textBox10.Text.ToString());
            baglan.Open(); //bağlantıyı açtık
            komut.ExecuteNonQuery(); // CRUD işlemlerinde kullanılıyor  
            baglan.Close(); //bağlantıyı kapattık

            verilerigoruntule(); //verileri görüntüler

            textBox1.Clear();                   //değerler yazıldıktan sonra kalan yazıları siler
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }




        int id = 0;
        private void button3_Click(object sender, EventArgs e) // ********************sil butonu****************
        {
           //komut = new SqlCommand("delete from İLAC where id=(" + columnHeader1 + ")", baglan);  // id nin bulunduğu kısımdaki veriyi sil
            SqlCommand komut;
            string sorgu = "delete from İLAC where ilac_id=@ilac_id";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@ilac_id", Convert.ToInt32(textBox1.Text));

            baglan.Open(); //bağlantıyı açtık
            komut.ExecuteNonQuery(); // CRUD işlemlerinde kullanılıyor  
            baglan.Close(); //bağlantıyı kapattık
            verilerigoruntule();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) //mause 2 kere tıklanınca 
        {
            id=int.Parse(listView1.SelectedItems[0].SubItems[0].Text); //veri türünü değiştirmek için kullandık
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;        
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox9.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox10.Text = listView1.SelectedItems[0].SubItems[9].Text;


        }
        
        private void button4_Click(object sender, EventArgs e) //********************güncelle butonu****************
        {

            //SqlCommand komut = new SqlCommand("update İLAC set ilac_id='" + textBox1.Text.ToString() + "',ilac_adi='" + textBox2.Text.ToString() + "',barkod='" + textBox3.Text.ToString() + "',ATC_id='" + textBox4.Text.ToString() + "',firma_id='" + textBox5.Text.ToString() + "',recete_turu-='" + textBox6.Text.ToString() + "',fiyat='" + textBox7.Text.ToString() + "',raf_id='" + textBox8.Text.ToString() + "',stok_adedi='" + textBox9.Text.ToString() + "'where ilac_id" + ilac_id + "", baglan);
            SqlCommand komut;
            string sorgu = "update İLAC set ilac_ad=@ilac_ad,barkod=@barkod,ATC_id=@ATC_id,firma_id=@firma_id,recete_turu=@recete_turu,fiyat=@fiyat,raf_id=@raf_id,stok_adedi=@stok_adedi,form_id=@form_id where ilac_id=@ilac_id";
            komut = new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@ilac_id", Convert.ToInt32(textBox1.Text));
            komut.Parameters.AddWithValue("@ilac_ad",textBox2.Text);
            komut.Parameters.AddWithValue("@barkod_id", textBox3.Text);    
            komut.Parameters.AddWithValue("@ATC_id", textBox4.Text);
            komut.Parameters.AddWithValue("@firma_id", textBox5.Text);
            komut.Parameters.AddWithValue("@recete_turu", textBox6.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox7.Text);
            komut.Parameters.AddWithValue("@raf_id", textBox8.Text);
            komut.Parameters.AddWithValue("@stok_adedi", textBox9.Text);
            komut.Parameters.AddWithValue("@form_id", textBox10.Text);

            baglan.Open(); //bağlantıyı açtık
            komut.ExecuteNonQuery();   // CRUD işlemlerinde kullanılıyor 
            baglan.Close(); //bağlantıyı kapattık
            verilerigoruntule();  // listeye tıklayarak değerleri değiştirebiliyoruz
        }

        private void button5_Click(object sender, EventArgs e) //******************ilac butonu******************
        {
            Form1 ekle = new Form1();
            ekle.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e) //********************satış butonu******************
        {
            Form2 ekle = new Form2();
            ekle.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e) //*******************hasta butonu*******************
        {
            Form3 ekle = new Form3();
            ekle.ShowDialog();



            }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)//************yeni satıs butonu************
        {
            Form2 ekle = new Form2();
            ekle.ShowDialog();

        }
    }
}
