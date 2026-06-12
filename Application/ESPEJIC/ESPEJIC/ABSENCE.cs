using ESPEJIC.Usercontrol_Absence;
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
    public partial class ABSENCE : Form
    {
        private bool timers;
        private bool timers1;
        private bool timersmenu;
        public ABSENCE()
        {
            InitializeComponent();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {

            button2.BackColor = Color.FromArgb(51, 51, 51);
        }

        private void Modifier_Abs_Load(object sender, EventArgs e)
        {
            panel11.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel11.Show();
            timerstage.Start();
            Modifier.BackColor = Color.FromArgb(23, 24, 29);
            Insert.BackColor = Color.FromArgb(23, 24, 29);
            List.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timers)
            {
                panel11.Height -= 7;
                if (panel11.Height == panel11.MinimumSize.Height)
                {
                    timerstage.Stop();
                    timers = false;
                }
               
            }
            else
            {
                panel11.Height += 7;
                if (panel11.Height == panel11.MaximumSize.Height)
                {
                    timerstage.Stop();
                    timers = true;
                }
            }
        }

        private void timerprof_Tick(object sender, EventArgs e)
        {
            if (timers1)
            {
                panel12.Height -= 7;
                if (panel12.Height == panel12.MinimumSize.Height)
                {
                    timerprof.Stop();
                    timers1 = false;
                }
            }
            else
            {
               

                panel12.Height += 7;
                if (panel12.Height == panel12.MaximumSize.Height)
                {
                    timerprof.Stop();
                    timers1 = true;
                }

            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(51,51,51) ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerprof.Start();
            modifier1.BackColor = Color.FromArgb(23, 24, 29);
            list1.BackColor = Color.FromArgb(23, 24, 29);
            insert1.BackColor = Color.FromArgb(23, 24, 29);

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void timermenu_Tick(object sender, EventArgs e)
        {
            if (timersmenu)
            {
                PANEL.Width += 7;
                if (PANEL.Width == PANEL.MaximumSize.Width)
                {
                    timermenu.Stop();
                    timersmenu = false;
                    
                }
            }
            else
            {
                PANEL.Width -= 7;
                
                if (PANEL.Width == PANEL.MinimumSize.Width)
                {
                   
                    timermenu.Stop();
                    timersmenu = true;
                }     
            }
        }

        private void btn_menu_f_Click(object sender, EventArgs e)
        {
        }

        private void btn_home_f_Click_1(object sender, EventArgs e)
        {
            Menu st = new Menu();
            st.Show();
            this.Hide();
        }

        private void AddUsercontrol (UserControl usecontrols)
        {
            usecontrols.Dock= DockStyle.Fill;
            PANELL.Controls.Clear();
            PANELL.Controls.Add(usecontrols);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UserControlAbs user = new UserControlAbs();
            AddUsercontrol(user);
        }

        private void Insert_MouseHover(object sender, EventArgs e)
        {
            Insert.BackColor = Color.FromArgb(51, 51, 51);
            Modifier.BackColor = Color.FromArgb(23, 24, 29);
            List.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void Insert_MouseLeave(object sender, EventArgs e)
        {
            Modifier.BackColor = Color.FromArgb(51, 51, 51);
            List.BackColor = Color.FromArgb(23, 24, 29);
            Insert.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void Modifier_MouseHover(object sender, EventArgs e)
        {
            Modifier.BackColor = Color.FromArgb(51, 51, 51);
            Insert.BackColor = Color.FromArgb(23, 24, 29);
            List.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void List_MouseHover(object sender, EventArgs e)
        {
            Modifier.BackColor = Color.FromArgb(23, 24, 29);
            Insert.BackColor = Color.FromArgb(23, 24, 29);
            List.BackColor = Color.FromArgb(51, 51, 51);
        }

        private void Modifier_Click(object sender, EventArgs e)
        {
            UserControlMos mo= new UserControlMos();
            AddUsercontrol(mo);
        }

        private void List_Click(object sender, EventArgs e)
        {
            UserControlLis lis= new UserControlLis();
            AddUsercontrol(lis);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            usercontrolforAbf forabs = new usercontrolforAbf();
            AddUsercontrol(forabs);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UserControlMof formo = new UserControlMof();
            AddUsercontrol(formo);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UserControlLif forLi = new UserControlLif();
            AddUsercontrol(forLi);
        }

        private void insert1_MouseHover(object sender, EventArgs e)
        {
            insert1.BackColor = Color.FromArgb(51, 51, 51);
            modifier1.BackColor = Color.FromArgb(23, 24, 29);
            list1.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void modifier1_MouseHover(object sender, EventArgs e)
        {
            modifier1.BackColor = Color.FromArgb(51, 51, 51);
            insert1.BackColor = Color.FromArgb(23, 24, 29);
            list1.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void list1_MouseHover(object sender, EventArgs e)
        {
            list1.BackColor = Color.FromArgb(51, 51, 51);
            insert1.BackColor = Color.FromArgb(23, 24, 29);
            modifier1.BackColor = Color.FromArgb(23, 24, 29);
        }

        private void insert1_Click(object sender, EventArgs e)
        {
            usercontrolforAbf forab = new usercontrolforAbf();
            AddUsercontrol(forab);
        }

    }
}
