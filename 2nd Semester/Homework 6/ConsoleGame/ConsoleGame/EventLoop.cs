namespace ConsoleGame;

/// <summary>
/// Allows for usage of key presses by user.
/// </summary>
public class EventLoop
{
    /// <summary>
    /// Handles actions directed to the left.
    /// </summary>
    public event EventHandler<EventArgs> LeftHandler = (_, _) => { };

    /// <summary>
    /// Handles actions directed to the right.
    /// </summary>
    public event EventHandler<EventArgs> RightHandler = (_, _) => { };

    /// <summary>
    /// Handles actions directed down.
    /// </summary>
    public event EventHandler<EventArgs> DownHandler = (_, _) => { };

    /// <summary>
    /// Handles actions directed up.
    /// </summary>
    public event EventHandler<EventArgs> UpHandler = (_, _) => { };

    /// <summary>
    /// Handles actions assigned to Escape button.
    /// </summary>
    public event EventHandler<EventArgs> EscHandler = (_, _) => { };

    /// <summary>
    /// Processes user input.
    /// </summary>
    public void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    this.LeftHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.RightArrow:
                    this.RightHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.DownArrow:
                    this.DownHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.UpArrow:
                    this.UpHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.Escape:
                    this.EscHandler(this, EventArgs.Empty);
                    isRunning = false;
                    break;
            }
        }
    }
}