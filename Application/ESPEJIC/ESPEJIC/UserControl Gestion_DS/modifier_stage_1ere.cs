using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ESPEJIC.gestion_de_stage
{
    public partial class modifier_stage_1ere : UserControl
    {
        private string selectedFilePath;
        private string selectedFilePath2;
        public SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True");
        public SqlCommand cmd,cmd1;
        public SqlDataReader dr;
        static private string nomEntr;
        public modifier_stage_1ere()
        {
            InitializeComponent();
        }
        private void Empty()
        {
            CIN_txt.Text = "";
            Date_db_txt.Text = "";
            Date_f_txt.Text = "";
            Nom_txt.Text = "";
            Pre_txt.Text = "";
            Nom_entr_txt.Text = "";
            Tele_txt.Text = "";
            Adrs_txt.Text = "";
            label2.Text = "";
            label14.Text = "";
        }
        private void modifier_stage_1ere_Load(object sender, EventArgs e)
        {
            dgvstagaire.Rows.Clear();
            cmd = new SqlCommand("Select Stage.CIN_Stagaire,Stagaire.Nom_stagaire,Stagaire.Pre_stagaire,Stagaire.Type_stagaire,Nom_Entr,Addrs_Ent,Stage.Tele,Date_d,Date_f,FileNameAtes,FileNameDs from Stage inner join Stagaire on Stage.CIN_Stagaire = Stagaire.CIN_Stagaire where Type_stagaire='1er année'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.dgvstagaire.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
                }
                cn.Close();
            }
            cn.Close();
        }

        private void dgvstagaire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmd = new SqlCommand("Select Stage.CIN_Stagaire, Stagaire.Nom_stagaire, Stagaire.Pre_stagaire, Nom_Entr, Addrs_Ent, Stage.Tele, Date_d, Date_f ,FileNameAtes,FileNameDs from Stage inner join Stagaire on Stage.CIN_Stagaire = Stagaire.CIN_Stagaire where Type_stagaire = '1er année'", cn);
            int position = dgvstagaire.CurrentRow.Index;
            this.CIN_txt.Text = this.dgvstagaire.Rows[position].Cells[0].Value.ToString();
            this.Nom_txt.Text = this.dgvstagaire.Rows[position].Cells[1].Value.ToString();
            this.Pre_txt.Text = this.dgvstagaire.Rows[position].Cells[2].Value.ToString();
            this.Nom_entr_txt.Text = this.dgvstagaire.Rows[position].Cells[4].Value.ToString();
            this.Adrs_txt.Text = this.dgvstagaire.Rows[position].Cells[5].Value.ToString();
            this.Tele_txt.Text = this.dgvstagaire.Rows[position].Cells[6].Value.ToString();
            this.Date_db_txt.Text = this.dgvstagaire.Rows[position].Cells[7].Value.ToString();
            this.Date_f_txt.Text = this.dgvstagaire.Rows[position].Cells[8].Value.ToString();
            nomEntr = this.dgvstagaire.Rows[position].Cells[4].Value.ToString();
            cmd1 = new SqlCommand("Select FileNameAtes , FileNameDs from Stage where CIN_Stagaire ='" + this.dgvstagaire.Rows[position].Cells[0].Value.ToString() + "'", cn);
            cn.Open();
            dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    label2.Text = dr[0].ToString();
                    label14.Text = dr[1].ToString();
                }
            }
            cn.Close();
        }

        private void Mdf_Click(object sender, EventArgs e)
        {
            string cont = " where CIN_Stagaire = '" + CIN_txt.Text + "' and Nom_Entr='"+ nomEntr+ "'";
            byte[] fileData = null;
            if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(selectedFilePath))
            {
                fileData = File.ReadAllBytes(selectedFilePath);
            }
            byte[] fileData2 = null;
            if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(selectedFilePath2))
            {
                fileData2 = File.ReadAllBytes(selectedFilePath2);
            }
            string query = "Update Stage set Nom_Entr = @Nom_Entr, Addrs_Ent = @Addrs_Ent, Date_f = @Date_f, Date_d = @Date_d, Tele = @Tele";
            if (fileData != null)
            {
                query += ", FileNameAtes = @FileNameAtes, FileDataAtes = @FileDataAtes";
            }
            if (fileData2 != null)
            {
                query += ", FileNameDs = @FileNameDs, FileDataDs = @FileDataDs";
            }
            using (cmd = new SqlCommand(query + cont, cn))
            {
                cmd.Parameters.AddWithValue("@Date_d", Date_db_txt.Value);
                cmd.Parameters.AddWithValue("@Date_f", Date_f_txt.Value);
                cmd.Parameters.AddWithValue("@Nom_Entr", Nom_entr_txt.Text);
                cmd.Parameters.AddWithValue("@Addrs_Ent", Adrs_txt.Text);
                cmd.Parameters.AddWithValue("@Tele", Tele_txt.Text);
                if (fileData != null)
                {
                    cmd.Parameters.AddWithValue("@FileNameAtes", Path.GetFileName(selectedFilePath));
                    cmd.Parameters.AddWithValue("@FileDataAtes", fileData);
                }
                if (fileData2 != null)
                {
                    cmd.Parameters.AddWithValue("@FileNameDs", Path.GetFileName(selectedFilePath2));
                    cmd.Parameters.AddWithValue("@FileDataDs", fileData2);
                }
                try
                {
                    DateTime dt1 = Date_db_txt.Value;
                    DateTime dt2 = Date_f_txt.Value;
                    TimeSpan Dif = dt1 - dt2;
                    if (Dif.Days > 0)
                    {
                        MessageBox.Show("Il s'agit d'une erreur, car la date de début est supérieure à la date de fin de stage");
                        return;
                    }
                    else if (Dif.Days == 0)
                    {
                        MessageBox.Show("Il s'agit d'une erreur, car la date de début est égale à la date de fin de stage");
                        return;
                    }
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information de Stage a été modifiée");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating data in the database: {ex.Message}");
                }
            }
            dgvstagaire.Rows.Clear();
            cn.Close();
            dr.Close();
            cmd = new SqlCommand("Select Stage.CIN_Stagaire,Stagaire.Nom_stagaire,Stagaire.Pre_stagaire,Stagaire.Type_stagaire,Nom_Entr,Addrs_Ent,Stage.Tele,Date_d,Date_f ,FileNameAtes,FileNameDs  from Stage inner join Stagaire on Stage.CIN_Stagaire = Stagaire.CIN_Stagaire where Type_stagaire='1er année'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.dgvstagaire.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
                }
                cn.Close();
            }
            cn.Close();
            dr.Close();
            Empty();
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("Delete From Stage where CIN_Stagaire ='" + CIN_txt.Text + "'  and Nom_Entr='"+ nomEntr+ "'", cn);
                dr = cmd.ExecuteReader();
                cn.Close();
                dr.Close() ;
                MessageBox.Show("Le Stage a été Supprimer!");
                Empty();
                dgvstagaire.Rows.Clear() ;
                cmd = new SqlCommand("Select Stage.CIN_Stagaire,Stagaire.Nom_stagaire,Stagaire.Pre_stagaire,Stagaire.Type_stagaire,Nom_Entr,Addrs_Ent,Stage.Tele,Date_d,Date_f ,FileNameAtes,FileNameDs from Stage inner join Stagaire on Stage.CIN_Stagaire = Stagaire.CIN_Stagaire where Type_stagaire='1er année'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        this.dgvstagaire.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
                    }
                    cn.Close();
                }
                cn.Close();
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Attes_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types
            fileDialog.Title = "Select a file";

            // Show the file dialog and check if the user clicked the OK button
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                selectedFilePath = fileDialog.FileName;

                // Process the selected file (e.g., display its path)
                label2.Text = Path.GetFileName(selectedFilePath);
            }
        }

        private void CIN_txt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dem_s_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "All files (*.*)|*.*"; // Filter to allow all file types
            fileDialog.Title = "Select a file";

            // Show the file dialog and check if the user clicked the OK button
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                selectedFilePath2 = fileDialog.FileName;

                // Process the selected file (e.g., display its path)
                label14.Text = Path.GetFileName(selectedFilePath2);
            }
        }
    }
}
