namespace Routers;

class Program
{
    static void Main()
    {
        string path = "C:\\Users\\Oleg\\Documents\\GitHub\\Homework\\2nd Semester\\Homework 5\\Routers\\Routers\\input.txt";
        var tree = Graph.MakeMinimalTree(path);
        Routers.MakeConfiguration(path);
    }
}