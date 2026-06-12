using ESPEJIC.UserControl_Note;
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
    public partial class Note : Form
    {
        public Note()
        {
            InitializeComponent();
        }

        private void AddUsercontrol(UserControl usecontrols)
        {
            usecontrols.Dock = DockStyle.Fill;
            panel9.Controls.Clear();
            panel9.Controls.Add(usecontrols);
        }

        private void Ajouter_btn_Click(object sender, EventArgs e)
        {
            Ajouter_N ajouter_N = new Ajouter_N();
            AddUsercontrol(ajouter_N);
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modifier_N md = new Modifier_N();
            AddUsercontrol(md);
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            this.Hide();
            mn.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bulletin bl = new Bulletin();
            AddUsercontrol(bl);
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Liste_N ls = new Liste_N();
            AddUsercontrol(ls);
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Modalite_de_passage md = new Modalite_de_passage();
            AddUsercontrol (md);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bulltien_Général bt = new Bulltien_Général();
            AddUsercontrol(bt);
        }
    }
}
