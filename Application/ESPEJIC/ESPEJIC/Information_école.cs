using ESPEJIC.UserControl_Ecole;
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
    public partial class Information_école : Form
    {
        public Information_école()
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
        private void btn_modifier_f_Click(object sender, EventArgs e)
        {
            Modifier_Inf_El Mdf_Inf = new Modifier_Inf_El();
            AddUserControl(Mdf_Inf);
        }

        private void btn_home_f_Click(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            autre at = new autre();
            at.Show();
            this.Hide();
        }
    }
}
