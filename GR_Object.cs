using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicReactor.CustomForms
{
    class GR_Object
    {
        public List<GR_Point_Base> gr_points;
        public List<GR_Line> gr_lines;
        public List<GR_Object> gr_objects;


        //public List<GR_Point_Base> returnPoints()
        //{
        //    return


        //}
        //public List<GR_Point_Base> SelectedPoints
        //{
        //    get
        //    {
        //        var s_points = from s in gr_objects 
        //                       from s.gr_points is GR_Point
        //                       select s;
        //        return s_points.ToList();
        //    }
        //}

    }
}

