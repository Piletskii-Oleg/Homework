namespace Routers;

internal static class DisjointSet
{
    internal static void Union(SetElement firstElement, SetElement secondElement)
    {
        var firstIdentificator = Find(firstElement);
        var secondIdentificator = Find(secondElement);

        if (firstIdentificator.Rank == secondIdentificator.Rank)
        {
            firstIdentificator.Rank++;
            secondIdentificator.Identificator = firstIdentificator;
        }
        else if (firstIdentificator.Rank > secondIdentificator.Rank)
        {
            secondIdentificator.Identificator = firstIdentificator;
        }
        else
        {
            firstIdentificator.Identificator = secondIdentificator;
        }
    }

    internal static SetElement Find(SetElement element)
    {
        if (element.Identificator != element)
        {
            element.Identificator = Find(element.Identificator);
        }
        return element.Identificator;
    }
}
