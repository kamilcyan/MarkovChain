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
            int randomIndex = random.Next(0, wyrazy.Length - 1);
            string badana = wyrazy[randomIndex];
            string zwyciesca = null;

            int szukanyIndeks = randomIndex;
           
            Console.WriteLine("wylosowany 1 wyraz: " + badana);

            Console.WriteLine("Ma indeks: " + szukanyIndeks);

            for(int i = 0; i< wyrazy.Length; i++)
            {
                zwyciesca = PodajWynik(prawdopodobienstwa[szukanyIndeks, i], badana, wyrazy[i]);
                Console.WriteLine("Zwyc {0} meczu to:  {1}, walczy ", i, zwyciesca);
                Console.WriteLine(wyrazy[i]);
            }
        }
        public string PodajWynik(double prawdop, string pierwsza, string druga)
        {
            Random random = new Random();

            int losowa = random.Next(1, 100);

            if(losowa < (prawdop * 100))
            {
                return druga;
            }
            else
            {
                return pierwsza;
            }
        }


    }
}   
