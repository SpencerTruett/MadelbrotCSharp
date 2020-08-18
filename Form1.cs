using MandelbrotCSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // Relevant Math
            // Where a is real and bi is imaginary
            // (a +bi)^2 represents your (a) real coordinate and (bi) your imaginary coordiante
            // (a + bi)^2 = a^2 + bi^2 + 2abi
            // (a^2 - b^2) + (2abi) where (a^2 + b^2) is purely real and (2abi) is purely imaginary

            // Starting a 0 (z) and the complez number (c) to z
            // f(z) = z^2 +c
            // The new value of z should be the old value of z squared plus c


            for (int x=0; x< pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    double a = (double)(x - (pictureBox1.Width / 2)) / (double)(pictureBox1.Width / 4);
                    double b = (double)(y - (pictureBox1.Height / 2)) / (double)(pictureBox1.Height / 4);

                    ComplexNumbers c = new ComplexNumbers(a, b);
                    ComplexNumbers z = new ComplexNumbers(0, 0);

                    // Initial iterarion
                    int it = 0;

                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0) break;
                    }
                    // Number of iterations
                    while (it<100);
                    bm.SetPixel(x, y, it < 100 ? Color.Red : Color.Blue);
                }
            }
            pictureBox1.Image = bm;
        }
    }
}
