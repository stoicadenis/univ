using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class CumparaParfum : Form
    {
        private String id;
        private String user;

        public CumparaParfum(String id, String nume, String valoare, String user)
        {
            InitializeComponent();
            this.id = id;
            this.user = user;
            txtNume.Text = nume;
            txtPret.Text = valoare;
        }

        private void CumparaParfum_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(txtNume, true);
            ControlExtension.Draggable(txtCantitate, true);
            ControlExtension.Draggable(txtPret, true);
            ControlExtension.Draggable(lblNume, true);
            ControlExtension.Draggable(label2, true);
            ControlExtension.Draggable(label3, true);
            ControlExtension.Draggable(btnContinua, true);
        }

        private void txtCantitate_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtCantitate.Text, @"^[a-zA-Z]+$"))
                btnContinua.Enabled = false;
            else
                btnContinua.Enabled = true;
        }

        private void btnContinua_Click(object sender, EventArgs e)
        {
            btnContinua.Enabled = false;
            txtCantitate.Enabled = false;

            Label lblUser = new Label();
            lblUser.Text = "User";
            lblUser.Height = 20;
            lblUser.Width = 70;
            lblUser.Font = new Font("Microsoft Sans Serif", lblNume.Font.Size, lblNume.Font.Style);
            ControlExtension.Draggable(lblUser, true);
            flowLayoutPanel1.Controls.Add(lblUser);

            TextBox txtUser = new TextBox();
            txtUser.Text = this.user;
            txtUser.Location = new Point(50, 10);
            txtUser.Height = 20;
            txtUser.Width = 100;
            txtUser.Enabled = false;
            flowLayoutPanel1.Controls.Add(txtUser);

            Label lblNumeClient = new Label();
            lblNumeClient.Text = "Nume";
            lblNumeClient.Height = 20;
            lblNumeClient.Width = 70;
            lblNumeClient.Font = new Font("Microsoft Sans Serif", lblNume.Font.Size, lblNume.Font.Style);
            flowLayoutPanel1.Controls.Add(lblNumeClient);

            TextBox txtNumeClient = new TextBox();
            txtNumeClient.Text = "";
            txtNumeClient.Location = new Point(50, 10);
            txtNumeClient.Height = 20;
            txtNumeClient.Width = 100;
            flowLayoutPanel1.Controls.Add(txtNumeClient);

            Label lblPrenume = new Label();
            lblPrenume.Text = "Prenume";
            lblPrenume.Height = 20;
            lblPrenume.Width = 70;
            lblPrenume.Font = new Font("Microsoft Sans Serif", lblNume.Font.Size, lblNume.Font.Style);
            flowLayoutPanel1.Controls.Add(lblPrenume);

            TextBox txtPrenumeClient = new TextBox();
            txtPrenumeClient.Text = "";
            txtPrenumeClient.Location = new Point(50, 10);
            txtPrenumeClient.Height = 20;
            txtPrenumeClient.Width = 100;
            flowLayoutPanel1.Controls.Add(txtPrenumeClient);

            Button cumparaParfum = new Button();
            cumparaParfum.Text = "Cumpara";
            cumparaParfum.Height = 35;
            cumparaParfum.Width = 90;

            cumparaParfum.Click += (s, d) =>
            {
                if (!txtUser.Text.Equals("") && !txtNumeClient.Text.Equals("") && !txtPrenumeClient.Text.Equals(""))
                {
                    MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;");
                    conn.Open();
                    MySqlCommand command = new MySqlCommand("select * from parfumuri where id = " + this.id + "", conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader["stoc"]) >= Convert.ToInt32(txtCantitate.Text))
                        {
                            reader.Close();

                            DateTime dataLocala = DateTime.Now;
                            command.CommandText = "insert into comanda (DataVanzarii, user) values ('" + dataLocala.ToString("yyyy'-'MM'-'dd") + "', '" + txtUser.Text + "')";
                            command.ExecuteNonQuery();

                            command.CommandText = "insert into vanzari (idParfum, cantitate) values ('" + this.id + "', '" + txtCantitate.Text + "')";
                            command.ExecuteNonQuery();

                            command.CommandText = "update parfumuri set stoc = stoc - " + txtCantitate.Text + ", unitatiVandute = unitatiVandute + " + txtCantitate.Text + " where id = " + this.id + "";
                            command.ExecuteNonQuery();

                            using (StreamWriter writer = new StreamWriter("./" + txtUser.Text + "_" + txtNume.Text + "_" + dataLocala.ToString("yyyy'-'MM'-'dd") + ".txt"))
                            {
                                writer.WriteLine(txtNumeClient.Text + " " + txtPrenumeClient.Text);
                                writer.WriteLine("ID: " + this.id + " Nume: " + txtNume.Text);
                                writer.WriteLine("Cantitate: " + txtCantitate.Text);
                                writer.WriteLine("Perioada de retur este de 14 zile incepand cu data de: " + dataLocala.ToString("yyyy'-'MM'-'dd"));
                                writer.Close();
                            }
                            MessageBox.Show("Ai cumparat cu succes produsul!");
                            this.Hide();
                        }
                    }
                }
                else
                    MessageBox.Show("Nu ati introdus date client!");
            };
            flowLayoutPanel1.Controls.Add(cumparaParfum);

            
        }
    }
}
