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
    public class Form4 : Form
    {
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxID;
        private TextBox textBoxSymptoms;
        private TextBox textBoxDiagnostic;
        private TextBox textBoxTreatment;
        private DateTimePicker dateTimePickerDate;
        private Button buttonAddConsultation;
        private Label labelNewConsultation;

        public Form4(string iD, string nAME, string sURENAME)
        {
            ID = iD;
            Name = nAME;
            SURENAME = sURENAME;
            InitializeComponent();
            textBoxID.Text = ID;
            dateTimePickerDate.Enabled = false;
        }

        public string ID { get; }
        public string SURENAME { get; }

        private void InitializeComponent()
        {
            this.labelNewConsultation = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxSymptoms = new System.Windows.Forms.TextBox();
            this.textBoxDiagnostic = new System.Windows.Forms.TextBox();
            this.textBoxTreatment = new System.Windows.Forms.TextBox();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.buttonAddConsultation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNewConsultation
            // 
            this.labelNewConsultation.AutoSize = true;
            this.labelNewConsultation.Font = new System.Drawing.Font("Vladimir Script", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewConsultation.Location = new System.Drawing.Point(223, 20);
            this.labelNewConsultation.Name = "labelNewConsultation";
            this.labelNewConsultation.Size = new System.Drawing.Size(332, 58);
            this.labelNewConsultation.TabIndex = 1;
            this.labelNewConsultation.Text = "New Consultation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Symptoms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Diagnostic";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 33);
            this.label4.TabIndex = 9;
            this.label4.Text = "Treatment";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(258, 126);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(268, 28);
            this.textBoxID.TabIndex = 14;
            // 
            // textBoxSymptoms
            // 
            this.textBoxSymptoms.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSymptoms.Location = new System.Drawing.Point(258, 247);
            this.textBoxSymptoms.Name = "textBoxSymptoms";
            this.textBoxSymptoms.Size = new System.Drawing.Size(268, 28);
            this.textBoxSymptoms.TabIndex = 15;
            // 
            // textBoxDiagnostic
            // 
            this.textBoxDiagnostic.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDiagnostic.Location = new System.Drawing.Point(258, 310);
            this.textBoxDiagnostic.Name = "textBoxDiagnostic";
            this.textBoxDiagnostic.Size = new System.Drawing.Size(268, 28);
            this.textBoxDiagnostic.TabIndex = 16;
            // 
            // textBoxTreatment
            // 
            this.textBoxTreatment.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTreatment.Location = new System.Drawing.Point(258, 374);
            this.textBoxTreatment.Name = "textBoxTreatment";
            this.textBoxTreatment.Size = new System.Drawing.Size(268, 28);
            this.textBoxTreatment.TabIndex = 17;
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.CalendarFont = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDate.Font = new System.Drawing.Font("Wide Latin", 7.8F);
            this.dateTimePickerDate.Location = new System.Drawing.Point(258, 192);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(268, 24);
            this.dateTimePickerDate.TabIndex = 25;
            // 
            // buttonAddConsultation
            // 
            this.buttonAddConsultation.Font = new System.Drawing.Font("Mistral", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddConsultation.Location = new System.Drawing.Point(233, 431);
            this.buttonAddConsultation.Name = "buttonAddConsultation";
            this.buttonAddConsultation.Size = new System.Drawing.Size(293, 83);
            this.buttonAddConsultation.TabIndex = 26;
            this.buttonAddConsultation.Text = "Add Consultation";
            this.buttonAddConsultation.UseVisualStyleBackColor = true;
            this.buttonAddConsultation.Click += new System.EventHandler(this.buttonAddConsultation_Click);
            // 
            // Form4
            // 
            this.ClientSize = new System.Drawing.Size(799, 546);
            this.Controls.Add(this.buttonAddConsultation);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.textBoxTreatment);
            this.Controls.Add(this.textBoxDiagnostic);
            this.Controls.Add(this.textBoxSymptoms);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelNewConsultation);
            this.Name = "Form4";
            this.Text = "Consultation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonAddConsultation_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;

            if (!Form3.IdValid(id))
            {
                MessageBox.Show("Id is invalid!", Form1.errorMessage);
                return;
            }

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

            dateTimePickerDate.Value = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
            int age;
            age = DateTime.Now.Year - dateTimePickerDate.Value.Year;
            if (DateTime.Now.DayOfYear < dateTimePickerDate.Value.DayOfYear)
            {
                age -= 1;
            }


            string connect = "Server=stoicadenis.com;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();

            string stmt = "INSERT into Consultations ([ID], [Data], [Simptoms], [Diagnostic], [Treatment]) values (@id, @data, @simptoms, @diagnostic, @treatment)";
            MySqlCommand sc = new MySqlCommand(stmt, con);
            sc.Parameters.AddWithValue("@id", textBoxID.Text);
            sc.Parameters.AddWithValue("@data", dateTimePickerDate.Value);
            sc.Parameters.AddWithValue("@simptoms", textBoxSymptoms.Text);
            sc.Parameters.AddWithValue("@diagnostic", textBoxDiagnostic.Text);
            sc.Parameters.AddWithValue("@treatment", textBoxTreatment.Text);
            MySqlDataReader myReader = sc.ExecuteReader();
            con.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
            MessageBox.Show("Saved with Success");
        }
    }
}
