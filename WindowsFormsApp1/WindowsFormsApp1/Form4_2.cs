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
    public partial class Form4_2 : Form
    {
        public int total = 0;
        public List<string> it = new List<string>();
        public Form4_2()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < it.Count; i+=2)
            {
                string b1 = it[i].Substring(0, it[i].Length - 4);
                while (b1.Length < 5)
                {
                    b1 += "　";
                }
                int b2 = Convert.ToInt32(it[i+1]);
                int b3 = Convert.ToInt32(it[i].Substring(it[i].Length - 2, 2))*b2;
                listBox1.Items.Add($"{b1} *{b2} ${b3}");
            }
            label1.Text = $"總共{total}元";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!= "" && total <= Convert.ToInt32(textBox1.Text))
            {
                label3.Text = "";
                label4.Visible = false;
                total = Convert.ToInt32(textBox1.Text) - total;
                int[] vs = new int[] {0,0,0,0,0,0,0};
                int[] m = new int[] {1000,500,100,50,10,5,1};
                for(int i = 0; i < 7; i++)
                {
                    if(total >= m[i])
                    {
                        vs[i] += total / m[i];
                        total -= m[i]*vs[i];
                        label3.Text += $"{m[i]}*{vs[i]}\n";
                    }
                }
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                label3.Text = "";
                label4.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
