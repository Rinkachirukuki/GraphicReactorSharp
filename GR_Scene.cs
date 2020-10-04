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
        public Pen selectPen = new Pen(Color.Red, 2);

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
                gr.FillEllipse(new SolidBrush(p.GetFillColor()), p.GetX() - p.GetRadius()/2, p.GetY() - p.GetRadius()/2, p.GetRadius(), p.GetRadius());
                gr.DrawEllipse(pen, p.GetX() - p.GetRadius()/2, p.GetY() - p.GetRadius()/2, p.GetRadius(), p.GetRadius());
                if (p.Selected) gr.DrawEllipse(selectPen, p.GetX() - (p.GetRadius() + p.GetWidth())/2, p.GetY() - (p.GetRadius() + p.GetWidth()) /2, p.GetRadius() + p.GetWidth(), p.GetRadius() + p.GetWidth());

            }
            pen.Dispose();

        }
        public void AddPoint(GR_Point point)
        {
            points.Add(point);
        }
        public void SelectPoints(int x1, int y1, int x2, int y2, bool reselect = true)
        {
            if (reselect) UnselectPoints();
            foreach (var s in points)
            {
                if (s.GetY() <= Math.Max(y1, y2) &&
                    s.GetY() >= Math.Min(y1, y2) &&
                    s.GetX() <= Math.Max(x1, x2) &&
                    s.GetX() >= Math.Min(x1, x2))
                {
                    s.Select();
                }

            }
        }
        public void UnselectPoints()
        {
           foreach (var s in points)
            {
                s.UnSelect();
            }
        }
                
        public List<GR_Point> SelectedPoints
        {
            get
            {
                var s_points = from s in points
                             where s.Selected
                             select s;
                return s_points.ToList();
            }
        }
    }
}
