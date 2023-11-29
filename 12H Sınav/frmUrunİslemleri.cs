using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmKategoriİslemleri kategori = new frmKategoriİslemleri();
            DialogResult result = kategori.ShowDialog();
            if (result == DialogResult.Cancel)
            {

            }
        }
    }
}
