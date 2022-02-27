namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input text to transform: ");
            string input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("No text found.");
                return;
            }
            
            string converted = BWTransform.DirectBWT(input, out int originalLineNumber);
            Console.WriteLine($"The transformed text is: {converted}");
            string convertedBack = BWTransform.ReverseBWT(converted, originalLineNumber);
            Console.WriteLine($"Transformed back: {convertedBack}");
            Console.WriteLine($"Are texts same: {input == convertedBack}");
        }
    }
}
