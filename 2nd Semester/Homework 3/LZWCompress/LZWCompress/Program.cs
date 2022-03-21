namespace LZWCompress;
using System.Collections;
class Program
{
    static void Main(string[] args)
    {
        string testPath = "C:\\Users\\Oleg\\Documents\\GitHub\\Homework\\2nd Semester\\Homework 3\\LZWCompress\\LZWCompress\\test2.txt";
        LZW.Encode(testPath);
        LZW.Decode(testPath + ".zipped");
    }
}