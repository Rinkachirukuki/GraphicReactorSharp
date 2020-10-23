using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    class GR_Point : ICloneable
    {
        public uint Id { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float Ok { get; set; }



        private float lineWidth;
        public float LineWidth 
        {
            get { return lineWidth; }
            set { lineWidth = value > 0 ? value : 1; }
        }


        private float radius;
        public float Radius
        {
            get { return radius; }
            set { radius = value > 0 ? value : 1; }
        }

        public Color OutColor { get; set; }
        public Color FillColor { get; set; }

        public bool Selected { get; set; }
        public GR_Point()
        {

            X = 0;
            Y = 0;
            Z = 0;
            Ok = 1;
            Radius = 10;
            OutColor = Color.Black;
            FillColor = Color.White;
            Selected = false;
        }
        public GR_Point(float x, float y, float z)
        {
            this.Id = 0;
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Ok = 1;
            this.LineWidth = lineWidth;
            this.Radius = 1;
            this.OutColor = Color.Black;
            this.FillColor = Color.Black;
            this.Selected = false;
        }
        private GR_Point(uint id, float x, float y, float z, float ok, float radius, float lineWidth, Color out_color, Color fill_color, bool selected)
        {
            this.Id = id;
            this.X= x;
            this.Y = y;
            this.Z = z;
            this.Ok = ok;
            this.LineWidth = lineWidth;
            this.Radius = radius;
            this.OutColor = out_color;
            this.FillColor = fill_color;
            this.Selected = selected;
        }
        public GR_Point(float x, float y, float radius, int r, int g, int b)
        {

            this.X = x;
            this.Y = y;
            this.Z = 0;
            this.Ok = 1;
            this.Radius = radius;
            this.OutColor = Color.FromArgb(r, g, b);
            this.FillColor = Color.FromArgb(r, g, b);
            this.Selected = false;
        }
        public GR_Point( float x, float y, float z, float radius, Color outColor)
        {
            this.X = x;
            this.Y = y;
            this.Z= z;
            this.Ok = 1;
            this.Radius = radius;
            this.OutColor = outColor;
            this.Selected = false;
        }
        public GR_Point( float x, float y, float z, float radius, float lineWight, int out_r, int out_g, int out_b, int fill_r, int fill_g, int fill_b)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Ok = 1;
            this.Radius = radius;
            this.LineWidth = lineWight;
            this.OutColor = Color.FromArgb(out_r, out_g, out_b);
            this.FillColor = Color.FromArgb(fill_r, fill_g, fill_b);
            this.Selected = false;
        }

        public void Select()
        {
            Selected = true;
        }
        public void UnSelect()
        {
            Selected = false;
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public object Clone()
        {
            return new GR_Point(Id, X, Y, Z, Ok, Radius, LineWidth, OutColor, FillColor, Selected);
        }
    }
}
