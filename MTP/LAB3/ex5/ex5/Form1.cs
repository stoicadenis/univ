using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(textUser.Text.Equals("") || textX.Text.Equals("") || textY.Text.Equals(""))
            {
                MessageBox.Show("Nu ati introdus date in TextBox-uri!");
            }
            else
            {
                Label lbl = new Label();
                lbl.Text = textUser.Text;
                lbl.SetBounds(int.Parse(textX.Text), int.Parse(textY.Text), 100, 30);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }
    }
}
