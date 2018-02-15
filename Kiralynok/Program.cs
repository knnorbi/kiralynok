using System;
using System.Collections.Generic;
using System.IO;

namespace Kiralynok
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabla t1 = new Tabla('@');
            Console.WriteLine("Üres tábla:");
            t1.Megjelenit();

            t1.Elhelyez(8);
            Console.WriteLine("Tábla 8 királynővel:");
            t1.Megjelenit();

            Console.WriteLine("Üres oszlopok száma: {0}", t1.UresOszlopokSzama);
            Console.WriteLine("Üres sorok száma: {0}", t1.UresSorokSzama);

            string file = "tablak64.txt";
            if (File.Exists(file))
                File.Delete(file);

            List<Tabla> tablak = new List<Tabla>();
            for (int i = 1; i <= 64; i++)
            {
                Tabla tabla = new Tabla('*');
                tabla.Elhelyez(i);
                tablak.Add(tabla);
            }

            using(StreamWriter strwr = new StreamWriter(file, true))
            {
                foreach (Tabla tabla in tablak)
                    strwr.WriteLine(tabla);
            }


            Console.ReadKey();
        }
    }
}
