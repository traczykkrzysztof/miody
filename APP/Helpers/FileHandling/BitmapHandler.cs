using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            Contour wynikContour = null;
            wynikContour.Bitmap = bitmap;
            for (int i = 0; i < bitmap.Height; i++) //po ilosci pikseli w wysokosci
            {
                for (int j = 0; j < bitmap.Width; j++) //po ilosci pikseli w szerokosci
                {                 
                    
                 CounturPoint point = new CounturPoint()
                     {
                         Location = new   System.Windows.Point(i, j),
                         Type = 0                     
                    //jak typ pylku zgarnac?      
                    
                     };
                    wynikContour.CounturSet.Add(point);
                }
            }
       

            return wynikContour;
        }
    }
}
