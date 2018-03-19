using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private Random random = new Random();
        private int contador = 0;
        private List<List<Mino>> Peca = new List<List<Mino>>(); 
        private List<Mino> CurrentPeca = new List<Mino>(); 

        public Form1()
        {
            InitializeComponent();
            Width = 1200;
            Height = 700;
            CenterToScreen();
            DoubleBuffered = true;
        }

        private void InitTimer()
        {
            timer.Interval += 10;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            contador++;
            if (tocou(CurrentPeca) || CurrentPeca.Count == 0 || MinoxMino(CurrentPeca))
            {
                int rand = random.Next(0, 8);
                List<Mino> conjuntoQuadrados = new List<Mino>();
                switch (rand)
                {
                    case 1:
                        for (int i = 0; i < 4; i++)
                        {
                            conjuntoQuadrados.Add(new Mino(500, 25 + 25 * i, 25, 25, 1, 1, i, new SolidBrush(Color.Blue)));
                        }
                        break;
                    case 2:
                        conjuntoQuadrados.Add(new Mino(500, 25, 25, 25, 1, 1, 0, new SolidBrush(Color.Red)));
                        conjuntoQuadrados.Add(new Mino(500, 50, 25, 25, 1, 1, 1, new SolidBrush(Color.Red)));
                        conjuntoQuadrados.Add(new Mino(500 + 25, 25, 25, 25, 1, 1, 2, new SolidBrush(Color.Red)));
                        conjuntoQuadrados.Add(new Mino(500 + 25, 50, 25, 25, 1, 1, 3, new SolidBrush(Color.Red)));
                        break;
                    case 3:
                        conjuntoQuadrados.Add(new Mino(500 + 25, 25, 25, 25, 1, 1, 0, new SolidBrush(Color.Green)));
                        conjuntoQuadrados.Add(new Mino(500, 50, 25, 25, 1, 1, 1, new SolidBrush(Color.Green)));
                        conjuntoQuadrados.Add(new Mino(500 + 50, 25, 25, 25, 1, 1, 2, new SolidBrush(Color.Green)));
                        conjuntoQuadrados.Add(new Mino(500 + 25, 50, 25, 25, 1, 1, 3, new SolidBrush(Color.Green)));
                        break;
                    case 4:
                        conjuntoQuadrados.Add(new Mino(500 - 25, 25, 25, 25, 1, 1, 0, new SolidBrush(Color.Purple)));
                        conjuntoQuadrados.Add(new Mino(500, 50, 25, 25, 1, 1, 1, new SolidBrush(Color.Purple)));
                        conjuntoQuadrados.Add(new Mino(500, 25, 25, 25, 1, 1, 2, new SolidBrush(Color.Purple)));
                        conjuntoQuadrados.Add(new Mino(500 + 25, 50, 25, 25, 1, 1, 3, new SolidBrush(Color.Purple)));
                        break;
                    case 5:
                        conjuntoQuadrados.Add(new Mino(500, 25, 25, 25, 1, 1, 0, new SolidBrush(Color.Yellow)));
                        conjuntoQuadrados.Add(new Mino(500, 50, 25, 25, 1, 1, 1, new SolidBrush(Color.Yellow)));
                        conjuntoQuadrados.Add(new Mino(500 - 25, 50, 25, 25, 1, 1, 2, new SolidBrush(Color.Yellow)));
                        conjuntoQuadrados.Add(new Mino(500 + 25, 50, 25, 25, 1, 1, 3, new SolidBrush(Color.Yellow)));
                        break;
                    case 6:
                        conjuntoQuadrados.Add(new Mino(500, 25, 25, 25, 1, 1, 0, new SolidBrush(Color.HotPink)));
                        conjuntoQuadrados.Add(new Mino(500, 50, 25, 25, 1, 1, 1, new SolidBrush(Color.HotPink)));
                        conjuntoQuadrados.Add(new Mino(500 + 25, 25, 25, 25, 1, 1, 2, new SolidBrush(Color.HotPink)));
                        conjuntoQuadrados.Add(new Mino(500 + 50, 25, 25, 25, 1, 1, 3, new SolidBrush(Color.HotPink)));
                        break;
                    case 7:
                        conjuntoQuadrados.Add(new Mino(500, 25, 25, 25, 1, 1, 0, new SolidBrush(Color.Coral)));
                        conjuntoQuadrados.Add(new Mino(500, 50, 25, 25, 1, 1, 1, new SolidBrush(Color.Coral)));
                        conjuntoQuadrados.Add(new Mino(500 - 25, 25, 25, 25, 1, 1, 2, new SolidBrush(Color.Coral)));
                        conjuntoQuadrados.Add(new Mino(500 - 50, 25, 25, 25, 1, 1, 3, new SolidBrush(Color.Coral)));
                        break;
                }
                CurrentPeca = conjuntoQuadrados;
            }
            if (!tocou(CurrentPeca))
            {
                foreach (var p in CurrentPeca)
                {
                    p.y+=25;
                }    
            }
            Invalidate();
        }

        private bool tocou(List<Mino> peca)
        {
            foreach (var p in peca)
            {
                if (p.y > 500)
                {
                    Peca.Add(peca);
                    return true;
                }
            }
            return false;
        }

        private bool MinoxMino(List<Mino> peca)
        {
            if (Peca.Count == 0)
            {
                return false;
            }
            foreach (var p in Peca)
            {
                foreach (var z in p)
                {
                    foreach (var m in peca)
                    {
                        if (m.y >= z.y-25 && m.x == z.x)
                        {
                            Peca.Add(peca);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool bordaRight(List<Mino> peca)
        {
            foreach (var p in peca)
            {
                if (p.x > 675)
                {
                    return true;
                }
            }
            return false;
        }

        private bool bordaLeft(List<Mino> peca)
        {
            foreach (var p in peca)
            {
                if ( p.x < 425)
                {
                    return true;
                }
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitTimer();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) return;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    foreach (var p in CurrentPeca)
                    {
                        if (!bordaLeft(CurrentPeca))
                        {
                            p.x -= 25;
                        }
                    }
                    break;
                case Keys.Right:
                    foreach (var p in CurrentPeca)
                    {
                        if (!bordaRight(CurrentPeca))
                        {
                            p.x += 25;    
                        }
                    }
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    foreach (var p in CurrentPeca)
                    {
                        p.y+=25;
                    }
                    break;
                case Keys.Shift:
                    break;
                case Keys.Space:
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(400, 50, 300, 500));
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(800, 50, 200, 200));
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(800, 350, 200, 200));
            foreach (var p in CurrentPeca)
            {
                e.Graphics.FillRectangle(p.pen, new Rectangle(p.x, p.y, p.Width, p.Height));
            }
            foreach (var p in Peca)
            {
                foreach (var z in p)
                {
                    e.Graphics.FillRectangle(z.pen, new Rectangle(z.x,z.y,z.Width,z.Height));
                }
            }
        }
    }
}
