using ESPEJIC.UserControl_Fichers;
using ESPEJIC.UserControl_Note;
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
    public partial class Stagaires : UserControl
    {
        private Bulletins bul;
        private ListeAbs labs;
        private Attes_passage atp;
        private Atte_Scol atsc;
        private Attestation_omog omg;
        public Stagaires()
        {
            InitializeComponent();
            bul = new Bulletins();
            labs = new ListeAbs();
            atp = new Attes_passage();
            atsc = new Atte_Scol();
            omg = new Attestation_omog();
            panel2.Controls.Add(bul);
            panel2.Controls.Add(labs);
            panel2.Controls.Add(atp);
            panel2.Controls.Add(atsc);
            panel2.Controls.Add(omg);
            bul.Visible = false;
            labs.Visible = false;
            atp.Visible = false;
            atsc.Visible = false;
            omg.Visible = false;
        }

        private void Stagaire_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("liste d'absence");
            comboBox1.Items.Add("Attestation de réussite");
            comboBox1.Items.Add("Attestation Scolarité");
            comboBox1.Items.Add("Attestation Omologé");
            comboBox1.Items.Add("Bulletin générale");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "liste d'absence")
            {
                labs.Visible = true;
                bul.Visible = false;
                atp.Visible = false;
                atsc.Visible = false;
                omg.Visible = false;
            }
            else if (comboBox1.Text == "Bulletin générale")
            {
                bul.Visible = true;
                labs.Visible = false;
                atp.Visible = false;
                omg.Visible=false;
                atsc.Visible = false;
            }
            else if (comboBox1.Text == "Attestation de réussite")
            {
                atp.Visible = true;
                bul.Visible = false;
                labs.Visible = false;
                omg.Visible=false;
                atsc.Visible = false;
            }
            
            else if (comboBox1.Text == "Attestation Scolarité")
            {
                atsc.Visible = true;
                bul.Visible = false;
                labs.Visible = false;
                omg.Visible=false;
                atp.Visible = false;
            }
            else if(comboBox1.Text == "Attestation Omologé")
            {
                omg.Visible = true;
                atsc.Visible = false;
                bul.Visible = false;
                labs.Visible = false;
                atp.Visible = false;
            }

        }
    }
}
