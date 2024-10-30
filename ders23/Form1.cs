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

namespace ders23
{


    public partial class Form1 : Form
    {

        static string constring = ("Data Source=DESKTOP-HHKVQ55\\SQLEXPRESS;Initial Catalog=Kayit;Integrated Security=True;");
        SqlConnection baglan = new SqlConnection(constring);
        public void kayitlari_getir()
        {
            baglan.Open();
            string getir = "Select *From KAYITLAR";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        public void verisil(int id)
        {
            baglan.Open();
            string sil = "delete from KAYITLAR Where uye_id=@id";
            SqlCommand komut=new SqlCommand(sil,baglan);
            komut.Parameters.AddWithValue("@id", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayitlari_getir();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into KAYITLAR (ad_soyad,kullanici_adi,sifre,email)values(@adsoyad,@kullaniciadi,@sifre,@email)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@adsoyad", textBox1.Text);
                    komut.Parameters.AddWithValue("@kullaniciadi", textBox2.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox3.Text);
                    komut.Parameters.AddWithValue("@email", textBox4.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("başarılı");
                    baglan.Close(); 

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("hatalı" + hata.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string kayit = "Select *From KAYITLAR where ad_soyad=@adsoyad";
            SqlCommand komut = new SqlCommand(kayit,baglan);
            komut.Parameters.AddWithValue("@adsoyad",textBox1.Text);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
            
            int id=Convert.ToInt32(row.Cells[0].Value);
                verisil(id);
                kayitlari_getir();  
            
            }

        }
        int i;
        private void button3_Click(object sender, EventArgs e)
        { 
            baglan.Open();
            string kayitgüncelle = ("Update KAYITLAR Set ad_soyad=@ad,kullanici_adi=@kullaniciadi,sifre=@sifre,email=@email Where uye_id=@id");
            SqlCommand komut = new SqlCommand(kayitgüncelle, baglan);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@kullaniciadi", textBox2.Text);
            komut.Parameters.AddWithValue("@sifre", textBox3.Text);
            komut.Parameters.AddWithValue("@email", textBox4.Text);
            komut.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);
            komut.ExecuteNonQuery();
            baglan.Close();
            kayitlari_getir();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i=e.RowIndex;
            textBox1.Text=dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            kayitlari_getir();
        }
    }
}

