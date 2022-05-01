namespace LZWCompress;

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
        this.Next = new Dictionary<byte, Vertex>();
        this.NumberInDictionary = 0;
    }

    /// <summary>
    /// Gets or sets a dictionary which has pointers to the next elements.
    /// </summary>
    public Dictionary<byte, Vertex> Next { get; set; }

    /// <summary>
    /// Gets or sets a value indicating the number of the word in dictionary.
    /// </summary>
    public int NumberInDictionary { get; set; }
}

/// <summary>
/// Prefix tree data structure.
/// </summary>
public class Trie
{
    private readonly Vertex head;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
    {
        this.head = new Vertex();
        this.Size = 0;
    }

    /// <summary>
    /// Gets or sets the amount of words in the Trie.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Adds an element to the Trie.
    /// </summary>
    /// <param name="element">An element to add.</param>
    /// <returns>True if the element was not present in the Trie and false otherwise.</returns>
    public bool Add(List<byte> element)
    {
        if (this.Contains(element))
        {
            return false;
        }

        Vertex currentElement = this.head;
        foreach (byte b in element)
        {
            if (!currentElement.Next.ContainsKey(b))
            {
                currentElement.Next.Add(b, new Vertex());
            }

            currentElement = currentElement.Next[b];
        }

        currentElement.NumberInDictionary = this.Size++;
        return true;
    }

    /// <summary>
    /// Gets the number in dictionary of the byte sequence.
    /// </summary>
    /// <param name="element">List of bytes.</param>
    /// <returns>Number in dictionary of the said byte sequence.</returns>
    public int GetNumberInDictionary(List<byte> element)
    {
        var currentElement = this.head;
        foreach (byte b in element)
        {
            currentElement = currentElement.Next[b];
        }

        return currentElement.NumberInDictionary;
    }

    /// <summary>
    /// Checks if the element is present in the Trie.
    /// </summary>
    /// <param name="element">An element to check.</param>
    /// <returns>True if the element is present and false otherwise.</returns>
    public bool Contains(List<byte> element)
    {
        Vertex currentElement = this.head;
        foreach (byte b in element)
        {
            if (!currentElement.Next.ContainsKey(b))
            {
                return false;
            }

            currentElement = currentElement.Next[b];
        }

        return true;
    }
}