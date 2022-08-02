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
    public partial class Doktor : Form
    {
        public Doktor()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Doktor_Load(object sender, EventArgs e)
        {
            DataTable dtdoktor = new DataTable();
            SqlDataAdapter dadoktor = new SqlDataAdapter("select * from Users where role= 'doktor'", bgl.baglantı());
            dadoktor.Fill(dtdoktor);
            dataGridView1.DataSource = dtdoktor;

            //kutuya bransları çekme
            SqlCommand komutbranş = new SqlCommand("Select Brans from Users", bgl.baglantı());
            SqlDataReader drbranş = komutbranş.ExecuteReader();
            while (drbranş.Read())
            {
                cmbbrans.Items.Add(drbranş[0]);
            }
            bgl.baglantı().Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komutekle = new SqlCommand("insert into Users (Username,password,role,brans) values (@p1,@p2,@p3,@p4)", bgl.baglantı());
            komutekle.Parameters.AddWithValue("@p1", txtad.Text);
            komutekle.Parameters.AddWithValue("@p2", txtsifre.Text);
            komutekle.Parameters.AddWithValue("@p3", txtrole.Text);
            komutekle.Parameters.AddWithValue("@p4", cmbbrans.Text);
            komutekle.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Doktor Kaydı Gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete from Users where Username=@p1", bgl.baglantı());
            komutsil.Parameters.AddWithValue("@p1", txtad.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kaydınız Silinmiştir", "Uyaarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }
    }
    }

