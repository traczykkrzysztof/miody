using System.Collections.Generic;
using System.Drawing;

namespace APP.Model
{
    public class Contour
    {
        public Contour()
        {
            CounturSet=new HashSet<CounturPoint>();
        }

        public HashSet<CounturPoint> CounturSet { get; set; }
        public Bitmap Bitmap { get; set; }
    }
}
