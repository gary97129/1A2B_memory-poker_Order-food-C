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
    public partial class Form4_1 : Form
    {        
        int total = 0;
        
        public Form4_1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int co = 1;
            if(textBox1.Text != "" & textBox1.Text != "1")
            {
                co = Convert.ToInt32(textBox1.Text);
            }
            for(int i = 1; i<= co; i++)
            {
                listBox1.Items.Insert(0, b.Text);
                total += Convert.ToInt32(b.Text.Substring(b.Text.Length - 2, 2));
            }
            textBox1.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                if(listBox1.SelectedIndex != -1)
                {
                    string b = listBox1.SelectedItem.ToString();
                    total -= Convert.ToInt32(b.Substring(b.Length - 2, 2));
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            textBox1.Text += b.Text; 
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >= 1)
            {
                List<string> it = new List<string>();
                for (int i = 0; i < listBox1.Items.Count; i++)
                {   
                    if (it.Contains(listBox1.Items[i]) == true)
                    {
                        int bb = Convert.ToInt32(it[it.IndexOf(listBox1.Items[i].ToString()) + 1]) + 1;
                        it[it.IndexOf(listBox1.Items[i].ToString())+1] = bb.ToString();
                    }
                    else
                    {
                        it.Add(listBox1.Items[i].ToString());
                        it.Add("1");
                    }
                }
                Form4_2 f4_2 = new Form4_2();
                f4_2.total = total;
                f4_2.it = it;
                f4_2.ShowDialog();
                listBox1.Items.Clear();
                total = 0;
            }
        }
    }
}
