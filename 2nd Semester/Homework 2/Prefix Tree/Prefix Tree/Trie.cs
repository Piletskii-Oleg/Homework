namespace PrefixTree;

internal class Vertex
{
    public Vertex[] Next { get; set; }
    public bool IsTerminal { get; set; }
    public int HowManyFollow { get; set; }
    public Vertex()
    {
        Next = new Vertex[26];
        IsTerminal = false;
        HowManyFollow = 0;
    }
}

public class Trie
{
    private Vertex head;

    public int Size { get; set; }
    public Trie()
    {
        this.head = new Vertex();
        this.Size = 0;
    }

    public bool Add(string element)
    {
        Vertex currentElement = head;
        foreach (char c in element)
        {
            int currentIndex = (int)c - 65;
            if (currentElement.Next[currentIndex] == null)
            {
                currentElement.Next[currentIndex] = new Vertex();
            }
            currentElement.HowManyFollow++;
            currentElement = currentElement.Next[currentIndex];
        }
        currentElement.IsTerminal = true;
        Size++;
        return true;
    }

    public bool Contains(string element)
    {
        Vertex currentElement = this.head;
        foreach (char c in element)
        {
            int currentIndex = (int)c - 65;
            if (currentElement.Next[currentIndex] == null)
            {
                return false;
            }
            currentElement = currentElement.Next[currentIndex];
        }
        return true;
    }

    public bool Remove(string element)
    {
        Vertex? currentElement = this.head;
        foreach (char c in element)
        {
            int currentIndex = (int)c - 65;
            if (currentElement.Next[currentIndex] == null)
            {
                return false;
            }

            currentElement.HowManyFollow--;
            if (currentElement.HowManyFollow == 0)
            {
                var toDelete = currentElement;
                currentElement = currentElement.Next[currentIndex];
                toDelete = null;
            }
            else
            {
                currentElement = currentElement.Next[currentIndex];
            }
        }
        Size--;
        return true;

        currentElement.IsTerminal = false;
        return true;
    }

    public int HowManyStartsWithPrefix(string prefix)
    {
        Vertex currentElement = this.head;
        foreach (char c in prefix)
        {
            int currentIndex = (int)c - 65;
            if (currentElement.Next[currentIndex] == null)
            {
                return 0;
            }
            currentElement = currentElement.Next[currentIndex];
        }
        return currentElement.HowManyFollow;
    }
}