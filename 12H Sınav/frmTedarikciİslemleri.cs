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
    public partial class frmTedarikciİslemleri : Form
    {
        public frmTedarikciİslemleri()
        {
            InitializeComponent();
        }
        SqlBaglanti bag = new SqlBaglanti();
        int seciliTedarikciId = 0;
        void TedarikciListele()
        {
            SqlCommand cmd = new SqlCommand("Select * from tedarikciler", bag.baglanti());
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        void FormuTemizle()
        {
           txtAdSoyad.Text = string.Empty;
           txtFirma.Text = string.Empty;
           txtMail.Text = string.Empty;
           rchAdres.Text = string.Empty;
           mskTelefon.Text = string.Empty;
        }
        private void frmTedarikciİslemleri_Load(object sender, EventArgs e)
        {
            TedarikciListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormuTemizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sorgu = "insert into tedarikciler(firma_adi,yetkili_adsoyad,telefon,mail,adres)values(@firma,@yetkili,@tel,@mail,@adres)";
            SqlCommand cmd = new SqlCommand(sorgu);
            cmd.Connection = bag.baglanti();
            cmd.Parameters.AddWithValue("@firma",txtFirma.Text);
            cmd.Parameters.AddWithValue("@yetkili", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@tel", mskTelefon.Text);
            cmd.Parameters.AddWithValue("@mail", txtMail.Text);
            cmd.Parameters.AddWithValue("@adres", rchAdres.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Tedarikçi Başarıyla Eklendi.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TedarikciListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sorgu = "delete from tedarikciler where id='"+seciliTedarikciId+"'";
            SqlCommand cmd = new SqlCommand(sorgu);
            cmd.Connection = bag.baglanti();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Tedarikçi Başarıyla Silindi.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TedarikciListele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sorgu = "update tedarikciler set firma_adi=@firma,yetkili_adsoyad=@yetkili,telefon=@tel,mail=@mail,adres=@adres";
            SqlCommand cmd = new SqlCommand(sorgu);
            cmd.Connection = bag.baglanti();
            cmd.Parameters.AddWithValue("@firma",txtFirma.Text);
            cmd.Parameters.AddWithValue("@yetkili", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@tel", mskTelefon.Text);
            cmd.Parameters.AddWithValue("@mail", txtMail.Text);
            cmd.Parameters.AddWithValue("@adres", rchAdres.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Tedarikçi Başarıyla Güncellendi.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TedarikciListele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtFirma.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            mskTelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            rchAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            seciliTedarikciId= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
