using KrydsOgBolleCore;

KrydsOgBolle kb = new KrydsOgBolle();

while (true)
{
    Console.Clear();
    List<int> p = kb.getGame();
    Console.WriteLine(p[0] + " | " + p[1] + " | " + p[2]);
    Console.WriteLine("---------");
    Console.WriteLine(p[3] + " | " + p[4] + " | " + p[5]);
    Console.WriteLine("---------");
    Console.WriteLine(p[6] + " | " + p[7] + " | " + p[8]);
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