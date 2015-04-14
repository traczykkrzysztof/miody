using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public Contour LoadBitmap(Bitmap path)
        {
            throw new NotImplementedException();
            Contour wynikContour = null;

            return wynikContour;
        }
    }
}
