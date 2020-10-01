using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    class GR_Scene
    {
        private List<GR_Point> points;

        public GR_Scene()
        {
            points = new List<GR_Point>();
        }
        public void Draw(Graphics gr)
        {
            Pen pen = new Pen(Color.Black);
            foreach (GR_Point p in points)
            {
                pen.Color = p.GetOutColor();
                pen.Width = p.GetWidth();
                gr.FillEllipse(new SolidBrush(p.GetFillColor()), p.GetX(), p.GetY(), p.GetRadius(), p.GetRadius());
                gr.DrawEllipse(pen, p.GetX(), p.GetY(), p.GetRadius(), p.GetRadius());

            }

        }
        public void AddPoint(GR_Point point)
        {
            points.Add(point);
        }

    }
}
