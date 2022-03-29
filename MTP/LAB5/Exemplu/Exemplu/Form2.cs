using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Exemplu
{
    public partial class Form2 : Form
    {
        string num, tst;

        public Form2(string nume, string test)
        {
            num = nume;
            tst = test;
            InitializeComponent();
        }

        List<Intrebari> TestGrila = new List<Intrebari>();
        public int total_intrebari;
        public int punctaj = 0;
        public int intrebare_curenta = 0;

        private void Form2_Load(object sender, EventArgs e)
        {
            numeCandidatTB.Text = num;
            int nr_intrebare;
            string tip_intrebare;
            string intrebare;
            int nr_variante_rasp;
            string[] variante_rasp;
            string linkPoza;
            string raspuns_corect;
            XmlDocument xmlDoc = new XmlDocument();

            // Citeste fișierul xml
            System.IO.StreamReader file = new System.IO.StreamReader(tst + ".xml");
            xmlDoc.Load(file);

            XmlNode root = xmlDoc.SelectSingleNode("testGrila");
            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    XmlNode child = root.ChildNodes[i];
                    if(child.HasChildNodes)
                    {
                        nr_intrebare = Convert.ToInt16(child.ChildNodes[0].InnerText);
                        tip_intrebare = child.ChildNodes[1].InnerText;
                        intrebare = child.ChildNodes[2].InnerText;

                        XmlNode variante = child.ChildNodes[3];
                        nr_variante_rasp = variante.ChildNodes.Count;
                        variante_rasp = new string[nr_variante_rasp];
                        for (int j = 0; j < variante.ChildNodes.Count; j++)
                            variante_rasp[j] = variante.ChildNodes[j].InnerText;

                        linkPoza = child.ChildNodes[4].InnerText;
                        raspuns_corect = child.ChildNodes[5].InnerText;

                        Intrebari intreb = new Intrebari(nr_intrebare, 
                            tip_intrebare, 
                            intrebare,
                            nr_variante_rasp, 
                            variante_rasp, 
                            linkPoza, 
                            raspuns_corect);
                        TestGrila.Add(intreb);
                    }
                }
            }
            file.Close();

            total_intrebari = TestGrila.Count;
            nr_intrebariTB.Text = total_intrebari.ToString();
            intreabreLabel.Text = TestGrila[0].Intrebare;
            Incarca_variante_raspuns(0);

            string link = TestGrila[0].LinkPoza;
            if (!link.Equals("0"))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Image.FromFile(link);
            }

            raspunsCorectTB.Text = TestGrila[0].Raspuns_corect;
        }

        private void urm_intrebareBtn_Click(object sender, EventArgs e)
        {
            string[] raspunsuri_corect = raspunsCorectTB.Text.Split(',');
            string[] raspunsuri = new string[raspunsuri_corect.Length];
            int count = 0;
            bool check = false;
            int nr_variante = flowLayoutPanel1.Controls.Count;
            for (int i = 1; i <= nr_variante; i++)
            {
                if (flowLayoutPanel1.Controls[i - 1].Name.Contains("ck"))
                {
                    CheckBox ck = (CheckBox)flowLayoutPanel1.Controls[i - 1];
                    if (ck.Checked == true && raspunsuri_corect.Contains(i.ToString()))
                    {
                        raspunsuri[count] = i.ToString();
                        count++;
                        if (Enumerable.SequenceEqual(raspunsuri_corect, raspunsuri))
                        {
                            punctaj++;
                            check = true;
                        }
                    }
                }
                else
                {
                    RadioButton rb = (RadioButton)flowLayoutPanel1.Controls[i - 1];
                    if (rb.Checked == true && raspunsuri_corect.Contains(i.ToString()))
                    {
                        punctaj++;
                        check = true;
                    }
                }
            }

            if (check == true)
            {
                punctajTB.Text = punctaj.ToString();
                if (intrebare_curenta < total_intrebari - 1)
                {
                    intrebare_curenta++;
                    intreabreLabel.Text = TestGrila[intrebare_curenta].Intrebare;
                    Incarca_variante_raspuns(intrebare_curenta);

                    string link = TestGrila[intrebare_curenta].LinkPoza;
                    if (!link.Equals("0"))
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = Image.FromFile(link);
                    }

                    raspunsCorectTB.Text = TestGrila[intrebare_curenta].Raspuns_corect;
                }
                else
                {
                    MessageBox.Show("Testul s-a incheiat");
                    urm_intrebareBtn.Enabled = false;
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Raspunsul este gresti. Mai incercati!");
            }
        }

        private void Incarca_variante_raspuns(int x)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            if (TestGrila[x].Tip_intrebare == "multiple")
            {
                for (int i = 0; i < TestGrila[x].Nr_variante_rasp; i++)
                {
                    CheckBox ck = new CheckBox();
                    ck.Text = TestGrila[x].Variante_rasp[i];
                    ck.Name = "ck" + (i + 1).ToString();
                    flowLayoutPanel1.Controls.Add(ck);
                }
            }
            else if (TestGrila[x].Tip_intrebare == "single")
            {
                for (int i = 0; i < TestGrila[x].Nr_variante_rasp; i++)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = TestGrila[x].Variante_rasp[i];
                    rb.Name = "rb" + (i + 1).ToString();
                    flowLayoutPanel1.Controls.Add(rb);
                }
            }
        }

    }
}
