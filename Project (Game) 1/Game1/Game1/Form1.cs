using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
    public partial class Form1 : Form
    {
        int sc; // score
        Bird bird;
        Pipe p1, p2;
        float pShift, grVal; // pShift - смещение вверх
        bool gameOver;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.DrawImage(bird.Spr, bird.X, bird.Y, bird.Spr_SZ, bird.Spr_SZ);
            gr.DrawImage(p1.SprTop, p1.X, p1.Y, p1.Spr_SZX, p1.Spr_SZY);
            gr.DrawImage(p1.SprBot, p1.X, p1.Y + p1.Spr_SZY + p1.WSize, p1.Spr_SZX, p1.Spr_SZY);
            gr.DrawImage(p2.SprTop, p2.X, p2.Y, p2.Spr_SZX, p2.Spr_SZY);
            gr.DrawImage(p2.SprBot, p2.X, p2.Y + p2.Spr_SZY + p2.WSize, p2.Spr_SZX, p2.Spr_SZY);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Upd();
        }

        public Form1()
        {
            InitializeComponent();
            Init();
            Invalidate();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (!gameOver) grVal = -7f;
            else Init();
            if (!timer1.Enabled)
            {
                timer1.Start();
                timer1.Interval = 10;
                grVal = -7f;
            }
        }

        private void Init()
        {
            gameOver = false;
            grVal = 0.1f;
            pShift = 206;
            sc = 0;
            bird = new Bird(50, 206);
            p1 = new Pipe(300, -pShift);
            p2 = new Pipe(600, -pShift);
            timer1.Start();
            timer1.Interval = 10;
        }
        private void Upd()
        {
            if (!gameOver)
            {
                this.Text = $"Score: {sc}";
                grVal += 0.3f;
                bird.Fall(grVal);
                p1.Move();
                p2.Move();
                crPipe();
                chGameOver(p1);
                if (!gameOver) chGameOver(p2);
                updScore();
                Invalidate();
            }
            else
            {
                // MessageBox.Show("Вы проиграли", "офф вайт айр форс цвета капусты", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                timer1.Stop();
            }
        }
        private void crPipe()
        {
            if (bird.X - 300 > p1.X)
            {
                Random r = new Random();
                float y1 = -pShift + r.Next(-101, 101);
                p1 = new Pipe(bird.X + 300, y1);
            }
            if (bird.X - 300 > p2.X)
            {
                Random r = new Random();
                float y2 = -pShift + r.Next(-101, 101);
                p2 = new Pipe(bird.X + 300, y2);
            }
        }
        private void chGameOver(Pipe p)
        {
            if ((bird.X > p.X && bird.X < p.X + p.Spr_SZX) || (bird.X + bird.Spr_SZ > p.X && bird.X + bird.Spr_SZ < p.X + p.Spr_SZX))
                if ((bird.Y <= p.Y + p.Spr_SZY) || (bird.Y + bird.Spr_SZ >= p.Y + p.Spr_SZY + p.WSize)) gameOver = true;
            else gameOver = false;
        }
        private void updScore()
        {
            if (bird.X > p1.X + p1.Spr_SZX && !p1.isPassed)
            {
                sc++;
                p1.isPassed = true;
            }
            if (bird.X > p2.X + p2.Spr_SZX && !p2.isPassed)
            {
                sc++;
                p2.isPassed = true;
            }
        }
    }
}
