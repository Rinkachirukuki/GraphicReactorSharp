using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    [Serializable]
    class GR_Line
    {
        public uint point1 { get; set; }
        public uint point2 { get; set; }

        public Color color { get; set; }
        public int width { get; set; }


        public GR_Line(uint point1, uint point2)
        {
            this.point1 = point1;
            this.point2 = point2;
            color = Color.Black;
            width = 2;
        }

        public GR_Line(uint point1, uint point2, int width)
        {
            this.point1 = point1;
            this.point2 = point2;
            color = Color.Black;
            this.width = width;
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
