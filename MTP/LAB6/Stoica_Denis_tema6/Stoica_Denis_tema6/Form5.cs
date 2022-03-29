using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stoica_Denis_tema6
{
    public class Form5 : Form
    {
        public static string currentImage = "";
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePickerData;
        private TextBox textBoxID;
        private TextBox textBoxImage;
        private TextBox textBoxDiagnostic;
        private Button buttonImage;
        private Button buttonOkay;
        private Button buttonCancel;
        private RichTextBox richTextBoxComments;
        private string iD;

        public Form5(string iD)
        {
            this.iD = iD;
            InitializeComponent();
            textBoxID.Text = iD;
            textBoxID.Enabled = false;
        }

        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerData = new System.Windows.Forms.DateTimePicker();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxImage = new System.Windows.Forms.TextBox();
            this.textBoxDiagnostic = new System.Windows.Forms.TextBox();
            this.buttonImage = new System.Windows.Forms.Button();
            this.buttonOkay = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.richTextBoxComments = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(70, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 33);
            this.label2.TabIndex = 8;
            this.label2.Text = "Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 33);
            this.label3.TabIndex = 9;
            this.label3.Text = "Diagnostic";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Kristen ITC", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(70, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 33);
            this.label4.TabIndex = 10;
            this.label4.Text = "Comments";
            // 
            // dateTimePickerData
            // 
            this.dateTimePickerData.CalendarFont = new System.Drawing.Font("Wide Latin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerData.Font = new System.Drawing.Font("Wide Latin", 7.8F);
            this.dateTimePickerData.Location = new System.Drawing.Point(230, 104);
            this.dateTimePickerData.Name = "dateTimePickerData";
            this.dateTimePickerData.Size = new System.Drawing.Size(268, 24);
            this.dateTimePickerData.TabIndex = 25;
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(230, 36);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(268, 28);
            this.textBoxID.TabIndex = 26;
            // 
            // textBoxImage
            // 
            this.textBoxImage.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImage.Location = new System.Drawing.Point(230, 160);
            this.textBoxImage.Name = "textBoxImage";
            this.textBoxImage.Size = new System.Drawing.Size(268, 28);
            this.textBoxImage.TabIndex = 27;
            // 
            // textBoxDiagnostic
            // 
            this.textBoxDiagnostic.Font = new System.Drawing.Font("Wide Latin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDiagnostic.Location = new System.Drawing.Point(230, 224);
            this.textBoxDiagnostic.Name = "textBoxDiagnostic";
            this.textBoxDiagnostic.Size = new System.Drawing.Size(268, 28);
            this.textBoxDiagnostic.TabIndex = 28;
            // 
            // buttonImage
            // 
            this.buttonImage.Location = new System.Drawing.Point(524, 158);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(47, 32);
            this.buttonImage.TabIndex = 30;
            this.buttonImage.Text = "   ...";
            this.buttonImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImage.UseVisualStyleBackColor = true;
            this.buttonImage.Click += new System.EventHandler(this.buttonImage_Click);
            // 
            // buttonOkay
            // 
            this.buttonOkay.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.buttonOkay.Location = new System.Drawing.Point(449, 428);
            this.buttonOkay.Name = "buttonOkay";
            this.buttonOkay.Size = new System.Drawing.Size(152, 45);
            this.buttonOkay.TabIndex = 31;
            this.buttonOkay.Text = "Okay";
            this.buttonOkay.UseVisualStyleBackColor = true;
            this.buttonOkay.Click += new System.EventHandler(this.buttonOkay_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(622, 428);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(152, 45);
            this.buttonCancel.TabIndex = 32;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // richTextBoxComments
            // 
            this.richTextBoxComments.Location = new System.Drawing.Point(230, 284);
            this.richTextBoxComments.Name = "richTextBoxComments";
            this.richTextBoxComments.Size = new System.Drawing.Size(371, 117);
            this.richTextBoxComments.TabIndex = 33;
            this.richTextBoxComments.Text = "";
            // 
            // Form5
            // 
            this.ClientSize = new System.Drawing.Size(807, 476);
            this.Controls.Add(this.richTextBoxComments);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOkay);
            this.Controls.Add(this.buttonImage);
            this.Controls.Add(this.textBoxDiagnostic);
            this.Controls.Add(this.textBoxImage);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.dateTimePickerData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "Form5";
            this.Text = "New Radiograph";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string nameImage = Path.GetFileName(dlg.FileName);
                textBoxImage.Text = nameImage;
                currentImage = nameImage;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            dateTimePickerData.Text = null;
            textBoxImage.Text = null;
            textBoxDiagnostic.Text = null;
            richTextBoxComments.Text = null;
        }

        private void buttonOkay_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;

            if (!Form3.IdValid(id))
            {
                MessageBox.Show("Id is not valid!", Form1.errorMessage);
                return;
            }
            string connect = "Server=stoicadenis.com;Database=stoicade_db;Uid=stoicade_user;Pwd=5uaV2c_)7_-);";
            MySqlConnection con = new MySqlConnection(connect);
            con.Open();

            string stmt = "INSERT into Radiograms ([ID], [Data], [Name_image], [Diagnostics], [Comments]) values (@id, @data, @nameImage, @diagnostics, @comments)";
            MySqlCommand sc = new MySqlCommand(stmt, con);
            sc.Parameters.AddWithValue("@id", textBoxID.Text);
            sc.Parameters.AddWithValue("@data", dateTimePickerData.Value);
            sc.Parameters.AddWithValue("@nameImage", textBoxImage.Text);
            sc.Parameters.AddWithValue("@diagnostics", textBoxDiagnostic.Text);
            sc.Parameters.AddWithValue("@comments", richTextBoxComments.Text);
            MySqlDataReader myReader = sc.ExecuteReader();
            con.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
            MessageBox.Show("Saved with Success");
        }
    }
}
