using APP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Helpers.FileHandling
{
    class ContourLoader // przyjmuje sting path(sciezke do pliku) ->  zwraca kontur.
        // TxtHandler -> przyjmuje plik, jesli jest txt i go zmienia na kontur
        // BitmapHandler -> przyjmuje plik, jesli jest .jpg  i go zmienia na kontur
    {
        public Contour LoadContour(string path)
        {
           
            Contour loadedContour;
            if (path.Contains("txt"))
            {
                TxtHandler txt  = new TxtHandler();
                loadedContour = txt.LoadTxt(path);
            }
            else
            {
                BitmapHandler bit = new BitmapHandler();
                loadedContour =  bit.LoadBitmap(path);
            }
            return loadedContour;
        }

    }
}
