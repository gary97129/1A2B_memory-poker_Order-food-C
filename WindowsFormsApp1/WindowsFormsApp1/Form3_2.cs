using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3_2 : Form
    {
        public string ra = "";
        public Form3_2()
        {
            InitializeComponent();
        }
        string z;
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = ra + "模式";
            Random rnd = new Random();
            if (ra == "簡單")
            {
                textBox1.MaxLength = 3;
            }
            if (ra == "一般")
            {
                textBox1.MaxLength = 4;
            }
            if (ra == "困難")
            {
                textBox1.MaxLength = 5;
            }
            z += rnd.Next(0, 10).ToString();
            while (true)
            {
                string c = rnd.Next(0, 10).ToString();
                if (z.Contains(c) == false)
                {
                    z += c;
                }
                if (z.Length == textBox1.MaxLength) { break; }
            }
            string z1 = "";
            for (int i = 0; i < textBox1.MaxLength; i++)
            {
                if (i % 2 == 0)
                {
                    int q = int.Parse(z.Substring(i, 1)) + 1;
                    if (q == 10)
                    {
                        q = 0;
                    }
                    z1 += q.ToString();
                }
                else
                {
                    int q = int.Parse(z.Substring(i, 1)) - 1;
                    if (q == -1)
                    {
                        q = 9;
                    }
                    z1 += q.ToString();
                }
            }
            label3.Text = textBox1.MaxLength.ToString() + "位數" + " 提示:" + z1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == textBox1.MaxLength)
            {
                int ss = 0;
                for (int i = 0; i < textBox1.MaxLength - 1; i++)
                {
                    for (int j = i + 1; j < textBox1.MaxLength; j++)
                    {
                        if (textBox1.Text.Substring(i, 1) == textBox1.Text.Substring(j, 1)) { ss = 1; break; }
                    }
                    if (ss == 1) { break; }
                }
                if (ss == 0)
                {
                    int aa = 0;
                    int bb = 0;
                    for (int i = 0; i < textBox1.MaxLength; i++)
                    {
                        if (textBox1.Text.Substring(i, 1) == z.Substring(i, 1))
                        {
                            aa += 1;
                        }
                        else
                        {
                            if (z.Contains(textBox1.Text.Substring(i, 1)) == true)
                            {
                                bb += 1;
                            }
                        }
                    }
                    listBox1.Items.Insert(0, textBox1.Text + "  " + aa.ToString() + "A" + bb.ToString() + "B");
                    textBox1.Text = "";
                    if (aa == textBox1.MaxLength)
                    {
                        MessageBox.Show("答對了", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Close();
                    }
                }
            }
        }

    }
}
