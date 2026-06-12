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
    public partial class autre : Form
    {
        public autre()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Modul md = new Modul();
            md.Show();
            this.Hide();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Information_école ie = new Information_école();
            ie.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Information_école ie = new Information_école();
            ie.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Fichiers fc = new Fichiers();
            fc.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Add_Document add_Document = new Add_Document();
            add_Document.Show();
            this.Hide();
        }

        private void autre_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Filiére fl = new Filiére();
            fl.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Filiére fl = new Filiére();
            fl.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Quiff qf = new Quiff();
            qf.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Quiff qf = new Quiff();
            qf.Show();
            this.Hide();
        }
    }
}
