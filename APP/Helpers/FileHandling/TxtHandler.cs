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
        /// <summary>
        /// Metoda odczytuje z pliku txt dane linijka po linijce
        /// dodając do wynikowego konturu  ContourPoint 
        /// </summary>
        /// <param name="reader">
        /// TextReader od naszego pliku tekstowego
        /// </param>
        /// <returns>
        /// Zwraca kontur
        /// </returns>
        public Contour LoadTxt(TextReader reader)
    {
            
            Contour wynikContour = new Contour();

            while (reader.Peek() != -1)
        {
                 string readLine = reader.ReadLine();
                 if (readLine != null)
            {
                     string[] line = readLine.Split(' ');
                     ContourPoint point = new ContourPoint()
                     {  // kazda linijka to odpowiednio współrzędna: X Y Typ pyłku ;rozna ilosc spacji
                         Location = new Point(int.Parse(line[0]), int.Parse(line[1])),
                         Type =  (Pylek) line[2]     
 
                     };
                     wynikContour.ContourSet.Add(point); 
                 }
            }
           
            
            return wynikContour;
        }
    }
}
