namespace Routers;

/// <summary>
/// Class that represents a node (a router) of a graph (a network).
/// </summary>
public class Node : SetElement
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="number">Index number of a node.</param>
    public Node(int number)
    {
        Number = number;
    }

    /// <summary>
    /// Gets or sets index number of a node.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Gets or sets list that contains edges connected to the node.
    /// </summary>
    public List<Edge> ConnectedEdges { get; set; } = new ();
}
