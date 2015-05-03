using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP.Model;

namespace APP.Helpers
{
    public class MaskGenerator
    {

        public Mask GenerateMask(Contour contour)
        {
            int height = (int) Math.Ceiling((double) contour.ContourSet.Max(point => point.Location.X));
            int width = (int)Math.Ceiling((double) contour.ContourSet.Max(point => point.Location.Y));

            foreach (Pylek pylek in Pylek.Values)
            {
                Bitmap bitmap= new Bitmap(width, height);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.SmoothingMode = SmoothingMode.None;


                foreach (ContourPoint contourPoint in contour.ContourSet.Where(point => point.Type==pylek))
                {
                    graphics.DrawLine(new Pen(Color.Black, 10), contourPoint.Location, contourPoint.Location);
                }



            }



            return  new Mask(height, width);







        }
    }
}
