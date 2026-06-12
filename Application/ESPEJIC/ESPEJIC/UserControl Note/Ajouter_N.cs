using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ESPEJIC.UserControl_Note
{
    public partial class Ajouter_N : UserControl
    {
        String connectionString = "Data Source=.;Initial Catalog=ESPEGIC;Integrated Security=True";
        private string Nom_Mat;
        private string ID;
        private string note;
        private string CIN_st;
        private int a;
        public Ajouter_N()
        {
            InitializeComponent();
            InitializeLabel();
        }
        private void InitializeLabel()
        {
            label2 = new Label();
            label2.Text = "Your Label Text";
            label2.AutoSize = true;
            Controls.Add(label2);
        }

        private void CenterLabel()
        {
            int centerX = (Width - label3.Width) / 2;
            label3.Location = new Point(centerX, 50);
        }

        private void Ajouter_Load(object sender, EventArgs e)
        {
            CenterLabel();
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    string query = "Select Type_stagaire from Classe";
                    SqlDataAdapter ad = new SqlDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    comboBox1.DisplayMember = "Type_stagaire";
                    comboBox1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            dataGridView2.Visible = false;
            flowLayoutPanel1.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;

        }

        private DataTable FetchAllStudentsFromDatabase()
        {
            // SQL query to fetch all students from the database
            string query = "SELECT CIN_Stagaire, Nom_stagaire, Pre_stagaire FROM Stagaire where Type_stagaire ='" + comboBox1.Text + "'";

            // Execute the query and return the result as a DataTable
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable students = new DataTable();
                        adapter.Fill(students);
                        return students;
                    }
                }
            }
        }

        private DataTable FetchAllSubjectsFromDatabase()
        {
            // SQL query to fetch all subjects from the database
            string query = "SELECT ID_Matiére, Nom_Mat FROM Matiére where Type_stagaire ='" + comboBox1.Text + "' and statu_mat='Active'";
            // Execute the query and return the result as a DataTable
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable subjects = new DataTable();
                        adapter.Fill(subjects);
                        return subjects;
                    }
                }
            }
        }

        private DataTable FetchAllStudentsFromDatabase1(string Type_stagaire)
        {
            // SQL query to fetch all students from the database
            string query = "SELECT CIN_Stagaire, Nom_stagaire, Pre_stagaire FROM Stagaire where Type_stagaire =@Type_stagaire";

            // Execute the query and return the result as a DataTable
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type_stagaire", Type_stagaire);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable students = new DataTable();
                        adapter.Fill(students);
                        return students;
                    }
                }
            }
        }

        private DataTable FetchAllSubjectsFromDatabase1(string Type_stagaire)
        {
            // SQL query to fetch all subjects from the database
            string query = "SELECT ID_Matiére, Nom_Mat FROM Matiére where Type_stagaire =@Type_stagaire";
            // Execute the query and return the result as a DataTable
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type_stagaire", Type_stagaire);
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable subjects = new DataTable();
                        adapter.Fill(subjects);
                        return subjects;
                    }
                }
            }
        }

        private string FetchGradeFromDatabase(string CIN_Stagaire, int ID_Matiére, string type_note)
        {
            Dictionary<string, string> gradeColumnMapping = new Dictionary<string, string>
            {
                { "Controles Continus", "Control_C" },
                { "EFCFT", "EFCE_thero" },
                { "EFCFP", "EFCE_prat" }
            };
            if (gradeColumnMapping.ContainsKey(type_note))
            {
                // Get the column name corresponding to the grade type
                string columnName = gradeColumnMapping[type_note];
                string query = $"SELECT {columnName} FROM Note WHERE CIN_Stagaire = @CIN_Stagaire AND ID_Matiére = @ID_Matiére";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CIN_Stagaire", CIN_Stagaire);
                        command.Parameters.AddWithValue("@ID_Matiére", ID_Matiére);
                        connection.Open();
                        var result = command.ExecuteScalar();
                        return result != null ? result.ToString() : "";
                    }
                }
            }
            else
            {
                return "";
            }
        }

        private string FetchGradeFromDatabase1(string CIN_Stagaire, int ID_Matiére, string type_note)
        {
            Dictionary<string, string> gradeColumnMapping = new Dictionary<string, string>
            {
                { "Controles Continus", "Control_C" },
                { "EFCFT", "EFCE_thero" },
                { "EFCFP", "EFCE_prat" }
            };
            if (gradeColumnMapping.ContainsKey(type_note))
            {
                // Get the column name corresponding to the grade type
                string columnName = gradeColumnMapping[type_note];
                string query = $"SELECT {columnName} FROM Note WHERE CIN_Stagaire = @CIN_Stagaire AND ID_Matiére = @ID_Matiére";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CIN_Stagaire", CIN_Stagaire);
                        command.Parameters.AddWithValue("@ID_Matiére", ID_Matiére);
                        connection.Open();
                        var result = command.ExecuteScalar();
                        return result != null ? result.ToString() : "";
                    }
                }
            }
            else
            {
                return "";
            }
        }

        private bool CheckExistValue()
        {
            SqlConnection con = new SqlConnection(connectionString);
            if (comboBox2.Text == "Controles Continus")
            {
                SqlCommand cmd = new SqlCommand("Select Control_C from Note where CIN_Stagaire = '" + CIN_st + "' and ID_Matiére = '" + ID + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                con.Close();
            }
            else if (comboBox2.Text == "EFCFT")
            {
                SqlCommand cmd = new SqlCommand("Select EFCE_thero from Note where CIN_Stagaire = '" + CIN_st + "' and ID_Matiére = '" + ID + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                con.Close();
            }
            else if (comboBox2.Text == "EFCFP")
            {
                SqlCommand cmd = new SqlCommand("Select EFCE_prat from Note where CIN_Stagaire = '" + CIN_st + "' and ID_Matiére = '" + ID + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
                con.Close();
            }
            else if(comboBox2.Text == "PFE")
            {
                SqlCommand cmd = new SqlCommand("Select PFE from PFE where CIN_Stagaire = '" + CIN_st + "'", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[0].ToString() != "NULL")
                    {
                        return true;
                    }   
                }
                con.Close();
            }
            return false;
        }

        private void LoadGrades1()
        {
            // Fetch all students and subjects from the database
            DataTable students = FetchAllStudentsFromDatabase1(comboBox1.Text);
            DataTable subjects = FetchAllSubjectsFromDatabase1(comboBox1.Text);

            // Create a new DataTable to store the grades
            DataTable gradesTable = new DataTable();

            // Add columns for full name and each subject
            gradesTable.Columns.Add("FullName", typeof(string));
            foreach (DataRow subjectRow in subjects.Rows)
            {
                string subjectName = subjectRow["Nom_Mat"].ToString();
                gradesTable.Columns.Add(subjectName, typeof(string));
            }

            // Populate the DataTable with student names and grades
            foreach (DataRow studentRow in students.Rows)
            {
                string studentID = studentRow["CIN_Stagaire"].ToString();
                string firstName = studentRow["Nom_stagaire"].ToString();
                string lastName = studentRow["Pre_stagaire"].ToString();
                string fullName = $"{firstName} {lastName}";

                // Create a new row for the student
                DataRow newRow = gradesTable.NewRow();
                newRow["FullName"] = fullName;

                // Fetch grades for the student from the database
                foreach (DataRow subjectRow in subjects.Rows)
                {
                    int subjectID = Convert.ToInt32(subjectRow["ID_Matiére"]);
                    string grade = FetchGradeFromDatabase1(studentID, subjectID, comboBox2.Text);
                    newRow[subjectRow["Nom_Mat"].ToString()] = grade;
                }

                // Add the row to the DataTable
                gradesTable.Rows.Add(newRow);
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = gradesTable;
        }

        private void LoadGrades(string type_note)
        {
            // Fetch all students and subjects from the database
            DataTable students = FetchAllStudentsFromDatabase();
            DataTable subjects = FetchAllSubjectsFromDatabase();

            // Create a new DataTable to store the grades
            DataTable gradesTable = new DataTable();

            // Add columns for full name and each subject
            gradesTable.Columns.Add("FullName", typeof(string));
            foreach (DataRow subjectRow in subjects.Rows)
            {
                string subjectName = subjectRow["Nom_Mat"].ToString();
                gradesTable.Columns.Add(subjectName, typeof(string));
            }

            // Populate the DataTable with student names and grades
            foreach (DataRow studentRow in students.Rows)
            {
                string studentID = studentRow["CIN_Stagaire"].ToString();
                string firstName = studentRow["Nom_stagaire"].ToString();
                string lastName = studentRow["Pre_stagaire"].ToString();
                string fullName = $"{firstName} {lastName}";

                // Create a new row for the student
                DataRow newRow = gradesTable.NewRow();
                newRow["FullName"] = fullName;

                // Fetch grades for the student from the database
                foreach (DataRow subjectRow in subjects.Rows)
                {
                    int subjectID = Convert.ToInt32(subjectRow["ID_Matiére"]);
                    string grade = FetchGradeFromDatabase(studentID, subjectID, type_note);
                    newRow[subjectRow["Nom_Mat"].ToString()] = grade;
                }

                // Add the row to the DataTable
                gradesTable.Rows.Add(newRow);
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = gradesTable;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un type d'examen.");
                e.Cancel = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            string select = comboBox2.SelectedItem.ToString();
            LoadGrades(select);
            if(comboBox2.SelectedIndex == 3)
            {
                flowLayoutPanel1.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                string query1 = "Select PFE from PFE as p inner join Stagaire as s on s.CIN_Stagaire = p.CIN_Stagaire where s.Type_Stagaire = '2émé année'";
                using(SqlConnection cn = new SqlConnection(connectionString))
                {
                    using(SqlCommand cmd = new SqlCommand(query1, cn))
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            a = 1;
                        }
                        else
                        {
                            a = 0;
                        }
                        cn.Close();
                    }
                }
                if(a == 1)
                {
                    string query2 = "SELECT \r\n    Stagaire.Nom_stagaire + ' ' + Stagaire.Pre_stagaire AS fullname, \r\n    PFE.PFE\r\nFROM \r\n    Stagaire\r\nLEFT JOIN \r\n    PFE \r\nON \r\n    Stagaire.CIN_Stagaire = PFE.CIN_Stagaire\r\nWHERE \r\n    Stagaire.Type_Stagaire = '2émé année';\r\n";
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query2, cn))
                        {
                            cn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                string Fullname = dr["fullname"].ToString();
                                string PFE = dr["PFE"].ToString();
                                dataGridView2.Rows.Add(Fullname, PFE);
                            }
                            cn.Close();
                        }
                    }
                }
                if(a == 0)
                {
                    DataTable dt = new DataTable();
                    string query = "Select Stagaire.Nom_stagaire+' '+Stagaire.Pre_stagaire as Fullname  from Stagaire where Type_Stagaire = '2émé année'";
                    using(SqlConnection cn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            cn.Open();
                            SqlDataAdapter dr = new SqlDataAdapter(query, cn);
                            dr.Fill(dt);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    foreach(DataRow row in dt.Rows)
                    {
                        dataGridView2.Rows.Add(row["Fullname"].ToString(), string.Empty);
                    }
                }
            }
            else
            {
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
                flowLayoutPanel1.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
            }
        }
            
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("veuillez choisir le type d'examen.");
                dataGridView1.ReadOnly = true;
                return;
            }
            dataGridView1.ReadOnly = false;
            if (e.ColumnIndex >= 0)
            {
                DataGridViewColumn clickedColumn = dataGridView1.Columns[e.ColumnIndex];
                Nom_Mat = clickedColumn.HeaderText;
            }
            string value  = Nom_Mat;
            string modifer = value.Replace("'", "''");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select ID_Matiére from Matiére where Nom_Mat = '" +modifer + "'";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {

                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ID = dr[0].ToString();
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            int position = dataGridView1.CurrentRow.Index;
            string querty = this.dataGridView1.Rows[position].Cells[0].Value.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "Select CIN_Stagaire from Stagaire where Nom_stagaire+' '+Pre_stagaire ='" + querty + "'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            CIN_st = dr[0].ToString();
                        }
                    }
                    conn.Close();
                    dr.Close();
                }
            }
        }
        
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell editedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                note = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (note == "")
                {
                    return;
                }
                if (comboBox2.Text == "Controles Continus")
                {
                    if (CheckExistValue() == false)
                    {
                        string noteWithDot = note.Replace(',', '.');
                        string query = "Insert into Note (CIN_Stagaire, ID_Matiére, Control_C) Values(@CIN_Stagaire, @ID_Matiére, @Control_C)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CIN_Stagaire", CIN_st);
                            cmd.Parameters.AddWithValue("@ID_Matiére", ID);
                            cmd.Parameters.AddWithValue("@Control_C", noteWithDot);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                    }
                    else
                    {
                        // Replace comma with period in the note value
                        string noteWithDot = note.Replace(',', '.');

                        // Use parameterized query to avoid SQL injection and handle data correctly
                        string query = "Update Note set Control_C = @Control_C where CIN_Stagaire = @CIN_Stagaire AND ID_Matiére = @ID_Matiére";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Control_C", noteWithDot);
                            cmd.Parameters.AddWithValue("@CIN_Stagaire", CIN_st);
                            cmd.Parameters.AddWithValue("@ID_Matiére", ID);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                    }
                }
                else if (comboBox2.Text == "EFCFT")
                {
                    if (CheckExistValue() == false)
                    {
                        // Replace comma with period in the note value
                        string noteWithDot = note.Replace(',', '.');

                        // Use parameterized query to insert the data
                        string query = "Insert into Note (CIN_Stagaire, ID_Matiére, EFCE_thero) Values (@CIN_Stagaire, @ID_Matiére, @EFCE_thero)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CIN_Stagaire", CIN_st);
                            cmd.Parameters.AddWithValue("@ID_Matiére", ID);
                            cmd.Parameters.AddWithValue("@EFCE_thero", noteWithDot);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else
                    {
                        // Replace comma with period in the note value
                        string noteWithDot = note.Replace(',', '.');

                        // Use parameterized query to update the data
                        string query = "Update Note set EFCE_thero = @EFCE_thero where CIN_Stagaire = @CIN_Stagaire AND ID_Matiére = @ID_Matiére";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@EFCE_thero", noteWithDot);
                            cmd.Parameters.AddWithValue("@CIN_Stagaire", CIN_st);
                            cmd.Parameters.AddWithValue("@ID_Matiére", ID);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                else if (comboBox2.Text == "EFCFP")
                {
                    // Replace comma with period in the note value
                    string noteWithDot = note.Replace(',', '.');

                    if (CheckExistValue() == false)
                    {
                        string query = "Insert into Note (CIN_Stagaire, ID_Matiére, EFCE_prat) Values (@CIN_Stagaire, @ID_Matiére, @EFCE_prat)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CIN_Stagaire", CIN_st);
                            cmd.Parameters.AddWithValue("@ID_Matiére", ID);
                            cmd.Parameters.AddWithValue("@EFCE_prat", noteWithDot);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else
                    {
                        string query = "Update Note set EFCE_prat = @EFCE_prat where CIN_Stagaire = @CIN_Stagaire AND ID_Matiére = @ID_Matiére";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@EFCE_prat", noteWithDot);
                            cmd.Parameters.AddWithValue("@CIN_Stagaire", CIN_st);
                            cmd.Parameters.AddWithValue("@ID_Matiére", ID);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                }
            }
        }

        private void ClearRows()
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                for(int i = 1;i < row.Cells.Count;i++)
                {
                    row.Cells[i].Value = null;
                }
            }
        }

        private void Mdf_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Les notes ont été ajoutés avec succès");
            ClearRows();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrades1();
            if(comboBox1.Text == "1er année")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Controles Continus");
                comboBox2.Items.Add("EFCFT");
                comboBox2.Items.Add("EFCFP");
                comboBox2.Items.Add("PFE");
            }
            if(comboBox1.Text == "2émé année")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Controles Continus");
                comboBox2.Items.Add("EFCFT");
                comboBox2.Items.Add("EFCFP");
                comboBox2.Items.Add("PFE");
                if (comboBox2.Items.Count > 0)
                    comboBox2.SelectedIndex = 0;
            }
            else
            {
                if(comboBox1.SelectedIndex == 0 && comboBox2.Items.Contains("PFE"))
                {
                    comboBox2.Items.Remove("PFE");
                }
                if(comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
            }
        }

        private void Ajouter_N_Resize(object sender, EventArgs e)
        {
            if (ParentForm != null && ParentForm.WindowState == FormWindowState.Maximized)
            {
                CenterLabel();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                e.CellStyle.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            }          
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Tab || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell editedCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                note = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (note == "")
                {
                    return;
                }
                if (CheckExistValue() == false)
                {
                    try
                    {
                        // Replace dot with comma
                        string formattedNote = note.Replace('.', ',');

                        // Convert the formatted note to a double using a culture that uses comma as decimal separator
                        double noteValue = Convert.ToDouble(formattedNote, new CultureInfo("fr-FR"));

                        string query = "INSERT INTO PFE (CIN_Stagaire, PFE) VALUES (@CIN_Stagaire, @PFE)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@CIN_Stagaire", CIN_st);
                            cmd.Parameters.AddWithValue("@PFE", noteValue);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Erreur de format : " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
                else
                {
                    string query;
                    query = "Update PFE set PFE = '" + note + "' where CIN_Stagaire = '" + CIN_st + "'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow != null && dataGridView2.Rows.Count > 0 && e.RowIndex >= 0)
            {
                int position = dataGridView2.CurrentRow.Index;
                if (dataGridView2.Rows[position].Cells[0].Value != null)
                {
                    string fullname = dataGridView2.Rows[position].Cells[0].Value.ToString();
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT CIN_Stagaire FROM Stagaire WHERE Nom_stagaire + ' ' + Pre_stagaire = @Fullname";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Fullname", fullname);
                            conn.Open();
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    CIN_st = dr.GetString(0);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }
    }
}
