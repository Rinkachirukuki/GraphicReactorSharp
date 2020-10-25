using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    class GR_Point_Base
    {
        virtual public float X { get; set; }
        virtual public float Y { get; set; }
        virtual public float Z { get; set; }

        virtual public float Ok { get; set; }

        virtual public float Radius { get; set; }

        virtual public Color FillColor { get; set; }
        virtual public void Draw(Graphics gr, Pen selectPen) { }
    }
}
