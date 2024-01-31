using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrydsOgBolleCore
{
    public class KrydsOgBolle
    {
        public List<int> listenAfxogy = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public int aktivPlayer = 1; //1 eller 2 er aktive.

        public bool move(int pos)
        {
            bool svar = false;
            if (listenAfxogy[pos]==0)
            {
                listenAfxogy[pos] = aktivPlayer;
                //---Ændrer spiller--------------
                if (aktivPlayer == 1)
                    aktivPlayer = 2;
                else
                    aktivPlayer = 1;
                //------------------------------
                svar = true;
            }
            return svar;
        }
        public List<int> getGame()
        {
            return listenAfxogy;
        }
        public void resetGame()
        {
            listenAfxogy = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    }
}
