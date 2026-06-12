using ESPEJIC.Archive_forms;
using ESPEJIC.UserControl_Archive;
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
    public partial class Archives : Form
    {
        public Archives()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu ();
            mn.Show ();
            this.Hide ();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Note_Archives nt_archive = new Note_Archives ();
            nt_archive.Show ();
             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ListeStagaire_Archive list_arch=new ListeStagaire_Archive ();
            list_arch.Show ();
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Paiment_Arch py = new Paiment_Arch ();
            py.Show ();
            this.Hide ();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Testor3 ts = new Testor3 ();
            ts.Show ();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ficher_Archiv ficher_Archiv = new Ficher_Archiv ();
            ficher_Archiv.Show ();
            this.Hide ();
        }
    }
}
