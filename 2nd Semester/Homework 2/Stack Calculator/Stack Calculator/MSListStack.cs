namespace Stack_Calculator
{
    public class MSListStack : IStack
    {
        private List<double> stack;

        public MSListStack()
        {
            stack = new List<double>();
        }

        public void Push(double element)
        {
            stack.Add(element);
        }

        public double Pop()
        {
            if (stack.Count <= 0)
            {
                throw new InvalidOperationException();
            }
            double removed = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return removed;
        }
    }
}
