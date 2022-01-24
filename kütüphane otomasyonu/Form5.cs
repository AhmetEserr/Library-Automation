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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
         SqlConnection bag = new SqlConnection("DATA SOURCE=AHMET;database = kutuphane; integrated security = true");
        SqlCommand kmt = new SqlCommand();

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
          void listele()
        {
            bag.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From kitaplar", bag);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bag.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           bag.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from kitaplar where barkodno like '%" + textBox5.Text + "%' or kitap_adi like '" + textBox5.Text + "' ", bag);
            DataTable tablo = new DataTable();
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bag.Close();
           
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox8.Text != "")
                {
                    bag.Open();
                    kmt = new SqlCommand("Insert into kitaplar (barkodno,kitap_adi,kitap_turu,yayin_evi,kitaptarih,yazar) values (@barkodno,@kitap_adi,@kitap_turu,@yayinevi,@kitaptarih,@yazar)", bag);
                    kmt.Parameters.AddWithValue("@barkodno", textBox1.Text);
                    kmt.Parameters.AddWithValue("@kitap_adi", textBox2.Text);
                    kmt.Parameters.AddWithValue("@kitap_turu", textBox3.Text);
                    kmt.Parameters.AddWithValue("@yayinevi", textBox4.Text);
                    kmt.Parameters.AddWithValue("@kitaptarih", textBox6.Text);
                    kmt.Parameters.AddWithValue("@yazar", textBox8.Text);
                    kmt.ExecuteNonQuery();
                    MessageBox.Show("kayıt yapıldı ");
                    bag.Close();
                    listele();
                }
                else
                {
                    MessageBox.Show("boş geçilmez");
                }
          
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();
            kmt = new SqlCommand("Delete  from kitaplar where barkodno=@barkodno", bag);
            kmt.Parameters.AddWithValue("@barkodno",textBox1.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Silindi");
            bag.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();

             kmt = new SqlCommand("UPDATE kitaplar SET kitap_adi ='" + textBox2.Text + "',kitap_turu='" + textBox3.Text + "',yayin_evi='" + textBox4.Text + "',kitaptarih='" + textBox6.Text + "',yazar='" + textBox8.Text +  "' WHERE barkodno='" + textBox1.Text + "'", bag);
            kmt.ExecuteNonQuery();
            kmt.Dispose();
            bag.Close();
            listele();
            MessageBox.Show("Güncelleme İşlemi Tamamlandı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
