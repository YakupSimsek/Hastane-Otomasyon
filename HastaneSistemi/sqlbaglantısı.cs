using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneSistemi
{
    internal class sqlbaglantısı
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=YAKUP\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
