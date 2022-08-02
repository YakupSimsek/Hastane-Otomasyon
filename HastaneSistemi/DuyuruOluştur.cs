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
    public partial class DuyuruOluştur : Form
    {
        public DuyuruOluştur()
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
            SqlCommand komut = new SqlCommand("insert into DuyuruTbl (Duyuru) values(@p1)", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",rtxtduyuru.Text);
            komut.ExecuteReader();
            bgl.baglantı().Close();
            MessageBox.Show("Duyuru oluşturulmuştur.","Kayıt",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
