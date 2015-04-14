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
    public interface ITxtHandler
    {
        Contour LoadTxt(TextReader reader);
    }

    public class TxtHandler : ITxtHandler
    {
        public Contour LoadTxt(TextReader reader)
        {
            
            
            Contour wynikContour = new Contour();

            while (reader.Peek() != -1)
             {
                 string readLine = reader.ReadLine();
                 if (readLine != null)
                 {
                     string[] line = readLine.Split(' ');
                     CounturPoint point = new CounturPoint()
                     {  // kazda linijka to odpowiednio współrzędna: X, Y     ; Typ pyłku 
                         Location = new Point(int.Parse(line[0]), int.Parse(line[1])),
                         Type = int.Parse(line[2])
                     };
                     wynikContour.CounturSet.Add(point); 
                 }
             }


            return wynikContour;
        }
    }
}
