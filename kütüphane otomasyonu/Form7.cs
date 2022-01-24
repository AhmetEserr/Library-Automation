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

namespace kütüphane_otomasyonu
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("DATA SOURCE=AHMET;database = kutuphane; integrated security = true");
        SqlCommand kmt = new SqlCommand();

        void listele()
        {
            bag.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From kullanıcı", bag);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bag.Close();

        }
        void listele2()
        {
            bag.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From kitaplar", bag);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            bag.Close();

        }
        void listele3() {
            bag.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanet",bag);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;
            bag.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
           listele();
           listele2();
           listele3();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bag.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from kullanıcı where tc like '%" + textBox1.Text + "%'", bag);
            DataTable tablo = new DataTable();
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bag.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bag.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from kitaplar where barkodno like '%" + textBox2.Text + "%' ", bag);
            DataTable tablo = new DataTable();
            adp.Fill(tablo);
            dataGridView2.DataSource = tablo;
            bag.Close();
        }
     /*   int tc;
        String ad;
        String soyad;
        string kitapvermet;
        int barkodno;
        String kitapadı;*/
      

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* dataGridView1.Rows[0].Cells[0].Value = dataGridView3.CurrentRow.Cells[0].Value.ToString();
             soyad = dataGridView1.CurrentRow.Cells[2].Value.ToString();
             kitapvermet = dataGridView1.CurrentRow.Cells[3].Value.ToString();*/
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
          textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            kmt = new SqlCommand("Insert into emanet (tc,kul_ad,kul_soyad,veris_tarih,barkodno,kitap_Adi) values (@tc,@kul_ad,@kul_soyad,@veris_tarih,@barkodno,@kitap_Adi)", bag);
            kmt.Parameters.AddWithValue("@tc", textBox3.Text);
            kmt.Parameters.AddWithValue("@kul_ad", textBox4.Text);
            kmt.Parameters.AddWithValue("@kul_soyad", textBox5.Text);
            kmt.Parameters.AddWithValue("@veris_tarih", textBox6.Text);
            kmt.Parameters.AddWithValue("@barkodno", textBox7.Text);
            kmt.Parameters.AddWithValue("@kitap_Adi", textBox8.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("AKTARILDI ");
            bag.Close();
            listele3();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Insert Into emanet2 (barkodno,kitap_Adi) VALUES ('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "')";
           // listele3();
            kmt.ExecuteNonQuery();
          //  listele3();
          */
            textBox7.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*   dataGridView1.Rows[0].Cells[0].Value = Convert.ToString(dataGridView3.CurrentRow.Cells[0].Value.ToString());
               ad = Convert.ToString(dataGridView3.CurrentRow.Cells[1].Value.ToString());
               soyad = dataGridView3.CurrentRow.Cells[2].Value.ToString();
               kitapvermet = dataGridView3.CurrentRow.Cells[3].Value.ToString();
               barkodno = Convert.ToInt32(dataGridView3.CurrentRow.Cells[4].Value.ToString());
               kitapadı = dataGridView3.CurrentRow.Cells[5].Value.ToString();*/
           }
            
           private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
           {
               dataGridView3.Rows[0].Cells[0].Value = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value.ToString());
           }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
            
         /*   baglanti.Open();
               ekle.Connection = baglanti;
               ekle.CommandText = "Insert Into arxiv (ad,say,qiymet,nisye,tarix,kateqoriya) VALUES ('" + dataGridView3.CurrentRow.Cells[1].Value.ToString() + "','" + dataGridView3.CurrentRow.Cells[2].Value.ToString() + "','" + dataGridView3.CurrentRow.Cells[3].Value.ToString() + "','" + dataGridView3.CurrentRow.Cells[5].Value.ToString() + "','" + dataGridView3.CurrentRow.Cells[4].Value.ToString() + "','" + dataGridView3.CurrentRow.Cells[6].Value.ToString() + "')";
               ekle.ExecuteNonQuery();*/
         
         
            
        
    }
}
