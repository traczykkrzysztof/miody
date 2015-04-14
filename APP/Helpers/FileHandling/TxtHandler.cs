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
        private static string[] ReadData(string line)
        {
            int i=0;
            string pierwszaLiczba = "";
            string drugaLiczba="";
            string typMiodu = "";


            while (line[i]!=',')
            {
                pierwszaLiczba += line[i];
                i++;
 
            }
            i++;
            while (line[i]!=',')
            {
                drugaLiczba += line[i];
                i++;
            }
            i++;
            while (i<line.Length)
            {
                typMiodu += line[i];
                i++;
            }
            string[] tab = { pierwszaLiczba, drugaLiczba, typMiodu };

            return tab;

        }
        
        public Contour LoadTxt(string path)
        {
            Contour wynikContour = new Contour();  //nie mogl byc null bo przeciez pokaze blad przy dostaniu sie do ConturSet

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            
             StreamReader sr = new StreamReader(fs);

             wynikContour.Bitmap = new System.Drawing.Bitmap(150, 150);
             wynikContour.CounturSet = new HashSet<CounturPoint>();

             string[] dane = { };
            while (!sr.EndOfStream)
            {
                Type obj = typeof(string);

//kod dostosowany pod format: wspolrzedna(int),wspolrzedna(int),typPyłku   np. 1,2,JakiśTyp  - bez spacji

                try
                {
                    dane = ReadData(sr.ReadLine());
                }
                catch (Exception)
                {

                }

                



                wynikContour.CounturSet.Add(new CounturPoint {Location = new Point(Convert.ToDouble(dane[0]),Convert.ToDouble(dane[1]))});


                wynikContour.Bitmap.SetPixel(Convert.ToInt32(dane[0]), Convert.ToInt32(dane[1]), System.Drawing.Color.Black);
              


            }
           
            
            return wynikContour;
        }
    }
}
