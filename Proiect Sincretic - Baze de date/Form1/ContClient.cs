using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class ContClient : Form
    {
        public ContClient()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!txtUser.Text.Equals("") && !txtPass.Text.Equals("") && !txtNume.Text.Equals("") && !txtPrenume.Text.Equals(""))
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;");
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM login WHERE user = '" + txtUser.Text + "'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    MessageBox.Show("Numele de utilizatorul folosit exista deja!");
                }
                else
                {
                    reader.Close();
                    command.CommandText = "INSERT INTO login VALUES ('" + txtUser.Text + "', '" + txtPass.Text + "')";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO client VALUES ('" + txtUser.Text + "', '" + txtNume.Text + "', '" + txtPrenume.Text + "', '" + dataNastere.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cont creat cu SUCCES!");
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Nu ati introdus datele corect!");
        }
    }
}
