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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("DATA SOURCE=AHMET;database = kutuphane; integrated security = true");
        SqlCommand kmt = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            this.Hide();
            frm5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void Form3_Load(object sender, EventArgs e)
        {

            listele();

        
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           bag.Open();
                SqlDataAdapter adp = new SqlDataAdapter("select * from kitaplar where barkodno like '%" + textBox5.Text + "%'", bag);
                DataTable tablo = new DataTable();
                adp.Fill(tablo);
                dataGridView1.DataSource = tablo;
            bag.Close();
           
            }
        
    }
}
