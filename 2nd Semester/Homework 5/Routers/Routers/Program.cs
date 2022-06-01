using Routers;
using Routers.Exceptions;

if (args.Length != 2)
{
    Console.WriteLine("Number of arguments was not correct");
}
else
{
    try
    {
        RoutersUtility.MakeConfiguration(args[0], args[1]);
    }
    catch (GraphNotConnectedException e)
    {
        var errorWriter = Console.Error;
        errorWriter.WriteLine(e.Message);
    }
}