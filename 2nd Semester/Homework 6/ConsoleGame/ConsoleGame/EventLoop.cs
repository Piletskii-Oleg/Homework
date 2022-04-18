namespace ConsoleGame;

public class EventLoop
{
    public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

    public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

    public event EventHandler<EventArgs> DownHandler = (sender, args) => { };

    public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

    public event EventHandler<EventArgs> EscHandler = (sender, args) => { };

    public void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    LeftHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.RightArrow:
                    RightHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.DownArrow:
                    DownHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.UpArrow:
                    UpHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.Escape:
                    EscHandler(this, EventArgs.Empty);
                    isRunning = false;
                    break;
            }
        }
    }
}