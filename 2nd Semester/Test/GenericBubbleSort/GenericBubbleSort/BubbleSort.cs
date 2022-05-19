namespace GenericBubbleSort;

public static class BubbleSort
{
    public static IList<T> Sort<T>(IList<T> list, IComparer<T>? comparer)
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

        return list;
    }

    public static ICollection<T> Sort<T>(ICollection<T> collection, IComparer<T>? comparer)
    {
        if (typeof(T).GetGenericArguments().Length > 1)
        {
            throw new ArgumentException("Collection must consist of only 1 parameter", nameof(collection));
        }

        var collectionList = new List<T>(collection);
        var sortedList = Sort(collectionList, comparer);
        return sortedList;
    }

    public static IEnumerable<T> Sort<T>(IEnumerable<T> enumerable, IComparer<T>? comparer)
    {
        if (typeof(T).GetGenericArguments().Length > 1)
        {
            throw new ArgumentException("Collection must consist of only 1 parameter", nameof(enumerable));
        }

        var enumerableList = new List<T>(enumerable);
        var sortedList = Sort(enumerableList, comparer);
        return sortedList;
    }

    private static void Swap<T>(IList<T> list, int index1, int index2)
    {
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
    }
}