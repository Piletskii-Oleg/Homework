namespace LZWCompress.Tests;

using NUnit.Framework;
using System.IO;

public class Tests
{
    [TestCase("compress", "txt")]
    [TestCase("Promise (Reprise)", "flac")]
    [TestCase("testchmb_a_08", "bsp")]
    [TestCase("Cat", "mp4")]
    public void FilesShouldBeCompressedCorrectly(string fileName, string fileExtension)
    {
        var path = $"../../../TestFiles/{fileName}.{fileExtension}";
        LZWCompress.Encode(path);
        LZWCompress.Decode(path + ".zipped");
        var originalBytes = File.ReadAllBytes(path);
        var newBytes = File.ReadAllBytes($"../../../TestFiles/{fileName}-unzipped.{fileExtension}");
        Assert.AreEqual(originalBytes, newBytes);
        Assert.AreEqual((double) new FileInfo(path).Length / new FileInfo(path + ".zipped").Length, LZWCompress.GetCompressionCoefficient(path));
    }
}