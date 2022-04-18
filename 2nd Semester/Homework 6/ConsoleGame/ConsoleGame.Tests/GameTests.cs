namespace ConsoleGame.Tests;

using System;
using System.IO;
using NUnit.Framework;
using ConsoleGame.Exceptions;

public class Tests
{
    private EventLoop eventLoop = new();

    [SetUp]
    public void Setup()
    {
        eventLoop = new EventLoop();
    }

    [Test]
    public void EmptyMapShouldThrowException()
    {
        Game? game = null;
        string path = "../../../empty.txt";
        Assert.Throws<EmptyMapException>(() => game = new Game(path));
    }

    [Test]
    public void MapWithNoFreeSpaceShouldThrowException()
    {
        Game? game = null;
        string path = "../../../nospace.txt";
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        Assert.Throws<NoSpaceToMoveException>(() => game = new Game(path));
    }
}