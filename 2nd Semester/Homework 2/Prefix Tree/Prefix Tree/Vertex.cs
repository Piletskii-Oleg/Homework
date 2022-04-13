namespace PrefixTree;

/// <summary>
/// Single vertex of a prefix tree.
/// </summary>
internal class Vertex
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Vertex"/> class.
    /// </summary>
    public Vertex()
    {
        this.Next = new Dictionary<char, Vertex>();
        this.IsTerminal = false;
        this.HowManyFollow = 0;
    }

    /// <summary>
    /// Gets or sets a dictionary which has pointers to the next elements.
    /// </summary>
    public Dictionary<char, Vertex> Next { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the vertex is terminal or not.
    /// </summary>
    public bool IsTerminal { get; set; }

    /// <summary>
    /// Gets or sets a value indicating how many words there are that have this vertex in them.
    /// </summary>
    public int HowManyFollow { get; set; }
}