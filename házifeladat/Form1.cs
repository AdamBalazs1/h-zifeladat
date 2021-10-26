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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
        public void rekFa(float n, int x, int y, float szog, int len, int branchNum )
        {
            if(n < 0)
            {
                return;
            }
            var rnd = new Random();
            int C = rnd.Next(-45, 45);

            
            PointF p1 = new PointF(x, y);
            PointF p2 = new PointF((int)(x + (len * Math.Cos(szog))), (int)(y + (len * Math.Sin(szog))));

            g.DrawLine(Pens.Red, p1, p2);

                for (int i = 0; i <= branchNum; i++)
                {
                    rekFa(n - 1, (int)p2.X, (int)p2.Y, szog + C, len - 5, branchNum);
                }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            rekFa(5, pictureBox1.Width / 2, pictureBox1.Height / 2, 60, 50, 3);
        }
    }
}
