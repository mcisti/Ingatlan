using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace proba
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
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string[] menupontok = { "1. Új ügyfél felvétele", "2. Új ingatlan felvétele", "3. Már eladott ingatlan törlése", "4. Ajánlat kérése", "5. Meglévő adatok kiírása", "Esc: Kilépés" };
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menupontok.Length; i++)
                {
                    Console.WriteLine(menupontok[i]);
                }
                char valasz = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (valasz)
                {
                    case '1':
                        UjUgyfel();
                        break;
                    case '2':
                        UjIngatlan();
                        break;
                    case '3':
                        IngatlanTorles();
                        break;
                    case '4':
                        Console.WriteLine("Ajánlatok");
                        break;
                    case '5':
                        Console.WriteLine("Meglévő adatok");
                        break;
                    case ((char)ConsoleKey.Escape):
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Nincs Ilyen menüpont!");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
