﻿namespace Routers;

internal static class DisjointSet
{
    internal static void Union(SetElement firstElement, SetElement secondElement)
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

    internal static SetElement Find(SetElement element)
    {
        if (element.Identificator != element)
        {
            element.Identificator = Find(element.Identificator);
        }
        return element.Identificator;
    }
}
