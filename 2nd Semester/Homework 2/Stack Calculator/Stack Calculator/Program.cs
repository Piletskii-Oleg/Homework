namespace StackCalculator;

internal class Program
{
    static void Main(string[] args)
    {
        string kek = "1 2 + 4 * 3 +";
        var stack = new ListStack();
        StackCalculator calc = new StackCalculator(stack);
    }
}
