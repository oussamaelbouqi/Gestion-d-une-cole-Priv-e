using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.UserControl_Note
{
    public partial class Modifier_N : UserControl
    {
        public SqlConnection cn;
        public SqlCommand cmd, cmd1;
        public SqlDataReader dr;
        public Modifier_N()
        {
            cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
             InitializeComponent();
        }
        private void Empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox8.Text = "";      
        }

        private void Modifier_N_Load(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("Select Type_stagaire from Classe", cn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }
                cn.Close();
            }
            cn.Close();
            comboBox1.DisplayMember = "Type_stagaire";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "1er année")
            {
                label2.Text = "Control Continus 1 :";
                label9.Text = "EFCFT 1 :";
                label4.Text = "EFCFP 1 :";
            }
            else if(comboBox1.Text == "2émé année")
            {
                label2.Text = "Control Continus 2 :";
                label9.Text = "EFCFT 2 :";
                label4.Text = "EFCFP 2 :";
            }
            cn.Open();
            comboBox3.Items.Clear();
            dgvstagaire1.Rows.Clear();
            textBox8.Text = "";
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            cmd = new SqlCommand("Select Nom_stagaire+' '+Pre_stagaire from Stagaire where Type_stagaire= '"+ comboBox1.Text +"' ", cn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr[0]);
                }
            }
           cn.Close();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select CIN_stagaire from Stagaire where  Nom_stagaire+' '+Pre_stagaire ='" + comboBox3.Text + "'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                SqlDataReader dr1 = cmd.ExecuteReader();
                if (dr1.HasRows)
                {
                    while (dr1.Read())
                    {
                        textBox7.Text = dr1[0].ToString();
                    }
                }
                cn.Close();
                dr1.Close();
            }
            dgvstagaire1.Rows.Clear();
            textBox8.Text = "";
            textBox1.Text = string.Empty;
            textBox2.Text= string.Empty;
            textBox3.Text = string.Empty;
            cmd = new SqlCommand(" select Nom_Mat,Control_C,EFCE_thero,EFCE_prat,ID_Note ,Matiére.ID_Matiére from Note inner join Matiére on  Matiére.ID_Matiére=Note.ID_Matiére inner join Stagaire on Stagaire.CIN_Stagaire=Note.CIN_Stagaire where Nom_stagaire+' '+Pre_stagaire= '" + comboBox3.Text + "'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
             if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.dgvstagaire1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
            }
            cn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Veuillez sélectionner le stagaire que vous souhaitez modifier.");
                return;
            }
            string query = "update Note set Control_C = @Control_C ,EFCE_thero = @EFCE_thero,EFCE_prat = @EFCE_prat where CIN_Stagaire= @CIN_stagaire and ID_Matiére= @ID_Matiére";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                string Control_C = textBox1.Text;
                string EFCE_thero = textBox2.Text;
                string EFCE_pra = textBox3.Text;
                Control_C = Control_C.Replace('.', ',');
                EFCE_thero = EFCE_thero.Replace('.', ',');
                EFCE_pra = EFCE_pra.Replace('.', ',');
                cn.Close();
                cn.Open();
                cmd.Parameters.AddWithValue("@Control_C", float.Parse(Control_C));
                cmd.Parameters.AddWithValue("@EFCE_thero", float.Parse(EFCE_thero));
                cmd.Parameters.AddWithValue("@EFCE_prat", float.Parse(EFCE_pra));
                cmd.Parameters.AddWithValue("@CIN_stagaire", textBox7.Text);
                cmd.Parameters.AddWithValue("@ID_Matiére", textBox6.Text);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("La note de cette Stagaire est modifier");
                }
                else
                {
                    MessageBox.Show("Aucune ligne n'a été Modifier");
                }
                cn.Close();
            }
            Empty();
            dgvstagaire1.Rows.Clear();
            cmd = new SqlCommand(" select Nom_Mat,Control_C,EFCE_thero,EFCE_prat from Note inner join Matiére on  Matiére.ID_Matiére=Note.ID_Matiére inner join Stagaire on Stagaire.CIN_Stagaire=Note.CIN_Stagaire where Nom_stagaire+' '+Pre_stagaire= '" + comboBox3.Text + "'", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.dgvstagaire1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                }
            }
            cn.Close();
        }

        private void dgvstagaire1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text="";
            int position = dgvstagaire1.CurrentRow.Index;
            this.textBox8.Text = this.dgvstagaire1.Rows[position].Cells[0].Value.ToString();
            this.textBox1.Text = this.dgvstagaire1.Rows[position].Cells[1].Value.ToString();
            this.textBox2.Text = this.dgvstagaire1.Rows[position].Cells[2].Value.ToString();
            this.textBox3.Text = this.dgvstagaire1.Rows[position].Cells[3].Value.ToString();
            string text = textBox8.Text;
            string value = text.Replace("'", "''");
            string query = "Select ID_Matiére from Matiére where Nom_Mat='" + value + "'";
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBox6.Text = dr[0].ToString();
                    }
                }
                cn.Close();
                dr.Close();
            }
        }     
    }
}

