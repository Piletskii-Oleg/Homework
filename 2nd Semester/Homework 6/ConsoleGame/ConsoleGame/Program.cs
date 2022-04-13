namespace ConsoleGame;

class Program
{
    static void Main()
    {
        string path = "../../../map.txt";
        using var streamReader = new StreamReader(File.OpenRead(path));
        while (!streamReader.EndOfStream)
        {
            Console.WriteLine(streamReader.ReadLine());
        }

        var eventLoop = new EventLoop();
        var game = new Game();
        eventLoop.LeftHandler += game.OnLeft;
        eventLoop.RightHandler += game.OnRight;
        eventLoop.DownHandler += game.OnDown;
        eventLoop.UpHandler += game.OnUp;

        eventLoop.Run();

    }

    static void PrintLog(List<string> log)
    {
        foreach (var item in log)
        { 
            Console.Write(item + ", ");
        }
        Console.WriteLine();
    }
}