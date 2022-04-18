namespace ConsoleGame.Tests;

using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using ConsoleGame.Exceptions;

public class Tests
{
    private EventLoop eventLoop = new();

    private event EventHandler<EventArgs> Directions = (sender, args) => { };

    [SetUp]
    public void Setup()
    {
        eventLoop = new EventLoop();
        Directions = (sender, args) => { };
    }

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
        string path = "../../../TestFiles/map.txt";
        var game = new Game(path);
        for (int i = 0; i < 5; i++)
        {
            game.OnLeft(this, EventArgs.Empty);
        }

        Assert.AreEqual((2, 1), game.GetPosition);
    }

    [Test]
    public void GoingRightShouldNotGoThroughWall()
    {
        string path = "../../../map.txt";
        var game = new Game(path);
        for (int i = 0; i < 5; i++)
        {
            game.OnRight(this, EventArgs.Empty);
        }

        Assert.AreEqual((2, 5), game.GetPosition);
    }
}