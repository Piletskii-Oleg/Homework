string path = args[0];
if (args[1] == "-c")
{
    LZWCompress.LZWCompress.Encode(path);
}
else if (args[1] == "-u")
{
    LZWCompress.LZWCompress.Decode(path);
}
else
{
    throw new ArgumentException("Passed parameter was not of correct form.", args[1]);
}