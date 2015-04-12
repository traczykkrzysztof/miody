using APP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Helpers.FileHandling
{
    class TxtHandler
    {
        public Contour LoadTxt(string path)
        {
            Contour wynikContour = null;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
             StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                wynikContour.CounturSet.Add(); //ConturePoint, po co poj. kropce typ pyłku?
            }
           
            
            return wynikContour;
        }
    }
}
