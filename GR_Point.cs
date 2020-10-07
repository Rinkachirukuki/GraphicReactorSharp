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
        public uint id;

        public float x;
        public float y;
        public float z;
        public float ok = 1;

        private float lineWidth;
        private float radius;

        private Color outColor;
        private Color fillColor;

        public bool Selected = false;
        public GR_Point()
        {

            x = 0;
            y = 0;
            z = 0;
            this.radius = 10;
            this.outColor = Color.Black;
            this.fillColor = Color.White;
            this.Selected = false;
        }

        private GR_Point(uint id, float x, float y, float z, float ok, float radius, float lineWidth, Color out_color, Color fill_color, bool selected)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.z = z;
            this.ok = ok;
            this.lineWidth = lineWidth;
            this.radius = radius;
            this.outColor = out_color;
            this.fillColor = fill_color;
            this.Selected = selected;
        }
        public GR_Point(float x, float y, float radius, int r, int g, int b)
        {

            this.x = x;
            this.y = y;
            this.z = 0;
            this.radius = radius;
            this.outColor = Color.FromArgb(r, g, b);
            this.fillColor = Color.FromArgb(r, g, b);
            this.Selected = false;
        }
        public GR_Point( float x, float y, float z, float radius, Color outColor)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
            this.outColor = outColor;
            this.Selected = false;
        }
        public GR_Point( float x, float y, float z, float radius, float lineWight, int out_r, int out_g, int out_b, int fill_r, int fill_g, int fill_b)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
            this.lineWidth = lineWight;
            this.outColor = Color.FromArgb(out_r, out_g, out_b);
            this.fillColor = Color.FromArgb(fill_r, fill_g, fill_b);
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

        public float GetX()
        {
            return x;
        }
        public float GetY()
        {
            return y;
        }
        public float GetZ()
        {
            return z;
        }
        public float GetRadius()
        {
            return radius;
        }
        public Color GetOutColor()
        {
            return outColor;
        }
        public Color GetFillColor()
        {
            return fillColor;
        }
        public float GetWidth()
        {
            return lineWidth;
        }
        public Point ToPoint()
        {
            return new Point((int)x, (int)y);
        }
        public void SetXY(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public void SetXYZ(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }




        public object Clone()
        {
            return new GR_Point(id, x, y, z, ok, radius, lineWidth, outColor, fillColor, Selected);
        }
    }
}
