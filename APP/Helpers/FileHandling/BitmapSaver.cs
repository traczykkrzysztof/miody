using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Helpers.FileHandling
{
    class BitmapSaver
    {
        /// <summary>
        /// Metoda zapisuje bitmape do pliku
        /// </summary>
        /// <param name="bitmap">
        /// Bitmapa, którą chcemy zapisać 
        /// </param>
        /// <param name="file_name">
        /// Nazwa pliku pod którą chcemy zapisać daną bitmapę
        /// </param>
        public BitmapSaver(Bitmap  bitmap, string file_name)
        {
            bitmap.Save(file_name); //format?
        }
    }
}
