using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KrydsOgBolleCore
{


    public static class DataSaver
    {
        /// <summary>
        /// Giver du denne metode hele rækken af træk (f.eks. 0, 3, 1, 5, 7, 4),
        /// så gemmer den en linje for hver O-træk (ulige index) i formatet:
        /// 
        /// 0 {3}
        /// 0, 3, 1 {5}
        /// 0, 3, 1, 5, 7 {4}
        /// 
        /// - Tilføjer (Append) linjerne i filen (overskriver ikke).
        /// - Hvis X starter, er X altid på index 0, 2, 4... og O på index 1, 3, 5...
        /// </summary>
        public static void AppendMovesAfterO(string filnavn, List<int> allMoves)
        {
            // Loop igennem alle træk
            for (int i = 0; i < allMoves.Count; i++)
            {
                // Check om indexet er ulige => O's tur
                if (i % 2 == 1)
                {
                    // Tag hele historikken indtil O's træk (dvs. index i)
                    List<int> partialMoves = allMoves.Take(i + 1).ToList();

                    // Formatér string med alt på komma nær sidste træk, som kommer i { }
                    // Hvis listen kun har én værdi (teoretisk), bliver det: {val}
                    // Ellers: "val1, val2, val3 ... {sidsteVal}"

                    // Hvis partialMoves har mere end 1 element, adskil alle undtagen sidste med komma
                    if (partialMoves.Count > 1)
                    {
                        string allButLast = string.Join(", ", partialMoves.Take(partialMoves.Count - 1));
                        string last = $"{{{partialMoves[^1]}}}"; // Sidste element i {} (krøllede parenteser)
                                                                 // Linjen kan fx blive "0, 3, 1 {5}"
                        string line = $"{allButLast} {last}";
                        File.AppendAllText(filnavn, line + Environment.NewLine);
                    }
                    else
                    {
                        // Hvis kun 1 element (teoretisk), så bliver det f.eks. "{3}"
                        File.AppendAllText(filnavn, $"{{{partialMoves[0]}}}" + Environment.NewLine);
                    }
                }
            }
        }
    }
}