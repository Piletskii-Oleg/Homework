namespace ConsoleGame;

using ConsoleGame.Exceptions;

/// <summary>
/// A console game where player moves within walls using directional keys.
/// </summary>
public class Game
{
    private readonly char[,] walls;

    private (int, int) playerPosition;

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    /// <param name="path">Path to the map.</param>
    public Game(string path)
    {
        this.walls = this.LoadMap(path);
    }

    /// <summary>
    /// Gets current position of the player.
    /// </summary>
    public (int, int) Position { get => this.playerPosition; }

    /// <summary>
    /// Corresponds to the player moving left.
    /// </summary>
    /// <param name="sender">References object that raised the event.</param>
    /// <param name="args">Event data.</param>
    public void OnLeft(object? sender, EventArgs args)
    {
        if (this.playerPosition.Item2 - 1 >= 0 &&
            this.walls[this.playerPosition.Item1, this.playerPosition.Item2 - 1] == ' ')
        {
            this.playerPosition.Item2--;
        }
    }

    /// <summary>
    /// Corresponds to the player moving right.
    /// </summary>
    /// <param name="sender">References object that raised the event.</param>
    /// <param name="args">Event data.</param>
    public void OnRight(object? sender, EventArgs args)
    {
        if (this.playerPosition.Item2 + 1 < this.walls.GetLength(1) &&
            this.walls[this.playerPosition.Item1, this.playerPosition.Item2 + 1] == ' ')
        {
            this.playerPosition.Item2++;
        }
    }

    /// <summary>
    /// Corresponds to the player moving down.
    /// </summary>
    /// <param name="sender">References object that raised the event.</param>
    /// <param name="args">Event data.</param>
    public void OnDown(object? sender, EventArgs args)
    {
        if (this.playerPosition.Item1 + 1 < this.walls.GetLength(0) &&
            this.walls[this.playerPosition.Item1 + 1, this.playerPosition.Item2] == ' ')
        {
            this.playerPosition.Item1++;
        }
    }

    /// <summary>
    /// Corresponds to the player moving up.
    /// </summary>
    /// <param name="sender">References object that raised the event.</param>
    /// <param name="args">Event data.</param>
    public void OnUp(object? sender, EventArgs args)
    {
        if (this.playerPosition.Item1 - 1 >= 0
            && this.walls[this.playerPosition.Item1 - 1, this.playerPosition.Item2] == ' ')
        {
            this.playerPosition.Item1--;
        }
    }

    /// <summary>
    /// Corresponds to the player exiting.
    /// </summary>
    /// <param name="sender">References object that raised the event.</param>
    /// <param name="args">Event data.</param>
    public void OnEsc(object? sender, EventArgs args)
    {
        Console.SetCursorPosition(0, this.walls.GetLength(0) + 1);
        Console.Write("Thanks for playing!");
    }

    /// <summary>
    /// Updates player's position.
    /// </summary>
    /// <param name="sender">References object that raised the event.</param>
    /// <param name="args">Event data.</param>
    public void UpdatePosition(object? sender, EventArgs args)
    {
        Console.Write(' ');
        this.ChangePosition(this.playerPosition);
    }

    /// <summary>
    /// Enables console display.
    /// </summary>
    public void StartConsole()
    {
        for (int i = 0; i < this.walls.GetLength(0); i++)
        {
            for (int j = 0; j < this.walls.GetLength(1); j++)
            {
                if ((i, j) == this.playerPosition)
                {
                    Console.Write('@');
                }
                else
                {
                    Console.Write(this.walls[i, j]);
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine("Press Escape to quit");
        Console.SetCursorPosition(this.playerPosition.Item2, this.playerPosition.Item1);
    }

    private void ChangePosition((int, int) newPosition)
    {
        Console.SetCursorPosition(newPosition.Item2, newPosition.Item1);
        Console.Write('@');
        Console.SetCursorPosition(newPosition.Item2, newPosition.Item1);
        this.playerPosition = newPosition;
    }

    private char[,] LoadMap(string path)
    {
        using var reader = new StreamReader(File.OpenRead(path));
        var line = string.Empty;
        int rowCount = 0;
        int columnCount = 0;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Length > columnCount)
            {
                columnCount = line.Length;
            }

            rowCount++;
        }

        if (rowCount == 0 && columnCount == 0)
        {
            throw new EmptyMapException();
        }

        var map = new char[rowCount, columnCount];
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        bool hasSpawnPoint = false;
        bool hasSpace = false;
        for (int i = 0; i < rowCount; i++)
        {
            line = reader.ReadLine();
            for (int j = 0; j < line!.Length; j++)
            {
                map[i, j] = line[j];
                if (line[j] == '@')
                {
                    this.playerPosition = (i, j);
                    map[i, j] = ' ';
                    hasSpawnPoint = true;
                }
                else if (line[j] == ' ')
                {
                    hasSpace = true;
                }
            }

            if (line.Length < columnCount)
            {
                hasSpace = true;
                for (int j = line.Length; j < columnCount; j++)
                {
                    map[i, j] = ' ';
                }
            }
        }

        if (!hasSpawnPoint)
        {
            throw new NoSpawnPointException();
        }
        else if (!hasSpace)
        {
            throw new NoSpaceToMoveException();
        }

        return map;
    }
}
