using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    class GR_Scene
    {
        private uint point_identificator;

        private List<GR_Point> points;
        private List<GR_Line> lines;
        private List<GR_Point> temp;

        public Pen selectPen { get; set; }

        public float Camera_VerticalAngle { get; set; }
        public float Camera_HorizontalAngle { get; set; }


        public GR_Scene()
        {
            points = new List<GR_Point>();
            lines = new List<GR_Line>();
            temp = new List<GR_Point>();

            selectPen = new Pen(Color.Red, 1.5f);
            selectPen.DashStyle = DashStyle.Dash;

            point_identificator = 1;
        }

        public void Draw(Graphics gr, float Xoffset = 0, float Yoffset = 0)
        {
            Pen pen = new Pen(Color.Black);
            temp.Clear();

            GR_Point centerPoint = GetPointsCenter();

            foreach (GR_Point p in points)
            {
                temp.Add((GR_Point)p.Clone());
            }
            double angleA = Camera_HorizontalAngle / 180 * Math.PI;
            double angleB = Camera_VerticalAngle / 180 * Math.PI;


            double[,] matrix = new double[,] {
                { 
                    Math.Cos(angleA),
                    0,
                    Math.Sin(angleA),
                    0
                },

                { 
                    Math.Sin(angleB)*Math.Sin(angleA),
                    Math.Cos(angleB),
                    -Math.Sin(angleB)*Math.Cos(angleA),
                    0
                },

                { 
                    -Math.Cos(angleB)*Math.Sin(angleA),
                    Math.Sin(angleB),
                    Math.Cos(angleA)*Math.Cos(angleB),
                    0
                },

                { 
                    Math.Cos(angleA) -  Math.Sin(angleA)*Math.Sin(angleB) - Math.Cos(angleB), 
                    Math.Cos(angleB) -  Math.Sin(angleB),
                    Math.Sin(angleA) +  Math.Cos(angleA)*Math.Sin(angleB) - Math.Cos(angleB),
                    1
                } 
            };
            
                

            

            foreach (GR_Point p in temp)
            {
                p.X = (float)(p.X * matrix[0, 0] + p.Y * matrix[1, 0] + p.Z * matrix[2, 0] + p.Ok * matrix[3, 0]);
                p.Y = (float)(p.X * matrix[0, 1] + p.Y * matrix[1, 1] + p.Z * matrix[2, 1] + p.Ok * matrix[3, 1]);
                p.Z = (float)(p.X * matrix[0, 2] + p.Y * matrix[1, 2] + p.Z * matrix[2, 2] + p.Ok * matrix[3, 2]);
                p.Ok = (float)(p.X * matrix[0, 3] + p.Y * matrix[1, 3] + p.Z * matrix[2, 3] + p.Ok * matrix[3, 3]);
            }
            foreach (GR_Line p in lines)
            {
                pen.Color = p.color;
                pen.Width = p.width;
                Point P1 = GetPointByUid(p.point1, temp).ToPoint();
                Point P2 = GetPointByUid(p.point2, temp).ToPoint();

                gr.DrawLine(pen, P1.X + Xoffset,P1.Y + Yoffset, P2.X + Xoffset, P2.Y + Yoffset);
            }

            foreach (GR_Point p in temp)
            {
                pen.Color = p.OutColor;
                pen.Width = p.LineWidth;
                gr.FillEllipse(new SolidBrush(p.FillColor), p.X - p.Radius / 2 + Xoffset, p.Y - p.Radius / 2 + Yoffset, p.Radius, p.Radius);
                gr.DrawEllipse(pen, p.X - p.Radius / 2 + Xoffset, p.Y - p.Radius / 2 + Yoffset, p.Radius, p.Radius);
                if (p.Selected) gr.DrawEllipse(selectPen, p.X - (p.Radius + p.LineWidth + 4) / 2 + Xoffset, p.Y - (p.Radius + p.LineWidth + 4) / 2 + Yoffset, p.Radius + p.LineWidth + 4, p.Radius + p.LineWidth + 4);

            }




            //foreach (GR_Point p in points)
            //{
            //    pen.Color = p.GetOutColor();
            //    pen.Width = p.GetWidth();
            //    gr.FillEllipse(new SolidBrush(p.GetFillColor()), p.GetX() - p.GetRadius() / 2, p.GetY() - p.GetRadius() / 2, p.GetRadius(), p.GetRadius());
            //    gr.DrawEllipse(pen, p.GetX() - p.GetRadius() / 2, p.GetY() - p.GetRadius() / 2, p.GetRadius(), p.GetRadius());
            //    if (p.Selected) gr.DrawEllipse(selectPen, p.GetX() - (p.GetRadius() + p.GetWidth()) / 2, p.GetY() - (p.GetRadius() + p.GetWidth()) / 2, p.GetRadius() + p.GetWidth(), p.GetRadius() + p.GetWidth());

            //}
            //if (temp.Count == 2)
            //{
            //    FontFamily fontFamily = new FontFamily("Arial");
            //    gr.DrawString((temp[0].X - temp[1].X).ToString() + "X + " + (temp[0].Y - temp[1].Y).ToString() + "Y + " + (temp[0].X * temp[1].Y + temp[1].X * temp[0].Y).ToString(), new Font(fontFamily, 7), new SolidBrush(Color.Black), (temp[0].X + temp[1].X)/2, (temp[0].Y + temp[1].Y)/2);
            //}
            pen.Dispose();

        }
       
        private GR_Point GetPointByUid(uint id)
        {
            foreach (GR_Point p in points)
            {
                if (p.Id == id) return p;
            }
            return null;
        }
        private GR_Point GetPointByUid(uint id, List<GR_Point> list)
        {
            foreach (GR_Point p in list)
            {
                if (p.Id == id) return p;
            }
            return null;
        }
        public void AddPoint(GR_Point point)
        {
            point.Id = point_identificator;
            point_identificator++;
            points.Add(point);
        }
        public void SelectPoints(int x1, int y1, int x2, int y2, bool reselect = true)
        {
            if (reselect) UnselectPoints();
            foreach (var s in points)
            {
                if (s.Y <= Math.Max(y1, y2) &&
                    s.Y >= Math.Min(y1, y2) &&
                    s.X <= Math.Max(x1, x2) &&
                    s.X >= Math.Min(x1, x2))
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
                if (Math.Pow((a.X - p.X), 2) + Math.Pow((a.Y - p.Y), 2) <= Math.Pow(p.Radius, 2))
                {
                    return p.Id;
                }
            }
            return 0;
        }
        public uint GetPointUid(float x, float y)
        {
            foreach (GR_Point p in points)
            {
                if (Math.Pow((x - p.X), 2) + Math.Pow((y - p.Y), 2) <= Math.Pow(p.Radius, 2))
                {
                    return p.Id;
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
        public void ConnectPoints(float x1,float y1, float x2, float y2)
        {
            uint point1_id = GetPointUid(x1,y1);
            uint point2_id = GetPointUid(x2,y2);
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
            if (selectedOnly)
                foreach (GR_Point l in SelectedPoints)
                {
                    DeleteLineByPoint(l.Id);
                    points.Remove(l);
                }
            else
            {
                points.Clear();
                lines.Clear();
            }
        }
        public GR_Point GetPointsCenter(bool selectedOnly = false)
        {
            if (selectedOnly && SelectedPoints.Count == 0) return new GR_Point(0, 0, 0);
            if (!selectedOnly && points.Count == 0) return new GR_Point(0, 0, 0);
            float x = 0;
            float y = 0;
            float z = 0;

            if (selectedOnly) 
            {
                
                foreach (GR_Point p in SelectedPoints)
                {
                    x += p.X;
                    y += p.Y;
                    z += p.Z;
                }

                x /= SelectedPoints.Count;
                y /= SelectedPoints.Count;
                z /= SelectedPoints.Count;
            }
            else
            {
                foreach (GR_Point p in points)
                {
                    x += p.X;
                    y += p.Y;
                    z += p.Z;
                }

                x /= points.Count;
                y /= points.Count;
                z /= points.Count;
            }

            return new GR_Point(x,y,z);
            
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
            if (selectedOnly)
                foreach (GR_Point p in SelectedPoints)
                {
                    p.X = (float)(p.X * matrix[0, 0] + p.Y * matrix[1, 0] + p.Z * matrix[2, 0] + p.Ok * matrix[3, 0]);
                    p.Y = (float)(p.X * matrix[0, 1] + p.Y * matrix[1, 1] + p.Z * matrix[2, 1] + p.Ok * matrix[3, 1]);
                    p.Z = (float)(p.X * matrix[0, 2] + p.Y * matrix[1, 2] + p.Z * matrix[2, 2] + p.Ok * matrix[3, 2]);
                    p.Ok = (float)(p.X * matrix[0, 3] + p.Y * matrix[1, 3] + p.Z * matrix[2, 3] + p.Ok * matrix[3, 3]);
                }
            else
                foreach (GR_Point p in points)
                {
                    p.X = (float)(p.X * matrix[0, 0] + p.Y * matrix[1, 0] + p.Z * matrix[2, 0] + p.Ok * matrix[3, 0]);
                    p.Y = (float)(p.X * matrix[0, 1] + p.Y * matrix[1, 1] + p.Z * matrix[2, 1] + p.Ok * matrix[3, 1]);
                    p.Z = (float)(p.X * matrix[0, 2] + p.Y * matrix[1, 2] + p.Z * matrix[2, 2] + p.Ok * matrix[3, 2]);
                    p.Ok = (float)(p.X * matrix[0, 3] + p.Y * matrix[1, 3] + p.Z * matrix[2, 3] + p.Ok * matrix[3, 3]);
                }


        }
        public void MovePoints(int x, int y, int z, bool selectedOnly = false)
        {
            if(selectedOnly)
                foreach (GR_Point p in SelectedPoints)
                {
                    p.X += x;
                    p.Y += y;
                    p.Z += z;
                }
            else
                foreach (GR_Point p in points)
                {
                    p.X += x;
                    p.Y += y;
                    p.Z += z;
                }
            
        }
    }
}
