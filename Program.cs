using KrydsOgBolleCore;
using System.Runtime.CompilerServices;


List < int[]> listenX = new List<int[]>();
List<int[]> listenO = new List<int[]>();
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
        TicTacToeDataSaver.AppendOData("dataset.txt", listenX, listenO);
        
        Console.WriteLine("Data gemt i dataset. Tryk 'n' for nyt spil, eller 'train' for at træne DNN");
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
    Console.WriteLine("Hvilken plads vil du sætte nu? eller vælg train for at træne modellen");
    //-----------------------------------------------------------



    //---------------Bruge Modellen til predictions. ------------------------------

    DNN_Trainer dnn2 = new DNN_Trainer();
    try
    {
        dnn2.DNN_Train_Again_SetUp();
        List<double> doubleList = kb.getGame().Select(i => (double)i).ToList();
        dnn2.DNN_Make_Predictions(doubleList);
    }
    catch (Exception e) {
        Console.WriteLine("Ingen model lavet endnu...");
    }
    
    //--------------------------------------------------

    String ind = Console.ReadLine();

    if (ind == "tf")
    {
        DNN_Trainer dnn = new DNN_Trainer();
        dnn.DNN_Setup_First_time();       
        String hentet = System.IO.File.ReadAllText(@"dataset.txt");
        dnn.DNN_Train_Again(hentet, 20);
        dnn.DNN_Export_Weights();        
    }
    if (ind == "ta")
    {
        DNN_Trainer dnn = new DNN_Trainer();
        dnn.DNN_Train_Again_SetUp();
       
        String hentet = System.IO.File.ReadAllText(@"dataset.txt");
        dnn.DNN_Train_Again(hentet, 100);
        dnn.DNN_Export_Weights();
    }

    try
    {
        int i = Convert.ToInt32(ind);
        if( kb.move(i))
        {
            //gemme i liste
            if (kb.aktivPlayer == 2) //X så gemmer vi hele boardet som det ser ud lige nu.
            {
                listenX.Add(kb.getGame().ToArray());
            }
            if (kb.aktivPlayer == 1)
            {
                int[] ints = new int[9];
                ints[i] = 1;
                listenO.Add(ints);
            }

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
