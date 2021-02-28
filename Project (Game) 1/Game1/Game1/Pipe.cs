using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Pipe
    {
        float x, y, wSize;
        Image sprTop, sprBot;
        int spr_szx, spr_szy;
        bool pass;
        public float X { get => x; }
        public float Y { get => y; }
        public float WSize { get => wSize; }
        public Image SprTop { get => sprTop; }
        public Image SprBot { get => sprBot; }
        public int Spr_SZX { get => spr_szx; }
        public int Spr_SZY { get => spr_szy; }
        public bool isPassed { get => pass; set { pass = value; } }
        public Pipe(float x, float y)
        {
            sprTop = new Bitmap(@"images\pipe.png");
            sprBot = new Bitmap(@"images\pipe.png");
            sprTop.RotateFlip(RotateFlipType.Rotate180FlipX);
            this.x = x;
            this.y = y;
            spr_szx = 50;
            spr_szy = 300;
            wSize = 150;
            pass = false;
        }
        public void Move()
        {
            x -= 2;
        }
    }
}
