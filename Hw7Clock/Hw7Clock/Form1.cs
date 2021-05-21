using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hw7Clock
{
    public partial class ClockWinForms : Form
    {
        private Timer timer = new();

        private int coordX;

        private int coordY;

        private Bitmap img;

        private Graphics graphics;

        public ClockWinForms()
            => InitializeComponent();

        public void Form1_Load(object sender, EventArgs e)
        {
            Width = 300;
            Height = 300;
            img = new Bitmap(Width + 1, Height + 1);
            coordX = Width / 2;
            coordY = Height / 2;
            this.BackColor = Color.Azure;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(this.timer1_Tick);
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics = Graphics.FromImage(img);
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;
            (int, int) coord;
            graphics.Clear(Color.Azure);
            graphics.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, 300, 300);
            graphics.DrawString("1", new Font("Elephant", 12), Brushes.Black, new PointF(210, 25));
            graphics.DrawString("2", new Font("Elephant", 12), Brushes.Black, new PointF(260, 70));
            graphics.DrawString("3", new Font("Elephant", 12), Brushes.Black, new PointF(280, 142));
            graphics.DrawString("4", new Font("Elephant", 12), Brushes.Black, new PointF(260, 200));
            graphics.DrawString("5", new Font("Elephant", 12), Brushes.Black, new PointF(210, 255));
            graphics.DrawString("6", new Font("Elephant", 12), Brushes.Black, new PointF(142, 276));
            graphics.DrawString("7", new Font("Elephant", 12), Brushes.Black, new PointF(70, 255));
            graphics.DrawString("8", new Font("Elephant", 12), Brushes.Black, new PointF(25, 200));
            graphics.DrawString("9", new Font("Elephant", 12), Brushes.Black, new PointF(0, 140));
            graphics.DrawString("10", new Font("Elephant", 12), Brushes.Black, new PointF(25, 70));
            graphics.DrawString("11", new Font("Elephant", 12), Brushes.Black, new PointF(70, 25));
            graphics.DrawString("12", new Font("Elephant", 12), Brushes.Black, new PointF(140, 2));
            coord = RotateMinSec(ss, 140);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(coordX, coordY), new Point(coord.Item1, coord.Item2));
            coord = RotateMinSec(mm, 110);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(coordX, coordY), new Point(coord.Item1, coord.Item2));
            coord = RotateHour(hh % 12, mm,80);
            graphics.DrawLine(new Pen(Color.Green, 3f), new Point(coordX, coordY), new Point(coord.Item1, coord.Item2));
            pictureBox1.Image = img;
            graphics.Dispose();
        }

        private (int, int) GetCoordinates(int value, int hLen)
        {
            (int, int) coordinates;
            if (value >= 0 && value <= 180)
            {
                coordinates.Item1 = coordX + (int)(hLen * Math.Sin(Math.PI * value / 180));
                coordinates.Item2 = coordY - (int)(hLen * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                coordinates.Item1 = coordX - (int)(hLen * -Math.Sin(Math.PI * value / 180));
                coordinates.Item2 = coordY - (int)(hLen * Math.Cos(Math.PI * value / 180));
            }
            return coordinates;
        }

        private (int, int) RotateMinSec(int value, int hLen)
        {
            value *= 6;
            return GetCoordinates(value, hLen);
        }

        private (int, int) RotateHour(int hValue, int mValue, int hLen)
        {
            int value = (int)((hValue * 30) + (mValue * 0.5));
            return GetCoordinates(value, hLen);
        }
    }
}