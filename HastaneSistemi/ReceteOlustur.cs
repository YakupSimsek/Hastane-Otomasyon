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
namespace HastaneSistemi
{
    public partial class ReceteOlustur : Form
    {
        public ReceteOlustur()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into ReceteTbl (Recete,HastaTc) values (@p1,@p2);", bgl.baglantı()) ;
            komut.Parameters.AddWithValue("@p1",rtxtrecete.Text);
            komut.Parameters.AddWithValue("@p2",msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı();
            MessageBox.Show("Reçete Oluşturuldu.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
