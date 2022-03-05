namespace Stack_Calculator
{
    public class MyListStack : IStack
    {
        internal class Node
        {
            public double Value { get; set; }

            public Node Next { get; set; }
            public Node(double value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node root;

        public MyListStack(double element)
        {
            root = new Node(element);
        }

        public MyListStack()
            : this(0) { }

        public void Push(double element)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }
            Node newNode = new Node(element);
            newNode.Next = root;
            root = newNode;
        }

        public double Pop()
        {
            double removed = root.Value;
            if (root.Next != null)
            {
                root = root.Next;
            }
            return removed;
        }

    }
}
