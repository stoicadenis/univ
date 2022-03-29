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
using System.Xml;
using System.Xml.Serialization;

namespace ex5
{ 

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            FileStream fs = new FileStream("C:\\Users\\Denis\\Desktop\\MTP\\LAB4\\ex5\\ex5\\tema.xml", FileMode.Open, FileAccess.Read);
            xmlDoc.Load(fs);

            XmlNode root = xmlDoc.SelectSingleNode("catalog");
            if(root.HasChildNodes)
            {
                for(int i = 0; i < root.ChildNodes.Count; i++)
                {
                    double newPrice = double.Parse(root.ChildNodes[i].SelectSingleNode("price").InnerText.ToString(), System.Globalization.CultureInfo.InvariantCulture) + (double.Parse(root.ChildNodes[i].SelectSingleNode("price").InnerText.ToString(), System.Globalization.CultureInfo.InvariantCulture) * 1 / 10);
                    root.ChildNodes[i].SelectSingleNode("price").InnerText = newPrice.ToString();
                }
            }
            MessageBox.Show("A fost adaugat un adaos de 10% la pret, verificati fisierul XML!");
            fs.Close();

            fs = new FileStream("C:\\Users\\Denis\\Desktop\\MTP\\LAB4\\ex5\\ex5\\tema.xml", FileMode.Open, FileAccess.Write);
            xmlDoc.Save(fs);
            fs.Close();
            Application.Exit();
        }
    }
}
