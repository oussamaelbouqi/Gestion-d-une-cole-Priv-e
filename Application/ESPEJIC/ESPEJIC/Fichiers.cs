using ESPEJIC.UserControl_Fichiers;
using ESPEJIC.UserControl_Formatteur;
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
    public partial class Fichiers : Form
    {
        public Fichiers()
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
        private void btn_home_f_Click(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void btn_reçu_Click(object sender, EventArgs e)
        {
            Reçu R = new Reçu();
            AddUserControl(R);
        }

        private void btn_stagiaire_Click(object sender, EventArgs e)
        {
            Stagaires stg = new Stagaires();
            AddUserControl(stg);
        }

        private void btn_stage_Click(object sender, EventArgs e)
        {
            Stage St = new Stage();
            AddUserControl(St);
        }

        private void bt_stati_Click(object sender, EventArgs e)
        {
            Stati Stat = new Stati();
            AddUserControl(Stat);
        }

        private void Fichiers_Load(object sender, EventArgs e)
        {

        }
    }
}
