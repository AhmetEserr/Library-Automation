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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bag = new SqlConnection("Data Source =AHMET; database = kutuphane; integrated security = true");
        SqlCommand komut = new SqlCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !="" && textBox2.Text !="")
            {
                 if (textBox1.Text == "admin" && textBox2.Text == "1234")
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
                frm2.textBox1.Text ="Hoşgeldin  "+ textBox1.Text;

            }
            else
            {
                bag.Open();
                komut = new SqlCommand("SELECT * FROM kul_giris where kul_ad='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'", bag);
                komut.Parameters.AddWithValue("@kul_ad", textBox1.Text);
                komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                SqlDataReader dr = komut.ExecuteReader();     
                if (dr.Read())
                {
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    this.Hide();
                    frm2.textBox1.Text ="Hoşgeldin   "+ textBox1.Text;
                }
                bag.Close();
            
            }
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre boş geçilemez !!");
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
