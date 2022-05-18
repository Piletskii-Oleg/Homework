namespace StackCalculator;

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
        string? input = null;
        Console.WriteLine("Введите \"Выход\", чтобы выйти.\n");
        while (input != "Выход")
        {
            input = null;
            int stackType = 0;
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Какой тип стека вы хотите использовать? \n1 - на массиве \n2 - на списке");
                Console.Write("Тип: ");
                input = Console.ReadLine();
                _ = int.TryParse(input, out stackType);
            }

            input = null;
            while (input == null)
            {
                Console.Write("Введите выражение, которое нужно посчитать: ");
                input = Console.ReadLine();
                if (input == "Exit")
                {
                    break;
                }
            }

            if (stackType == 1)
            {
                var arrayStack = new ArrayStack();
                Console.WriteLine(Calculator.Evaluate(input, arrayStack));
            }
            else
            {
                var listStack = new ListStack();
                Console.WriteLine(Calculator.Evaluate(input, listStack));
            }
        }

        Console.WriteLine("Работа завершена.");
    }
}