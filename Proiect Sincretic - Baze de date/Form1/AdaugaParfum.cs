using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class AdaugaParfum : Form
    {
        public AdaugaParfum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!txtNume.Text.Equals("") && !txtStoc.Text.Equals("") && txtStoc.Text.All(s => char.IsDigit(s)) && !txtValUnitara.Text.Equals("") && txtValUnitara.Text.All(s => char.IsDigit(s)))
            {
                MySqlConnection conn = new MySqlConnection("Server=localhost;Database=mtp;Uid=root;Pwd=Denis123!;");
                conn.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO parfumuri (parfum, descriere, stoc, unitatiVandute, dataExpirare, valoareUnitara) VALUES ('" + txtNume.Text + "', '" + txtDescriere.Text + "', " + txtStoc.Text + ", 0, '" + dataExpirare.Text + "', " + txtValUnitara.Text + ")", conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Ati introdus cu succes datele!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Nu ati introdus datele bine in formular!");
            }
        }

        private void label5_DragDrop(object sender, DragEventArgs e)
        {
            var fisier = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (fisier != null && fisier.Any() && fisier[0].Contains(".txt"))
            {
                string[] linii = System.IO.File.ReadAllLines(fisier[0]);
                if(linii.Count() == 5)
                {
                    txtNume.Text = linii[0];
                    txtDescriere.Text = linii[1];
                    txtStoc.Text = linii[2];
                    dataExpirare.Text = linii[3];
                    txtValUnitara.Text = linii[4];
                    MessageBox.Show("Fisier uploadad cu succes!");
                }
                else
                {
                    MessageBox.Show("Continutul fisierului este invalid!");
                }
            }
            else
                MessageBox.Show("Fisier invalid!");
        }

        private void label5_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
