namespace StackCalculator;

internal static class Program
{
    private static void Main(string[] args)
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
                int.TryParse(input, out stackType);
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

            var arrayStack = new ArrayStack();
            var listStack = new ListStack();
            if (stackType == 1)
            {
                Console.WriteLine(StackCalculator.Evaluate(input, arrayStack));
            }
            else
            {
                Console.WriteLine(StackCalculator.Evaluate(input, listStack));
            }
        }

        Console.WriteLine("Работа завершена.");
    }
}