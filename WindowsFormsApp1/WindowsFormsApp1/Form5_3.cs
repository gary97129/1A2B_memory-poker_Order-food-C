using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApp1
{
    public partial class Form5_3 : Form
    {
        public int h, v;
        int k,kk; 
        bool bo;
        public SoundPlayer player;
        List<Button> btns = new List<Button>();
        List<PictureBox> imgs = new List<PictureBox>();
        Graphics formGraphics;
        List<int> bntlist = new List<int>();
        Button Lbtn = new Button();
        Button Rbtn = new Button();
        Random rnd = new Random();

        public Form5_3()
        {
            InitializeComponent();
        }

        private void Form5_2_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < h * v; i++)
            {
                if(i< h * v / 2)
                {
                    bo=true;
                    while (bo)
                    {
                        k = rnd.Next(1, 11);
                        bo = bntlist.Contains(k);
                    }
                    bntlist.Add(k);
                }
                else
                {
                    bntlist.Add(bntlist[i - (h * v / 2)]);
                }
            }
            int n = bntlist.Count;
            while (n > 0)
            {
                n--;
                k = rnd.Next(0, n);
                int t = bntlist[k];
                bntlist[k] = bntlist[n];
                bntlist[n] = t;
            }

            //85,106
            int x = 0;
            int y = 0;
            int id = 0;
            for (int i = 1; i <= v; i++)
            {
                x += 600 / (v + 1);
                y = 0;
                for (int j = 1; j <= h; j++)
                {
                    y += 580 / (h + 1);
                    Button btn = new Button();
                    PictureBox img = new PictureBox();
                    btn.Name = id.ToString();
                    btn.BackColor = Color.Gray;
                    btn.Location = new Point(x - 42, y - 53);
                    img.Location = new Point(x - 42, y - 53);
                    btn.Click += new EventHandler(button_Click);
                    btn.Size = new Size(85, 106);
                    img.Size = new Size(85, 106);
                    img.Visible = false;
                    img.Image = (Image)Properties.Resources.ResourceManager.GetObject("s" + bntlist[id]);
                    Controls.Add(btn);
                    Controls.Add(img);
                    btns.Add(btn);
                    imgs.Add(img);
                    img.BringToFront();
                    id++;
                }
            }
            

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            imgs[Convert.ToInt32(btn.Name)].Visible = true;
            imgs[Convert.ToInt32(btn.Name)].Refresh();
            btn.Enabled = false;
            if (Lbtn.Name == "")
            {
                Lbtn = btn;
            }
            else
            {
                if (kk != 0) { formGraphics.Clear(Color.WhiteSmoke); }
                Rbtn = btn;
                if (bntlist[Convert.ToInt32(Lbtn.Name)] != bntlist[Convert.ToInt32(Rbtn.Name)])
                {
                    play("n");
                    play("f");
                    Thread.Sleep(1000);
                    imgs[Convert.ToInt32(Lbtn.Name)].Visible = false;
                    imgs[Convert.ToInt32(Rbtn.Name)].Visible = false;
                    Lbtn.Enabled = true;
                    Rbtn.Enabled = true;
                }
                else
                {
                    play("y");
                    Thread.Sleep(1000);
                }
                Lbtn = new Button();
                Rbtn = new Button();
            }
            int gg = 0;
            foreach(Button i in btns)
            {
                if(i.Enabled == true)
                {
                    gg = 1;
                }
            }
            if (gg == 0)
            {
                player.Stop();
                play("win");
                MessageBox.Show("WIN", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form5_1 f5_1 = new Form5_1();
            Hide();
            f5_1.player = player;
            f5_1.ShowDialog();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Button a1 = new Button();
            Button a2 = new Button();
            for(int i = 0; i < h * v; i++)
            {
                if (btns[i].Enabled == true)
                {
                    a1 = btns[bntlist.IndexOf(bntlist[i])];
                    a2 = btns[bntlist.LastIndexOf(bntlist[i])];
                    break;
                }
            }
            formGraphics = CreateGraphics();
            if (kk != 0) { formGraphics.Clear(Color.WhiteSmoke); } else { kk = 1; }
            formGraphics.DrawRectangle(new Pen(Color.Yellow,5),new Rectangle (a1.Location.X-3,a1.Location.Y-3,91,112));
            formGraphics.DrawRectangle(new Pen(Color.Yellow,5), new Rectangle(a2.Location.X-3, a2.Location.Y-3, 91, 112));
        }

        private void play(string a) 
        {
            var player1 = new WMPLib.WindowsMediaPlayer();
            player1.URL = a + ".wav";
        }
    }
}


