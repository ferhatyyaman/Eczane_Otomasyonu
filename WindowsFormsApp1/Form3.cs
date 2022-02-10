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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }


        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-24GJBGT\\SQLExpress01;Initial Catalog=ECZANE;Integrated Security=True");


        // hasta listesi
        private void hastaverileri()

        {
           // listView1.Items.Clear();   //silerken üstte veriler kalmasın diye

            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from HASTA", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["hasta_id"].ToString();
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["Ad_Soyad"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Dogum_yeri"].ToString());
                ekle.SubItems.Add(oku["Dogum_tarihi"].ToString());
                ekle.SubItems.Add(oku["adres"].ToString());
                ekle.SubItems.Add(oku["Tel_no"].ToString());
              
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e) //*******************kayıt butonu*****************
        {
            SqlCommand komut;
            string sorgu= "Insert into HASTA(hasta_id,TC,Ad_Soyad,Cinsiyet,Dogum_yeri,Dogum_tarihi,adres,Tel_no) values (@hasta_id,@TC,@Ad_Soyad,@Cinsiyet,@Dogum_yeri,@Dogum_tarihi,@adres,@Tel_no)";
            //komut = new SqlCommand("Insert into HASTA(TC,Ad_Soyad,Cinsiyet,Dogum_yeri,Dogum_tarihi,adres,,Tel_no)values('" + textBox1.Text.ToString() + "' , '" + textBox2.Text.ToString() + "' , '" + textBox3.Text.ToString() + "' , '" + textBox4.Text.ToString() + "' , '" + textBox5.Text.ToString() + "' , '" + textBox6.Text.ToString() + "' , '" + textBox7.Text.ToString() + "'", baglan);
            komut=new SqlCommand(sorgu, baglan);
            komut.Parameters.AddWithValue("@hasta_id", textBox1.Text.ToString());
            komut.Parameters.AddWithValue("@TC", textBox2.Text.ToString());
            komut.Parameters.AddWithValue("@Ad_Soyad", textBox3.Text.ToString());
            komut.Parameters.AddWithValue("@Cinsiyet", textBox4.Text.ToString());
            komut.Parameters.AddWithValue("@Dogum_yeri", textBox5.Text.ToString());
            komut.Parameters.AddWithValue("@Dogum_tarihi", textBox6.Text.ToString());
            komut.Parameters.AddWithValue("@adres", textBox7.Text.ToString());
            komut.Parameters.AddWithValue("@tel_no", textBox8.Text.ToString());
            baglan.Open();
            komut.ExecuteNonQuery();
            baglan.Close();
            hastaverileri();

            textBox1.Clear();
            textBox2.Clear();                   //yazılar yazıldıktan sonra kalan yazıları siler
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //***************kaydetme butonu*****************
        {
            hastaverileri();
        }
    }
}
