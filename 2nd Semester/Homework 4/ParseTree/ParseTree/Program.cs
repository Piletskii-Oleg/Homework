namespace ParseTree;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter an expression: ");
        string input = Console.ReadLine();
        var root = Tree.CreateTree(input);
        if (root is null)
        {
            Console.WriteLine("No tree was made.");
        }
        else
        {
            Console.WriteLine($"The result is: {Tree.CalculateValue(root)}");
            Console.Write("The expression was:");
            Tree.PrintTree(root);
        }
    }
}