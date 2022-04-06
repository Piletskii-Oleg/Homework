namespace Routers;

class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        string path = "C:\\Users\\Oleg\\Documents\\GitHub\\Homework\\2nd Semester\\Homework 5\\Routers\\Routers\\input.txt";
        graph.FillMatrix(path);
    }
}