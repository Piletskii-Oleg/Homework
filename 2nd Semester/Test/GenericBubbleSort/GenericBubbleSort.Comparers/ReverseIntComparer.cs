namespace GenericBubbleSort.Comparers;

public class ReverseComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x > y)
        {
            return -1;
        }
        else if (x == y)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}