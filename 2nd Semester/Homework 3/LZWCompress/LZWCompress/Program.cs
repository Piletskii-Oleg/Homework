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
    throw new ArgumentException("Passed parameter was not of correct form.", args[1]);
}
//var bytes = File.ReadAllBytes(path);
//var (tr, num) = LZWCompress.BWTransform.DirectBWT(bytes);
//var trr = LZWCompress.BWTransform.ReverseBWT(tr, num);
Console.WriteLine("s");