namespace BWTransform;

/// <summary>
/// Class implementing Burrows-Wheeler transform algorithm.
/// </summary>
public static class BWTransform
{
    /// <summary>
    /// Transforms text using direct Burrows-Wheeler transform algorithm.
    /// </summary>
    /// <param name="input">Text to transform.</param>
    /// <returns>Transformed text and line in the shift table corresponding to the original text.</returns>
    public static (string, int) DirectBWT(string input)
    {
        var table = new string[input.Length];
        for (int i = 0; i < table.Length; i++)
        {
            table[i] = CycleShift(input, i);
        }

        Array.Sort(table, StringComparer.Ordinal);

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

    /// <summary>
    /// Convert transformed text back to normal using reverse Burrows-Wheeler transform algorithm.
    /// </summary>
    /// <param name="input">Transformed text.</param>
    /// <param name="originalLineNumber">Number of the original line in the shift table.</param>
    /// <returns>Original text.</returns>
    public static string ReverseBWT(string input, int originalLineNumber)
    {
        var sortedInput = SortString(input);
        var dictionary = CreateDictionary(sortedInput);
        var positionArray = new int[input.Length];
        for (int i = 0; i < positionArray.Length; i++)
        {
            positionArray[i] = dictionary[input[i]];
            dictionary[input[i]]++;
        }

        int currentPos = originalLineNumber;
        var result = new char[input.Length];
        for (int i = input.Length - 1; i >= 0; i--)
        {
            result[i] = input[currentPos];
            currentPos = positionArray[currentPos];
        }

        return new string(result);
    }

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

    private static string SortString(string input)
    {
        var array = input.ToCharArray();
        Array.Sort(array, StringComparer.Ordinal);
        return new string(array);
    }

    private static Dictionary<char, int> CreateDictionary(string sortedInput)
    {
        var dictionary = new Dictionary<char, int>();
        for (int i = 0; i < sortedInput.Length; i++)
        {
            if (!dictionary.ContainsKey(sortedInput[i]))
            {
                dictionary.Add(sortedInput[i], i);
            }
        }

        return dictionary;
    }
}