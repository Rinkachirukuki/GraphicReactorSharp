using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor
{
    class GR_Object
    {
        public uint Id;

        public List<GR_Point> gr_points;
        public List<GR_Line> gr_lines;
        public List<GR_Object> gr_objects;

        public GR_Object()
        {
            gr_points = new List<GR_Point>();
            gr_lines = new List<GR_Line>();
            gr_objects = new List<GR_Object>();
        }

        public GR_Object(uint id)
        {
            Id = id;
            gr_points = new List<GR_Point>();
            gr_lines = new List<GR_Line>();
            gr_objects = new List<GR_Object>();
        }


        public List<GR_Point> Points
        {
            get
            {
                List<GR_Point> list = gr_points.ToList();
                foreach(GR_Object ob in gr_objects)
                {
                    list.AddRange(ob.Points);
                }
                return list;
            }
        }
        public List<GR_Point> SelectedPoints
        {
            get
            {
                List<GR_Point> list = (from p in gr_points where p.Selected select p).ToList();
                foreach (GR_Object ob in gr_objects)
                    list.Concat(ob.Points);
                
                return list;
            }
        }
        public void RemoveSelectedPoints()
        {
            for (int i = 0; i < gr_points.Count; i++)
                if (gr_points[i].Selected)
                {
                    gr_points.RemoveAt(i);
                    i--;
                }
                    

            foreach (GR_Object ob in gr_objects)
                ob.RemoveSelectedPoints();
            
        }
        public void SelectedForAllPoints(bool sel)
        {
            foreach (GR_Point p in gr_points)
                p.Selected = sel;
            foreach (GR_Object ob in gr_objects)
                ob.SelectedForAllPoints(sel);
        }

        public GR_Object GetObjectById(uint obId)
        {
            if (Id == obId) return this;

            foreach (GR_Object ob in gr_objects)
            {
                if (ob.Id == obId)
                    return ob;
                else 
                {
                    GR_Object obj = ob.GetObjectById(obId);
                    if (obj != null)
                        return obj;
                }   
            }
            return null;
        }

    }
}

