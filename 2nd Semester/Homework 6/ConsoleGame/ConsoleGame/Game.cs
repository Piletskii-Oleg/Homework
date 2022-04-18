namespace ConsoleGame;

using static Console;
using ConsoleGame.Exceptions;

public class Game
{
    private readonly char[,] walls;

    private (int, int) playerPosition;

    public (int, int) PositionInMatrix { get; private set; }

    public Game(string path)
    {
        walls = LoadMap(path);
    }

    public void OnLeft(object? sender, EventArgs args)
    {
        if (playerPosition.Item2 - 1 >= 0 &&
            walls[playerPosition.Item1, playerPosition.Item2 - 1] == ' ')
        {
            playerPosition.Item2--;
        }
    }

    public void OnRight(object? sender, EventArgs args)
    {
        if (playerPosition.Item2 + 1 < walls.GetLength(1) &&
            walls[playerPosition.Item1, playerPosition.Item2 + 1] == ' ')
        {
            playerPosition.Item2++;
        }
    }

    public void OnDown(object? sender, EventArgs args)
    {
        if (playerPosition.Item1 + 1 < walls.GetLength(0) &&
            walls[playerPosition.Item1 + 1, playerPosition.Item2] == ' ')
        {
            playerPosition.Item1++;
        }
    }

    public void OnUp(object? sender, EventArgs args)
    {
        if (playerPosition.Item1 - 1 >= 0
            && walls[playerPosition.Item1 - 1, playerPosition.Item2] == ' ')
        {
            playerPosition.Item1--;
        }
    }

    public void OnEsc(object? sender, EventArgs args)
    {
        SetCursorPosition(0, walls.GetLength(0) + 1);
        Write("Thanks for playing!");
    }

    public void UpdatePosition(object? sender, EventArgs args)
    {
        Write(' ');
        ChangePosition(playerPosition);
    }

    private void ChangePosition((int, int) newPosition)
    {
        SetCursorPosition(newPosition.Item2, newPosition.Item1);
        Write('@');
        SetCursorPosition(newPosition.Item2, newPosition.Item1);
        playerPosition = newPosition;
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
                    playerPosition = (i, j);
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

    public void StartConsole()
    {
        for (int i = 0; i < walls.GetLength(0); i++)
        {
            for (int j = 0; j < walls.GetLength(1); j++)
            {
                if ((i, j) == playerPosition)
                {
                    Write('@');
                }
                else
                {
                    Write(walls[i, j]);
                }
            }
            WriteLine();
        }

        WriteLine("Press Escape to quit");
        SetCursorPosition(playerPosition.Item2, playerPosition.Item1);
    }
}
