namespace Stack_Calculator
{
    internal class ListStack : IStack
    {
        internal class Node
        {
            public int value;
            public Node next;
            public Node(int value)
            {
                this.value = value;
                next = null;
            }
        }

        private Node root;

        public void Push(int element)
        {

        }

        public int Pop()
        {

        }

        public int Peek()
        {

        }
    }
}
