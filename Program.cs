using KrydsOgBolleCore;

KrydsOgBolle kb = new KrydsOgBolle();
IDictionary<int, string> xo = new Dictionary<int, string>();
xo.Add(0, " ");
xo.Add(1, "X"); //adding a key/value using the Add() method
xo.Add(2, "O");
while (true)
{
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
        kb.move(i);
    }
    catch (Exception ex) { }
}