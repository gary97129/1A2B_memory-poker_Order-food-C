using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1
{
    public partial class Form5_2 : Form
    {
        public int v;
        public SoundPlayer player;
        public Form5_2()
        {
            InitializeComponent();
        }

        private void Form5_2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                if((v*i)%2 == 0)
                {
                    comboBox1.Items.Add(i);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("請輸入列數", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form5_3 f5_3 = new Form5_3();
                f5_3.v = v;
                f5_3.h = Convert.ToInt32(comboBox1.Text);
                f5_3.player = player;
                Hide();
                f5_3.ShowDialog();
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5_1 f5_1 = new Form5_1();
            Hide();
            f5_1.player = player;
            f5_1.ShowDialog();
            Close();
        }
    }
}
