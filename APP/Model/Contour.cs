using System.Collections.Generic;
using System.Drawing;

namespace APP.Model
{
    public class Contour
    {
        public Contour()
        {
            ContourSet=new HashSet<ContourPoint>();
        }

        public HashSet<ContourPoint> ContourSet { get; set; }
        public Bitmap Bitmap { get; set; }
    }
}
