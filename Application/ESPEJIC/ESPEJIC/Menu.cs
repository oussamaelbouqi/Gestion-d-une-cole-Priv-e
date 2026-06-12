using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Formatteur fr = new Formatteur();
            fr.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Stagaire st1 = new Stagaire();
            st1.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void stg_label_Click(object sender, EventArgs e)
        {
            Config_admin st1 = new Config_admin();
            st1.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Config_admin st1 = new Config_admin();
            st1.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Formatteur fr = new Formatteur();
            fr.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Payment py = new Payment();
            py.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Payment py = new Payment();
            py.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ABSENCE aBSENCE = new ABSENCE();
            aBSENCE.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Gestion_de_stagaire gs = new Gestion_de_stagaire();
            gs.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Gestion_de_stagaire gs = new Gestion_de_stagaire();
            gs.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Note nt = new Note();
            this.Hide();
            nt.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Note nt = new Note();
            this.Hide();
            nt.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            autre at = new autre();
            at.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Statistique st = new Statistique();
            st.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Archives ar = new Archives();   
            ar.Show();
            this.Hide();
        }
    }
}
