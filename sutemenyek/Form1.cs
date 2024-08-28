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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<sutik> sutemenyek = new List<sutik>();
        private void button1_Click(object sender, EventArgs e)
        {
            bool feltoltve = false;
            StreamReader read = new StreamReader("sutemenyek.txt");
            while (!read.EndOfStream)
            {
                var tomb = read.ReadLine().Split(';');
                sutik tmp = new sutik();
                tmp.sutinev = tomb[0];
                tmp.sutiara = Convert.ToInt32(tomb[1]);
                sutemenyek.Add(tmp);
                feltoltve = true;
                if (feltoltve == true)
                {
                    button2.Visible = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form2 f2 = new form2();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
