namespace Prefix_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Add("ELE");
            Console.WriteLine(trie.Contains("ELE"));
            trie.Add("ELEV");
            trie.Remove("ELE");
            Console.WriteLine(trie.Contains("ELE"));
            Console.WriteLine(trie.Contains("ELEV"));
            Console.WriteLine(trie.HowManyStartsWithPrefix("EL"));
            return;
        }
    }
}