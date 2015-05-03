using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using APP.Model;

namespace APP.Helpers.FileHandling
{
    public interface IBitmapHandler
    {
        Contour LoadBitmap(Bitmap path);
    }

    public class BitmapHandler : IBitmapHandler
    {
        public Contour LoadBitmap(Bitmap bitmap)//dostaje bitmape
        {
            //na jednej bitmapie mamy wiele konturow, ktore roznia sie kolorem
            Contour wynikContour = new Contour();
            wynikContour.Bitmap = bitmap; // todo fixme please 
            for (int i = 0; i < bitmap.Height; i++) //po ilosci pikseli w wysokosci
            {
                for (int j = 0; j < bitmap.Width; j++) //po ilosci pikseli w szerokosci
                {
                    Color pixelcolor = bitmap.GetPixel(j, i);
                 ContourPoint point = new ContourPoint()
                     {                        
                         Location = new Point(i, j),
                         Type = (Pylek)pixelcolor     
                     };
                    wynikContour.ContourSet.Add(point);
                }
            }
       

            return wynikContour;
        }
    }
}
