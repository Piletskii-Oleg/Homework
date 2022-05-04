namespace LZWCompress;

/// <summary>
/// Class implementing Burrows-Wheeler transform algorithm.
/// </summary>
public static class BWTransform
{
    /// <summary>
    /// Transforms file using direct Burrows-Wheeler transform algorithm.
    /// </summary>
    /// <param name="path">Path to file to transform.</param>
    /// <returns>Transformed file and line in the shift table that corresponds to the original text.</returns>
    public static (byte[], int) DirectBWT(byte[] bytes)
    {
        var table = new List<byte[]>();
        for (int i = 0; i < bytes.Length; i++)
        {
            table.Add(CycleShift(bytes, i));
        }

        table.Sort();

        var result = new byte[table.Count];
        int originalLineNumber = -1;
        for (int i = 0; i < table.Count; i++)
        {
            byte[] currentString = table[i];
            if (originalLineNumber == -1 && currentString == bytes)
            {
                originalLineNumber = i;
            }

            result[i] = currentString[^1];
        }

        return (result, originalLineNumber);
    }

    /// <summary>
    /// Convert transformed file back to normal using reverse Burrows-Wheeler transform algorithm.
    /// </summary>
    /// <param name="input">Transformed file.</param>
    /// <param name="originalLineNumber">Number of the original line in the shift table.</param>
    /// <returns>Original file.</returns>
    public static byte[] ReverseBWT(byte[] bytes, int originalLineNumber)
    {
        var sortedInput = bytes;
        Array.Sort(sortedInput);
        var dictionary = CreateDictionary(sortedInput);
        var positionArray = new int[bytes.Length];
        for (int i = 0; i < positionArray.Length; i++)
        {
            positionArray[i] = dictionary[bytes[i]];
            dictionary[bytes[i]]++;
        }

        int currentPos = originalLineNumber;
        var result = new byte[bytes.Length];
        for (int i = bytes.Length - 1; i >= 0; i--)
        {
            result[i] = bytes[currentPos];
            currentPos = positionArray[currentPos];
        }

        return result;
    }

    private static byte[] CycleShift(byte[] input, int offset)
    {
        var output = new byte[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            if (i + offset >= input.Length)
            {
                offset = -i;
            }

            output[i] = input[i + offset];
        }

        return output;
    }

    private static string SortString(string input)
    {
        var array = input.ToCharArray();
        Array.Sort(array, StringComparer.Ordinal);
        return new string(array);
    }

    private static Dictionary<byte, int> CreateDictionary(byte[] sortedInput)
    {
        var dictionary = new Dictionary<byte, int>();
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