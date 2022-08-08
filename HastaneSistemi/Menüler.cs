using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneSistemi
{
    public partial class Menüler : Form
    {
        public Menüler()
        {
            InitializeComponent();
            Desing();
        }
        private void Desing()
        {
            pnlmenu1.Visible = false;
            pnlmenu2.Visible = false;
            pnlduyuru.Visible = false;
            pnlrecete.Visible = false;
            
        }
        private void HideMenu()
        {
            if (pnlmenu1.Visible == true)
                pnlmenu1.Visible = false;
            if (pnlmenu2.Visible == true)
                pnlmenu2.Visible = false;
            if(pnlduyuru.Visible==true)
                pnlduyuru.Visible=false;
            if(pnlrecete.Visible==true)
                pnlrecete.Visible=false; 
            
        }
        private void ShowMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnmenu1_Click(object sender, EventArgs e)
        {
            ShowMenu(pnlmenu1);
        }

        private void btnmenu2_Click(object sender, EventArgs e)
        {
            ShowMenu(pnlmenu2);
        }

        private Form activeForm = null;
        private void anapanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlana.Controls.Add(childForm);
            pnlana.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            anapanel(new Branşlar()); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anapanel(new Doktor());
        }

        private void btnduyuru_Click(object sender, EventArgs e)
        {
            ShowMenu(pnlduyuru);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            anapanel(new Randevuoluştur());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            anapanel(new AktifRandevu());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            anapanel(new DuyuruOluştur());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anapanel(new AktifRandevular()); ;
        }

        private void btnreceteolustur_Click(object sender, EventArgs e)
        {
            anapanel(new ReceteOlustur()) ;
        }

        private void btnrecete_Click(object sender, EventArgs e)
        {
            ShowMenu(pnlrecete);
        }

        private void btnakfrecete_Click(object sender, EventArgs e)
        {
            anapanel(new AktıfRecete());
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Login fr = new Login();
            fr.Show();
            this.Hide();
        }
    }
}
