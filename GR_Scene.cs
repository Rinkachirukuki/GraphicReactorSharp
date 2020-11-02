﻿using System;
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

        public List<GR_Point> points;
        public List<GR_Point> figure1 = new List<GR_Point>();
        public List<GR_Point> figure2 = new List<GR_Point>();
        public List<GR_Point> figure3 = new List<GR_Point>();
        private List<GR_Line> lines;
        private List<GR_Point> temp;
        public float[,] globalArw;
        public Pen selectPen { get; set; }

        public float Camera_VerticalAngle { get; set; }
        public float Camera_HorizontalAngle { get; set; }
        public float Camera_VerticalOffset { get; set; }
        public float Camera_HorizontalOffset { get; set; }

        public void SetFigure1()
        {
            figure1 = SelectedPoints;
        }
        public void SetFigure2()
        {
            figure2 = SelectedPoints;
        }
        public void SetFigure3()
        {
            figure3 = SelectedPoints;
        }

        public GR_Scene()
        {
            points = new List<GR_Point>();
            lines = new List<GR_Line>();
            temp = new List<GR_Point>();

            

            selectPen = new Pen(Color.Red, 1.5f);
            selectPen.DashStyle = DashStyle.Dot;

            point_identificator = 1;
        }

        public void Draw(Graphics gr, float Xoffset = 0, float Yoffset = 0)
        {

            Pen pen = new Pen(Color.Black);

            double[,] matrix = CalculateRotationMatrix();

            DrawXYZ(gr,matrix,Xoffset,Yoffset);
            

            UpdateTemp();

            if (figure1.Count > 0 && figure2.Count > 0 && figure3.Count > 0 && figure1.Count == figure3.Count)
            {
                for (int i = 0; i < figure1.Count; i++)
                {
                    GR_Point newpoint = new GR_Point();
                    newpoint.X = figure1[i].X * 1 / 6 + figure2[i].X * 2 / 6 + figure3[i].X * 3 / 6;
                    newpoint.Y = figure1[i].Y * 1 / 6 + figure2[i].Y * 2 / 6 + figure3[i].Y * 3 / 6;
                    temp.Add(newpoint);
                }

            }

            for (int i = 0; i < points.Count; i++)
            {
                temp[i].X = (float)(points[i].X * matrix[0, 0] + points[i].Y * matrix[1, 0] + points[i].Z * matrix[2, 0] + points[i].Ok * matrix[3, 0]);
                temp[i].Y = (float)(points[i].X * matrix[0, 1] + points[i].Y * matrix[1, 1] + points[i].Z * matrix[2, 1] + points[i].Ok * matrix[3, 1]);
                temp[i].Z = (float)(points[i].X * matrix[0, 2] + points[i].Y * matrix[1, 2] + points[i].Z * matrix[2, 2] + points[i].Ok * matrix[3, 2]);
                temp[i].Ok = (float)(points[i].X * matrix[0, 3] + points[i].Y * matrix[1, 3] + points[i].Z * matrix[2, 3] + points[i].Ok * matrix[3, 3]);
            }


            foreach (GR_Line p in lines)
            {
                pen.Color = p.color;
                pen.Width = p.width;
                Point P1 = GetPointByUid(p.point1, temp).ToPoint();
                Point P2 = GetPointByUid(p.point2, temp).ToPoint();

                gr.DrawLine(pen, P1.X + Xoffset,-P1.Y + Yoffset, P2.X + Xoffset, -P2.Y + Yoffset);
            }

            temp.Sort();

            foreach (GR_Point p in temp)
            {
                pen.Color = p.OutColor;
                pen.Width = p.LineWidth;
                gr.FillEllipse(new SolidBrush(p.FillColor), p.X - p.Radius / 2 + Xoffset, - p.Y - p.Radius / 2 + Yoffset, p.Radius, p.Radius);
                gr.DrawEllipse(pen, p.X - p.Radius / 2 + Xoffset, - p.Y - p.Radius / 2 + Yoffset, p.Radius, p.Radius);
                if (p.Selected) gr.DrawEllipse(selectPen, p.X - (p.Radius + p.LineWidth + 4) / 2 + Xoffset, - p.Y - (p.Radius + p.LineWidth + 4) / 2 + Yoffset, p.Radius + p.LineWidth + 4, p.Radius + p.LineWidth + 4);

            }

            DrawXYZarrows(gr, CalculateXYZarrows(matrix, Xoffset, Yoffset));
            if (temp.Count == 2)
            {
                FontFamily fontFamily = new FontFamily("Arial");
                gr.DrawString((temp[0].Y * temp[1].Ok - temp[1].Y*temp[0].Ok).ToString() + "X - " + (temp[0].X * temp[1].Ok - temp[1].X * temp[0].Ok).ToString() + "Y + " + (temp[0].X * temp[1].Y - temp[1].X * temp[0].Y).ToString(), new Font(fontFamily, 7), new SolidBrush(Color.Black), (temp[0].X + temp[1].X) / 2 + Xoffset, -(temp[0].Y + temp[1].Y) / 2 + Yoffset);
            }
            pen.Dispose();

        }
        private float[,] CalculateXYZarrows(double[,] matrix, float Xoffset, float Yoffset)
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
                arw1[i, 0] = (float)(arw[i, 0] * matrix[0, 0] + arw[i, 1] * matrix[1, 0] + arw[i, 2] * matrix[2, 0] + arw[i, 3] * matrix[3, 0]) + Xoffset;
                arw1[i, 1] = -(float)(arw[i, 0] * matrix[0, 1] + arw[i, 1] * matrix[1, 1] + arw[i, 2] * matrix[2, 1] + arw[i, 3] * matrix[3, 1]) + Yoffset;
                arw1[i, 2] = (float)(arw[i, 0] * matrix[0, 2] + arw[i, 1] * matrix[1, 2] + arw[i, 2] * matrix[2, 2] + arw[i, 3] * matrix[3, 2]);
                arw1[i, 3] = (float)(arw[i, 0] * matrix[0, 3] + arw[i, 1] * matrix[1, 3] + arw[i, 2] * matrix[2, 3] + arw[i, 3] * matrix[3, 3]);
            }
            return arw1;
            
        }
        private void DrawXYZarrows(Graphics gr,float[,] arw)
        {
            if (arw.GetLength(0) == 0) return;
            globalArw = arw;
            gr.DrawLine(new Pen(Color.Red, 3), arw[0, 0], arw[0, 1], arw[1, 0], arw[1, 1]);
            gr.DrawLine(new Pen(Color.Green, 3), arw[0, 0], arw[0, 1], arw[2, 0], arw[2, 1]);
            gr.DrawLine(new Pen(Color.Blue, 3), arw[0, 0], arw[0, 1], arw[3, 0], arw[3, 1]);
        }

        public bool HitXarrow(float x, float y,float Xoffset = 0, float Yoffset = 0)
        {
            double[,] matrix = CalculateRotationMatrix();
            float[,] arr = CalculateXYZarrows(matrix, Xoffset,Yoffset);
            if (arr.GetLength(0) == 0) return false;
            return isIntersect(arr[0,0], arr[0, 1], arr[1, 0], arr[1, 1], x,  y,  2);
        }
        public bool HitYarrow(float x, float y, float Xoffset = 0, float Yoffset = 0)
        {
            double[,] matrix = CalculateRotationMatrix();
            float[,] arr = CalculateXYZarrows(matrix, Xoffset, Yoffset);
            if (arr.GetLength(0) == 0) return false;
            return isIntersect(arr[0, 0], arr[0, 1], arr[2, 0], arr[2, 1], x, y, 2);
        }
        public bool HitZarrow(float x, float y, float Xoffset = 0, float Yoffset = 0)
        {
            double[,] matrix = CalculateRotationMatrix();
            float[,] arr = CalculateXYZarrows(matrix, Xoffset, Yoffset);
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
        private void DrawXYZ(Graphics gr, double[,] matrix, float Xoffset, float Yoffset)
        {

            float[,] arw = new float[,] {
            {Xoffset*2, 0, 0, 1},
            {-Xoffset*2, 0, 0, 1},

            {0, Yoffset*2, 0, 1},
            {0, -Yoffset*2, 0, 1},

            {0, 0,  Yoffset*2, 1},
            {0, 0, - Yoffset*2, 1}
            };


            
            float[,] arw1 = new float[6, 4];


            for (int i = 0; i < arw.GetLength(0); i++)
            {
                arw1[i, 0] = (float)(arw[i, 0] * matrix[0, 0] + arw[i, 1] * matrix[1, 0] + arw[i, 2] * matrix[2, 0] + arw[i, 3] * matrix[3, 0]) + Xoffset;
                arw1[i, 1] = -(float)(arw[i, 0] * matrix[0, 1] + arw[i, 1] * matrix[1, 1] + arw[i, 2] * matrix[2, 1] + arw[i, 3] * matrix[3, 1]) + Yoffset;
                arw1[i, 2] = (float)(arw[i, 0] * matrix[0, 2] + arw[i, 1] * matrix[1, 2] + arw[i, 2] * matrix[2, 2] + arw[i, 3] * matrix[3, 2]);
                arw1[i, 3] = (float)(arw[i, 0] * matrix[0, 3] + arw[i, 1] * matrix[1, 3] + arw[i, 2] * matrix[2, 3] + arw[i, 3] * matrix[3, 3]);
            }
            gr.DrawLine(new Pen(Color.FromArgb(50,Color.Red), 2), arw1[0, 0], arw1[0, 1], arw1[1, 0], arw1[1, 1]);
            gr.DrawLine(new Pen(Color.FromArgb(50, Color.Green), 2), arw1[2, 0], arw1[2, 1], arw1[3, 0], arw1[3, 1]);
            gr.DrawLine(new Pen(Color.FromArgb(50, Color.Blue), 2), arw1[4, 0], arw1[4, 1], arw1[5, 0], arw1[5, 1]);
        }
        private double[,] CalculateRotationMatrix()
        {
            double angleA = Camera_HorizontalAngle / 180 * Math.PI;
            double angleB = Camera_VerticalAngle / 180 * Math.PI;
            return new double[,] {
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
                    Math.Cos(angleA) -  Math.Sin(angleA)*Math.Sin(angleB) - Math.Cos(angleB) + Camera_HorizontalOffset,
                    Math.Cos(angleB) -  Math.Sin(angleB) - Camera_VerticalOffset,
                    Math.Sin(angleA) +  Math.Cos(angleA)*Math.Sin(angleB) - Math.Cos(angleB),
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
            foreach (var s in temp)
            {
                if (s.Y  <= Math.Max(y1, y2) &&
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
            foreach (GR_Point p in temp)
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
        public void MovePoints(bool x, bool y, bool z, int eX, int StartX, int eY, int StartY, bool selectedOnly = false)
        {
            //ax x  x1 arw[0, 0], y1  arw[0, 1], x2 arw[1, 0], y2 arw[1, 1];
            // ax y x1 arw[0, 0], y1 arw[0, 1], x2 arw[2, 0], y2 arw[2, 1];
            //ax z x1 arw[0, 0], y1 arw[0, 1], x2 arw[3, 0],y2 arw[3, 1]);
            float Vlengthdif = Math.Abs((float)Math.Sqrt(Math.Pow(StartX, 2) + Math.Pow(StartY, 2)) -(float)Math.Sqrt(Math.Pow(eX, 2) + Math.Pow(eY, 2)));
            
            if (selectedOnly)
            {
                foreach (GR_Point p in SelectedPoints)
                {
                    float speed = 50f;
                    if (x)
                    {
                        
                        float vecX = globalArw[1, 0] - globalArw[0, 0];
                        float vecY = globalArw[1, 1] - globalArw[0, 1];

                        float vecStartEx = eX - StartX;
                        float vecStartEy = eY - StartY;
                        float cosA = 0;
                        float normalizeRate = 1;
                        if((float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2)) !=0) //normalize vecX
                        {
                            normalizeRate = 1.0f / (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2));
                        }
                        vecX*= normalizeRate * 100;
                        vecY *= normalizeRate * 100;
                        if (((float)Math.Sqrt(Math.Pow(vecStartEx, 2) + Math.Pow(vecStartEy, 2)) *
                           (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2))) == 0) cosA = 1;
                        else
                        {
                            cosA = (vecStartEx * vecX + vecStartEy * vecY) / ((float)Math.Sqrt(Math.Pow(vecStartEx, 2) + Math.Pow(vecStartEy, 2)) *
                           (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2)));
                        }
                        
                        p.X += Vlengthdif*cosA* normalizeRate * speed;
                    }
                    if (y)
                    {
                        float vecX = globalArw[2, 0] - globalArw[0, 0];
                        float vecY = globalArw[2, 1] - globalArw[0, 1];
                        float vecStartEx = eX - StartX;
                        float vecStartEy = eY - StartY;
                        float cosA = 0;
                        float normalizeRate = 1;
                        if ((float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2)) != 0) //normalize vecX
                        {
                            normalizeRate = 1.0f / (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2));
                        }
                        vecX *= normalizeRate * 100;
                        vecY *= normalizeRate * 100;

                        if (((float)Math.Sqrt(Math.Pow(vecStartEx, 2) + Math.Pow(vecStartEy, 2)) *
                           (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2))) == 0) cosA = 1;
                        else
                        {
                            cosA = (vecStartEx * vecX + vecStartEy * vecY) / ((float)Math.Sqrt(Math.Pow(vecStartEx, 2) + Math.Pow(vecStartEy, 2)) *
                            (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2)));
                        }

                        p.Y += Vlengthdif * cosA * normalizeRate * speed;
                    }
                    if (z)
                    {
                        float vecX = globalArw[3, 0] - globalArw[0, 0];
                        float vecY = globalArw[3, 1] - globalArw[0, 1];
                        
                        float vecStartEx = eX - StartX;
                        float vecStartEy = eY - StartY;
                        float cosA = 0;
                        float normalizeRate = 1;
                        if ((float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2)) != 0) //normalize vecX
                        {
                            normalizeRate = 1.0f / (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2));
                        }

                        vecX *= normalizeRate *100;
                        vecY *= normalizeRate *100;

                        if (((float)Math.Sqrt(Math.Pow(vecStartEx, 2) + Math.Pow(vecStartEy, 2)) *
                           (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2))) == 0) cosA = 1;
                        else
                        {
                            cosA = (vecStartEx * vecX + vecStartEy * vecY) / ((float)Math.Sqrt(Math.Pow(vecStartEx, 2) + Math.Pow(vecStartEy, 2)) *
                            (float)Math.Sqrt(Math.Pow(vecX, 2) + Math.Pow(vecY, 2)));
                        }

                        p.Z += Vlengthdif * cosA *  normalizeRate * speed;
                    }  
                }
            }
            else
                foreach (GR_Point p in points)
                {
                   // p.X += x;
                   // p.Y += y;
                   // p.Z += z;
                }
            
        }
    }
}
