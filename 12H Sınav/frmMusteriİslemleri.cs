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
namespace _12H_Sınav
{
    public partial class frmMusteriİslemleri : Form
    {
        public frmMusteriİslemleri()
        {
            InitializeComponent();
        }
        
        SqlBaglanti bag = new SqlBaglanti();
        int secilenMusteriID = 0;

        void MusteriGetir()
        {
            SqlCommand cmd = new SqlCommand("Select * from musteriler");
            cmd.Connection = bag.baglanti();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        void FormuTemizle()
        {
            TxtAdSoyad.Text = string.Empty;
            txtFirma.Text = string.Empty;
            txtMail.Text = string.Empty;
            rchAdres.Text = string.Empty;
            mskTel.Text = string.Empty;
            secilenMusteriID = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into musteriler(ad_soyad,firma_adi,telefon,mail,adres)values(@ad,@firma,@tel,@mail,@adres)", bag.baglanti());
                cmd.Connection = bag.baglanti();
                cmd.Parameters.AddWithValue("@ad", TxtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@firma", txtFirma.Text);
                cmd.Parameters.AddWithValue("@tel", mskTel.Text);
                cmd.Parameters.AddWithValue("@mail", txtMail.Text);
                cmd.Parameters.AddWithValue("@adres", rchAdres.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Müşteri Başarıyla Eklendi.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriGetir();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu.","Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
           
        }

        private void frmMusteriİslemleri_Load(object sender, EventArgs e)
        {
            MusteriGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete from musteriler where id='"+secilenMusteriID+"'");
                cmd.Connection = bag.baglanti();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Müşteri Başarıyla Silindi.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriGetir();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update musteriler set ad_soyad=@ad,firma_adi=@firma,telefon=@tel,mail=@mail,adres=@adres");
                cmd.Parameters.AddWithValue("@ad",TxtAdSoyad.Text);
                cmd.Parameters.AddWithValue("@firma", txtFirma.Text);
                cmd.Parameters.AddWithValue("@tel", mskTel.Text);
                cmd.Parameters.AddWithValue("@mail",txtMail.Text);
                cmd.Parameters.AddWithValue("@adres", rchAdres.Text);
                cmd.Connection = bag.baglanti();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Müşteri Başarıyla Güncellendi.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriGetir();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenMusteriID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            TxtAdSoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtFirma.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            mskTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            rchAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
