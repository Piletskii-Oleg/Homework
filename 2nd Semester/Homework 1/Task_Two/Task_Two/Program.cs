namespace BWTransform;

/// <summary>
/// Main class.
/// </summary>
public static class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    public static void Main()
    {
        Console.Write("Input text to transform: ");
        string? input = Console.ReadLine();
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