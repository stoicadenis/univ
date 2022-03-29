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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!txtUser.Text.Equals("") && !txtPass.Text.Equals(""))
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;");
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM login WHERE user = '" + txtUser.Text + "' AND pass = '" + txtPass.Text + "'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Visible = false;
                    var Main = new Main(txtUser.Text);
                    Main.ShowDialog();
                    
                }
                else
                    MessageBox.Show("Nu ati introdus un user/ pass valida.");
            }
            else
                MessageBox.Show("Nu ati introdus date in textbox-uri!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newAcc = new ContClient();
            newAcc.ShowDialog();
        }
    }
}
