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

        public List<GR_Point_Base> points;
        private List<GR_Line> lines;
        private List<GR_Point_Base> temp;

        public Pen selectPen { get; set; }

        public float Camera_VerticalAngle { get; set; }
        public float Camera_HorizontalAngle { get; set; }
        public float Camera_VerticalOffset { get; set; }
        public float Camera_HorizontalOffset { get; set; }

        public float VerticalOffset { get; set; }
        public float HorizontalOffset { get; set; }

        public float Temp_Xtransform { get; set; }
        public float Temp_Ytransform { get; set; }
        public float Temp_Ztransform { get; set; }


        public GR_Scene()
        {
            points = new List<GR_Point_Base>();
            lines = new List<GR_Line>();
            temp = new List<GR_Point_Base>();

            

            selectPen = new Pen(Color.Red, 1.5f);
            selectPen.DashStyle = DashStyle.Dot;

            point_identificator = 1;

            HorizontalOffset = 0;
            VerticalOffset = 0;

            Camera_HorizontalAngle = 0;
            Camera_VerticalAngle = 0;
            Camera_HorizontalOffset = 0;
            Camera_VerticalOffset = 0;

            Temp_Xtransform = 0;
            Temp_Ytransform = 0;
            Temp_Ztransform = 0;
        }

        public void Draw(Graphics gr, bool compLines = false)
        {

            Pen pen = new Pen(Color.Black);

            double[,] matrix = CalculateRotationMatrix();
            double[,] temp_matrix = CalculateTempRotationMatrix();

            DrawXYZ(gr,matrix);

            UpdateTemp();

            foreach (GR_Point p in temp)
            {
                if (p.Selected)
                {
                    GR_Point p1 = (GR_Point)p.Clone();
                    p.X = (float)(p1.X * temp_matrix[0, 0] + p1.Y * temp_matrix[1, 0] + p1.Z * temp_matrix[2, 0] + p1.Ok * temp_matrix[3, 0]);
                    p.Y = (float)(p1.X * temp_matrix[0, 1] + p1.Y * temp_matrix[1, 1] + p1.Z * temp_matrix[2, 1] + p1.Ok * temp_matrix[3, 1]);
                    p.Z = (float)(p1.X * temp_matrix[0, 2] + p1.Y * temp_matrix[1, 2] + p1.Z * temp_matrix[2, 2] + p1.Ok * temp_matrix[3, 2]);
                    p.Ok = (float)(p1.X * temp_matrix[0, 3] + p1.Y * temp_matrix[1, 3] + p1.Z * temp_matrix[2, 3] + p1.Ok * temp_matrix[3, 3]);
                }
            }
            foreach (GR_Point p in temp)
            {
                GR_Point p1 = (GR_Point)p.Clone();
                p.X = (float)(p1.X * matrix[0, 0] + p1.Y * matrix[1, 0] + p1.Z * matrix[2, 0] + p1.Ok * matrix[3, 0]);
                p.Y = (float)(p1.X * matrix[0, 1] + p1.Y * matrix[1, 1] + p1.Z * matrix[2, 1] + p1.Ok * matrix[3, 1]);
                p.Z = (float)(p1.X * matrix[0, 2] + p1.Y * matrix[1, 2] + p1.Z * matrix[2, 2] + p1.Ok * matrix[3, 2]);
                p.Ok = (float)(p1.X * matrix[0, 3] + p1.Y * matrix[1, 3] + p1.Z * matrix[2, 3] + p1.Ok * matrix[3, 3]);

            }

           

            if (compLines)
            {
                foreach (GR_Line p in lines)
                {
                    temp.AddRange(ToSimplePointList(p, 50));
                }
            }
            else
            {
                foreach (GR_Line line in lines)
                {
                    gr.DrawLine(new Pen(line.color,line.width), GetPointByUid(line.point1).ToPoint(), GetPointByUid(line.point2).ToPoint());
                }
            }
            

            temp.Sort();

            foreach (GR_Point_Base p in temp)
            {
                p.Draw(gr,selectPen);
            }

            DrawXYZarrows(gr, CalculateXYZarrows(matrix));
           
            pen.Dispose();

        }
        public List<GR_Point_Base> ToSimplePointList(GR_Line line,int n)
        {
            List <GR_Point_Base> lst  = new List<GR_Point_Base>();
            GR_Point_Base p1 = GetPointByUid(line.point1, temp);
            GR_Point_Base p2 = GetPointByUid(line.point2, temp);
            float adX = (p2.X - p1.X) / n;
            float adY = (p2.Y - p1.Y) / n;
            float adZ = (p2.Z - p1.Z) / n;
            for (int i = 0; i < n;i++)
            {
                lst.Add(new GR_Point_Simple(p1.X + adX * i, p1.Y + adY * i, p1.Z + adZ * i, 1 ,line.width,line.color));
            }
            return lst;

        }
        private float[,] CalculateXYZarrows(double[,] matrix)
        {
            if (SelectedPoints.Count == 0) return new float[0,0];
            GR_Point centerPoint = GetPointsCenter(true);

            float cX = centerPoint.X;
            float cY = centerPoint.Y;
            float cZ = centerPoint.Z;

            float[,] arw = new float[,] {
            {cX,cY,cZ,1},
            {cX + 30,cY,cZ,1},
            {cX,cY + 30,cZ,1},
            {cX,cY,cZ + 30,1}
            };
            float[,] arw1 = new float[4,4];

            for (int i = 0; i < arw.GetLength(0); i++)
            {
                arw1[i, 0] = (float)(arw[i, 0] * matrix[0, 0] + arw[i, 1] * matrix[1, 0] + arw[i, 2] * matrix[2, 0] + arw[i, 3] * matrix[3, 0]);
                arw1[i, 1] = (float)(arw[i, 0] * matrix[0, 1] + arw[i, 1] * matrix[1, 1] + arw[i, 2] * matrix[2, 1] + arw[i, 3] * matrix[3, 1]);
                arw1[i, 2] = (float)(arw[i, 0] * matrix[0, 2] + arw[i, 1] * matrix[1, 2] + arw[i, 2] * matrix[2, 2] + arw[i, 3] * matrix[3, 2]);
                arw1[i, 3] = (float)(arw[i, 0] * matrix[0, 3] + arw[i, 1] * matrix[1, 3] + arw[i, 2] * matrix[2, 3] + arw[i, 3] * matrix[3, 3]);
            }
            return arw1;
            
        }
        public void DrawXYZarrows(Graphics gr,float[,] arw)
        {
            if (arw.GetLength(0) == 0) return;
            gr.DrawLine(new Pen(Color.Red, 3), arw[0, 0], arw[0, 1], arw[1, 0], arw[1, 1]);
            gr.DrawLine(new Pen(Color.Green, 3), arw[0, 0], arw[0, 1], arw[2, 0], arw[2, 1]);
            gr.DrawLine(new Pen(Color.Blue, 3), arw[0, 0], arw[0, 1], arw[3, 0], arw[3, 1]);
        }

        public bool HitXarrow(float x, float y)
        {
            double[,] matrix = CalculateRotationMatrix();
            float[,] arr = CalculateXYZarrows(matrix);
            if (arr.GetLength(0) == 0) return false;
            return isIntersect(arr[0,0], arr[0, 1], arr[1, 0], arr[1, 1], x,  y,  2);
        }
        public bool HitYarrow(float x, float y)
        {
            double[,] matrix = CalculateRotationMatrix();
            float[,] arr = CalculateXYZarrows(matrix);
            if (arr.GetLength(0) == 0) return false;
            return isIntersect(arr[0, 0], arr[0, 1], arr[2, 0], arr[2, 1], x, y, 2);
        }
        public bool HitZarrow(float x, float y)
        {
            double[,] matrix = CalculateRotationMatrix();
            float[,] arr = CalculateXYZarrows(matrix);
            if (arr.GetLength(0) == 0) return false;
            return isIntersect(arr[0, 0], arr[0, 1], arr[3, 0], arr[3, 1], x, y, 2);
        }

        public bool isIntersect(float x1line, float y1line, float x2line, float y2line, float x, float y, float R)
        {
            x1line = x1line - x;
            x2line = x2line - x;
            y1line = y1line - y;
            y2line = y2line - y;
            float l1 = (float)Math.Sqrt(x1line * x1line + y1line * y1line);
            float l2 = (float)Math.Sqrt(x2line * x2line + y2line * y2line);
            if ((l1 <= R && l2 >= R) || (l1 >= R && l2 <= R))
            {
                return true;
            }
            else if (l1 < R && l2 < R) { return false; }
            else
            {
                float p1 = x1line * (x2line - x1line) + y1line * (y2line - y1line);
                float p2 = x2line * (x2line - x1line) + y2line * (y2line - y1line);
                if (((p1 >= 0 && p2 <= 0) || (p1 <= 0) && (p2 >= 0)) && Math.Abs(x2line * y1line - x1line * y2line) / Math.Sqrt(Math.Pow(y2line - y1line, 2) + Math.Pow(x2line - x1line, 2)) <= R)
                { return true; }
                else { return false; }
            }
        }
        private void DrawXYZ(Graphics gr, double[,] matrix)
        {

            float[,] arw = new float[,] {
            {HorizontalOffset*2, 0, 0, 1},
            {-HorizontalOffset*2, 0, 0, 1},

            {0, VerticalOffset*2, 0, 1},
            {0, -VerticalOffset*2, 0, 1},

            {0, 0,  VerticalOffset*2, 1},
            {0, 0, - VerticalOffset*2, 1}
            };


            
            float[,] arw1 = new float[6, 4];


            for (int i = 0; i < arw.GetLength(0); i++)
            {
                arw1[i, 0] = (float)(arw[i, 0] * matrix[0, 0] + arw[i, 1] * matrix[1, 0] + arw[i, 2] * matrix[2, 0] + arw[i, 3] * matrix[3, 0]);
                arw1[i, 1] = (float)(arw[i, 0] * matrix[0, 1] + arw[i, 1] * matrix[1, 1] + arw[i, 2] * matrix[2, 1] + arw[i, 3] * matrix[3, 1]);
                arw1[i, 2] = (float)(arw[i, 0] * matrix[0, 2] + arw[i, 1] * matrix[1, 2] + arw[i, 2] * matrix[2, 2] + arw[i, 3] * matrix[3, 2]);
                arw1[i, 3] = (float)(arw[i, 0] * matrix[0, 3] + arw[i, 1] * matrix[1, 3] + arw[i, 2] * matrix[2, 3] + arw[i, 3] * matrix[3, 3]);
            }
            gr.DrawLine(new Pen(Color.FromArgb(50,Color.Red), 2), arw1[0, 0], arw1[0, 1], arw1[1, 0], arw1[1, 1]);
            gr.DrawLine(new Pen(Color.FromArgb(50, Color.Green), 2), arw1[2, 0], arw1[2, 1], arw1[3, 0], arw1[3, 1]);
            gr.DrawLine(new Pen(Color.FromArgb(50, Color.Blue), 2), arw1[4, 0], arw1[4, 1], arw1[5, 0], arw1[5, 1]);
        }
        private double[,] CalculateRotationMatrix()
        {
            double B = Camera_HorizontalAngle / 180 * Math.PI;
            double A = Camera_VerticalAngle / 180 * Math.PI;
            double C = 0;

            //return new double[,] {
            //    {
            //        Math.Cos(A),
            //        -Math.Sin(A) * Math.Cos(B),
            //        Math.Sin(A) * Math.Sin(B),
            //        0
            //    },

            //    {
            //        Math.Sin(A),
            //        -Math.Cos(A)*Math.Cos(B),
            //        -Math.Cos(A)*Math.Sin(B),
            //        0
            //    },

            //    {
            //        0,
            //        -Math.Sin(B),
            //        Math.Cos(B),
            //        0
            //    },

            //    {
            //        Camera_HorizontalOffset + HorizontalOffset,
            //        Camera_VerticalOffset + VerticalOffset,
            //        0,
            //        1
            //    }
            //}; ;
            return new double[,] {
                {
                    Math.Cos(B) * Math.Cos(C),
                    Math.Cos(B) * Math.Sin(C),
                    Math.Sin(B),
                    0
                },

                {
                    Math.Sin(A) * Math.Sin(B) * Math.Cos(C) + Math.Cos(A) * Math.Sin(C),
                    Math.Sin(A) * Math.Sin(B) * Math.Sin(C) - Math.Cos(A) * Math.Cos(C),
                    -Math.Sin(A)*Math.Cos(B),
                    0
                },

                {
                    -Math.Cos(A) * Math.Sin(B) * Math.Cos(C) + Math.Sin(A) * Math.Sin(C),
                    -Math.Cos(A) * Math.Sin(B) * Math.Sin(C) - Math.Sin(A) * Math.Cos(C),
                    Math.Cos(A)*Math.Cos(B),
                    0
                },

                {
                    Camera_HorizontalOffset + HorizontalOffset,
                    Camera_VerticalOffset + VerticalOffset,
                    0,
                    1
                }
            }; ;
        }
        private void UpdateTemp(bool selectedOnly = false)
        {
            temp.Clear();
            if(selectedOnly)
                foreach (GR_Point p in SelectedPoints)
                {
                    temp.Add((GR_Point)p.Clone());
                }
            else
                foreach (GR_Point p in points)
                {
                    temp.Add((GR_Point)p.Clone());
                }
        }
       
        private GR_Point GetPointByUid(uint id)
        {
            foreach (GR_Point_Base p in temp)
            {
                if (p is GR_Point && p.Id == id) return (GR_Point)p;
            }
            return null;
        }
        private GR_Point GetPointByUid(uint id, List<GR_Point_Base> list)
        {
            foreach (GR_Point_Base p in list)
            {
                if (p is GR_Point && p.Id == id) return (GR_Point)p;
            }
            return null;
        }
        public void AddPoint(GR_Point point)
        {
            point.Id = point_identificator;
            point.X -= HorizontalOffset + Camera_HorizontalOffset;
            point.Y += VerticalOffset + Camera_VerticalOffset;
            point_identificator++;
            points.Add(point);
        }
        public void SelectPoints(int x1, int y1, int x2, int y2, bool reselect = true)
        {
            if (reselect) UnselectPoints();
            foreach (var s in temp)
            {
                if (s.Id != 0 &&
                    s.Y  <= Math.Max(y1, y2) &&
                    s.Y  >= Math.Min(y1, y2) &&
                    s.X  <= Math.Max(x1, x2) &&
                    s.X  >= Math.Min(x1, x2))
                {

                    GetPointByUid(s.Id, points).Select();
                }

            }
        }
        public void UnselectPoints()
        {
            foreach (GR_Point_Base s in points)
            {
                if (s is GR_Point)
                    ((GR_Point)s).UnSelect();
            }
        }
        public uint GetPointUid(Point a)
        {
            foreach (GR_Point_Base p in points)
            {
                if (p is GR_Point && Math.Pow((a.X - p.X), 2) + Math.Pow((a.Y - p.Y), 2) <= Math.Pow(p.Radius, 2))
                {
                    return p.Id;
                }
            }
            return 0;
        }
        public uint GetPointUid(float x, float y)
        {
            foreach (GR_Point_Base p in temp)
            {
                if (p is GR_Point && Math.Pow((x - p.X), 2) + Math.Pow((y - p.Y), 2) <= Math.Pow(p.Radius, 2))
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
        public void ConnectPoints(float x1,float y1, float x2, float y2, int width, Color color)
        {
            uint point1_id = GetPointUid(x1,y1);
            uint point2_id = GetPointUid(x2,y2);
            if (LineCorrectAndDoesntExists(point1_id, point2_id))
                lines.Add(new GR_Line(point1_id,point2_id,width,color));
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


        public List<GR_Point_Base> SelectedPoints
        {
            get
            {
                var s_points = from s in points
                               where s is GR_Point
                               where ((GR_Point)s).Selected
                               select s;
                return s_points.ToList();
            }
        }

        public void MatrixOperation(double[,] matrix, bool selectedOnly = false)
        {
            if (matrix.Length != 16) return;
            if (selectedOnly)
            {
                UpdateTemp(true);
                for (int i = 0; i < temp.Count; i++)
                {
                    points[i].X = (float)(temp[i].X * matrix[0, 0] + temp[i].Y * matrix[1, 0] + temp[i].Z * matrix[2, 0] + temp[i].Ok * matrix[3, 0]);
                    points[i].Y = (float)(temp[i].X * matrix[0, 1] + temp[i].Y * matrix[1, 1] + temp[i].Z * matrix[2, 1] + temp[i].Ok * matrix[3, 1]);
                    points[i].Z = (float)(temp[i].X * matrix[0, 2] + temp[i].Y * matrix[1, 2] + temp[i].Z * matrix[2, 2] + temp[i].Ok * matrix[3, 2]);
                    points[i].Ok = (float)(temp[i].X * matrix[0, 3] + temp[i].Y * matrix[1, 3] + temp[i].Z * matrix[2, 3] + temp[i].Ok * matrix[3, 3]);
                }
            }
            else
            {
                UpdateTemp(false);
                for (int i = 0; i < temp.Count; i++)
                {
                    points[i].X = (float)(temp[i].X * matrix[0, 0] + temp[i].Y * matrix[1, 0] + temp[i].Z * matrix[2, 0] + temp[i].Ok * matrix[3, 0]);
                    points[i].Y = (float)(temp[i].X * matrix[0, 1] + temp[i].Y * matrix[1, 1] + temp[i].Z * matrix[2, 1] + temp[i].Ok * matrix[3, 1]);
                    points[i].Z = (float)(temp[i].X * matrix[0, 2] + temp[i].Y * matrix[1, 2] + temp[i].Z * matrix[2, 2] + temp[i].Ok * matrix[3, 2]);
                    points[i].Ok = (float)(temp[i].X * matrix[0, 3] + temp[i].Y * matrix[1, 3] + temp[i].Z * matrix[2, 3] + temp[i].Ok * matrix[3, 3]);
                }
            }
                


        }
        public void ResetCamera()
        {
            Camera_HorizontalAngle = 0;
            Camera_VerticalAngle = 0;
            Camera_VerticalOffset = 0;
            Camera_HorizontalOffset = 0;
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
        public void PreviewSelectedPointsRotation(float angX, float angY, float angZ)
        {

            Temp_Xtransform += angX;
            Temp_Ytransform += angY;
            Temp_Ztransform += angZ;

        }
        private double[,] CalculateTempRotationMatrix()
        {
            double A = Temp_Xtransform / 180 * Math.PI;
            double B = Temp_Ytransform / 180 * Math.PI;
            double C = Temp_Ztransform / 180 * Math.PI;

            GR_Point_Base P = GetPointsCenter(true);

            return new double[,] {
                {
                    Math.Cos(B) * Math.Cos(C),
                    -Math.Cos(B) * Math.Sin(C),
                    Math.Sin(B),
                    0
                },

                {
                    Math.Sin(A) * Math.Sin(B) * Math.Cos(C) + Math.Cos(A) * Math.Sin(C),
                    -Math.Sin(A) * Math.Sin(B) * Math.Sin(C) + Math.Cos(A) * Math.Cos(C),
                    -Math.Sin(A)*Math.Cos(B),
                    0
                },

                {
                    -Math.Cos(A) * Math.Sin(B) * Math.Cos(C) + Math.Sin(A) * Math.Sin(C),
                    Math.Cos(A) * Math.Sin(B) * Math.Sin(C) + Math.Sin(A) * Math.Cos(C),
                    Math.Cos(A)*Math.Cos(B),
                    0
                },

                {
                    (-P.X*Math.Cos(B)+P.Y*Math.Sin(A)*Math.Sin(B) - P.Z*Math.Sin(B))*Math.Cos(C) - (P.Y*Math.Cos(A) + P.Z*Math.Sin(A))*Math.Sin(C) + P.X,
                    (P.X*Math.Cos(B)-P.Y*Math.Sin(A)*Math.Sin(B)+P.Z*Math.Cos(A))*Math.Sin(C) - (P.Y*Math.Cos(A)+P.Z*Math.Sin(A))*Math.Cos(C) + P.Y,
                    -P.X*Math.Sin(B)+P.Y*Math.Sin(A)*Math.Cos(B)-P.Z*Math.Cos(A) + P.Z,
                    1
                }
            }; ;
        }
        public void ApplyTransformation()
        {
            double[,] temp_matrix = CalculateTempRotationMatrix();
            foreach (GR_Point p in SelectedPoints)
            {
                GR_Point p1 = (GR_Point)p.Clone();
                p.X = (float)(p1.X * temp_matrix[0, 0] + p1.Y * temp_matrix[1, 0] + p1.Z * temp_matrix[2, 0] + p1.Ok * temp_matrix[3, 0]);
                p.Y = (float)(p1.X * temp_matrix[0, 1] + p1.Y * temp_matrix[1, 1] + p1.Z * temp_matrix[2, 1] + p1.Ok * temp_matrix[3, 1]);
                p.Z = (float)(p1.X * temp_matrix[0, 2] + p1.Y * temp_matrix[1, 2] + p1.Z * temp_matrix[2, 2] + p1.Ok * temp_matrix[3, 2]);
                p.Ok = (float)(p1.X * temp_matrix[0, 3] + p1.Y * temp_matrix[1, 3] + p1.Z * temp_matrix[2, 3] + p1.Ok * temp_matrix[3, 3]);
            }
        }
        public void ResetTemp()
        {
            Temp_Xtransform = 0;
            Temp_Ytransform = 0;
            Temp_Ztransform = 0;
        }
    }
}
