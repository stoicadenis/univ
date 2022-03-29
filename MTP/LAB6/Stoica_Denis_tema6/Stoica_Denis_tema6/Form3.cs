using MySql.Data.MySqlClient;
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

namespace Stoica_Denis_tema6
{
    public class Form3 : Form
    {
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox textBoxName;
        private TextBox textBoxMotherName;
        private TextBox textBoxID;
        private TextBox textBoxSurename;
        private TextBox textBoxFatherName;
        private ComboBox comboBoxSex;
        private TextBox textBoxAge;
        private TextBox textBoxLocationBorn;
        private TextBox textBoxAPGAR;
        private TextBox textBoxFamilyDoctor;
        private TextBox textBoxAntecedente;
        private DateTimePicker dateTimePickerBirth;
        private Button buttonSavePacients;
        private Button buttonCancel;
        private Label label1;

        public Form3()
        {
            InitializeComponent();
            addGenderToComboBox();
            dateTimePickerBirth.Enabled = false;
            textBoxAge.Enabled = false;
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxMotherName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxSurename = new System.Windows.Forms.TextBox();
            this.textBoxFatherName = new System.Windows.Forms.TextBox();
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxLocationBorn = new System.Windows.Forms.TextBox();
            this.textBoxAPGAR = new System.Windows.Forms.TextBox();
            this.textBoxFamilyDoctor = new System.Windows.Forms.TextBox();
            this.textBoxAntecedente = new System.Windows.Forms.TextBox();
            this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.buttonSavePacients = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(499, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Pacient\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Surename";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 33);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sex";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(85, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 33);
            this.label6.TabIndex = 5;
            this.label6.Text = "Name mother";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(85, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 33);
            this.label7.TabIndex = 6;
            this.label7.Text = "Name father";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(660, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 33);
            this.label8.TabIndex = 7;
            this.label8.Text = "DateOfBirth";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(660, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 33);
            this.label9.TabIndex = 8;
            this.label9.Text = "Age";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(660, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 33);
            this.label10.TabIndex = 9;
            this.label10.Text = "Location born";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(662, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 33);
            this.label11.TabIndex = 10;
            this.label11.Text = "APGAR";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(660, 367);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 33);
            this.label12.TabIndex = 11;
            this.label12.Text = "Family doctor";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(662, 425);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 33);
            this.label13.TabIndex = 12;
            this.label13.Text = "Antecedente";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(274, 136);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(268, 28);
            this.textBoxName.TabIndex = 13;
            // 
            // textBoxMotherName
            // 
            this.textBoxMotherName.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMotherName.Location = new System.Drawing.Point(274, 371);
            this.textBoxMotherName.Name = "textBoxMotherName";
            this.textBoxMotherName.Size = new System.Drawing.Size(268, 28);
            this.textBoxMotherName.TabIndex = 14;
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(274, 316);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(268, 28);
            this.textBoxID.TabIndex = 15;
            // 
            // textBoxSurename
            // 
            this.textBoxSurename.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSurename.Location = new System.Drawing.Point(274, 197);
            this.textBoxSurename.Name = "textBoxSurename";
            this.textBoxSurename.Size = new System.Drawing.Size(268, 28);
            this.textBoxSurename.TabIndex = 16;
            // 
            // textBoxFatherName
            // 
            this.textBoxFatherName.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFatherName.Location = new System.Drawing.Point(274, 429);
            this.textBoxFatherName.Name = "textBoxFatherName";
            this.textBoxFatherName.Size = new System.Drawing.Size(268, 28);
            this.textBoxFatherName.TabIndex = 17;
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Location = new System.Drawing.Point(274, 252);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(268, 29);
            this.comboBoxSex.TabIndex = 18;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAge.Location = new System.Drawing.Point(862, 192);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(268, 28);
            this.textBoxAge.TabIndex = 19;
            // 
            // textBoxLocationBorn
            // 
            this.textBoxLocationBorn.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLocationBorn.Location = new System.Drawing.Point(862, 253);
            this.textBoxLocationBorn.Name = "textBoxLocationBorn";
            this.textBoxLocationBorn.Size = new System.Drawing.Size(268, 28);
            this.textBoxLocationBorn.TabIndex = 20;
            // 
            // textBoxAPGAR
            // 
            this.textBoxAPGAR.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAPGAR.Location = new System.Drawing.Point(862, 316);
            this.textBoxAPGAR.Name = "textBoxAPGAR";
            this.textBoxAPGAR.Size = new System.Drawing.Size(268, 28);
            this.textBoxAPGAR.TabIndex = 21;
            // 
            // textBoxFamilyDoctor
            // 
            this.textBoxFamilyDoctor.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFamilyDoctor.Location = new System.Drawing.Point(862, 372);
            this.textBoxFamilyDoctor.Name = "textBoxFamilyDoctor";
            this.textBoxFamilyDoctor.Size = new System.Drawing.Size(268, 28);
            this.textBoxFamilyDoctor.TabIndex = 22;
            // 
            // textBoxAntecedente
            // 
            this.textBoxAntecedente.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAntecedente.Location = new System.Drawing.Point(862, 430);
            this.textBoxAntecedente.Name = "textBoxAntecedente";
            this.textBoxAntecedente.Size = new System.Drawing.Size(268, 28);
            this.textBoxAntecedente.TabIndex = 23;
            // 
            // dateTimePickerBirth
            // 
            this.dateTimePickerBirth.CalendarFont = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerBirth.Location = new System.Drawing.Point(862, 136);
            this.dateTimePickerBirth.Name = "dateTimePickerBirth";
            this.dateTimePickerBirth.Size = new System.Drawing.Size(268, 24);
            this.dateTimePickerBirth.TabIndex = 24;
            // 
            // buttonSavePacients
            // 
            this.buttonSavePacients.Font = new System.Drawing.Font("Mistral", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSavePacients.Location = new System.Drawing.Point(274, 485);
            this.buttonSavePacients.Name = "buttonSavePacients";
            this.buttonSavePacients.Size = new System.Drawing.Size(293, 83);
            this.buttonSavePacients.TabIndex = 25;
            this.buttonSavePacients.Text = "Save Pacient";
            this.buttonSavePacients.UseVisualStyleBackColor = true;
            this.buttonSavePacients.Click += new System.EventHandler(this.buttonSavePacients_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Mistral", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(636, 485);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(293, 83);
            this.buttonCancel.TabIndex = 26;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(1142, 594);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSavePacients);
            this.Controls.Add(this.dateTimePickerBirth);
            this.Controls.Add(this.textBoxAntecedente);
            this.Controls.Add(this.textBoxFamilyDoctor);
            this.Controls.Add(this.textBoxAPGAR);
            this.Controls.Add(this.textBoxLocationBorn);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.comboBoxSex);
            this.Controls.Add(this.textBoxFatherName);
            this.Controls.Add(this.textBoxSurename);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxMotherName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Wide Latin", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.Text = "Add Pacient";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public static bool IdValid(string cnp)
        {
            int s, a1, a2, l1, l2, z1, z2, j1, j2, n1, n2, n3, cifc, u;
            if (cnp.Trim().Length != 13)
            {
                return false;
            }
            else
            {
                s = Convert.ToInt16(cnp.Substring(0, 1));
                a1 = Convert.ToInt16(cnp.Substring(1, 1));
                a2 = Convert.ToInt16(cnp.Substring(2, 1));
                l1 = Convert.ToInt16(cnp.Substring(3, 1));
                l2 = Convert.ToInt16(cnp.Substring(4, 1));
                z1 = Convert.ToInt16(cnp.Substring(5, 1));
                z2 = Convert.ToInt16(cnp.Substring(6, 1));
                j1 = Convert.ToInt16(cnp.Substring(7, 1));
                j2 = Convert.ToInt16(cnp.Substring(8, 1));
                n1 = Convert.ToInt16(cnp.Substring(9, 1));
                n2 = Convert.ToInt16(cnp.Substring(10, 1));
                n3 = Convert.ToInt16(cnp.Substring(11, 1));
                cifc = Convert.ToInt16(((s * 2 + a1 * 7 + a2 * 9 + l1 * 1 + l2 * 4 + z1
               * 6 + z2 * 3 + j1 * 5 + j2 * 8 + n1 * 2 + n2 * 7 + n3 * 9) % 11));
                if (cifc == 10)
                {
                    cifc = 1;
                }
                u = Convert.ToInt16(cnp.Substring(12, 1));
                if (cifc == u)
                {
                    return true;
                }
                return false;
            }
        }

        public void addGenderToComboBox()
        {
            comboBoxSex.Items.Add("male");
            comboBoxSex.Items.Add("female");
        }

        private void buttonSavePacients_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            if (!IdValid(id))
            {
                MessageBox.Show("Id is invalid!", Form1.errorMessage);
                return;
            }
            string day, month, year;
            year = id.Substring(1, 2);
            month = id.Substring(3, 2);
            day = id.Substring(5, 2);

            if (id.StartsWith("1") || id.StartsWith("2"))
            {
                year = "19" + year;
            }
            else
            {
                year = "20" + year;
            }

            dateTimePickerBirth.Value = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            int age;
            age = DateTime.Now.Year - dateTimePickerBirth.Value.Year;
            if (DateTime.Now.DayOfYear < dateTimePickerBirth.Value.DayOfYear)
            {
                age -= 1;
            }
            textBoxAge.Text = age.ToString();

            string connect = "Server=stoicadenis.com;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();

            string stmt = "INSERT into Pacients ([ID], [Name], [Surename], [Sex], [Name_mum], [Name_dad], [Date_of_birth], [Location_of_birth], [APGAR], [Family_doctor], [Antecedence]) values (@id, @n, @p, @s, @nm, @nt, @dn, @ln, @apgar, @mf, @a)";
            MySqlCommand sc = new MySqlCommand(stmt, con);
            sc.Parameters.AddWithValue("@id", textBoxID.Text);
            sc.Parameters.AddWithValue("@n", textBoxName.Text);
            sc.Parameters.AddWithValue("@p", textBoxSurename.Text);
            sc.Parameters.AddWithValue("@s", comboBoxSex.Text);
            sc.Parameters.AddWithValue("@nm", textBoxMotherName.Text);
            sc.Parameters.AddWithValue("@nt", textBoxFatherName.Text);
            sc.Parameters.AddWithValue("@dn", dateTimePickerBirth.Value);
            sc.Parameters.AddWithValue("@ln", textBoxLocationBorn.Text);
            sc.Parameters.AddWithValue("@apgar", textBoxAPGAR.Text);
            sc.Parameters.AddWithValue("@mf", textBoxFamilyDoctor.Text);
            sc.Parameters.AddWithValue("@a", textBoxAntecedente.Text);
            MySqlDataReader myReader = sc.ExecuteReader();
            con.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
            MessageBox.Show("Saved with Success", "Success");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
        }
    }
}
