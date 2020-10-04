using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    class GR_Line
    {
        public uint point1;
        public uint point2;

        public Color color;
        public int width;


        public GR_Line(uint point1, uint point2)
        {
            this.point1 = point1;
            this.point2 = point2;
            color = Color.Black;
            width = 1;
        }
        public GR_Line(uint point1, uint point2, int width, Color color)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.width = width;
            this.color = color;
        }
    }
}
