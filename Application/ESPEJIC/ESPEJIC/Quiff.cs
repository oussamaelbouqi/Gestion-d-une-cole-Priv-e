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
    public partial class Quiff : Form
    {
        public Quiff()
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

        private void Quiff_Load(object sender, EventArgs e)
        {
            Modifier_Qui ajouter = new Modifier_Qui();
            AddUserControl(ajouter);
        }
    }
}
