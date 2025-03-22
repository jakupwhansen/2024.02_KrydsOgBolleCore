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
        public static void AppendOData(string filename, List<int> moves)
        {
            // Go through O's moves => odd indices: 1, 3, 5, ...
            for (int i = 1; i < moves.Count; i += 2)
            {
                // 1) Build the board (9 ints) before O's new move:
                //    0 = empty, 1 = X, 2 = O
                int[] boardBefore = new int[9];

                // Fill in X and O for all moves up to (but NOT including) i-th move
                for (int j = 0; j < i; j++)
                {
                    int pos = moves[j];
                    if (j % 2 == 0)
                    {
                        // X's move
                        boardBefore[pos] = 1;
                    }
                    else
                    {
                        // O's move
                        boardBefore[pos] = 2;
                    }
                }

                // 2) "Output" array: use 1 to mark the new O position, otherwise 0
                int[] oMoveArray = new int[9];
                oMoveArray[moves[i]] = 1; // <-- CHANGED HERE (was '2')

                // 3) Convert both arrays to comma-separated strings
                string boardString = string.Join(",", boardBefore);
                string oMoveString = string.Join(",", oMoveArray);

                // Example: "1,0,0,0,0,0,0,0,0 {0,0,0,0,1,0,0,0,0}"
                string line = $"{boardString} {{{oMoveString}}}";

                // Append line to the file
                File.AppendAllText(filename, line + Environment.NewLine);
            }
        }
    }
}
