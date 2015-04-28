using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Helpers.Miary
{
    class Miara1 //oraz 3.
    {
        
            static double miara1(int[,] tab1, int[,] tab2)
            {
                int iloczyn = 0;
                int suma = 0;
                double Result = iloczyn / suma;

                for (int i = 0; i < tab1.GetLength(0); i++)
                {
                    for (int j = 0; j < tab1.GetLength(1); j++)
                    {
                        if (tab1[i, j] != 0 && tab1[i, j] == tab2[i, j])
                        {
                            iloczyn++;
                        }
                        if ((tab1[i, j] != 0 && tab2[i, j] == 0) || (tab1[i, j] == 0 && tab2[i, j] != 0))
                        {
                            suma++;
                        }
                        if (tab1[i, j] != 0 && tab2[i, j] != 0 && tab1[i, j] != tab2[i, j])
                        {
                            suma += 2;
                        }
                    }
                }
                //suma = suma - iloczyn;
                return Result;
            }
            static double miara3(int[,] tab1, int[,] tab2)
            {
                int licznik = 0;
                double Result = licznik / tab1.Length;
                for (int i = 0; i < tab1.GetLength(0); i++)
                {
                    for (int j = 0; j < tab1.GetLength(1); j++)
                    {
                        if (tab1[i, j] != tab2[i, j])
                        {
                            licznik++;
                        }
                    }
                }
                return Result;
            }


           
                //int a = 6;
                //int b = 6;
                //int[,] tab1 = new int[a, b];
                //int[,] tab2 = new int[a, b];
                //miara1(tab1, tab2);
                //miara3(tab1, tab2);







            
        }
    }
}
