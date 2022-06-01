namespace Routers;

/// <summary>
/// Class that represents an edge (a connection) of a graph (a network).
/// </summary>
public class Edge : IComparable<Edge>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Edge"/> class.
    /// </summary>
    /// <param name="capacity">Carrying capacity of the connection.</param>
    /// <param name="begin">One point of an edge.</param>
    /// <param name="end">Another point of an edge.</param>
    public Edge(int capacity, Node begin, Node end)
    {
        Capacity = capacity;
        Begin = begin;
        End = end;
    }

    /// <summary>
    /// Gets carrying capacity of a connection.
    /// </summary>
    public int Capacity { get; private set; }

    /// <summary>
    /// Gets one point of an edge.
    /// </summary>
    public Node Begin { get; private set; }

    /// <summary>
    /// Gets another point of an edge.
    /// </summary>
    public Node End { get; private set; }

    /// <summary>
    /// Compares the current instance with another edge.
    /// </summary>
    /// <param name="edge">Another edge.</param>
    /// <returns>Integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</returns>
    /// <exception cref="ArgumentNullException">Throws if null was passed as a parameter.</exception>
    public int CompareTo(Edge? edge)
    {
        if (edge is null)
        {
            throw new ArgumentNullException(nameof(edge));
        }

        return edge.Capacity.CompareTo(this.Capacity);
    }
}
