using KrydsOgBolleCore;
using System.Runtime.CompilerServices;
List<int> listenAfxogyHistory = new List<int>();
KrydsOgBolle kb = new KrydsOgBolle();
IDictionary<int, string> xo = new Dictionary<int, string>();
xo.Add(0, " ");
xo.Add(1, "X"); //adding a key/value using the Add() method
xo.Add(2, "O");
while (true)
{
    //----Tjek for vinder--------------------------------------------------
    int vinder = kb.CheckForWinner();
    if (vinder == 1)
    {
        Console.WriteLine("Kryds har vundet.");
    }
    if (vinder == 2)
    {
        Console.WriteLine("Bolle har vundet.");
        var data2 = new List<int> { 1, 2, 3, 4 };        

        
        //   1,0,0,0,0,0,0,0,0 {0,0,0,0,1,0,0,0,0}
        //   1,0,0,0,2,0,0,1,0 {0,1,0,0,0,0,0,0,0}
        TicTacToeDataSaver.AppendOData("dataset.txt", listenAfxogyHistory);
        
        Console.WriteLine("Tryk 'n' for nyt spil");
        String space = Console.ReadLine();
        if (space == "n")
            kb.resetGame();
    }
    //------------------------------------------------------------------
    Console.Clear();
    List<int> p = kb.getGame();
    Console.WriteLine(xo[p[0]] + " | " + xo[p[1]] + " | " + xo[p[2]]);
    Console.WriteLine("---------");
    Console.WriteLine(xo[p[3]] + " | " + xo[p[4]] + " | " + xo[p[5]]);
    Console.WriteLine("---------");
    Console.WriteLine(xo[p[6]] + " | " + xo[p[7]] + " | " + xo[p[8]]);
    Console.WriteLine("   ");
    Console.WriteLine("Hvilken plads vil du sætte nu?");



    String ind = Console.ReadLine();
    try
    {
        int i = Convert.ToInt32(ind);
        if( kb.move(i))
        {
            //gemme i liste
            listenAfxogyHistory.Add(i);
        }
    }
    catch (Exception ex) { } 
}
