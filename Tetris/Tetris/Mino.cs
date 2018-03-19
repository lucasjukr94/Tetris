using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class Mino : Control
    {
        public Mino(int x,int y,int width, int height, int Rotation, int tipo, int index, SolidBrush pen)
        {
            this.x = x;
            this.y = y;
            Width = width;
            Height = height;
            this.Rotation = Rotation;
            this.tipo = tipo;
            this.index = index;
            this.pen = pen;
        }
        public int x { get; set; }
        public int y { get; set; }
        public int Rotation { get; set; }
        public int tipo { get; set; }
        public int index { get; set; }
        public SolidBrush pen { get; set; }
    }
}
