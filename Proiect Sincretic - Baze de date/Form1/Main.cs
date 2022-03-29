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
    public partial class Main : Form
    {
        private bool client = false;
        private String user;
        public Main(String user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM client where user = '" + this.user + "'", conn);
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                if(!reader["user"].Equals("admin"))
                {
                    btnRaportParfum.Enabled = false;
                    btnTopClienti.Enabled = false;
                    btnVanzari.Enabled = false;
                    client = true;
                    this.Refresh();
                    Application.DoEvents();
                }
            }
            reader.Close();

            command.CommandText = "UPDATE parfumuri SET valoareUnitara = valoareUnitara - valoareUnitara / 10, reducereExp = 1 WHERE (MONTH(CURDATE()) + 3) >= MONTH(dataExpirare) AND reducereExp = 0 AND YEAR(dataExpirare) = YEAR(CURDATE())";
            command.ExecuteNonQuery();
            
            conn.Close();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnParfum_Click(object sender, EventArgs e)
        {
            var parfumuri = new Parfumuri(client, user);
            parfumuri.ShowDialog();
        }

        private void btnRaportParfum_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("select * from parfumuri where unitatiVandute = (select MAX(unitatiVandute) from parfumuri)", conn);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            MessageBox.Show("Cel mai vandut produs este: " + Convert.ToString(reader["parfum"]));
            reader.Close();
            conn.Close();
        }

        private void btnTopClienti_Click(object sender, EventArgs e)
        {
            String[] clienti = new String[3];
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;Allow User Variables=True;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("select client.nume, client.prenume, comanda.codComanda, comanda.user, sum(vanzari.cantitate) as sumaCantitate, sum(vanzari.cantitate * (select parfumuri.valoareUnitara from parfumuri where parfumuri.id = vanzari.idParfum)) as valoareProduse " +
                "from comanda " +
                "inner join client on client.user = comanda.user " +
                "inner join vanzari on comanda.codComanda = vanzari.codComanda " +
                "group by comanda.user order by sumaCantitate desc", conn);
            MySqlDataReader reader = command.ExecuteReader();
            
            for(int i = 0; i < 3; i++)
            {
                reader.Read();
                clienti[i] = "Valoarea produselor este: " + Convert.ToString(reader["valoareProduse"]) + " Client: " + Convert.ToString(reader["nume"]) + " " + Convert.ToString(reader["prenume"]);
            }
            reader.Close();
            MessageBox.Show(clienti[0] + '\n' + clienti[1] + '\n' + clienti[2]);
            conn.Close();
        }

        private void btnVanzari_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;Allow User Variables=True;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("select comanda.DataVanzarii, comanda.codComanda, sum(vanzari.cantitate) as sumaCantitate, sum(vanzari.cantitate * (select parfumuri.valoareUnitara from parfumuri where parfumuri.id = vanzari.idParfum)) as valoareProduse " +
                "from comanda " +
                "inner join vanzari on comanda.codComanda = vanzari.codComanda " +
                "where MONTH(comanda.DataVanzarii) = MONTH(CURDATE()) group by MONTH(comanda.DataVanzarii)", conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                MessageBox.Show("Au fost cumparate pe luna curenta " + Convert.ToString(reader["sumaCantitate"]) + " produse insumand suma de " + Convert.ToString(reader["valoareProduse"]) + " lei."); 
        }

        private void btnCautaParfum_Click(object sender, EventArgs e)
        {
            if(!txtCautare.Text.Equals(""))
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;");
                conn.Open();
                MySqlCommand command = new MySqlCommand("select * from parfumuri where parfum like '%" + txtCautare.Text + "%' OR descriere like '%" + txtCautare.Text + "%'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    reader.Close();
                    string querry = "select * from parfumuri where parfum like '%" + txtCautare.Text + "%' OR descriere like '%" + txtCautare.Text + "%'";
                    MySqlDataAdapter da = new MySqlDataAdapter(querry, conn);
                    DataSet ds = new DataSet();
                    dataGridView1.Visible = true;
                    da.Fill(ds, "parfumuri");
                    dataGridView1.DataSource = ds.Tables["parfumuri"].DefaultView;
                }
            }
            else
            {
                MessageBox.Show("Nu a fost gasit nici un rezultat!");
                dataGridView1.Visible = false;
            }
            
        }
    }
}
