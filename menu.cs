using System;

namespace ingatlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            string[] menupontok = { "1. Új ügyfél felvétele", "2. Új ingatlan felvétele", "3. Már eladott ingatlan törlése", "4. Meglévő adatok kiírása", "Esc: Kilépés" };
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
                        Console.WriteLine("Ügyfeles");
                        break;
                    case '2':
                        Console.WriteLine("Ingatlanos");
                        break;
                    case '3':
                        Console.WriteLine("Eladott ingatlanos");
                        break;
                    case '4':
                        Console.WriteLine("Meglévő adatos");
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
