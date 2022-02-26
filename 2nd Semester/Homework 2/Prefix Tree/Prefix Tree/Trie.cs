namespace Prefix_Tree
{
    internal class Vertex
    {
        public Vertex[] next;
        public bool isTerminal;
        public Vertex()
        {
            this.next = new Vertex[26];
            this.isTerminal = false;
        }
    }

    internal class Trie
    {
        private Vertex root;

        public Trie()
        {
            this.root = new Vertex();
        }

        public bool Add(string element)
        {
            Vertex currentElement = this.root;
            foreach (char c in element)
            {
                int currentIndex = (int)c - 65;
                if (currentElement.next[currentIndex] == null)
                {
                    currentElement.next[currentIndex] = new Vertex();
                }
                currentElement = currentElement.next[currentIndex];
            }
            currentElement.isTerminal = true;
            return true;
        }

        public bool Contains(string element)
        {
            Vertex currentElement = this.root;
            foreach (char c in element)
            {
                int currentIndex = (int)c - 65;
                if (currentElement.next[currentIndex] == null)
                {
                    return false;
                }
                currentElement = currentElement.next[currentIndex];
            }
            if (currentElement.isTerminal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(string element)
        {
            Vertex currentElement = this.root;
            foreach (char c in element)
            {
                int currentIndex = (int)c - 65;
                if (currentElement.next[currentIndex] == null)
                {
                    return false;
                }
                currentElement = currentElement.next[currentIndex];
            }
            currentElement.isTerminal = false;
            return true;
        }

        public int HowManyStartsWithPrefix(string prefix)
        {
            Vertex currentElement = this.root;
            foreach (char c in prefix)
            {
                int currentIndex = (int)c - 65;
                if (currentElement.next[currentIndex] == null)
                {
                    return 0;
                }
                currentElement = currentElement.next[currentIndex];
            }
            int count = 0;
            foreach (Vertex v in currentElement.next)
            {
                if (v != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
