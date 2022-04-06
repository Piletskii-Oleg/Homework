namespace Routers;

internal class Node : SetElement
{
    internal int Number { get; set; }

    internal Node(int number)
        : base(number)
    {
        Number = number;
    }
}
