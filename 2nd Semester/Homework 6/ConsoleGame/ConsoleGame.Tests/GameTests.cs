namespace ConsoleGame.Tests;

using System;
using NUnit.Framework;
using ConsoleGame.Exceptions;

public class GameTests
{
    [Test]
    public void EmptyMapShouldThrowException()
    {
        Game? game = null;
        string path = "../../../TestFiles/empty.txt";
        Assert.Throws<EmptyMapException>(() => game = new Game(path));
    }

    [Test]
    public void MapWithNoFreeSpaceShouldThrowException()
    {
        Game? game = null;
        string path = "../../../TestFiles/nospace.txt";
        Assert.Throws<NoSpaceToMoveException>(() => game = new Game(path));
    }

    [Test]
    public void MapWithNoSpawnPointShouldThrowException()
    {
        Game? game = null;
        string path = "../../../TestFiles/nospawn.txt";
        Assert.Throws<NoSpawnPointException>(() => game = new Game(path));
    }

    [Test]
    public void GoingLeftShouldNotGoThroughWall()
    {
        string path = "../../../TestFiles/goingStraight.txt";
        var game = new Game(path);
        for (int i = 0; i < 5; i++)
        {
            game.OnLeft(this, EventArgs.Empty);
        }

        Assert.AreEqual((2, 1), game.Position);
    }

    [Test]
    public void GoingRightShouldNotGoThroughWall()
    {
        string path = "../../../TestFiles/goingStraight.txt";
        var game = new Game(path);
        for (int i = 0; i < 5; i++)
        {
            game.OnRight(this, EventArgs.Empty);
        }

        Assert.AreEqual((2, 5), game.Position);
    }

    [Test]
    public void GoingUpShouldNotGoThroughWall()
    {
        string path = "../../../TestFiles/goingStraight.txt";
        var game = new Game(path);
        for (int i = 0; i < 5; i++)
        {
            game.OnUp(this, EventArgs.Empty);
        }

        Assert.AreEqual((1, 3), game.Position);
    }

    [Test]
    public void GoingDownShouldNotGoThroughWall()
    {
        string path = "../../../TestFiles/goingStraight.txt";
        var game = new Game(path);
        for (int i = 0; i < 5; i++)
        {
            game.OnDown(this, EventArgs.Empty);
        }

        Assert.AreEqual((3, 3), game.Position);
    }

    [Test]
    public void PlayerShouldBeAbleToPassThroughNarrowCorridors()
    {
        string path = "../../../TestFiles/corridor.txt";
        var game = new Game(path);
        for (int i = 0; i < 2; i++)
        {
            game.OnUp(this, EventArgs.Empty);
        }

        for (int i = 0; i < 6; i++)
        {
            game.OnRight(this, EventArgs.Empty);
        }

        for (int i = 0; i < 4; i++)
        {
            game.OnDown(this, EventArgs.Empty);
        }

        for (int i = 0; i < 7; i++)
        {
            game.OnLeft(this, EventArgs.Empty);
        }

        Assert.AreEqual((5, 1), game.Position);
    }
}