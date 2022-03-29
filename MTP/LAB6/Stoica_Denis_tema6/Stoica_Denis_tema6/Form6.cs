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
    public class Form6 : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox textBoxName;
        private TextBox textBoxSurename;
        private ComboBox comboBoxSex;
        private TextBox textBoxID;
        private TextBox textBoxMotherName;
        private TextBox textBoxFatherName;
        private DateTimePicker dateTimePickerBirth;
        private TextBox textBoxAge;
        private TextBox textBoxLocationBorn;
        private TextBox textBoxAPGAR;
        private TextBox textBoxFamilyDoctor;
        private TextBox textBoxAntecedente;
        private PictureBox pictureBox1;
        private Button buttonOkay;
        private Button buttonCancel;
        private FlowLayoutPanel flowLayoutPanelRadiographs;
        private DataGridView dataGridViewConsultations;
        private DataGridView dataGridViewPacients;
        private string iD;

        public Form6(string iD)
        {
            this.iD = iD;
            InitializeComponent();
            textBoxID.Text = iD;
            textBoxID.Enabled = false;
            addGenderToComboBox();
            loadDataGrid();
            showImages();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurename = new System.Windows.Forms.TextBox();
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxMotherName = new System.Windows.Forms.TextBox();
            this.textBoxFatherName = new System.Windows.Forms.TextBox();
            this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxLocationBorn = new System.Windows.Forms.TextBox();
            this.textBoxAPGAR = new System.Windows.Forms.TextBox();
            this.textBoxFamilyDoctor = new System.Windows.Forms.TextBox();
            this.textBoxAntecedente = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonOkay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanelRadiographs = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewConsultations = new System.Windows.Forms.DataGridView();
            this.dataGridViewPacients = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsultations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacients)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, -8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Visualize Pacients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "Surename";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 33);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sex";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 33);
            this.label6.TabIndex = 7;
            this.label6.Text = "Name mother";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 285);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 33);
            this.label7.TabIndex = 8;
            this.label7.Text = "Name father";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(521, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 33);
            this.label8.TabIndex = 9;
            this.label8.Text = "DateOfBirth";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(521, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 33);
            this.label9.TabIndex = 10;
            this.label9.Text = "Age";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(521, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(183, 33);
            this.label10.TabIndex = 11;
            this.label10.Text = "Location born";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(521, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 33);
            this.label11.TabIndex = 12;
            this.label11.Text = "APGAR";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(516, 242);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 33);
            this.label12.TabIndex = 13;
            this.label12.Text = "Family doctor";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(516, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 33);
            this.label13.TabIndex = 14;
            this.label13.Text = "Antecedente";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(220, 52);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(268, 28);
            this.textBoxName.TabIndex = 15;
            // 
            // textBoxSurename
            // 
            this.textBoxSurename.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSurename.Location = new System.Drawing.Point(220, 94);
            this.textBoxSurename.Name = "textBoxSurename";
            this.textBoxSurename.Size = new System.Drawing.Size(268, 28);
            this.textBoxSurename.TabIndex = 17;
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Location = new System.Drawing.Point(220, 195);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(268, 29);
            this.comboBoxSex.TabIndex = 19;
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(220, 144);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(268, 28);
            this.textBoxID.TabIndex = 20;
            // 
            // textBoxMotherName
            // 
            this.textBoxMotherName.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMotherName.Location = new System.Drawing.Point(220, 242);
            this.textBoxMotherName.Name = "textBoxMotherName";
            this.textBoxMotherName.Size = new System.Drawing.Size(268, 28);
            this.textBoxMotherName.TabIndex = 21;
            // 
            // textBoxFatherName
            // 
            this.textBoxFatherName.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFatherName.Location = new System.Drawing.Point(220, 289);
            this.textBoxFatherName.Name = "textBoxFatherName";
            this.textBoxFatherName.Size = new System.Drawing.Size(268, 28);
            this.textBoxFatherName.TabIndex = 22;
            // 
            // dateTimePickerBirth
            // 
            this.dateTimePickerBirth.CalendarFont = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerBirth.Font = new System.Drawing.Font("Wide Latin", 7.8F);
            this.dateTimePickerBirth.Location = new System.Drawing.Point(710, 52);
            this.dateTimePickerBirth.Name = "dateTimePickerBirth";
            this.dateTimePickerBirth.Size = new System.Drawing.Size(268, 24);
            this.dateTimePickerBirth.TabIndex = 25;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAge.Location = new System.Drawing.Point(710, 99);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(268, 28);
            this.textBoxAge.TabIndex = 26;
            // 
            // textBoxLocationBorn
            // 
            this.textBoxLocationBorn.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLocationBorn.Location = new System.Drawing.Point(710, 148);
            this.textBoxLocationBorn.Name = "textBoxLocationBorn";
            this.textBoxLocationBorn.Size = new System.Drawing.Size(268, 28);
            this.textBoxLocationBorn.TabIndex = 27;
            // 
            // textBoxAPGAR
            // 
            this.textBoxAPGAR.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAPGAR.Location = new System.Drawing.Point(710, 196);
            this.textBoxAPGAR.Name = "textBoxAPGAR";
            this.textBoxAPGAR.Size = new System.Drawing.Size(268, 28);
            this.textBoxAPGAR.TabIndex = 28;
            // 
            // textBoxFamilyDoctor
            // 
            this.textBoxFamilyDoctor.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFamilyDoctor.Location = new System.Drawing.Point(710, 246);
            this.textBoxFamilyDoctor.Name = "textBoxFamilyDoctor";
            this.textBoxFamilyDoctor.Size = new System.Drawing.Size(268, 28);
            this.textBoxFamilyDoctor.TabIndex = 29;
            // 
            // textBoxAntecedente
            // 
            this.textBoxAntecedente.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAntecedente.Location = new System.Drawing.Point(710, 290);
            this.textBoxAntecedente.Name = "textBoxAntecedente";
            this.textBoxAntecedente.Size = new System.Drawing.Size(268, 28);
            this.textBoxAntecedente.TabIndex = 30;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(850, 651);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 131);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // buttonOkay
            // 
            this.buttonOkay.Font = new System.Drawing.Font("Mistral", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOkay.Location = new System.Drawing.Point(153, 708);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(225, 74);
            this.buttonOkay.TabIndex = 34;
            this.buttonOkay.Text = "Okay";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Mistral", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(375, 708);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(225, 74);
            this.buttonCancel.TabIndex = 35;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // flowLayoutPanelRadiographs
            // 
            this.flowLayoutPanelRadiographs.Location = new System.Drawing.Point(62, 569);
            this.flowLayoutPanelRadiographs.Name = "flowLayoutPanelRadiographs";
            this.flowLayoutPanelRadiographs.Size = new System.Drawing.Size(653, 122);
            this.flowLayoutPanelRadiographs.TabIndex = 36;
            // 
            // dataGridViewConsultations
            // 
            this.dataGridViewConsultations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsultations.Location = new System.Drawing.Point(267, 323);
            this.dataGridViewConsultations.Name = "dataGridViewConsultations";
            this.dataGridViewConsultations.RowHeadersWidth = 51;
            this.dataGridViewConsultations.RowTemplate.Height = 24;
            this.dataGridViewConsultations.Size = new System.Drawing.Size(400, 96);
            this.dataGridViewConsultations.TabIndex = 37;
            // 
            // dataGridViewPacients
            // 
            this.dataGridViewPacients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacients.Location = new System.Drawing.Point(62, 425);
            this.dataGridViewPacients.Name = "dataGridViewPacients";
            this.dataGridViewPacients.RowHeadersWidth = 51;
            this.dataGridViewPacients.RowTemplate.Height = 24;
            this.dataGridViewPacients.Size = new System.Drawing.Size(851, 138);
            this.dataGridViewPacients.TabIndex = 39;
            // 
            // Form6
            // 
            this.ClientSize = new System.Drawing.Size(1058, 786);
            this.Controls.Add(this.dataGridViewPacients);
            this.Controls.Add(this.dataGridViewConsultations);
            this.Controls.Add(this.flowLayoutPanelRadiographs);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOkay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxAntecedente);
            this.Controls.Add(this.textBoxFamilyDoctor);
            this.Controls.Add(this.textBoxAPGAR);
            this.Controls.Add(this.textBoxLocationBorn);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.dateTimePickerBirth);
            this.Controls.Add(this.textBoxFatherName);
            this.Controls.Add(this.textBoxMotherName);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.comboBoxSex);
            this.Controls.Add(this.textBoxSurename);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form6";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsultations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Size = new Size(0, 0);
        }

        public void addGenderToComboBox()
        {
            comboBoxSex.Items.Add("male");
            comboBoxSex.Items.Add("female");
        }

        public void loadDataGrid()
        {
            string connect = "Server=stoicadenis.com;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            MySqlConnection cnn = new MySqlConnection(connect);
            cnn.Open();
            string tablePacients = "SELECT * FROM Pacients where ID='" + iD + "'";
            string tableConsulations = "SELECT * FROM Consultations where ID='" + iD + "'";
            string tableRadiograms = "SELECT * FROM Radiograms where ID='" + iD + "'";
            MySqlDataAdapter daPacients = new MySqlDataAdapter(tablePacients, connect);
            MySqlDataAdapter daConsultations = new MySqlDataAdapter(tableConsulations, connect);
            MySqlDataAdapter daRadiograms = new MySqlDataAdapter(tableRadiograms, connect);
            DataSet dsPacients = new DataSet();
            DataSet dsConsultations = new DataSet();
            DataSet dsRadiograms = new DataSet();
            daPacients.Fill(dsPacients, "Pacients");
            daConsultations.Fill(dsConsultations, "Consultations");
            daRadiograms.Fill(dsRadiograms, "Radiograms");
            dataGridViewPacients.DataSource = dsPacients.Tables["Pacients"].DefaultView;
            dataGridViewConsultations.DataSource = dsConsultations.Tables["Consultations"].DefaultView;
            cnn.Close();
        }

        public void showImages()
        {
            PictureBox pb;
            int index = 0;
            flowLayoutPanelRadiographs.Controls.Clear();
            string connect = "Server=stoicadenis.com;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();
            string stmt = "SELECT * from Radiograms where ID='" + iD + "'";
            MySqlCommand sc = new MySqlCommand(stmt, con);
            MySqlDataReader dr = sc.ExecuteReader();
            while (dr.Read())
            {
                string photo = dr["Name_image"].ToString();
                string path = @"C:\Users\Denis\Desktop\images\" + photo;
                pb = new PictureBox();
                pb.Name = "Picture" + index.ToString();
                pb.SetBounds(0, 0, 90, 70);
                pb.BackColor = Color.Black;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = Bitmap.FromFile(path);
                pb.Tag = index++;
                flowLayoutPanelRadiographs.Controls.Add(pb);
                pb.Click += pbClick;
            }
            con.Close();
            sc.Dispose();
            dr.Close();
        }
        private void pbClick(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = pic.Image;
            pic.BorderStyle = BorderStyle.Fixed3D;
        }

        private void buttonOkay_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            if (!Form3.IdValid(id))
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
    }
}
