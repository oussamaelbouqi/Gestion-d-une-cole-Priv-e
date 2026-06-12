using ESPEJIC.UserControl_Formatteur;
using ESPEJIC.UserController;
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
    public partial class Formatteur : Form
    {
        public Formatteur()
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
        private void btn_ajouter_f_Click(object sender, EventArgs e)
        {
            Ajouter_F ajouter = new Ajouter_F();
            AddUserControl(ajouter);
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void panel_f_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_home_f_Click(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void btn_liste_f_Click(object sender, EventArgs e)
        {
            Liste_F liste = new Liste_F();
            AddUserControl(liste);
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btn_modifier_f_Click(object sender, EventArgs e)
        {
            Modifier_F mdf = new Modifier_F();
            AddUserControl(mdf);
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
        }
    }
}
