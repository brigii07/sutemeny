using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sutemenyek
{
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }

        public int vegeredmeny = 0;
        List<sutik> sutemenyek = new List<sutik>();
        private void form2_Load(object sender, EventArgs e)
        {
            StreamReader read = new StreamReader("sutemenyek.txt");
            while (!read.EndOfStream)
            {
                var tomb = read.ReadLine().Split(';');
                sutik tmp = new sutik();
                tmp.sutinev = tomb[0];
                tmp.sutiara = Convert.ToInt32(tomb[1]);
                sutemenyek.Add(tmp);
            }

            for (int i = 0; i < sutemenyek.Count; i++)
            {
                checkBox1.Text = sutemenyek[0].sutinev + " (" + sutemenyek[0].sutiara + " Ft)";
                checkBox2.Text = sutemenyek[1].sutinev + " (" + sutemenyek[1].sutiara + " Ft)";
                checkBox3.Text = sutemenyek[2].sutinev + " (" + sutemenyek[2].sutiara + " Ft)";
                checkBox4.Text = sutemenyek[3].sutinev + " (" + sutemenyek[3].sutiara + " Ft)";
                checkBox5.Text = sutemenyek[4].sutinev + " (" + sutemenyek[4].sutiara + " Ft)";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
                if (checkBox1.Checked == true && textBox1.Text != string.Empty || checkBox2.Checked == true && textBox2.Text != string.Empty || checkBox3.Checked == true && textBox3.Text != string.Empty || checkBox4.Checked == true && textBox4.Text != string.Empty || checkBox5.Checked == true && textBox5.Text != string.Empty)
                {
                    MessageBox.Show("A rendelés leadva!", "Siker!");
                    button3.Visible = true;
                }
                else if(checkBox1.Checked == false && textBox1.Text == string.Empty || checkBox2.Checked == false && textBox2.Text == string.Empty || checkBox3.Checked == false && textBox3.Text == string.Empty || checkBox4.Checked == false && textBox4.Text == string.Empty || checkBox5.Checked == false && textBox5.Text == string.Empty)
                {
                    MessageBox.Show("Nem jelölt meg süteményt vagy nem adott meg mennyiséget!", "Hiba!");
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                    button3.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            richTextBox1.Visible = true;

            int osszmennyiseg = 0;
            int mennyiseg1 = 0;
            int mennyiseg2 = 0;
            int mennyiseg3 = 0;
            int mennyiseg4 = 0;
            int mennyiseg5 = 0;
            string sutemeny = string.Empty;

            if (textBox1.Text != string.Empty)
            {
                mennyiseg1 = Convert.ToInt32(textBox1.Text);
                vegeredmeny += mennyiseg1 * 300;
                osszmennyiseg += mennyiseg1;
                sutemeny += "Somlói Galuska";
            }

            if (textBox2.Text != string.Empty)
            {
                mennyiseg2 = Convert.ToInt32(textBox2.Text);
                vegeredmeny += mennyiseg2 * 280;
                osszmennyiseg += mennyiseg2;
                sutemeny += " Rákózci Túros";
            }

            if (textBox3.Text != string.Empty)
            {
                mennyiseg3 = Convert.ToInt32(textBox3.Text);
                vegeredmeny += mennyiseg3 * 350;
                osszmennyiseg += mennyiseg3;
                sutemeny += " Csoki Torta";
            }

            if (textBox4.Text != string.Empty)
            {
                mennyiseg4 = Convert.ToInt32(textBox4.Text);
                vegeredmeny += mennyiseg4 * 400;
                osszmennyiseg += mennyiseg4;
                sutemeny += " Marcipán Alagút";
            }

            if (textBox5.Text != string.Empty)
            {
                mennyiseg5 = Convert.ToInt32(textBox5.Text);
                vegeredmeny += mennyiseg5 * 400;
                osszmennyiseg += mennyiseg5;
                sutemeny += " Eszterházy Szelet";
            }

            richTextBox1.Text = "Rendelt süti(k): " + sutemeny +  "\nMennyiség: " + osszmennyiseg.ToString() + "\nFizetendő összeg: "+ vegeredmeny.ToString() + "Ft";

            StreamWriter wr;
           
            if (!File.Exists("szamlak.txt"))
            {
                wr = new StreamWriter("szamlak.txt");
            }
            else
            {
                wr = File.AppendText("szamlak.txt");
            }

            wr.Write("Rendelt süti(k): " + sutemeny + "\nMennyiség: " + osszmennyiseg.ToString() + "\nFizetendő összeg: " + vegeredmeny.ToString() + "Ft\n");
            wr.Close();

            MessageBox.Show("A számla kiírásra került!");
        }
    }
}
