namespace Routers;

/// <summary>
/// Class that represents an element of a disjoint set.
/// </summary>
public class SetElement
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetElement"/> class.
    /// </summary>
    public SetElement()
    {
        Identificator = this;
    }

    /// <summary>
    /// Gets or sets an element that represents the disjoint set.
    /// </summary>
    public SetElement Identificator { get; set; }

    /// <summary>
    /// Gets or sets distance from an element to the identificator.
    /// </summary>
    public int Rank { get; set; }
}
