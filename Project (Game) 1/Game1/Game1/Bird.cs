using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Bird
    {
        float x, y;
        Image spr;
        int spr_sz; // размер спрайта (картинки)

        public float X { get => x; }
        public float Y { get => y; }
        public Image Spr { get => spr; }
        public int Spr_SZ { get => spr_sz; }
        public Bird(float x, float y)
        {
            spr = new Bitmap(@"Images\bird.png");
            this.x = x;
            this.y = y;
            spr_sz = 30;
        }
        public void Fall(float gr)
        {
            this.y += gr;
        }
    }
}
