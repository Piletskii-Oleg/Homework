namespace BWTransform;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Input text to transform: ");
        string input = Console.ReadLine();
        if (input == null)
        {
            throw new ArgumentNullException();
        }

        (string converted, int originalLineNumber) = BWTransform.DirectBWT(input);
        Console.WriteLine($"The transformed text is: {converted}");
        string convertedBack = BWTransform.ReverseBWT(converted, originalLineNumber);
        Console.WriteLine($"Transformed back: {convertedBack}");
        Console.WriteLine($"Are texts same: {input == convertedBack}");
    }
}