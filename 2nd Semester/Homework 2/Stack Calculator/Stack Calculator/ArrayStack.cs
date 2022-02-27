namespace Stack_Calculator
{
    internal class ArrayStack : IStack
    {
        public int Capacity { get; set; }
        private int[] stack;
        private int currentIndex;
        public ArrayStack(int capacity)
        {
            Capacity = capacity;
            stack = new int[capacity];
            currentIndex = 0;
        }

        private bool isEmpty()
        {
            return currentIndex == 0;
        }

        private bool isFull()
        {
            return currentIndex == stack.Length - 1;
        }
        public void Push(int element)
        {
            if (isFull())
            {
                Console.WriteLine("The stack is full!");
                return;
            }
            stack[currentIndex] = element;
            currentIndex++;
        }

        public int Pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("The stack is empty!");
                return 0;
            }
            currentIndex--;
            return stack[currentIndex];
        }

        public int Peek()
        {
            return stack[currentIndex];
        }
    }
}
