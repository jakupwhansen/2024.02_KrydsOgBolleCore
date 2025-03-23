using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KrydsOgBolleCore
{
    public static class TicTacToeDataSaver
    {
        /// <summary>
        /// Appends data rows for each O move in the given moves array.
        ///
        /// For each O-move at index i (i = 1,3,5,...):
        ///   1) Build the "board before O's new move" as 9 integers:
        ///      - 1 = X has played here
        ///      - 2 = O has played here
        ///      - 0 = empty
        ///   2) Build the "new O move" as 9 integers:
        ///      - Exactly one cell = 1 (the O move), the rest = 0
        ///   3) Append a line:  "<board> {<newOMoveArray>}"
        ///       to the file.
        /// </summary>
        public static void AppendOData(string filename, List<int[]> listX, List<int[]> listO)
        {
            int i = 0;
            string samlet = "";
            while (i < listX.Count)  //Der er altid samme antal i listX og ListO fordi List0 er den sidste som slår og vinder.
            { 
                
                int j = 0;
                while (j < listX[i].Length )
                {
                    samlet += listX[i][j]+ ",";
                    j++;
                }
                int k = 0;
                //Fjerner sidste komma her:
                samlet = samlet.Remove(samlet.Length - 1);

                samlet =  samlet + "{";
                while (k < listO[i].Length)
                {
                    samlet += listO[i][k] + ",";
                    k++;
                }
                samlet =  samlet + "}" + Environment.NewLine;
               
                i++;
            }

            // Example: "1,0,0,0,0,0,0,0,0 {0,0,0,0,1,0,0,0,0}"
            File.AppendAllText(filename, samlet );

        }
    }
}
