using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    [Serializable]
    class GR_Point_Simple : GR_Point_Base
    {
        private float radius;
        override public float Radius
        {
            get { return radius; }
            set { radius = value > 0 ? value : 1; }
        }
        public GR_Point_Simple()
        {
            Id = 0;
            X = 0;
            Y = 0;
            Z = 0;
            Ok = 0;
            Radius = 1;
            FillColor = Color.Black;
        }
        public GR_Point_Simple(float x,float y, float z,float ok,float radius, Color color)
        {
            Id = 0;
            X = x;
            Y = y;
            Z = z;
            Ok = ok;
            Radius = radius;
            FillColor = color;
        }

        override public object Clone()
        {
            throw new NotImplementedException();
        }

        override public int CompareTo(GR_Point_Base other)
        {
            return -Z.CompareTo(other.Z);
        }

        override public void Draw(Graphics gr, Pen selectPen) {
            gr.FillEllipse(new SolidBrush(FillColor), X - Radius / 2, Y - Radius / 2, Radius, Radius);
        }
    }
}
