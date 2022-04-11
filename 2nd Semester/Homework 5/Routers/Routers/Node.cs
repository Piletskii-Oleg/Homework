namespace Routers;

public class Node : SetElement
{
    public int Number { get; set; }

    public List<Edge> ConnectedEdges { get; set; } = new ();

    public Node(int number)
        : base()
    {
        Number = number;
    }
}
