namespace ConsoleGame;

using static Console;
using ConsoleGame.Exceptions;

public class Game
{
    private readonly char[,] walls;

    public Game(string path)
    {
        walls = LoadMap(path);
        Spawn();
    }

    public void OnLeft(object? sender, EventArgs args)
    {
        if (CursorLeft - 2 >= 0 && CursorLeft <= walls.GetLength(1) && walls[CursorTop, CursorLeft - 2] == ' ')
        {
            CursorLeft--;
            Write(' ');
            CursorLeft -= 2;
            Write("@");
        }
    }

    public void OnRight(object? sender, EventArgs args)
    {
        if (CursorLeft >= 0 && CursorLeft < walls.GetLength(1) && walls[CursorTop, CursorLeft] == ' ')
        {
            RemoveCharacter();
            Write("@");
        }
    }

    public void OnDown(object? sender, EventArgs args)
    {
        if (CursorTop + 1 < walls.GetLength(0) && CursorLeft - 1 < walls.GetLength(1) && walls[CursorTop + 1, CursorLeft - 1] == ' ')
        {
            RemoveCharacter();
            CursorLeft--;
            CursorTop++;
            Write("@");
        }
    }

    public void OnUp(object? sender, EventArgs args)
    { 
        if (CursorTop - 1 >= 0 && CursorTop < walls.GetLength(0) && walls[CursorTop - 1, CursorLeft - 1] == ' ')
        {
            RemoveCharacter();
            CursorLeft--;
            CursorTop--;
            Write("@");
        }
    }

    public void OnEsc(object? sender, EventArgs args)
    {
        SetCursorPosition(0, walls.GetLength(0) + 1);
        Write("Thanks for playing!");
    }

    private static void RemoveCharacter()
    {
        CursorLeft--;
        Write(' ');
    }

    private static char[,] LoadMap(string path)
    {
        using var reader = new StreamReader(File.OpenRead(path));
        var line = string.Empty;
        int sizeX = 0;
        int sizeY = 0;
        while ((line = reader.ReadLine()) != null)
        {
            WriteLine(line);
            if (line.Length > sizeX)
            {
                sizeX = line.Length;
            }

            sizeY++;
        }

        if (sizeX == 0 && sizeY == 0)
        {
            throw new EmptyMapException();
        }

        WriteLine("Press Escape to quit");

        var map = new char[sizeY, sizeX];
        reader.BaseStream.Seek(0, SeekOrigin.Begin);
        for (int i = 0; i < sizeY; i++)
        {
            line = reader.ReadLine();
            for (int j = 0; j < line!.Length; j++)
            {
                map[i, j] = line[j];
            }

            if (line.Length < sizeX)
            {
                for (int j = line.Length; j < sizeX; j++)
                {
                    map[i, j] = ' ';
                }
            }
        }

        return map;
    }

    private void Spawn()
    {
        bool hasFreeSpace = false;
        bool spawned = false;
        for (int i = 0; i < walls.GetLength(0); i++)
        {
            for (int j = 0; j < walls.GetLength(1); j++)
            {
                if (walls[i, j] == '@')
                {
                    SetCursorPosition(j, i);
                    Write('@');
                    walls[i, j] = ' ';
                    spawned = true;
                }

                if (walls[i, j] == ' ')
                {
                    hasFreeSpace = true;
                }

                if (spawned && hasFreeSpace)
                {
                    return;
                }
            }
        }

        if (!spawned)
        {
            throw new NoSpawnPointException();
        }

        if (!hasFreeSpace)
        {
            throw new NoSpaceToMoveException();
        }
    }
}
