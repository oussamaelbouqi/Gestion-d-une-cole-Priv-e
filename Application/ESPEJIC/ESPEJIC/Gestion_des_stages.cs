using ESPEJIC.gestion_de_stage;
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
    public partial class Gestion_de_stagaire : Form
    {  
        bool times;
        bool times1;
        bool times2;

        public Gestion_de_stagaire()
        {
            InitializeComponent();        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(times)
            {

                panel11.Height += 7;
                if (panel11.Height == panel11.MaximumSize.Height)
                {
                    timer1.Stop();
                    times = false;
                }
            }
            else
            {
             
                panel11.Height -= 7;
                if (panel11.Height == panel11.MinimumSize.Height)
                {
                    timer1.Stop();
                    times = true;
                }
            }
        }

        private void Gestion_de_stagaire_Load(object sender, EventArgs e)
        {

        }

        private void utilisateur(UserControl user)
        {
            user.Dock = DockStyle.Fill;
            panel13.Controls.Clear();
            panel13.Controls.Add(user);

        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (times1)
            {

                panel11.Width += 7;
                if (panel11.Width == panel11.MaximumSize.Width)
                {
                    timer2.Stop();
                    times1 = false;
                    
                }
            }
            else
            {

                panel11.Width -= 7;
                if (panel11.Width == panel11.MinimumSize.Width)
                {
                    timer2.Stop();
                    times1 = true;
                  
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(times2)
            {
                panel12.Height += 7; 
                if (panel12.Height== panel12.MaximumSize.Height)
                {
                    timer3.Stop(); 
                    times2=false;

                }
                
            }
            else
            {
                panel12.Height -= 7;
                if (panel12.Height==panel12.MinimumSize.Height)
                {
                    timer3.Stop();
                    times2=true;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            stage_1er_anne ha = new stage_1er_anne();

            utilisateur(ha);
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            modifier_stage_1ere ha = new modifier_stage_1ere();
            utilisateur(ha);
        }

        private void List_Click(object sender, EventArgs e)
        {
            la_liste_1ere ha = new la_liste_1ere();
            utilisateur(ha);
        }

        private void insert1_Click(object sender, EventArgs e)
        {
            stage_2eme_anne st = new stage_2eme_anne();
            utilisateur(st);
        }

        private void modifier1_Click(object sender, EventArgs e)
        {
            modifier_stage_2eme ha = new modifier_stage_2eme();
            utilisateur(ha);
        }

        private void list1_Click(object sender, EventArgs e)
        {
            la_liste_2eme ha = new la_liste_2eme();
            utilisateur(ha);
        }

        private void btn_home_f_Click_1(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void btn_menu_f_Click(object sender, EventArgs e)
        {
            timer2.Start();

        }
    }
}
