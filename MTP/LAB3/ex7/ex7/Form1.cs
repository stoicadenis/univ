using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ex7
{
    public partial class Form1 : Form
    {
        private string[] subDirs = Directory.GetDirectories("C:\\Users\\Denis\\Desktop\\MTP\\LAB3\\ex7\\ex7\\Echipa");
        private string[] fisiere;

        private TextBox txtEchipaNoua;
        private TextBox[] txtJucator = new TextBox[3];
        private int x = 0, y = 0;
        public Form1()
        {
            InitializeComponent();

            foreach (string currSubDir in subDirs)
                comboBox1.Items.Add(currSubDir.Split('\\').Last());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCNP.Visible = false;
            lblDataNasterii.Visible = false;
            lblDetalii.Visible = false;
            lblNume.Visible = false;
            lblPost.Visible = false;
            lblVarsta.Visible = false;
            txtCNP.Visible = false;
            txtDataNasterii.Visible = false;
            txtNume.Visible = false;
            txtPost.Visible = false;
            txtVarsta.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            fisiere = Directory.GetFiles("C:\\Users\\Denis\\Desktop\\MTP\\LAB3\\ex7\\ex7\\Echipa\\" + comboBox1.Text);
            foreach (string fis in fisiere)
            {
                string[] nume = File.ReadAllLines(fis);
                Button btn = new Button();
                btn.Text = nume[0];
                btn.SetBounds(x, y, 200, 40);
                btn.Click += new EventHandler(btnClick_Jucator);
                flowLayoutPanel1.Controls.Add(btn);
                y += 42;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblCNP.Visible = false;
            lblDataNasterii.Visible = false;
            lblDetalii.Visible = false;
            lblNume.Visible = false;
            lblPost.Visible = false;
            lblVarsta.Visible = false;
            txtCNP.Visible = false;
            txtDataNasterii.Visible = false;
            txtNume.Visible = false;
            txtPost.Visible = false;
            txtVarsta.Visible = false;
            flowLayoutPanel1.Controls.Clear();

            txtEchipaNoua = new TextBox();
            txtEchipaNoua.SetBounds(0, 0, 200, 35);

            Button btnEchipaNoua = new Button();
            btnEchipaNoua.Text = "Adauga Echipa";
            btnEchipaNoua.SetBounds(0, 40, 200, 35);
            btnEchipaNoua.Click += new EventHandler(btnClick_EchipaNoua);

            flowLayoutPanel1.Controls.Add(txtEchipaNoua);
            flowLayoutPanel1.Controls.Add(btnEchipaNoua);
        }

        private void btnClick_EchipaNoua(object sender, EventArgs e)
        {
            DirectoryInfo di = Directory.CreateDirectory("C:\\Users\\Denis\\Desktop\\MTP\\LAB3\\ex7\\ex7\\Echipa\\" + txtEchipaNoua.Text);
            comboBox1.Items.Add(txtEchipaNoua.Text);
            comboBox1.ResetText();
            flowLayoutPanel1.Controls.Clear();
            MessageBox.Show("Echipa adaugata cu succes");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Eroare la comboBox, nu ati selectat echipa!");
            }
            else
            {
                lblCNP.Visible = false;
                lblDataNasterii.Visible = false;
                lblDetalii.Visible = false;
                lblNume.Visible = false;
                lblPost.Visible = false;
                lblVarsta.Visible = false;
                txtCNP.Visible = false;
                txtDataNasterii.Visible = false;
                txtNume.Visible = false;
                txtPost.Visible = false;
                txtVarsta.Visible = false;
                flowLayoutPanel1.Controls.Clear();

                Label[] lblJucator = new Label[3];
                lblJucator[0] = new Label();
                lblJucator[1] = new Label();
                lblJucator[2] = new Label();
                lblJucator[0].Text = "Nume";
                lblJucator[1].Text = "Post";
                lblJucator[2].Text = "CNP";
                lblJucator[0].SetBounds(0, 0, 35, 20);
                lblJucator[1].SetBounds(0, 22, 30, 20);
                lblJucator[2].SetBounds(0, 44, 30, 20);

                txtJucator[0] = new TextBox();
                txtJucator[1] = new TextBox();
                txtJucator[2] = new TextBox();
                txtJucator[0].SetBounds(32, 0, 150, 30);
                txtJucator[1].SetBounds(32, 22, 150, 30);
                txtJucator[2].SetBounds(32, 44, 150, 30);

                Button btnAddJucator = new Button();
                btnAddJucator.Text = "Adauga Jucator";
                //btnAddJucator.Click += (se, ee) => { btnClick_JucatorNou(sender, e, txtJucator[2].Text); };
                btnAddJucator.Click += new EventHandler(btnClick_JucatorNou);
                btnAddJucator.SetBounds(0, 0, 150, 40);
                flowLayoutPanel1.Controls.Add(lblJucator[0]);
                flowLayoutPanel1.Controls.Add(txtJucator[0]);
                flowLayoutPanel1.Controls.Add(lblJucator[1]);
                flowLayoutPanel1.Controls.Add(txtJucator[1]);
                flowLayoutPanel1.Controls.Add(lblJucator[2]);
                flowLayoutPanel1.Controls.Add(txtJucator[2]);
                flowLayoutPanel1.Controls.Add(btnAddJucator);
            }
        }

        private void btnClick_JucatorNou(object sender, EventArgs e)
        {
            string docPath = @"C:\Users\Denis\Desktop\MTP\LAB3\ex7\ex7\Echipa\" + comboBox1.Text + @"\" + txtJucator[2].Text + ".txt";
            using (StreamWriter writer = new StreamWriter(docPath))
            {
                writer.WriteLine(txtJucator[0].Text);
                writer.WriteLine(txtJucator[1].Text);
            }
           
            MessageBox.Show("Jucatorul s-a adaugat cu succes!");
            comboBox1.ResetText();
            flowLayoutPanel1.Controls.Clear();
        }

        private void btnClick_Jucator(object sender, EventArgs e)
        {
            lblCNP.Visible = true;
            lblDataNasterii.Visible = true;
            lblDetalii.Visible = true;
            lblNume.Visible = true;
            lblPost.Visible = true;
            lblVarsta.Visible = true;
            txtCNP.Visible = true;
            txtDataNasterii.Visible = true;
            txtNume.Visible = true;
            txtPost.Visible = true;
            txtVarsta.Visible = true;

            Button btnClick = (Button)sender;
            string[] jucator = new string[2];
            foreach (string fis in fisiere)
            {
                jucator = File.ReadAllLines(fis);
                if (jucator[0].Equals(btnClick.Text))
                {
                    txtNume.Text = jucator[0];
                    txtPost.Text = jucator[1];
                    txtCNP.Text = fis.Split('\\').Last().Split('.').First();
                    break;
                }        
            }
            string[] buffer = Regex.Split(txtCNP.Text, string.Empty);
            
            txtDataNasterii.Text = buffer[6] + buffer[7] + "." + buffer[4] + buffer[5] + "." + (buffer[1] == "1" ? "19" : "20") + buffer[2] + buffer[3];

            int buff = 2021 - int.Parse((buffer[1] == "1" ? "19" : "20") + buffer[2] + buffer[3]);
            txtVarsta.Text = buff.ToString();
        }
    }
}
