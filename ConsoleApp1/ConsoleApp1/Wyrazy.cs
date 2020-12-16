using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Wyrazy
    {
        string[] wyrazy = {"zerowy", "pierwszy", "drugi", "trzeci", "czwarty"};

        



        public void Symulacja()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, wyrazy.Length - 1);
            string badana = wyrazy[randomIndex];

            int szukanyIndeks = randomIndex;


            Dictionary<int, double> slow = new Dictionary<int, double>();

            slow = TworzenieSlownika(1);

            foreach(var item in slow)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            WyborWyrazu(slow);

        }

        public Dictionary<int, double> TworzenieSlownika(int indeks)
        {
            double suma = 0;
            double[] tab = new double[2];

            double[,] prawdopodobienstwa = { 
                                         { 0.1, 0.2, 0.3, 0.1, 0.2},
                                         { 0.3, 0.4, 0.1, 0.2, 0.1 },
                                         { 0.1, 0.1, 0.1, 0.5, 0.3 },
                                         { 0.1, 0.1, 0.2, 0.1, 0.3 },
                                         { 0.4, 0.2, 0.3, 0.1, 0.1 },
                                       };
            Dictionary<int, double> slownik = new Dictionary<int, double>();

            for(int i = 0; i< wyrazy.Length; i++)
            {
                suma += prawdopodobienstwa[i, indeks];
                slownik.Add(i, prawdopodobienstwa[i, indeks]);
            }


            return slownik;
        }

        public string WyborWyrazu(Dictionary<int, double> slownik)
        {
            string wybrana;
            double suma = 0;
            double szukana = Losuj();

            Console.WriteLine("szukana " + szukana);

            foreach (var item in slownik)
            {
                suma += item.Value;

                if(szukana /100  < suma && szukana/100 > suma - item.Value)
                {
                    wybrana = wyrazy[item.Key];
                    Console.WriteLine(wybrana);
                    return wybrana;
                }
            }

            return null;
        }

        int Losuj()
        {
            Random random = new Random();
            int wylosowana = random.Next(0, 100);

            return wylosowana;
        }


    }
}   
