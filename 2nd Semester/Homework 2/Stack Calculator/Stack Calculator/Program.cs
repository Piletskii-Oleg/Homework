namespace Stack_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kek = "1 2 + 4 * 3 +";
            var stack = new MSListStack();
            Calculator calc = new Calculator(stack);
            calc.AddInput(kek);
            Console.WriteLine(calc.Evaluate());
        }
    }
}