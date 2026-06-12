using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESPEJIC.UserControl_Archive.UserControl_Ficher_Arch
{
    public partial class Stagaire_arch : UserControl
    {
        private Attestation_rusc_arch ats;
        private Attestation_scol_arch attestation_Scol_Arch;
        private Attestation_omog_arch attestation_omog_Arch;
        private Bulettin_arch bulettin_arch;
        public Stagaire_arch()
        {
            InitializeComponent();
            attestation_Scol_Arch = new Attestation_scol_arch();
            ats = new Attestation_rusc_arch();
            attestation_omog_Arch  = new Attestation_omog_arch();
            bulettin_arch = new Bulettin_arch();
            panel2.Controls.Add(ats);
            panel2.Controls.Add(attestation_Scol_Arch);
            panel2.Controls.Add(attestation_omog_Arch);
            panel2.Controls.Add(bulettin_arch);
            ats.Visible = false;
            attestation_Scol_Arch.Visible = false;
            attestation_omog_Arch.Visible = false;
            bulettin_arch.Visible = false;
        }

        private void Stagaire_arch_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Attestation de réussite");
            comboBox1.Items.Add("Attestation de Scolarité");
            comboBox1.Items.Add("Attestation Omologé");
            comboBox1.Items.Add("Bulletin générale");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Attestation de réussite")
            {
                ats.Visible = true;
                attestation_Scol_Arch.Visible = false;
                bulettin_arch.Visible = false;
                attestation_omog_Arch.Visible = false;
            }
            if(comboBox1.Text == "Attestation de Scolarité")
            {
                ats.Visible=false;
                attestation_Scol_Arch.Visible = true;
                bulettin_arch.Visible = false;
                attestation_omog_Arch.Visible = false;
            }
            if (comboBox1.Text == "Attestation Omologé")
            {
                ats.Visible = false;
                attestation_Scol_Arch.Visible = false;
                attestation_omog_Arch.Visible = true;
                bulettin_arch.Visible = false;
            }
            if(comboBox1.Text == "Bulletin générale")
            {
                ats.Visible = false;
                attestation_Scol_Arch.Visible = false;
                attestation_omog_Arch.Visible = false;
                bulettin_arch.Visible = true;
            }
        }
    }
}
