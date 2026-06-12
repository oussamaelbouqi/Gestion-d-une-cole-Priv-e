

using ESPEJIC.UserControl_Note;
using ESPEJIC.UserControl_Note_Arch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC.Archive_forms
{
    public partial class Note_Archives : Form
    {
        public Note_Archives()
        {
            InitializeComponent();
        }
        private void AddUsercontrol(UserControl usecontrols)
        {
            usecontrols.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(usecontrols);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            // Bulletin bl = new Bulletin();
            //AddUsercontrol(bl);
            //this.MaximizeBox = false;
            //this.WindowState = FormWindowState.Normal;

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Archives menu = new Archives();
            menu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListeNote_Arch lst = new ListeNote_Arch();
            AddUsercontrol(lst);
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            modilateV2 v2= new modilateV2();
            AddUsercontrol(v2);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Bulletin_Arch bl_ar = new Bulletin_Arch();
            AddUsercontrol(bl_ar);
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void btn_home_Click_1(object sender, EventArgs e)
        {
            Menu mn= new Menu();
            mn.Show();
            this.Hide();
        }
    }
}
