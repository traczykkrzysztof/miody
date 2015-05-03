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
    public interface ITxtHandler
    {
        Contour LoadTxt(TextReader reader);
    }

    public class TxtHandler : ITxtHandler
    {
        public Contour LoadTxt(TextReader reader)
        {
            //Pylek numero = 1;
            //Pylek kolorp = KnownColor.ActiveCaption;
            //Pylek nazwo = "rzepakowy";
            //string name;
       

           
            Contour wynikContour = new Contour();

            while (reader.Peek() != -1)
        {
                 string readLine = reader.ReadLine();
                 if (readLine != null)
            {
                     string[] line = readLine.Split(' ');
                     ContourPoint point = new ContourPoint()
                     {  // kazda linijka to odpowiednio współrzędna: X, Y     ; Typ pyłku 
                         Location = new Point(int.Parse(line[0]), int.Parse(line[1])),
                         Type = int.Parse(line[2])
                     };
                     wynikContour.ContourSet.Add(point); 
                 }
            }
           
            
            return wynikContour;
        }
    }
}
