using System;
namespace Kiralynok
{
    public class Tabla
    {
        private string[,] T;
        private char UresCella;

        public int UresOszlopokSzama
        {
            get
            {
                int ures = 0;
                for (int i = 0; i < T.GetLength(1); i++)
                {
                    if (UresOszlop(i))
                        ures++;
                }
                return ures;
            }
        }

        public int UresSorokSzama
        {
            get
            {
                int ures = 0;
                for (int i = 0; i < T.GetLength(0); i++)
                {
                    if (UresSor(i))
                        ures++;
                }
                return ures;
            }
        }

        public Tabla(char c)
        {
            T = new string[8,8];
            UresCella = c;
            for (int k = 0; k < T.GetLength(0); k++)
            {
                for (int b = 0; b < T.GetLength(1); b++)
                    T[k, b] = Convert.ToString(UresCella);
            }
        }

        public void Megjelenit() 
        {
            for (int k = 0; k < T.GetLength(0); k++)
            {
                for (int b = 0; b < T.GetLength(1); b++)
                    Console.Write(T[k, b]);
                Console.Write("\n");
            }   
        }

        public override string ToString()
        {
            string str = "";
            for (int k = 0; k < T.GetLength(0); k++)
            {
                for (int b = 0; b < T.GetLength(1); b++)
                    str += T[k, b];
                str += "\n";
            }
            return str;
        }

        public void Elhelyez(int n)
        {
            Random random = new Random();
            int sikeres = 0;
            while(sikeres < n)
            {
                int hely = random.Next(T.GetLength(0) * T.GetLength(1));
                int sor = hely/T.GetLength(0);
                int oszlop = hely % T.GetLength(1);
                if(T[sor,oszlop] == Convert.ToString(UresCella))
                {
                    T[sor, oszlop] = "K";
                    sikeres++;
                }
            }
        }

        public bool UresSor(int sor)
        {
            if (sor > T.GetLength(0) - 1)
                return false;
            for (int i = 0; i < T.GetLength(1); i++)
            {
                if (T[sor, i] == "K")
                    return false;
            }
            return true;
        }

        public bool UresOszlop(int oszlop) 
        {
            if (oszlop > T.GetLength(1) - 1)
                return false;
            for (int i = 0; i < T.GetLength(0); i++)
            {
                if (T[i, oszlop] == "K")
                    return false;
            }
            return true;
        }
    }
}
