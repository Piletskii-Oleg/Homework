namespace Routers.Tests;

using System.IO;
using NUnit.Framework;

public class RoutersTests
{
    [Test]
    public void ConfigurationShouldBeMinimal()
    {
        string path = "../../../TestFiles/correct.txt";
        string outputPath = "../../../TestFiles/output.txt";
        RoutersUtility.MakeConfiguration(path);
        Assert.Multiple(() =>
        {
            using var output = new StreamReader(File.OpenRead(outputPath));
            Assert.AreEqual("1: 2 (100) 5 (32) ", output.ReadLine());
            Assert.AreEqual("3: 4 (12) ", output.ReadLine());
            Assert.AreEqual("5: 4 (31) ", output.ReadLine());
        });
    }
}