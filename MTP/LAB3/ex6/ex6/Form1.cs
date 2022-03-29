using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex6
{
    public partial class Form1 : Form
    {
        private int x, y;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtM.Text.Equals("") || txtN.Text.Equals(""))
            {
                MessageBox.Show("Nu ati introdus nr de linii/ coloane!");
            }
            else
            {
                x = y = 0;
                for(int i = 0; i < int.Parse(txtM.Text); i++)
                {
                    for (int j = 0; j < int.Parse(txtN.Text); j++)
                    {
                        Button btn = new Button();
                        btn.Text = i + " " + j;
                        btn.SetBounds(x, y, 500/int.Parse(txtM.Text), 400/int.Parse(txtN.Text));
                        flowLayoutPanel1.Controls.Add(btn);
                        y += 500 / int.Parse(txtM.Text) + 10;
                    }
                    x += 400 / int.Parse(txtN.Text) + 10;
                }
            }
        }

    }
}
