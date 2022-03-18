namespace LZWCompress;

class Program
{
    static void Main(string[] args)
    {
        var list = LZW.Encode("geekific-geekific");
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        LZW.Compress("C:\\Users\\Oleg\\Documents\\GitHub\\Homework\\2nd Semester\\Homework 3\\LZWCompress\\LZWCompress\\pin.txt");
    }
}