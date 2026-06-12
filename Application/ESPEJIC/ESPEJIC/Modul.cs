using ESPEJIC.UseControl_Quiffance;
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
    public partial class Modul : Form
    {
        public Modul()
        {
            InitializeComponent();
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel9.Controls.Clear();
            panel9.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            Ajouter_M ajouter = new Ajouter_M();
            AddUserControl(ajouter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modifier_M modifier_m = new Modifier_M();
            AddUserControl (modifier_m);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            la_liste_M la_Liste = new la_liste_M();
            AddUserControl(la_Liste);
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            autre stt = new autre();
            stt.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modifier_Qui qf = new Modifier_Qui();
            AddUserControl(qf);
        }
    }
}
