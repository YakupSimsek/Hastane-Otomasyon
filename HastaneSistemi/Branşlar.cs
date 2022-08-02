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

namespace HastaneSistemi
{
    public partial class Branşlar : Form
    {
        public Branşlar()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Branşlar_Load(object sender, EventArgs e)
        {
            //branşlar
            DataTable dtbrans = new DataTable();
            SqlDataAdapter dabrans = new SqlDataAdapter("select BransAd from BransTbl", bgl.baglantı());
            dabrans.Fill(dtbrans);
            dataGridView1.DataSource = dtbrans;

           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;            
            txtbransad.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into BransTbl(BransAd) values (@p1)", bgl.baglantı());
            komutekle.Parameters.AddWithValue("@p1", txtbransad.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Yeni Branş Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from BransTbl where BransAd=@p1 ", bgl.baglantı());
            komutsil.Parameters.AddWithValue("@p1", txtbransad.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Branş Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
