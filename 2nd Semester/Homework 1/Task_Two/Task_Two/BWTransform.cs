namespace TaskTwo
{
    internal static class BWTransform
    {
        private static string CycleShift(string input, int offset)
        {
            var output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                if (i + offset >= input.Length)
                {
                    offset = -i;
                }
                output[i] = input[i + offset];
            }
            return new string(output);
        }

        public static (string, int) DirectBWT(string input)
        {
            var table = new string[input.Length];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = CycleShift(input, i);
            }
            Array.Sort(table);

            var result = new char[table.Length];
            int originalLineNumber = -1;
            for (int i = 0; i < table.Length; i++)
            {
                string currentString = table[i];
                if (originalLineNumber == -1 && currentString == input)
                {
                    originalLineNumber = i;
                }
                result[i] = currentString[currentString.Length - 1];
            }
            return (new string(result), originalLineNumber);
        }

        private static string SortString(string input)
        {
            var array = input.ToCharArray();
            Array.Sort(array);
            return new string(array);
        }

        private static char[] CreateAlphabet(string sortedInput)
        {
            int size = 1;
            for (int i = 0; i < sortedInput.Length - 1; i++)
            {
                if (sortedInput[i] != sortedInput[i + 1])
                {
                    size++;
                }
            }
            var alphabet = new char[size];
            int currentPos = 0;
            for (int i = 0; i < sortedInput.Length; i++)
            {
                if (!alphabet.Contains(sortedInput[i]))
                {
                    alphabet[currentPos] = sortedInput[i];
                    currentPos++;
                }
            }
            return alphabet;
        }

        public static string ReverseBWT(string input, int originalLineNumber)
        {
            string sortedInput = SortString(input);
            var positionArray = new int[input.Length];
            for (int i = 0; i < positionArray.Length; i++)
            {
                positionArray[i] = -1;
            }
            char[] alphabet = CreateAlphabet(sortedInput);
            int currentPos = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                int elementPos = input.IndexOf(alphabet[i]);
                for (int j = 0; j < sortedInput.Length; j++)
                {
                    if (alphabet[i] == sortedInput[j])
                    {
                        while (positionArray[elementPos] != -1 || input[elementPos] != alphabet[i])
                        {
                            elementPos++;
                        }
                        positionArray[elementPos] = currentPos;
                        currentPos++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            currentPos = originalLineNumber;
            var result = new char[input.Length];
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result[i] = input[currentPos];
                currentPos = positionArray[currentPos]++;
            }
            return new string(result);
        }
    }
}
