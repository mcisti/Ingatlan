using System;
using System.Collections.Generic;

namespace _0413
{
    class Program
    {
        static List<string> Ugyfelek = new List<string>();
        static List<string> ingatlanok = new List<string>();

        static void UjUgyfel()
        {
            Console.WriteLine("Kérem adja meg az ügyfél nevét");
            string nev = Console.ReadLine();


        }
        static void UjIngatlan()
        {

        }
        static void IngatlanTorles()
        {

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n Válasszon egy opciót");
                Console.WriteLine("1. új ügyfél felvétele");
                Console.WriteLine("2.Új ingatlan felvétele ");
                Console.WriteLine("3.Leadott ingatlan törlése");
                Console.WriteLine("4.Kilépés");
                string menu = Console.ReadLine();
                Console.Clear();
                switch (menu)
                {
                    case "1":
                        UjUgyfel();
                        break;
                    case "2":
                        UjIngatlan();
                        break;
                    case "3":
                        IngatlanTorles();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Érvénytelen opció");
                        break;


                }
            }
            
           
        }
    }
}
