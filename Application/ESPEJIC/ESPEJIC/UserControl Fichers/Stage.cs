using ESPEJIC.UserControl_Fichers;
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

namespace ESPEJIC.UserControl_Fichiers
{
    public partial class Stage : UserControl
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        private Demande_de_stage dms;
        private Convention_de_stage convention;
        public Stage()
        {
            InitializeComponent();
            dms = new Demande_de_stage();
            convention = new Convention_de_stage();
            dms.Visible = false;
            convention.Visible = false;
            panel2.Controls.Add(dms);
            panel2.Controls.Add(convention);
        }

        private void Stage_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Demande de Stage");
            comboBox2.Items.Add("Convention de Stage");
            comboBox2.Items.Add("Attestation de Stage");
            comboBox2.Items.Add("Fiche Evaluation Stage");
            comboBox2.Items.Add("Attestation de Stage");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text == "Demande de Stage")
            {
                dms.Visible = true;
            }
            if(comboBox2.Text == "Convention de Stage")
            {
                dms.Visible = false;
                convention.Visible = true;
            }
        }
    }
}
