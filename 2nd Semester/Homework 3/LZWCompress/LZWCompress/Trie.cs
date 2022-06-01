namespace LZWCompress;

/// <summary>
/// Prefix tree data structure.
/// </summary>
public class Trie
{
    private readonly Vertex head;
    private Vertex lastVisited;

    /// <summary>
    /// Initializes a new instance of the <see cref="Trie"/> class.
    /// </summary>
    public Trie()
    {
        this.head = new Vertex();
        this.Size = 0;
        this.lastVisited = this.head;
    }

    /// <summary>
    /// Gets the amount of words in the Trie.
    /// </summary>
    public int Size { get; private set; }

    /// <summary>
    /// Gets the number of the byte sequence in the dictionary.
    /// </summary>
    /// <param name="element">List of bytes.</param>
    /// <returns>Number of the said byte sequence.</returns>
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
    /// Gets the number of the last requested byte sequence in the dictionary.
    /// </summary>
    /// <returns>Number of the last requested byte sequence.</returns>
    public int GetNumberInDictionary()
        => this.lastVisited.NumberInDictionary;

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
                this.lastVisited = currentElement;
                return false;
            }

            currentElement = currentElement.Next[b];
        }

        return true;
    }

    /// <summary>
    /// Adds an element to the previously viewed sequence in the Trie.
    /// </summary>
    /// <param name="element">An element to add.</param>
    public void Add(byte element)
    {
        this.lastVisited.Next.Add(element, new Vertex());
        this.lastVisited.Next[element].NumberInDictionary = this.Size;
        this.Size++;
    }

    private class Vertex
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
}