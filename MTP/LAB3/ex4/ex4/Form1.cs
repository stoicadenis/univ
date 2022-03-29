using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex4
{
    public partial class Form1 : Form
    {
        private int position = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (comboControale.Text.Equals("Button"))
            {
                Button button = new Button();
                button.Text = "Button";
                button.SetBounds(0, position, 200, 30);
                position += 32;
                flowLayoutPanel1.Controls.Add(button);
            }
            else if (comboControale.Text.Equals("ComboBox"))
            {
                ComboBox combo = new ComboBox();
                combo.SetBounds(0, position, 200, 30);
                position += 32;
                flowLayoutPanel1.Controls.Add(combo);
            }
            else if (comboControale.Text.Equals("TextBox"))
            {
                TextBox textbox = new TextBox();
                textbox.SetBounds(0, position, 200, 30);
                position += 32;
                flowLayoutPanel1.Controls.Add(textbox);
            }
            else
                MessageBox.Show("Nu ati selectat nici un element!");
            
        }
    }
}
