namespace PrefixTree;

internal class Program
{
    static void Main(string[] args)
    {
        Trie trie = new Trie();
        trie.Add("ELE");
        Console.WriteLine(trie.Contains("ELE"));
        trie.Add("ELEV");
        Console.WriteLine(trie.Size);
        trie.Remove("ELE");
        Console.WriteLine(trie.Size);
        Console.WriteLine(trie.Contains("ELE"));
        Console.WriteLine(trie.Contains("ELEV"));
        trie.Remove("ELEV");
        Console.WriteLine(trie.Contains("ELE"));
        Console.WriteLine(trie.Contains("ELEV"));
        Console.WriteLine(trie.Size);
        Console.WriteLine(trie.HowManyStartsWithPrefix("EL"));
        return;
    }
}
