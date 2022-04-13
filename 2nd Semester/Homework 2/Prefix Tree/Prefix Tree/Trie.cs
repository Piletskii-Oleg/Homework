namespace PrefixTree;

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
        if (this.Contains(element))
        {
            return false;
        }

        foreach (char c in element)
        {
            if (!currentElement.Next.ContainsKey(c))
            {
                currentElement.Next.Add(c, new Vertex());
            }

            currentElement.HowManyFollow++;
            currentElement = currentElement.Next[c];
        }

        currentElement.HowManyFollow++;
        currentElement.IsTerminal = true;
        this.Size++;
        return true;
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
            if (!currentElement.Next.ContainsKey(c))
            {
                return false;
            }

            currentElement = currentElement.Next[c];
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
            if (!currentElement.Next.ContainsKey(c))
            {
                return false;
            }

            currentElement = currentElement.Next[c];
        }

        if (currentElement.IsTerminal)
        {
            currentElement = this.head;
            foreach (char c in element)
            {
                currentElement.HowManyFollow--;
                if (currentElement.HowManyFollow == 0)
                {
                    var next = currentElement.Next[c];
                    currentElement.Next.Remove(c);
                    currentElement = next;
                }
                else
                {
                    currentElement = currentElement.Next[c];
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
            if (!currentElement.Next.ContainsKey(c))
            {
                return 0;
            }

            currentElement = currentElement.Next[c];
        }

        return currentElement.HowManyFollow;
    }
}