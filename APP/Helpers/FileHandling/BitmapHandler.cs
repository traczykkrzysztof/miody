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
            //na jednej bitmapie mamy wiele konturow, ktore roznia sie kolorem
            Contour wynikContour = new Contour();
            wynikContour.Bitmap = bitmap;
            for (int i = 0; i < bitmap.Height; i++) //po ilosci pikseli w wysokosci
            {
                for (int j = 0; j < bitmap.Width; j++) //po ilosci pikseli w szerokosci
                {
                    Color pixelcolor = bitmap.GetPixel(i, j);

                    KnownColor znanyColor = pixelcolor.ToKnownColor();  //mamy juz enum z lista kolorów
                    Pylek wynik = (Pylek)znanyColor; //z enuma klasy.

                    //https://msdn.microsoft.com/en-us/library/system.drawing.knowncolor(v=vs.110).aspx
                    // korzystamy z wbudowanej juz listy enum i moze zostac int jako TYP.
                    //int numerEnumeracji = (int) znanyColor;
                    //kolor tego konkretnego pixela
                    ContourPoint point = new ContourPoint()
                        {
                            Location = new System.Windows.Point(i, j),
                            Type = wynik,
                        };
                    wynikContour.ContourSet.Add(point);
                }
            }


            return wynikContour;
        }
    }
}
