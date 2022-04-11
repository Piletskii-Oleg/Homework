namespace Routers;

public class Edge : IComparable<Edge>
{
    public int Capacity { get; set; }

    public Node Begin { get; set; }

    public Node End { get; set; }

    public Edge(int capacity, Node begin, Node end)
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
