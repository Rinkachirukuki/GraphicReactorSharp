using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    class GR_Scene
    {
        private uint point_identificator = 1;
        private List<GR_Point> points;
        private List<GR_Line> lines;
        public Pen selectPen = new Pen(Color.Red, 2);

        public GR_Scene()
        {
            points = new List<GR_Point>();
            lines = new List<GR_Line>();
        }
        public void Draw(Graphics gr)
        {
            Pen pen = new Pen(Color.Black);
            foreach (GR_Line p in lines)
            {
                pen.Color = p.color;
                pen.Width = p.width;
                gr.DrawLine(pen, GetPointByUid(p.point1).ToPoint(), GetPointByUid(p.point2).ToPoint());

            }
            foreach (GR_Point p in points)
            {
                pen.Color = p.GetOutColor();
                pen.Width = p.GetWidth();
                gr.FillEllipse(new SolidBrush(p.GetFillColor()), p.GetX() - p.GetRadius() / 2, p.GetY() - p.GetRadius() / 2, p.GetRadius(), p.GetRadius());
                gr.DrawEllipse(pen, p.GetX() - p.GetRadius() / 2, p.GetY() - p.GetRadius() / 2, p.GetRadius(), p.GetRadius());
                if (p.Selected) gr.DrawEllipse(selectPen, p.GetX() - (p.GetRadius() + p.GetWidth()) / 2, p.GetY() - (p.GetRadius() + p.GetWidth()) / 2, p.GetRadius() + p.GetWidth(), p.GetRadius() + p.GetWidth());

            }
            pen.Dispose();

        }
        private GR_Point GetPointByUid(uint id)
        {
            foreach (GR_Point p in points)
            {
                if (p.id == id) return p;
            }
            return null;
        }
        public void AddPoint(GR_Point point)
        {
            point.id = point_identificator;
            point_identificator++;
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
        public uint GetPointUid(Point a)
        {
            foreach (GR_Point p in points)
            {
                if (Math.Pow((a.X - p.GetX()), 2) + Math.Pow((a.Y - p.GetY()), 2) <= Math.Pow(p.GetRadius(), 2))
                {
                    return p.id;
                }
            }
            return 0;
        }

        public void ConnectPoints(Point a, Point b)
        {
            uint point1_id = GetPointUid(a);
            uint point2_id = GetPointUid(b);
            if (point1_id == point2_id || point1_id == 0 || point2_id == 0) return;
            else lines.Add(new GR_Line(point1_id, point2_id));

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
        public void MatrixOperation(float[,] matrix, bool selectedOnly = false)
        {
            if (matrix.Length != 16) return;
            foreach (GR_Point p in selectedOnly ? SelectedPoints : points)
            {
                p.x = p.x * matrix[0, 0] + p.y * matrix[1, 0] + p.z * matrix[2, 0] + p.ok * matrix[3, 0];
                p.y = p.x * matrix[0, 1] + p.y * matrix[1, 1] + p.z * matrix[2, 1] + p.ok * matrix[3, 1];
                p.z = p.x * matrix[0, 2] + p.y * matrix[1, 2] + p.z * matrix[2, 2] + p.ok * matrix[3, 2];
                p.z = p.x * matrix[0, 3] + p.y * matrix[1, 3] + p.z * matrix[2, 3] + p.ok * matrix[3, 3];
            }

        }
        public void MovePoints(int x, int y, int z, bool selectedOnly = false)
        {
            foreach (GR_Point p in selectedOnly ? SelectedPoints : points)
            {
                p.x += x;
                p.y += y;
                p.z += z;
            }

        }
    }
}
