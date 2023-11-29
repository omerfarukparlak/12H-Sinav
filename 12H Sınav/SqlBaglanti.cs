using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _12H_Sınav
{
    internal class SqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection bag = new SqlConnection("Data Source=DESKTOP-AF7QEIJ\\SQLEXPRESS;Initial Catalog=stok_takip_db;Integrated Security=True");
            bag.Open();
            return bag;
        }
    }
}
