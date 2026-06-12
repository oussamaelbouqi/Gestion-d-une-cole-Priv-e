using ESPEJIC.UserControl_Document;
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
    public partial class Add_Document : Form
    {
        public Add_Document()
        {
            InitializeComponent();
        }
        private void AddUsercontrol(UserControl usecontrols)
        {
            usecontrols.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(usecontrols);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ajouter_Document ajouter_Document = new Ajouter_Document();
            AddUsercontrol(ajouter_Document);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Modifier_Document modifier_Document = new Modifier_Document();
            AddUsercontrol(modifier_Document);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Printt_Docoment printt_Docoment = new Printt_Docoment();
            AddUsercontrol (printt_Docoment);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            autre at = new autre();
            at.Show();
            this.Hide();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }
    }
}
