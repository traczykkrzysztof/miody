using APP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APP.Helpers.FileHandling
{
    class TxtHandler
    {
        public Contour LoadTxt(StreamReader reader)
        {
            
            
            Contour wynikContour = new Contour();

             while (!reader.EndOfStream)
             {
                 string readLine = reader.ReadLine();
                 if (readLine != null)
                 {
                     string[] line = readLine.Split(' ');
                     CounturPoint point = new CounturPoint()
                     {
                         Location = new Point(int.Parse(line[0]), int.Parse(line[1])),
                         Type = int.Parse(line[2])
                     };
                     wynikContour.CounturSet.Add(point); //ConturePoint, po co poj. kropce typ pyłku?
                 }
             }


            return wynikContour;
        }
    }
}
