using ESPEJIC.UserControl_Paiment;
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
    public partial class Payment : Form
    {
        public Payment()
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
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Paiment_Stagaire paiment_Stagaire = new Paiment_Stagaire();
            AddUserControl(paiment_Stagaire);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Paiment_Stagaire pys = new Paiment_Stagaire();
            AddUserControl(pys);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Salaire_For salaire_For = new Salaire_For();
            AddUserControl(salaire_For);
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }
    }
}
