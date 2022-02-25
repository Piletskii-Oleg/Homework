namespace Task_One
{
    class Program
    {
        static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[i] < array[j])
                    {
                        Swap(array, i, j);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] array = { 6, 9, 55, 67, 93, 4 };
            BubbleSort(array);
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}