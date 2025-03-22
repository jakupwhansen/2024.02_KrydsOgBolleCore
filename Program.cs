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
        //   1,0,0,0,0,0,0,0,0 {0,0,0,0,1,0,0,0,0}
        //   1,0,0,0,2,0,0,1,0 {0,1,0,0,0,0,0,0,0}
        TicTacToeDataSaver.AppendOData("dataset.txt", listenAfxogyHistory);
        
        Console.WriteLine("Tryk 'n' for nyt spil, eller 'train' for at træne DNN");
        String space = Console.ReadLine();
        
        if (space == "n")
            kb.resetGame();
        if (space == "train")
        {
            DNN_Trainer dnn = new DNN_Trainer();
            dnn.DNN_Setup();
            dnn.DNN_Import_Weights();
            String hentet = System.IO.File.ReadAllText(@"dataset.txt");
            dnn.DNN_Train_Again(hentet, 10000);
            dnn.DNN_Export_Weights();

        }
            
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

    //---------------Tester modellen her.------------------------------

    DNN_Trainer dnn2 = new DNN_Trainer();
    dnn2.DNN_Setup();
    dnn2.DNN_Import_Weights();
    List<double> doubleList = kb.getGame().Select(i => (double)i).ToList();
    dnn2.DNN_Make_Predictions(doubleList);
    //--------------------------------------------------

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

/// <summary>
/// Konverterer et board-array (9 felter: 0=tom, 1=X, 2=O) 
/// til en streng som "1,0,0,0,2,0,0,1,0".
/// </summary>
static string BoardToString(int[] board)
{
    if (board == null || board.Length != 9)
        throw new ArgumentException("board skal være et int-array med præcis 9 felter.");

    return string.Join(",", board);
}
