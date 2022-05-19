namespace GenericBubbleSort.Comparers;

public class StringLengthComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x is null)
        {
            throw new ArgumentException("String cannot be null", x);
        }
        else if (y is null)
        {
            throw new ArgumentException("String cannot be null", y);
        }

        if (x.Length > y.Length)
        {
            return 1;
        }
        else if (x.Length == y.Length)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}