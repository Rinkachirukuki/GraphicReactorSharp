﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    class GR_Point : ICloneable
    {
        private float x;
        private float y;
        private float z;
        private float lineWight;
        private float radius;
        private Color outColor;
        private Color fillColor;
        public GR_Point()
        {
            x = 0;
            y = 0;
            z = 0;
            this.radius = 10;
            this.outColor = Color.Black;
            this.fillColor = Color.White;
        }
        public GR_Point(float x, float y, float radius, Color out_color, Color fill_color)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
            this.radius = radius;
            this.outColor = out_color;
            this.fillColor = fill_color;
        }
        public GR_Point(float x, float y, float radius, int r, int g, int b)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
            this.radius = radius;
            this.outColor = Color.FromArgb(r, g, b);
            this.fillColor = Color.FromArgb(r, g, b);
        }
        public GR_Point(float x, float y, float z, float radius, Color color)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
            this.outColor = color;
        }
        public GR_Point(float x, float y, float z, float radius, float lineWight, int out_r, int out_g, int out_b, int fill_r, int fill_g, int fill_b)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.radius = radius;
            this.lineWight = lineWight;
            this.outColor = Color.FromArgb(out_r, out_g, out_b);
            this.fillColor = Color.FromArgb(fill_r, fill_g, fill_b);
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
            return lineWight;
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
            throw new NotImplementedException();
        }
    }
}