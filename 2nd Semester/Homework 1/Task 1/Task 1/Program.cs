namespace TaskOne;

public static class Program
{
    private static void Swap(int[] array, int index1, int index2)
    {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

    private static void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(array, j, j + 1);
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }
    }

    private static void Main(string[] args)
    {
        int[] array = { 6, 9, 55, 67, 93, 4 };
        BubbleSort(array);
        foreach (int i in array)
        {
            Console.WriteLine(i);
        }
    }
}
