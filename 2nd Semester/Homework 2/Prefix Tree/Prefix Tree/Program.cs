namespace PrefixTree;

internal static class Program
{
    public static void Main(string[] args)
    {
        Trie trie = new Trie();
        string? input = string.Empty;
        Console.WriteLine("Введите номер действия, которое вы хотите выполнить:\n0 - открыть помощь\n" +
                "1 - добавить слово \n2 - удалить слово \n3 - проверить, есть ли слово\n" +
                "4 - посмотреть, сколько слов имеют данный префикс \n5 - получить размер дерева \n" +
                "Введите \"Выход\", чтобы выйти из программы.");
        while (input != "Выход")
        {
            input = Console.ReadLine();
            switch (input)
            {
                case null:
                    throw new ArgumentNullException();
                case "0":
                    Console.WriteLine("0 - открыть помощь" +
                        "1 - добавить слово \n2 - удалить слово \n3 - проверить, есть ли слово\n" +
                        "4 - посмотреть, сколько слов имеют данный префикс \n5 - получить размер дерева \n" +
                        "Введите \"Выход\", чтобы выйти из программы.");
                    break;
                case "1":
                    Console.Write("Введите слово, которое нужно добавить в дерево: ");
                    input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentNullException();
                    }

                    if (trie.Add(input))
                    {
                        Console.WriteLine($"Слово {input} было добавлено");
                    }
                    else
                    {
                        Console.WriteLine("Такое слово уже есть!");
                    }

                    break;
                case "2":
                    Console.Write("Введите слово, которое нужно удалить из дерева: ");
                    input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentNullException();
                    }

                    if (trie.Remove(input))
                    {
                        Console.WriteLine($"Слово {input} было удалено");
                    }
                    else
                    {
                        Console.WriteLine("Такого слова нет!");
                    }

                    break;
                case "3":
                    Console.Write("Введите слово, которое нужно найти в дереве: ");
                    input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentNullException();
                    }

                    if (trie.Contains(input))
                    {
                        Console.WriteLine($"Слово {input} есть в дереве.");
                    }
                    else
                    {
                        Console.WriteLine("Такого слова нет!");
                    }

                    break;
                case "4":
                    Console.Write("Введите префикс: ");
                    input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentNullException();
                    }

                    int howManyStart = trie.HowManyStartsWithPrefix(input);
                    if (howManyStart == 0)
                    {
                        Console.WriteLine("Нет слов, начинающихся так.");
                    }
                    else
                    {
                        Console.WriteLine($"Есть {howManyStart} слов, начинающихся на префикс {input}");
                    }

                    break;
                case "5":
                    Console.WriteLine($"Размер дерева: {trie.Size}");
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    break;
            }

            Console.Write("Введите номер действия: ");
        }
    }
}
