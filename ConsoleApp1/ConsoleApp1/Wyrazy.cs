using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Wyrazy
    {
        string[] wyrazy = {"zerowy", "pierwszy", "drugi", "trzeci", "czwarty"};

        double[,] prawdopodobienstwa = { { 0.1, 0.2, 0.3, 0.1, 0.2},
                                         { 0.3, 0.4, 0.1, 0.2, 0.1 },
                                         { 0.1, 0.1, 0.1, 0.5, 0.3 },
                                         { 0.1, 0.1, 0.2, 0.1, 0.3 },
                                         { 0.4, 0.2, 0.3, 0.1, 0.1 },
                                       };

        public void Symulacja()
        {
            Random random = new Random();
            string badana = wyrazy[random.Next(0, wyrazy.Length-1)];
            string badana1 = null;
            for (int i =0; i < 100; i++)
            {
                int szukanyIndeks = 0;
                for(int j = 0; j<wyrazy.Length; j++)
                {
                    if(badana == wyrazy[j])
                    {
                        szukanyIndeks = j;
                    }
                }
                badana = PodajWynik(prawdopodobienstwa[szukanyIndeks, szukanyIndeks + 1], badana, wyrazy[szukanyIndeks+1]);
                Console.WriteLine(badana);
            }
        }
        public string PodajWynik(double prawdop, string pierwsza, string druga)
        {
            Random random = new Random();

            int losowa = random.Next(1, 100);

            if(losowa < (prawdop * 100))
            {
                return druga;
            }else if(losowa == (prawdop * 100))
            {
                return "remis";
            }
            else
            {
                return pierwsza;
            }
        }
    }
}   
