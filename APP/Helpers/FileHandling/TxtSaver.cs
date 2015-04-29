using APP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Helpers.FileHandling
{
    class TxtSaver
    {
        public TxtSaver(Contour kontur, TextWriter writer)
        {
            string linia;
            string pylek_nazwa;
            foreach (var item in kontur.ContourSet)
            {
                if (item != null)
                {
                    pylek_nazwa = (Pylek)item.Type;
                    linia = Convert.ToString(item.Location.X) + " " + Convert.ToString(item.Location.Y) + " " + Convert.ToString(pylek_nazwa);
                    writer.WriteLine(linia);

                }
            }
        }
    }
}
