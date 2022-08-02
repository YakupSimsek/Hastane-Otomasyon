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
    public partial class Randevuoluştur : Form
    {
        public Randevuoluştur()
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
            SqlCommand komutkaydet = new SqlCommand("insert into RandevularTbl (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor,HastaTc) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglantı());
            komutkaydet.Parameters.AddWithValue("@p1", msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@p2", msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@p4", cmbdoktor.Text);
            komutkaydet.Parameters.AddWithValue("@p5", msktc.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Randevu Kaydınız Gerçekleşmiştir.", "Kayıt");
        }

        private void Randevuoluştur_Load(object sender, EventArgs e)
        {
            SqlCommand komutbranş = new SqlCommand("Select BransAd from BransTbl", bgl.baglantı());
            SqlDataReader drbranş = komutbranş.ExecuteReader();
            while (drbranş.Read())
            {
                cmbbrans.Items.Add(drbranş[0]);
            }
            bgl.baglantı().Close();
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komutdoktor = new SqlCommand("Select username from Users where role = 'doktor' AND Brans =  @p1", bgl.baglantı());
            komutdoktor.Parameters.AddWithValue("@p1",cmbbrans.Text);
            SqlDataReader drdoktor = komutdoktor.ExecuteReader();
            while (drdoktor.Read())
            {
                cmbdoktor.Items.Add(drdoktor[0].ToString());
            }
            bgl.baglantı().Close();
        }
    }
    }

