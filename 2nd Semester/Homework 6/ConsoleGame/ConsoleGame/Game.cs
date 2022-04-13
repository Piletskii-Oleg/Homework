namespace ConsoleGame;

public class Game
{
    public void OnLeft(object sender, EventArgs args)
    {
        try
        {
            Console.CursorLeft--;
            Console.Write(" ");
            Console.CursorLeft -= 2;
            Console.Write("@");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.CursorLeft--;
            Console.Write("@");
        }
    }

    public void OnRight(object sender, EventArgs args)
    {
        if (Console.CursorLeft == 0)
        {
            Console.Write("@");
        }
        else
        {
            RemoveCharacter();
            Console.Write("@");
        }
    }

    public void OnDown(object sender, EventArgs args)
    {
        RemoveCharacter();
        Console.CursorLeft--;
        Console.CursorTop++;
        Console.Write("@");
    }

    public void OnUp(object sender, EventArgs args)
    {
        try
        {
            RemoveCharacter();
            Console.CursorLeft--;
            Console.CursorTop--;
            Console.Write("@");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.Write("@");
        }
    }

    private static void RemoveCharacter()
    {
        Console.CursorLeft--;
        Console.Write(" ");
    }
}
