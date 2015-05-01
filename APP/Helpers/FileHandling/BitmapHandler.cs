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
        /// <summary>
        /// Metoda odczytuje z bitmapy dane, tworząc kontur
        /// </summary>
        /// <param name="bitmap">
        /// Instancja bitmapy, na jednej bitmapie mamy wiele konturow, ktore roznia sie kolorem
        /// </param>
        /// <returns>
        /// Zwraca Kontur
        /// </returns>
        public Contour LoadBitmap(Bitmap bitmap)
        {
            Contour wynikContour = new Contour();
            wynikContour.Bitmap = bitmap;
            for (int i = 0; i < bitmap.Height; i++) 
            {
                for (int j = 0; j < bitmap.Width; j++) 
                {
                    Color pixelcolor = bitmap.GetPixel(i, j);

                    KnownColor znanyColor = pixelcolor.ToKnownColor();  //mamy juz enum z lista kolorów
                    Pylek wynik = (Pylek)znanyColor; //z enuma klasy.

                    //https://msdn.microsoft.com/en-us/library/system.drawing.knowncolor(v=vs.110).aspx
                    // korzystamy z wbudowanej juz listy enum i moze zostac int jako TYP.
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
