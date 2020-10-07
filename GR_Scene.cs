using System;
using System.Collections.Generic;
using System.Data;
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
        private List<GR_Point> temp = new List<GR_Point>();
        public Pen selectPen = new Pen(Color.Red, 2);

        public GR_Scene()
        {
            points = new List<GR_Point>();
            lines = new List<GR_Line>();
        }
        public void Draw(Graphics gr, double ang = 0)
        {
            Pen pen = new Pen(Color.Black);
            //foreach (GR_Line p in lines)
            //{
            //    pen.Color = p.color;
            //    pen.Width = p.width;
            //    gr.DrawLine(pen, GetPointByUid(p.point1).ToPoint(), GetPointByUid(p.point2).ToPoint());

            //}


            temp.Clear();

            foreach (GR_Point p in points)
            {
                temp.Add((GR_Point)p.Clone());
            }
                double[,] matrix = new double[,] {
                { 1, 0, 0, 0 },
                { 0, Math.Cos(Math.PI * ang / 180), -Math.Sin(Math.PI * ang / 180), 0 },
                { 0, Math.Sin(Math.PI * ang / 180), Math.Cos(Math.PI * ang / 180), 0 },
                { 0, 0, 0, 1 } };

            

            foreach (GR_Point p in temp)
            {
                p.x = (float)(p.x * matrix[0, 0] + p.y * matrix[1, 0] + p.z * matrix[2, 0] + p.ok * matrix[3, 0]);
                p.y = (float)(p.x * matrix[0, 1] + p.y * matrix[1, 1] + p.z * matrix[2, 1] + p.ok * matrix[3, 1]);
                p.z = (float)(p.x * matrix[0, 2] + p.y * matrix[1, 2] + p.z * matrix[2, 2] + p.ok * matrix[3, 2]);
                p.z = (float)(p.x * matrix[0, 3] + p.y * matrix[1, 3] + p.z * matrix[2, 3] + p.ok * matrix[3, 3]);
            }
            foreach (GR_Line p in lines)
            {
                pen.Color = p.color;
                pen.Width = p.width;

                gr.DrawLine(pen, GetPointByUid(p.point1, temp).ToPoint(), GetPointByUid(p.point2, temp).ToPoint());

            }
            foreach (GR_Point p in temp)
            {
                pen.Color = p.GetOutColor();
                pen.Width = p.GetWidth();
                gr.FillEllipse(new SolidBrush(p.GetFillColor()), p.GetX() - p.GetRadius() / 2, p.GetY() - p.GetRadius() / 2, p.GetRadius(), p.GetRadius());
                gr.DrawEllipse(pen, p.GetX() - p.GetRadius() / 2, p.GetY() - p.GetRadius() / 2, p.GetRadius(), p.GetRadius());
                if (p.Selected) gr.DrawEllipse(selectPen, p.GetX() - (p.GetRadius() + p.GetWidth()) / 2, p.GetY() - (p.GetRadius() + p.GetWidth()) / 2, p.GetRadius() + p.GetWidth(), p.GetRadius() + p.GetWidth());

            }




            //foreach (GR_Point p in points)
            //{
            //    pen.Color = p.GetOutColor();
            //    pen.Width = p.GetWidth();
            //    gr.FillEllipse(new SolidBrush(p.GetFillColor()), p.GetX() - p.GetRadius() / 2, p.GetY() - p.GetRadius() / 2, p.GetRadius(), p.GetRadius());
            //    gr.DrawEllipse(pen, p.GetX() - p.GetRadius() / 2, p.GetY() - p.GetRadius() / 2, p.GetRadius(), p.GetRadius());
            //    if (p.Selected) gr.DrawEllipse(selectPen, p.GetX() - (p.GetRadius() + p.GetWidth()) / 2, p.GetY() - (p.GetRadius() + p.GetWidth()) / 2, p.GetRadius() + p.GetWidth(), p.GetRadius() + p.GetWidth());

            //}
            if (temp.Count == 2)
            {
                FontFamily fontFamily = new FontFamily("Arial");
                gr.DrawString((temp[0].x - temp[1].x).ToString() + "X + " + (temp[0].y - temp[1].y).ToString() + "Y + " + (temp[0].x * temp[1].y + temp[1].x * temp[0].y).ToString(), new Font(fontFamily, 7), new SolidBrush(Color.Black), (temp[0].x + temp[1].x)/2, (temp[0].y + temp[1].y)/2);
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
        private GR_Point GetPointByUid(uint id, List<GR_Point> list)
        {
            foreach (GR_Point p in list)
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
            if (LineCorrectAndDoesntExists(point1_id, point2_id))
                lines.Add(new GR_Line(point1_id, point2_id));
        }
        private bool LineCorrectAndDoesntExists(uint p1,uint p2)
        {
            if (p1 == p2 || p1 == 0 || p2 == 0) return false;
            foreach(GR_Line l in lines)
                if ((l.point1 == p1 && l.point2 == p2) || (l.point2 == p1 && l.point1 == p2)) return false;
            return true;
        }
        private bool DeleteLineByPoint(uint p)
        {
            for (int i =0; i < lines.Count; i++)
            {
                if (lines[i].point1 == p || lines[i].point2 == p)
                {
                    lines.RemoveAt(i);
                    i--;
                }
            }
                
                    
            return false;
        }
        public void DeletePoints (bool selectedOnly = false)
        {
            foreach (GR_Point l in SelectedPoints)
            {
                DeleteLineByPoint(l.id);
                points.Remove(l);
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
        public void MatrixOperation(double[,] matrix, bool selectedOnly = false)
        {
            if (matrix.Length != 16) return;
            foreach (GR_Point p in selectedOnly ? SelectedPoints : points)
            {
                p.x = (float)(p.x * matrix[0, 0] + p.y * matrix[1, 0] + p.z * matrix[2, 0] + p.ok * matrix[3, 0]);
                p.y = (float)(p.x * matrix[0, 1] + p.y * matrix[1, 1] + p.z * matrix[2, 1] + p.ok * matrix[3, 1]);
                p.z = (float)(p.x * matrix[0, 2] + p.y * matrix[1, 2] + p.z * matrix[2, 2] + p.ok * matrix[3, 2]);
                p.z = (float)(p.x * matrix[0, 3] + p.y * matrix[1, 3] + p.z * matrix[2, 3] + p.ok * matrix[3, 3]);
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
