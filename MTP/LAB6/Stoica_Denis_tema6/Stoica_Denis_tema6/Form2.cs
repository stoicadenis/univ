using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Stoica_Denis_tema6
{
    public class Form2 : Form
    {
        private static string ID = "";
        private static string NAME = "";
        private static string SURENAME = "";
        private static string SEX = "";
        private static string NAME_MUM = "";
        private static string NAME_DAD = "";
        private static string DATE_BIRTH = "";
        private static string AGE = "";
        private static string LOCATION = "";
        private static string APGAR = "";
        private static string FAMILY_DOCTOR = "";
        private static string ANTECENTE = "";

        private Form3 form3;
        private Form4 form4;
        private Form5 form5;
        private Form6 form6;
        private Form7 form7;

        private Label labelPacients;
        private Label labelIntroduction;
        private Button buttonFind;
        private Button buttonAddConsulation;
        private Button buttonSeePacientList;
        private Button buttonAddRadiographics;
        private Button buttonEndApplication;
        private DataGridView dataGridView1;
        private Button buttonAddPacient;
        private Button buttonRefresh;
        private Button buttonDisplayEverything;
        private Button button1;
        private TextBox textBoxFindName;

        public Form2()
        {
            InitializeComponent();
            loadForm2();
        }

        private void InitializeComponent()
        {
            this.labelPacients = new System.Windows.Forms.Label();
            this.labelIntroduction = new System.Windows.Forms.Label();
            this.textBoxFindName = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonAddConsulation = new System.Windows.Forms.Button();
            this.buttonSeePacientList = new System.Windows.Forms.Button();
            this.buttonAddRadiographics = new System.Windows.Forms.Button();
            this.buttonEndApplication = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAddPacient = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonDisplayEverything = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPacients
            // 
            this.labelPacients.AutoSize = true;
            this.labelPacients.Font = new System.Drawing.Font("Vladimir Script", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPacients.Location = new System.Drawing.Point(458, 4);
            this.labelPacients.Name = "labelPacients";
            this.labelPacients.Size = new System.Drawing.Size(169, 58);
            this.labelPacients.TabIndex = 0;
            this.labelPacients.Text = "Pacients";
            // 
            // labelIntroduction
            // 
            this.labelIntroduction.AutoSize = true;
            this.labelIntroduction.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntroduction.Location = new System.Drawing.Point(12, 65);
            this.labelIntroduction.Name = "labelIntroduction";
            this.labelIntroduction.Size = new System.Drawing.Size(271, 27);
            this.labelIntroduction.TabIndex = 1;
            this.labelIntroduction.Text = "Introduceti numele cautat:\r\n";
            // 
            // textBoxFindName
            // 
            this.textBoxFindName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFindName.Location = new System.Drawing.Point(289, 65);
            this.textBoxFindName.Name = "textBoxFindName";
            this.textBoxFindName.Size = new System.Drawing.Size(324, 30);
            this.textBoxFindName.TabIndex = 2;
            // 
            // buttonFind
            // 
            this.buttonFind.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.buttonFind.Location = new System.Drawing.Point(851, 22);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(181, 73);
            this.buttonFind.TabIndex = 3;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonAddConsulation
            // 
            this.buttonAddConsulation.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.buttonAddConsulation.Location = new System.Drawing.Point(12, 348);
            this.buttonAddConsulation.Name = "buttonAddConsulation";
            this.buttonAddConsulation.Size = new System.Drawing.Size(181, 73);
            this.buttonAddConsulation.TabIndex = 4;
            this.buttonAddConsulation.Text = "Add consulation";
            this.buttonAddConsulation.UseVisualStyleBackColor = true;
            this.buttonAddConsulation.Click += new System.EventHandler(this.buttonAddConsulation_Click);
            // 
            // buttonSeePacientList
            // 
            this.buttonSeePacientList.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.buttonSeePacientList.Location = new System.Drawing.Point(446, 348);
            this.buttonSeePacientList.Name = "buttonSeePacientList";
            this.buttonSeePacientList.Size = new System.Drawing.Size(181, 73);
            this.buttonSeePacientList.TabIndex = 5;
            this.buttonSeePacientList.Text = "See pacient list";
            this.buttonSeePacientList.UseVisualStyleBackColor = true;
            this.buttonSeePacientList.Click += new System.EventHandler(this.buttonSeePacientList_Click);
            // 
            // buttonAddRadiographics
            // 
            this.buttonAddRadiographics.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.buttonAddRadiographics.Location = new System.Drawing.Point(851, 348);
            this.buttonAddRadiographics.Name = "buttonAddRadiographics";
            this.buttonAddRadiographics.Size = new System.Drawing.Size(181, 73);
            this.buttonAddRadiographics.TabIndex = 6;
            this.buttonAddRadiographics.Text = "Add radiographics";
            this.buttonAddRadiographics.UseVisualStyleBackColor = true;
            this.buttonAddRadiographics.Click += new System.EventHandler(this.buttonAddRadiographics_Click);
            // 
            // buttonEndApplication
            // 
            this.buttonEndApplication.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.buttonEndApplication.Location = new System.Drawing.Point(446, 531);
            this.buttonEndApplication.Name = "buttonEndApplication";
            this.buttonEndApplication.Size = new System.Drawing.Size(181, 73);
            this.buttonEndApplication.TabIndex = 7;
            this.buttonEndApplication.Text = "End Application";
            this.buttonEndApplication.UseVisualStyleBackColor = true;
            this.buttonEndApplication.Click += new System.EventHandler(this.buttonEndApplication_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1020, 224);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // buttonAddPacient
            // 
            this.buttonAddPacient.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddPacient.Location = new System.Drawing.Point(446, 438);
            this.buttonAddPacient.Name = "buttonAddPacient";
            this.buttonAddPacient.Size = new System.Drawing.Size(181, 73);
            this.buttonAddPacient.TabIndex = 9;
            this.buttonAddPacient.Text = "Add Pacient\r\n";
            this.buttonAddPacient.UseVisualStyleBackColor = true;
            this.buttonAddPacient.Click += new System.EventHandler(this.buttonAddPacient_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Yi Baiti", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(633, 60);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(72, 38);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonDisplayEverything
            // 
            this.buttonDisplayEverything.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.buttonDisplayEverything.Location = new System.Drawing.Point(17, 438);
            this.buttonDisplayEverything.Name = "buttonDisplayEverything";
            this.buttonDisplayEverything.Size = new System.Drawing.Size(181, 73);
            this.buttonDisplayEverything.TabIndex = 11;
            this.buttonDisplayEverything.Text = "Display everything";
            this.buttonDisplayEverything.UseVisualStyleBackColor = true;
            this.buttonDisplayEverything.Click += new System.EventHandler(this.buttonDisplayEverything_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tempus Sans ITC", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.Location = new System.Drawing.Point(851, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 73);
            this.button1.TabIndex = 12;
            this.button1.Text = "Delete Everything";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(1044, 616);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDisplayEverything);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonAddPacient);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonEndApplication);
            this.Controls.Add(this.buttonAddRadiographics);
            this.Controls.Add(this.buttonSeePacientList);
            this.Controls.Add(this.buttonAddConsulation);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBoxFindName);
            this.Controls.Add(this.labelIntroduction);
            this.Controls.Add(this.labelPacients);
            this.Name = "Form2";
            this.Text = "Pacients";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void buttonEndApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void loadForm2()
        {
            string connect = "Server=45.86.220.2;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            MySqlConnection cnn = new MySqlConnection(connect);
            cnn.Open();
            string tabel_date = "select * FROM Pacients";
            MySqlDataAdapter da = new MySqlDataAdapter(tabel_date, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pacients");
            dataGridView1.DataSource = ds.Tables["Pacients"].DefaultView;
            cnn.Close();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string connect = "Server=stoicadenis.com;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            string stmt = "select * from Pacients where Name='" + textBoxFindName.Text + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(stmt, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pacients");
            dataGridView1.DataSource = ds.Tables["Pacients"].DefaultView;
            con.Close();
            da.Dispose();
            ds.Dispose();
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int index = 0;
                ID = row.Cells[index].Value.ToString(); index += 1;
                NAME = row.Cells[index].Value.ToString(); index += 1;
                SURENAME = row.Cells[index].Value.ToString(); index += 1;
            }
        }

        private void buttonAddPacient_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.Show();
        }

        private void buttonAddConsulation_Click(object sender, EventArgs e)
        {
            if (ID == string.Empty)
            {
                MessageBox.Show("ID is empty", "Error");
                return;
            }
            if (!Form3.IdValid(ID))
            {
                MessageBox.Show("Id is not valid!", Form1.errorMessage);
                return;
            }

            form4 = new Form4(ID, NAME, SURENAME);
            form4.Show();
        }

        private void buttonAddRadiographics_Click(object sender, EventArgs e)
        {
            if (ID == string.Empty)
            {
                MessageBox.Show("ID is empty", "Error");
                return;
            }
            if (!Form3.IdValid(ID))
            {
                MessageBox.Show("Id is not valid!", Form1.errorMessage);
                return;
            }

            form5 = new Form5(ID);
            form5.Show();
        }

        private void buttonSeePacientList_Click(object sender, EventArgs e)
        {
            if (ID == string.Empty)
            {
                MessageBox.Show("ID is empty", "Error");
                return;
            }
            if (!Form3.IdValid(ID))
            {
                MessageBox.Show("Id is not valid!", Form1.errorMessage);
                return;
            }
            form6 = new Form6(ID);
            form6.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            string connect = "Server=stoicadenis.com;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            MySqlConnection cnn = new MySqlConnection(connect);
            cnn.Open();
            string tabel_date = "select * FROM Pacients";
            MySqlDataAdapter da = new MySqlDataAdapter(tabel_date, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Pacients");
            dataGridView1.DataSource = ds.Tables["Pacients"].DefaultView;
            cnn.Close();
        }

        private void buttonDisplayEverything_Click(object sender, EventArgs e)
        {
            int countSelected = dataGridView1.SelectedRows.Count;
            if (countSelected <= 0)
            {
                MessageBox.Show("Nothing is selected!", Form1.errorMessage);
                return;
            }
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int index = 0;
                ID = row.Cells[index].Value.ToString(); index += 1;
                NAME = row.Cells[index].Value.ToString(); index += 1;
                SURENAME = row.Cells[index].Value.ToString(); index += 1;
                SEX = row.Cells[index].Value.ToString(); index += 1;
                NAME_MUM = row.Cells[index].Value.ToString(); index += 1;
                NAME_DAD = row.Cells[index].Value.ToString(); index += 1;

                string day, month, year;
                year = ID.Substring(1, 2);
                month = ID.Substring(3, 2);
                day = ID.Substring(5, 2);

                if (ID.StartsWith("1") || ID.StartsWith("2"))
                {
                    year = "19" + year;
                }
                else
                {
                    year = "20" + year;
                }

                DATE_BIRTH = year + "//" + month + "//" + day;
                int age;
                int intYear = int.Parse(year);
                age = DateTime.Now.Year - intYear;
                if (DateTime.Now.DayOfYear < intYear)
                {
                    age -= 1;
                }
                AGE = row.Cells[index].Value.ToString(); index += 1;
                LOCATION = row.Cells[index].Value.ToString(); index += 1;
                APGAR = row.Cells[index].Value.ToString(); index += 1;
                FAMILY_DOCTOR = row.Cells[index].Value.ToString(); index += 1;
                ANTECENTE = row.Cells[index].Value.ToString(); index += 1;
                if (count <= 0)
                {
                    form7 = new Form7(ID, NAME, SURENAME, SEX, NAME_MUM, NAME_DAD, DATE_BIRTH, AGE, LOCATION, APGAR, FAMILY_DOCTOR, ANTECENTE);
                    form7.Show();
                    count += 1;
                }
            }
        }

        private static void deleteRowSQL(string connection, string table, string id)
        {
            bool flag = false;
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                using (MySqlCommand command = new MySqlCommand("DELETE from " + table + " where ID='" + id + "'"))
                {
                    command.Connection = con;
                    command.ExecuteNonQuery();
                    flag = true;
                }
                con.Close();
            }
            if (flag == false)
            {
                MessageBox.Show("Error when trying to delete", Form1.errorMessage);
                return;
            }
            MessageBox.Show("Deleted with success from " + table + "table", "Success");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ID == string.Empty)
            {
                MessageBox.Show("ID is empty", "Error");
                return;
            }
            if (!Form3.IdValid(ID))
            {
                MessageBox.Show("Id is not valid!", Form1.errorMessage);
                return;
            }
            string connect = "Server=stoicadenis.com;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            for (int i = 0; i < 3; ++i)
            {
                if (i == 0)
                {
                    deleteRowSQL(connect, "Pacients", ID);
                }
                if (i == 1)
                {
                    deleteRowSQL(connect, "Consultations", ID);
                }
                if (i == 2)
                {
                    deleteRowSQL(connect, "Radiograms", ID);
                }
            }
        }
    }
}
