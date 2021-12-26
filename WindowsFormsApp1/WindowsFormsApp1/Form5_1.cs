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
    public partial class Form5_1 : System.Windows.Forms.Form
    {
        public SoundPlayer player;
        public Form5_1()
        {
            InitializeComponent();
        }

        private void Form5_1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 5; i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("請輸入行數", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form5_2 f5_2 = new Form5_2();
                f5_2.v = Convert.ToInt32(comboBox1.Text);
                f5_2.player = player;
                Hide();
                f5_2.ShowDialog();
                Close();
            }
        }

    }
}
