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
    }
}
