using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12H_Sınav
{
    public partial class frmUrunİslemleri : Form
    {
        public frmUrunİslemleri()
        {
            InitializeComponent();
        }
        SqlBaglanti bag = new SqlBaglanti();
        int secilenUrunKodu = 0;
        void UrunGetir()
        {
            var sorgu = "Select urun_kodu,urun_adi,stok_adedi,fiyat from urunler inner join kategoriler on kategoriler.kategori_id=urunler.kategori_id";
            SqlCommand cmd = new SqlCommand(sorgu);
            cmd.Connection = bag.baglanti();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        void FormuTemizle()
        {
            txtUrun.Text = "";
            txtFiyat.Text = "";
            cmbKategori.Text = "";
            cmbTedarikci.Text = "";
            nmAdet.Value = 0;
            rchAciklama.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategoriİslemleri kategori = new frmKategoriİslemleri();
            DialogResult result = kategori.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                UrunGetir();
            }
        }

        private void frmUrunİslemleri_Load(object sender, EventArgs e)
        {
            UrunGetir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var sorgu = "Insert into urunler(urun_adi_,kategori_id,tedarikci_id,stok_adedi,fiyat,aciklama)values(@ad,@kategori,@tedarikci,@stok,@fiyat,@aciklama)";
                SqlCommand cmd = new SqlCommand(sorgu);
                cmd.Connection = bag.baglanti();
                cmd.Parameters.AddWithValue("@ad", txtUrun.Text);
                cmd.Parameters.AddWithValue("@kategori", cmbKategori.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tedarikci", cmbTedarikci.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@adet", nmAdet.Value);
                cmd.Parameters.AddWithValue("@fiyat", txtFiyat.Text);
                cmd.Parameters.AddWithValue("@aciklama", rchAciklama.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün Başarıyla Eklendi.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UrunGetir();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var sorgu = "delete from urunler where=urun_kodu'" + secilenUrunKodu + "'";
                SqlCommand cmd = new SqlCommand(sorgu);
                cmd.Connection = bag.baglanti();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün Başarıyla Silindi.");
                UrunGetir();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var sorgu = "update urunler set urun_adi=@ad,kategori_id=@kid,tedarikci_id=@tid,stok_adedi=@adet,fiyat=@fiyat,aciklama=@aciklama";
                SqlCommand cmd = new SqlCommand(sorgu);
                cmd.Connection = bag.baglanti();
                cmd.Parameters.AddWithValue("@ad", txtUrun.Text);
                cmd.Parameters.AddWithValue("@kid", cmbKategori.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tid", cmbTedarikci.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@adet", nmAdet.Value);
                cmd.Parameters.AddWithValue("@fiyat", txtFiyat.Text);
                cmd.Parameters.AddWithValue("@aciklama", rchAciklama.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün Başarıyla Güncellendi.");
                UrunGetir();
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrun.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtFiyat.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cmbKategori.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbTedarikci.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            nmAdet.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
            rchAciklama.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
