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
    public partial class Form3_1 : Form
    {
        public string ra = "";
        public Form3_1()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3_2 f3_2 = new Form3_2();
            if (radioButton1.Checked)
            {
                ra = "簡單";
            }
            if (radioButton2.Checked)
            {
                ra = "一般";
            }
            if (radioButton3.Checked)
            {
                ra = "困難";
            }
            Hide();
            f3_2.ra = ra;
            f3_2.ShowDialog();
            Close();
        }
    }
}
