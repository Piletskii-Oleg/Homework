namespace ConsoleGame;

class Program
{
    static void Main()
    {
        string path = "../../../map.txt";
        var eventLoop = new EventLoop();
        var game = new Game(path);

        eventLoop.LeftHandler += game.OnLeft;
        eventLoop.RightHandler += game.OnRight;
        eventLoop.DownHandler += game.OnDown;
        eventLoop.UpHandler += game.OnUp;
        eventLoop.EscHandler += game.OnEsc;

        eventLoop.Run();
    }
}