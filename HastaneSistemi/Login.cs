using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace HastaneSistemi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=YAKUP\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
        private void btnkapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtad_Click(object sender, EventArgs e)
        {
            txtad.BackColor = Color.White;
            pnlad.BackColor = Color.White;
            txtsifre.BackColor = SystemColors.Control;
            pnlsifre.BackColor = SystemColors.Control;
            lblad.Visible = false;

            if (txtsifre.Text=="")
            {
                lblsifre.Visible = true;
                lblhata.Text = "Formu doldurunuz!!";
            }

        }

        private void txtsifre_Click(object sender, EventArgs e)
        {
            txtsifre.BackColor = Color.White;
            pnlsifre.BackColor = Color.White;
            txtad.BackColor = SystemColors.Control;
            pnlad.BackColor = SystemColors.Control;
            lblsifre.Visible = false;

            if (txtad.Text == "")
            {
                lblad.Visible = true;
                lblhata.Text = "Formu doldurunuz!!";

            }
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtsifre.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtsifre.UseSystemPasswordChar = true;
        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {
            if (txtad.Text == "")
            {
                lblad.Visible = true;
                lblhata.Text = "Formu doldurunuz!!";
            }
            else
            {
                lblad.Visible = false;
                lblhata.Text = "";
            }
        }

        private void txtsifre_TextChanged(object sender, EventArgs e)
        {
            if (txtsifre.Text == "")
            {
                lblsifre.Visible = true;
                lblhata.Text = "Formu doldurunuz!!";
            }
            else
            {
                lblsifre.Visible = false;
                lblhata.Text = "";
            }
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                
                SqlCommand komut = new SqlCommand("select * from Users inner join roles on users.role = roles.role where username = @p1 and password = @p2", con);
                komut.Parameters.AddWithValue("@p1", txtad.Text);
                komut.Parameters.AddWithValue("@p2", txtsifre.Text);
                SqlDataAdapter sda = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string rol = dt.Rows[0][6].ToString();
                    if (rol == "doktor")
                    {
                        Menüler fr = new Menüler();
                        fr.btnmenu1.Visible = false;
                        fr.btnranolustur.Visible = false;
                        fr.Show();
                        this.Hide();


                    }
                    else if (rol == "sekreter")
                    {
                        Menüler fr = new Menüler();
                        fr.Show();
                        fr.btnreceteolustur.Visible = false;
                        this.Hide();

                    }
                }
                else
                {
                    lblhata.Text = "Hatalı kullancı adı veya sifre !!";
                }

                con.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
