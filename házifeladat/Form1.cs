using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace házifeladat
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        public double ToDeg(double x)
        {
            return x;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int x = pictureBox1.Width;
            int y = pictureBox1.Height;
            g = e.Graphics;
            rekFa(5,
                x / 2,
                y / 2,
                90,
                40,
                3);
        }
        public void rekFa(float n, float x, float y, double szog, int len, int branchNum)
        {
            if (n < 0)
            {
                return;
            }
            var rnd = new Random();

            double ph1 = Math.Round(Math.Cos(szog * Math.PI / 180), 6);
            double ph2 = Math.Round(Math.Sin(szog * Math.PI / 180), 6);

            PointF p1 = new PointF(x, y);
            PointF p2 = new PointF((float)(x + len * ph1), (float)(y - len * ph2));

            g.DrawLine(Pens.Red, p1, p2);

            for (int i = 0; i < branchNum; i++)
            {
                int C = rnd.Next(-45, 45);

                rekFa(n - 1, (int)p2.X, (int)p2.Y, szog + C, len - 5, branchNum);
            }
        }
    }
}