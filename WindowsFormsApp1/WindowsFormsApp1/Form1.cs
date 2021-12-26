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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        string z,ans = "";
        Random rnd = new Random();
        int s1, s2,sum;


        private void textBox2_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox2, z + "+");
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.BackColor = Color.Gray;
            toolTip1.AutoPopDelay = 32000;
            toolTip1.ToolTipTitle = "提示訊息";
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                textBox2_Click(sender, e);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "root");
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.BackColor = Color.Gray;
            toolTip1.AutoPopDelay = 32000;
            toolTip1.ToolTipTitle = "提示訊息";
            toolTip1.ReshowDelay = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            s1 = rnd.Next(8, 11);
            for(int i = 1;i<=s1;i++)
            {
                s2 = rnd.Next(0, 2);
                if(s2==0)
                {
                    s2 = rnd.Next(97, 123);
                    z += ((char)s2).ToString() + " ";
                    ans += ((char)s2).ToString();
                }
                else
                {
                    s2 = rnd.Next(0, 10);
                    z += s2.ToString() + " ";
                    sum += s2;
                }
            }
            ans += sum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult f;
            if (textBox1.Text.ToUpper() == "ROOT" & textBox2.Text.ToLower() == ans)
            {
                f = MessageBox.Show("登入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                f = MessageBox.Show("登入失敗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
    }
}
