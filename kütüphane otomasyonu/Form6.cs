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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("DATA SOURCE=AHMET;database = kutuphane; integrated security = true");
        SqlCommand kmt = new SqlCommand();
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        void listele()
        {
            bag.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From kullanıcı", bag);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bag.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            bag.Open();
                SqlDataAdapter adp = new SqlDataAdapter("select * from kullanıcı where tc like '%" + textBox1.Text + "%'", bag);
                DataTable tablo = new DataTable();
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
                bag.Close();
           
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listele();
            textBox4.Text = dateTimePicker1.Value.ToString();
            //textBox6.Text = dateTimePicker2.Value.ToString();
            textBox4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                bag.Open();
                kmt = new SqlCommand("Insert into kullanıcı(tc,kul_ad,kul_soyad,veris_tarih,alis_tarih,tel,adres) values (@tc,@kul_ad,@kul_soyad,@veris_tarih,@alis_tarih,@tel,@adres)", bag);
                kmt.Parameters.AddWithValue("@tc", textBox1.Text);
                kmt.Parameters.AddWithValue("@kul_ad", textBox2.Text);
                kmt.Parameters.AddWithValue("@kul_soyad", textBox3.Text);
                kmt.Parameters.AddWithValue("@veris_tarih", textBox4.Text);
                kmt.Parameters.AddWithValue("@alis_tarih", textBox6.Text);
                kmt.Parameters.AddWithValue("@tel", textBox7.Text);
                kmt.Parameters.AddWithValue("@adres", textBox8.Text);
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = dateTimePicker2.Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bag.Open();
            kmt = new SqlCommand("Delete  from kullanıcı where tc=@tc", bag);
            kmt.Parameters.AddWithValue("@tc", textBox1.Text);
            kmt.ExecuteNonQuery();
            MessageBox.Show("Silindi");
            bag.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bag.Open();
            kmt = new SqlCommand("UPDATE kullanıcı SET   kul_ad='" + textBox2.Text + "',kul_soyad='" + textBox3.Text + "',veris_tarih='" + textBox4.Text + "',alis_tarih='" + textBox6.Text + "',tel='" + textBox7.Text + "',adres='" + textBox8.Text + "' WHERE tc='" + textBox1.Text + "'", bag);
            kmt.ExecuteNonQuery();
            kmt.Dispose();
            bag.Close();
            listele();
            MessageBox.Show("Güncelleme İşlemi Tamamlandı !", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
