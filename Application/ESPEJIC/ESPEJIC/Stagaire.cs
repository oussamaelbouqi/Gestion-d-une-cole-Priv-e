using ESPEJIC.UserController;
using ESPEJIC.UserController_Stagaire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC
{
    public partial class Stagaire : Form
    {
        public Stagaire()
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

        private void button5_Click(object sender, EventArgs e)
        {
            Ajouter ajouter = new Ajouter();
            AddUserControl(ajouter);
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modifer_S mstg = new Modifer_S();
            AddUserControl(mstg);
            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            La_liste liste = new La_liste();
            AddUserControl(liste);
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Stagaire_Load(object sender, EventArgs e)
        {

        }

        private void btn_home_click(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Note nt = new Note();
            nt.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ABSENCE aBSENCE = new ABSENCE();
            aBSENCE.Show();
            this.Hide();
        }
    }
}
