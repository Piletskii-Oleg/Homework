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
        this.Next = new Vertex[256];
        this.IsTerminal = false;
        this.HowManyFollow = 0;
    }

    /// <summary>
    /// Gets or sets array in which every index corresponds to the index of the next char element.
    /// </summary>
    public Vertex?[] Next { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the vertex is terminal or not.
    /// </summary>
    public bool IsTerminal { get; set; }

    /// <summary>
    /// Gets or sets a value indicating how many words there are that have this vertex in them.
    /// </summary>
    public int HowManyFollow { get; set; }
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
    public bool Add(string element)
    {
        Vertex? currentElement = this.head;
        bool wordIsNew = false;
        foreach (char c in element)
        {
            int currentIndex = c;
            if (currentElement.Next[currentIndex] == null)
            {
                currentElement.Next[currentIndex] = new Vertex();
                wordIsNew = true;
            }

            currentElement.HowManyFollow++;
            currentElement = currentElement.Next[currentIndex];
        }

        currentElement.HowManyFollow++;
        currentElement.IsTerminal = true;
        if (wordIsNew)
        {
            this.Size++;
            return true;
        }
        else
        {
            foreach (char c in element)
            {
                currentElement = this.head;
                int currentIndex = c;
                currentElement.HowManyFollow--;
                currentElement = currentElement.Next[currentIndex];
            }

            return false;
        }
    }

    /// <summary>
    /// Checks if the element is present in the Trie.
    /// </summary>
    /// <param name="element">An element to check.</param>
    /// <returns>True if the element is present and false otherwise.</returns>
    public bool Contains(string element)
    {
        Vertex? currentElement = this.head;
        foreach (char c in element)
        {
            int currentIndex = c;
            if (currentElement.Next[currentIndex] == null)
            {
                return false;
            }

            currentElement = currentElement.Next[currentIndex];
        }

        return true;
    }

    /// <summary>
    /// Removes an element from the Trie.
    /// </summary>
    /// <param name="element">An element to remove.</param>
    /// <returns>True if the element was present and false otherwise.</returns>
    public bool Remove(string element)
    {
        Vertex? currentElement = this.head;
        foreach (char c in element)
        {
            int currentIndex = c;
            if (currentElement.Next[currentIndex] == null)
            {
                return false;
            }

            currentElement = currentElement.Next[currentIndex];
        }

        if (currentElement.IsTerminal)
        {
            currentElement = this.head;
            foreach (char c in element)
            {
                int currentIndex = c;
                if (currentElement.Next[currentIndex] == null)
                {
                    return false;
                }

                currentElement.HowManyFollow--;
                if (currentElement.HowManyFollow == 0)
                {
                    var next = currentElement.Next[currentIndex];
                    currentElement.Next[currentIndex] = null;
                    currentElement = next;
                }
                else
                {
                    currentElement = currentElement.Next[currentIndex];
                }
            }

            currentElement.IsTerminal = false;
            this.Size--;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Shows how many words start with the given prefix.
    /// </summary>
    /// <param name="prefix">The given prefix.</param>
    /// <returns>The amount of words starting with the given prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        Vertex? currentElement = this.head;
        foreach (char c in prefix)
        {
            int currentIndex = c;
            if (currentElement.Next[currentIndex] == null)
            {
                return 0;
            }

            currentElement = currentElement.Next[currentIndex];
        }

        return currentElement.HowManyFollow;
    }
}