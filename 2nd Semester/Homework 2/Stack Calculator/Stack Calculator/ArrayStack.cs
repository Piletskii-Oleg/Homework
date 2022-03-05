namespace Stack_Calculator
{
    /// <summary>
    /// Last-In-First-Out container implemented using array.
    /// </summary>
    public class ArrayStack : IStack
    {
        private int capacity;
        private double[] stack;
        private int currentIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayStack"/> class.
        /// </summary>
        /// <param name="capacity"></param>
        public ArrayStack(int capacity)
        {
            this.capacity = capacity;
            this.stack = new double[capacity];
            this.currentIndex = 0;
        }

        /// <summary>
        /// Puts an element to the stack.
        /// </summary>
        /// <param name="element">Element to add.</param>
        public void Push(double element)
        {
            if (this.currentIndex == this.stack.Length)
            {
                throw new IndexOutOfRangeException();
            }
            this.stack[this.currentIndex] = element;
            this.currentIndex++;
        }

        /// <summary>
        /// Removes last element from the stack and returns its value.
        /// </summary>
        /// <returns>Last element from the stack.</returns>
        public double Pop()
        {
            if (this.currentIndex == 0)
            {
                throw new IndexOutOfRangeException();
            }
            double removed = this.stack[--this.currentIndex];
            return removed;
        }
    }
}
