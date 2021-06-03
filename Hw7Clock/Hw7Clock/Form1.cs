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
    /// <summary>
    /// часы
    /// </summary>
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

        private void DrawNumber(string font, (int x, int y)[] coordinates)
        {
            for (int i = 1; i < 13; ++i)
            {
                graphics.DrawString(i.ToString(), new Font(font, 12), Brushes.Black, new PointF(coordinates[i - 1].x, coordinates[i - 1].y));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics = Graphics.FromImage(img);
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;
            (int x, int y) coord;
            graphics.Clear(Color.Azure);
            graphics.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, 300, 300);
            var coordinatesNumbers = new (int x, int y)[]
            {
                (210, 25),
                (260, 70),
                (280, 142),
                (260, 200),
                (210, 255),
                (142, 276),
                (70, 255),
                (25, 200),
                (0, 140),
                (25, 70),
                (70, 25),
                (142, 2)
            };
            DrawNumber("Elephant", coordinatesNumbers);
            coord = RotateMinSec(ss, 140);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(coordX, coordY), new Point(coord.x, coord.y));
            coord = RotateMinSec(mm, 110);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(coordX, coordY), new Point(coord.x, coord.y));
            coord = RotateHour(hh % 12, mm,80);
            graphics.DrawLine(new Pen(Color.Green, 3f), new Point(coordX, coordY), new Point(coord.x, coord.y));
            pictureBox1.Image = img;
            graphics.Dispose();
        }

        private (int, int) GetCoordinates(int value, int hLen)
        {
            (int x, int y) coordinates;
            if (value >= 0 && value <= 180)
            {
                coordinates.x= coordX + (int)(hLen * Math.Sin(Math.PI * value / 180));
                coordinates.y = coordY - (int)(hLen * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                coordinates.x = coordX - (int)(hLen * -Math.Sin(Math.PI * value / 180));
                coordinates.y = coordY - (int)(hLen * Math.Cos(Math.PI * value / 180));
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