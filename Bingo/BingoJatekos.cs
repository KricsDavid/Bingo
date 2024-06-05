using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    internal class BingoJatekos
    {
        public string Nev { get; set; }
        public int[,] Kartya { get; set; }
        public bool[,] Talalatok { get; set; }

        public BingoJatekos(string nev, int[,] kartya)
        {
            Nev = nev;
            Kartya = kartya;
            Talalatok = new bool[5, 5];
        }

        public void SorsoltSzamotJelol(int szam)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Kartya[i, j] == szam)
                    {
                        Talalatok[i, j] = true;
                    }
                }
            }
        }


        public bool BingoEll()
        {
            // vízszintes nyerés
            for (int i = 0; i < 5; i++)
            {
                bool nyert = true;
                for (int j = 0; j < 5; j++)
                {
                    if (!Talalatok[i, j])
                    {
                        nyert = false;
                        break;
                    }
                }
                if (nyert)
                {
                    return true;
                }
            }

            // függőleges nyerés
            for (int j = 0; j < 5; j++)
            {
                bool nyert = true;
                for (int i = 0; i < 5; i++)
                {
                    if (!Talalatok[i, j])
                    {
                        nyert = false;
                        break;
                    }
                }
                if (nyert)
                {
                    return true;
                }
            }

            // átlós nyerés
            bool nyert1 = true;
            bool nyert2 = true;
            for (int i = 0; i < 5; i++)
            {
                if (!Talalatok[i, i])
                {
                    nyert1 = false;
                }
                if (!Talalatok[i, 4 - i])
                {
                    nyert2 = false;
                }
            }
            if (nyert1 || nyert2)
            {
                return true;
            }

            return false;
        }

    }
}
