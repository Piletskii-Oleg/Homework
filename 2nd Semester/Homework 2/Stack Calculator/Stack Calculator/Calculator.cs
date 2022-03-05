namespace Stack_Calculator
{
    /// <summary>
    /// Calculator using reverse Polish notation.
    /// </summary>
    internal class Calculator
    {
        private const double Epsilon = 0.00001;

        /// <summary>
        /// Gets or sets the input string which value is calculated.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the stack used.
        /// </summary>
        public IStack Stack { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class.
        /// </summary>
        /// <param name="input">String to calculate.</param>
        /// <param name="stack">Stack used.</param>
        public Calculator(string input, IStack stack)
        {
            Input = input;
            Stack = stack;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class. String should be added.
        /// </summary>
        /// <param name="stack">Stack used.</param>
        public Calculator(IStack stack)
            : this("", stack) { }
        public string AddInput(string input)
            => Input = input;

        public double Evaluate()
        {
            string[] array = Input.Split(' ');
            double currentNumber;
            foreach (string item in array)
            {
                if (double.TryParse(item, out currentNumber))
                {
                    Stack.Push(currentNumber);
                }

                else
                {
                    switch (item)
                    {
                        case "*":
                            double multiplication = Stack.Pop() * Stack.Pop();
                            Stack.Push(multiplication);
                            break;

                        case "+":
                            double addition = Stack.Pop() + Stack.Pop();
                            Stack.Push(addition);
                            break;

                        case "-":
                            double subtraction = Stack.Pop() - Stack.Pop();
                            Stack.Push(subtraction);
                            break;

                        case "/":
                            double dividend = Stack.Pop();
                            double divisor = Stack.Pop();
                            if (divisor < Epsilon)
                            {
                                throw new DivideByZeroException();
                            }
                            Stack.Push(dividend / divisor);
                            break;

                        default:
                            throw new ArgumentException();
                            break;
                    }
                }
            }
            return Stack.Pop();
        }
    }
}
