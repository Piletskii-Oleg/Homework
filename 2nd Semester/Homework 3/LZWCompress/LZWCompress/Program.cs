string path = args[0];
if (args[1] == "-c")
{
    LZWCompress.LZWCompress.Encode(path);
    Console.WriteLine(LZWCompress.LZWCompress.GetCompressionCoefficient(path));
}
else if (args[1] == "-u")
{
    LZWCompress.LZWCompress.Decode(path);
}
else
{
    Console.WriteLine("Passed parameter was not of correct form.");
}