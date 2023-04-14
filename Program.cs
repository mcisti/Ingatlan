using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

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
            Console.WriteLine("Kérem adja meg az ügyfél telefonszámát");
            string telefonszam = Console.ReadLine();
            Console.WriteLine("Kérem adja meg az ügyfél azonosítóját");
            string azonosito = Console.ReadLine();
            StreamWriter ujAllomany = new StreamWriter("UjUgyfelek.txt");
            ujAllomany.WriteLine($"{nev}\t{telefonszam}\t{azonosito}");
            ujAllomany.Close();
            Ugyfelek.Add($"{nev}\t{telefonszam}\t{azonosito}");
            Console.WriteLine("Az ügyfél sikeresen hozzáadva!");
            
        }
        static void UjIngatlan()
        {
            Console.WriteLine("Kérem adja meg az ingatlan címét");
            string cim = Console.ReadLine();
            Console.WriteLine("Kérem adja meg az ingatlan árát");
            int ar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kérem adja meg az ingatlan Tulajdonosának a nevét");
            string tulajdonos = Console.ReadLine();
            StreamWriter ujAllomany = new StreamWriter("UjIngatlanok.txt");
            ujAllomany.WriteLine($"{cim}\t{ar}\t{tulajdonos}");
            ujAllomany.Close();
            ingatlanok.Add($"{cim}\t{ar}\t{tulajdonos}");
            Console.WriteLine("Az ingatlan sikeresen hozzáadva!");




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