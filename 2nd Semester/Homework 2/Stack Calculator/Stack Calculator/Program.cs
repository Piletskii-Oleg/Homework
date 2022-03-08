namespace StackCalculator;

class Program
{
    static void Main(string[] args)
    {
        string? input = null;
        while (input != "Выход")
        {
            int? stackType = null;
            while (stackType == null && stackType != 1 && stackType != 2)
            {
                Console.WriteLine("Какой тип стека вы хотите использовать? /n1 - на массиве /n2 - на списке");
                Console.Write("Тип: ");
                stackType = int.Parse(Console.ReadLine());
            }

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