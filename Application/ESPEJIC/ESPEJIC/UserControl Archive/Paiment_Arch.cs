using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC.UserControl_Archive
{
    public partial class Paiment_Arch : Form
    {
        public Paiment_Arch()
        {
            InitializeComponent();
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void btn_home_f_Click(object sender, EventArgs e)
        {
            Archives ar = new Archives();
            ar.Show();
            this.Hide();
        }

        private void Paiment_Arch_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Laliste_Paiement_Arch ls = new Laliste_Paiement_Arch();
            AddUserControl(ls);
        }
    }
}
