namespace GenericBubbleSort;

/// <summary>
/// Class that implements a generic bubble sort method.
/// </summary>
public static class BubbleSort
{
    /// <summary>
    /// Sorts a list using bubble sort.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    /// <param name="list">A list that implements IList.</param>
    /// <param name="comparer">Comparer to use.</param>
    public static void Sort<T>(IList<T> list, IComparer<T>? comparer)
    {
        if (comparer == null)
        {
            comparer = Comparer<T>.Default;
        }

        for (int i = 0; i < list.Count - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < list.Count - i - 1; j++)
            {
                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    Swap(list, j, j + 1);
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }
    }

    private static void Swap<T>(IList<T> list, int index1, int index2)
    {
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}