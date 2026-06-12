using ESPEJIC.UserControl_Archive.UserControl_Ficher_Arch;
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
    public partial class Ficher_Archiv : Form
    {
        public Ficher_Archiv()
        {
            InitializeComponent();
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btn_stagiaire_Click(object sender, EventArgs e)
        {
            Stagaire_arch stagaire_Arch = new Stagaire_arch();
            AddUserControl(stagaire_Arch);
        }

        private void btn_home_f_Click(object sender, EventArgs e)
        {
            Archives archives = new Archives();
            archives.Show();
            this.Hide();
        }
    }
}
