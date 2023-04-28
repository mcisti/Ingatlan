using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace nev
{
    class Program
    {
        struct ingatlan
        {
            public int Azonosito;
            public string IngatlanHelye;
            public int IngatlanSzama;
            public int Alapterulet;
            public int IngatlanAra;
        }
        struct ugyfel
        {
            public int azonosito;
            public string nev;
            public string tel;

        }
        static List<ugyfel> ugyfelek = new List<ugyfel>();
        static List<ingatlan> ingatlanok = new List<ingatlan>();

        static void UjUgyfel()
        {
            Console.WriteLine("Kérem adja meg az ügyfél nevét:");
            string nev = Console.ReadLine();
            Console.WriteLine("Kérem adja meg az ügyfél telefonszámát:");
            string telefonszam = Console.ReadLine();
            Console.WriteLine("Kérem adja meg az ügyfél azonosítóját:");
            int azonosito = Convert.ToInt32(Console.ReadLine());
            StreamWriter ujAllomany = new StreamWriter("ugyfelek.txt", true);
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
            ingatlan ingatlan = new ingatlan { IngatlanHelye = cim, IngatlanAra = ar, IngatlanSzama = ingatlanok.Count + 1 };
            StreamWriter ujAllomany = new StreamWriter("ingatlanok.txt", true);
            ujAllomany.WriteLine($"{ingatlan.IngatlanSzama}  \t{cim}\t{ar}\t{tulajdonos}");
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
        static void ajanlat()
        {
            Console.WriteLine("Kérem adja meg a felhasznalói kódját: ");
            int kod = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg a mai dátumot: (pl: 20230414)");
            int datum = int.Parse(Console.ReadLine());
            StreamWriter allomany2 = new StreamWriter($"{kod}_{datum}.txt");
            allomany2.WriteLine("Ügyfélkód:{0} Dátum:{1}", kod, datum);
            allomany2.WriteLine("AZON Cím\t                             \tAlapter.   \tÁr");
            for (int i = 0; i < ingatlanok.Count; i++)
            {

                allomany2.WriteLine("{0} {1}\t                           {2}   \t{3}", ingatlanok[i].Azonosito, ingatlanok[i].IngatlanHelye, ingatlanok[i].IngatlanSzama, ingatlanok[i].IngatlanAra);
            }
            allomany2.Close();
        }
        static void kiiras()
        {
            string[] kiiras = File.ReadAllLines("ingatlanok.txt");
            for (int i = 0; i < kiiras.Length; i++)
            {
                Console.WriteLine(kiiras[i]);
            }
        }
        static void Main(string[] args)
        {
            string[] ingatlanfalj = File.ReadAllLines("ingatlanok.txt");
            for (int i = 0; i < ingatlanfalj.Length; i++)
            {
                ingatlan ujingatlan = new ingatlan();
                ujingatlan.Azonosito = int.Parse(ingatlanfalj[i].Split("\t")[0]);
                ujingatlan.IngatlanHelye = ingatlanfalj[i].Split("\t")[1];
                ujingatlan.IngatlanSzama = int.Parse(ingatlanfalj[i].Split("\t")[2]);
                ujingatlan.IngatlanAra = int.Parse(ingatlanfalj[i].Split("\t")[3]);
                ingatlanok.Add(ujingatlan);
            }
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
                        ajanlat();
                        break;
                    case '5':
                        kiiras();
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
