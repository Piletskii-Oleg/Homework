namespace Routers;

internal class SetElement
{
    internal SetElement(int value)
    {
        Next = null;
        Identificator = this;
        Tail = this;
        Rank = 0;
        Value = value;
    }

    internal SetElement? Next { get; set; }

    internal SetElement Tail { get; set; }

    internal SetElement Identificator { get; set; }

    internal int Rank { get; set; }

    internal int Value { get; set; }
}
