using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace _0413
{
    class Program
    {
        struct Adatok
        {
            public int Azonosito;
            public string IngatlanHelye;
            public int IngatlanSzama;
            public int Alapterulet;
            public int IngatlanAra;
        }
        static List<Adatok> ugyfelek = new List<Adatok>();
        static List<Adatok> ingatlanok = new List<Adatok>();

        static void UjUgyfel()
        {
            Console.WriteLine("Kérem adja meg az ügyfél nevét:");
            string nev = Console.ReadLine();
            Console.WriteLine("Kérem adja meg az ügyfél telefonszámát:");
            string telefonszam = Console.ReadLine();
            Console.WriteLine("Kérem adja meg az ügyfél azonosítóját:");
            int azonosito = Convert.ToInt32(Console.ReadLine());
            StreamWriter ujAllomany = new StreamWriter("UjUgyfelek.txt", true);
            ujAllomany.WriteLine($"{nev}\t{telefonszam}\t{azonosito}");
            ujAllomany.Close();
            Console.WriteLine("Az ügyfél sikeresen hozzáadva!");
        }

        static void UjIngatlan()
        {
            Console.WriteLine("Kérem adja meg az ingatlan címét:");
            string cim = Console.ReadLine();
            Console.WriteLine("Kérem adja meg az ingatlan árát:");
            int ar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kérem adja meg az ingatlan tulajdonosának a nevét:");
            string tulajdonos = Console.ReadLine();
            Adatok ingatlan = new Adatok { IngatlanHelye = cim, IngatlanAra = ar, IngatlanSzama = ingatlanok.Count + 1 };
            StreamWriter ujAllomany = new StreamWriter("UjIngatlanok.txt", true);
            ujAllomany.WriteLine($"{ingatlan.IngatlanSzama}\t{cim}\t{ar}\t{tulajdonos}");
            ujAllomany.Close();
            ingatlanok.Add(ingatlan);
            Console.WriteLine("Az ingatlan sikeresen hozzáadva!");
        }

        static void IngatlanTorles()
        {
            Console.WriteLine("Adja meg az ingatlan címét amit törölni fog:");
            string cimek = Console.ReadLine();
            for (int i = 0; i < ingatlanok.Count; i++)
            {
                if (ingatlanok[i].IngatlanHelye == cimek)
                {
                    ingatlanok.RemoveAt(i);
                    Console.WriteLine("Az ingatlan sikeresen eltávolítva.");
                    return;
                }
            }
            Console.WriteLine("Az ingatlan nem található!");
        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine(" Válasszon egy opciót");
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