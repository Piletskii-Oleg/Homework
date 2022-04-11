namespace Routers;

internal class Edge : IComparable<Edge>
{
    internal int Capacity { get; set; }

    internal Node Begin { get; set; }

    internal Node End { get; set; }

    internal Edge(int capacity, Node begin, Node end)
    {
        Capacity = capacity;
        Begin = begin;
        End = end;
    }

    public int CompareTo(Edge? edge)
    {
        if (edge is null)
        {
            throw new NotImplementedException();
        }

        if (edge.Capacity.CompareTo(this.Capacity) != 0)
        {
            return edge.Capacity.CompareTo(this.Capacity);
        }
        else
        {
            return 0;
        }
    }
}
