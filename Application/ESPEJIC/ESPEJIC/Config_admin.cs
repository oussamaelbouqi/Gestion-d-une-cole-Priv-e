using ESPEJIC.UserControl_Admin;
using ESPIGIC;
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
    public partial class Config_admin : Form
    {
        public Config_admin()
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

        private void btn_home_Click(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void Config_admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Resert_password st = new Resert_password();
            st.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset_Admin restadmin = new Reset_Admin();
            AddUserControl(restadmin);
        }
    }
}
