using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Wyrazy
    {
        string[] wyrazy = {"zerowy", "pierwszy", "drugi", "trzeci", "czwarty"};
        
        public void Symulacja()
        {

            Dictionary<int, double> slownik = new Dictionary<int, double>();
            slownik = TworzenieSlownika(0);

            string szukana = WyborWyrazu(slownik);
        }

        void RysujSlownik(Dictionary<int, double> s)
        {

            foreach (var item in s)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        public Dictionary<int, double> TworzenieSlownika(int indeks)
        {
            double suma = 0;

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

            RysujSlownik(slownik);

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
