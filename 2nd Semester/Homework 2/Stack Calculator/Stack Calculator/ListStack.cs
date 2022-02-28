using System.Collections.Generic;

namespace Stack_Calculator
{
    internal class ListStack : IStack
    {
        //internal class Node
        //{
        //    public int value;
        //    public Node next;
        //    public Node(int value)
        //    {
        //        this.value = value;
        //        next = null;
        //    }
        //}
        
        //private Node root;
        private List<int> stack = new List<int>();

        public ListStack(int element)
        {
            stack.Add(element);
        }

        public void Push(int element)
        {
            stack.Add(element);
        }

        public int Pop()
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("The stack is empty!");
                return 0;
            }
            int removed = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return removed;
        }

        public int Peek()
        {
            return stack[stack.Count - 1];
        }
    }
}
