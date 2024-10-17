namespace SabungRobot;

class Program{
    static void Main(string[] args)
    {
        Console.WriteLine($"\n==============================================");
        Console.WriteLine($"============ Bakar Robot Musuhmu =============");
        Console.WriteLine($"==============================================");
        Permainan game = new Permainan();
        game.Pilih_Robot();
        game.Mulai_Permainan();
    }
}



