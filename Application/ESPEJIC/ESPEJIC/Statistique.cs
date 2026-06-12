using ESPEJIC.Usercontrol_Absence;
using ESPEJIC.UserControl_Statistique;
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
    public partial class Statistique : Form
    {
        public Statistique()
        {
            InitializeComponent();
        }

        private void AddUsercontrol(UserControl usecontrols)
        {
            usecontrols.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(usecontrols);
        }

        private void btn_home_f_Click(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void btn_liste_f_Click(object sender, EventArgs e)
        {
            liste_statis list_stq = new liste_statis();
            AddUsercontrol(list_stq);
        }
    }
}
