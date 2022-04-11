namespace Routers;

/// <summary>
/// Class to conduct operations on elements of a disjoint set.
/// </summary>
public static class DisjointSet
{
    /// <summary>
    /// Unites two sets.
    /// </summary>
    /// <param name="firstElement">Element of the first set.</param>
    /// <param name="secondElement">Element of the second set.</param>
    public static void Union(SetElement firstElement, SetElement secondElement)
    {
        var firstIdentity = Find(firstElement);
        var secondIdentity = Find(secondElement);

        if (firstIdentity.Rank == secondIdentity.Rank)
        {
            firstIdentity.Rank++;
            secondIdentity.Identificator = firstIdentity;
        }
        else if (firstIdentity.Rank > secondIdentity.Rank)
        {
            secondIdentity.Identificator = firstIdentity;
        }
        else
        {
            firstIdentity.Identificator = secondIdentity;
        }
    }

    /// <summary>
    /// Finds identificator of the set.
    /// </summary>
    /// <param name="element">Element of the said set.</param>
    /// <returns>Identificator of the set.</returns>
    public static SetElement Find(SetElement element)
    {
        if (element.Identificator != element)
        {
            element.Identificator = Find(element.Identificator);
        }

        return element.Identificator;
    }
}
