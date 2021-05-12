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
    public partial class Form1 : Form
    {
        Bitmap back, hour, minute, second;

        public Form1()
        {
            InitializeComponent();
            back = new Bitmap("..\\background.png");
            hour = new Bitmap("..\\hour.png");
            minute = new Bitmap("..\\minute.png");
            second = new Bitmap("..\\second.png");
        }

        private Bitmap Rotate(Bitmap rotater, float angle)
        {

        }
    }
}
