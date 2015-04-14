using APP.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Helpers.FileHandling
{
    public class ContourLoader // przyjmuje sting path(sciezke do pliku) ->  zwraca kontur.
        // TxtHandler -> przyjmuje plik, jesli jest txt i go zmienia na kontur
        // BitmapHandler -> przyjmuje plik, jesli jest .jpg  i go zmienia na kontur
    {
        private ITxtHandler _txtHandler;
        private IBitmapHandler _bitmapHandler;

        public ContourLoader(IBitmapHandler bitmapHandler, ITxtHandler txtHandler)
        {
            _bitmapHandler = bitmapHandler;
            _txtHandler = txtHandler;
        }

        public Contour LoadContour(string path)
        {
           
            Contour loadedContour;
            if (path.Contains("txt"))
            {
                StreamReader reader = new StreamReader(path);
                loadedContour = _txtHandler.LoadTxt(reader);
            }
            else
            {
                Bitmap bitmap = new Bitmap(path);
                loadedContour = _bitmapHandler.LoadBitmap(bitmap);
            }
            return loadedContour;
        }

    }
}
