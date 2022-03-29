using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stoica_Denis_tema6
{
    public partial class Form1 : Form
    {
        public Form2 form2;
        private static Dictionary<string, string> hashMap = new Dictionary<string, string>();
        public const string errorMessage = "Error";
        private static int countRead = 0;

        public Form1()
        {
            InitializeComponent();
            textBoxUserName.MaxLength = 10;
            textBoxPassword.MaxLength = 10;
            if (countRead == 0)
            {
                readFile();
            }
            countRead += 1;
        }

        public void readFile()
        {
            buttonLogIn.Enabled = true;
            buttonCancel.Enabled = true;

            foreach (string line in System.IO.File.ReadLines(@"C:\Users\Denis\Desktop\MTP\LAB6\Stoica_Denis_tema6\Stoica_Denis_tema6\bin\Debug\text.txt"))
            {
                int i = 0, j = 1;
                string[] splitter = line.Split('-');
                hashMap.Add(splitter[i], splitter[j]);
            }
        }

        public bool checkOnlyCharacters(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        public void change()
        {
            buttonLogIn.Enabled = false;
            buttonCancel.Enabled = false;
            Thread.Sleep(3000);
            buttonLogIn.Enabled = true;
            buttonCancel.Enabled = true;
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            if (userName == "" || userName == " " || password == "" || password == " ")
            {
                MessageBox.Show("Some error occured", errorMessage); change();
                return;
            }

            if (!checkOnlyCharacters(userName) || !checkOnlyCharacters(password))
            {
                MessageBox.Show("There can't be numbers!", errorMessage); change();
                return;
            }

            bool flag = false;
            foreach (KeyValuePair<string, string> input in hashMap)
            {
                if ((userName == input.Key) && (password == input.Value))
                {
                    flag = true;
                    break;
                }
                continue;
            }

            if (!flag)
            {
                MessageBox.Show("Username or password are incorrect!\n", errorMessage);
                change();
                return;
            }

            form2 = new Form2();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Size = new Size(0, 0);
            form2.Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxUserName.Text = null;
            textBoxPassword.Text = null;
        }
    }
}
