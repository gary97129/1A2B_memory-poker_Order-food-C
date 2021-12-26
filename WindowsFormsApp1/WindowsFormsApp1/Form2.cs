using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3_1 f3_1 = new Form3_1();
            Hide();
            f3_1.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4_1 f4_1 = new Form4_1();
            Hide();
            f4_1.ShowDialog();
            Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.The_Right_Time);
            Form5_1 f5_1 = new Form5_1();
            Hide();
            player.PlayLooping();
            f5_1.player = player;
            f5_1.ShowDialog();
            player.Stop();
            Show();
        }
    }
}
