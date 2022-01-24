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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("DATA SOURCE=AHMET;database = kutuphane; integrated security = true");
        SqlCommand kmt = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            this.Hide();
            frm6.Show();
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

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bag.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from kullanıcı where tc like '%" + textBox1.Text + "%'", bag);
            DataTable tablo = new DataTable();
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bag.Close();
           /* if(radioButton1.Checked==true)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from kullanıcı where tc like '%" + textBox1.Text + "%'", bag);
                DataTable tablo = new DataTable();
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else if(radioButton2.Checked==true)
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from kullanıcı where kul_ad like '%" + textBox1.Text + "%'", bag);
                DataTable tablo = new DataTable();
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }*/

        }
    }
}
