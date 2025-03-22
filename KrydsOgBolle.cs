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
        /// <summary>
        /// Tjekker om der er en vinder.
        /// Returnerer:
        /// - 1, hvis spiller 1 har vundet
        /// - 2, hvis spiller 2 har vundet
        /// - 0, hvis ingen har vundet
        /// </summary>
        public int CheckForWinner()
        {
            // Alle vinder-kombinationer i 3x3 brættet:
            int[][] vinderrækker = new int[][]
            {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
            };

            foreach (var rk in vinderrækker)
            {
                // Hvis feltet ikke er 0 (altså enten 1 eller 2) og 
                // alle felter i rækken er ens, så har vi en vinder.
                if (listenAfxogy[rk[0]] != 0 &&
                    listenAfxogy[rk[0]] == listenAfxogy[rk[1]] &&
                    listenAfxogy[rk[1]] == listenAfxogy[rk[2]])
                {
                    return listenAfxogy[rk[0]];
                }
            }

            // Ingen har vundet
            return 0;
        }
    }
}
