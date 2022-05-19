namespace GenericBubbleSort.Comparers;

public class FractionComparer : IComparer<double>
{
    public int Compare(double x, double y)
    {
        var fractionX = x - Math.Truncate(x);
        var fractionY = y - Math.Truncate(y);
        double threshold = 1e-9;
        if (fractionX > fractionY)
        {
            return 1;
        }
        else if (Math.Abs(fractionX - fractionY) < threshold)
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}