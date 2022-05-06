namespace LZWCompress;

/// <summary>
/// Implementation of the Lempel-Ziv-Welch algorithm.
/// </summary>
public static class LZWCompress
{
    /// <summary>
    /// Encodes file.
    /// </summary>
    /// <param name="path">Path to the file.</param>
    public static void Encode(string path)
    {
        var trie = new Trie();
        for (int i = 0; i < 256; i++)
        {
            trie.Add(new[] { (byte)i }.ToList());
        }

        var allBytes = File.ReadAllBytes(path);
        using var writer = new BinaryWriter(File.Open(path + ".zipped", FileMode.Create));
        int byteAmount = 1;
        var previousBytes = new List<byte>();
        foreach (byte b in allBytes)
        {
            var currentBytes = previousBytes.ToList();
            currentBytes.Add(b);
            if (trie.Contains(currentBytes))
            {
                previousBytes = currentBytes.ToList();
            }
            else
            {
                trie.Add(currentBytes);
                int currentNumber = trie.GetNumberInDictionary(previousBytes);
                previousBytes.Clear();
                previousBytes.Add(currentBytes[^1]);
                writer.Write(TransformToBytes(currentNumber, byteAmount));
                if (trie.Size >= Math.Pow(2, byteAmount * 8))
                {
                    byteAmount++;
                }
            }
        }

        if (previousBytes.Any())
        {
            int currentNumber = trie.GetNumberInDictionary(previousBytes);
            writer.Write(TransformToBytes(currentNumber, byteAmount));
        }
    }

    /// <summary>
    /// Calculates coefficient of compression after using LZW.
    /// </summary>
    /// <param name="path">Path to the original file.</param>
    /// <returns>Compression Coefficient.</returns>
    public static double GetCompressionCoefficient(string path)
    {
        var originalSize = new FileInfo(path).Length;
        var newSize = new FileInfo(path + ".zipped").Length;
        return (double)originalSize / newSize;
    }

    /// <summary>
    /// Decodes file encoded by the LZW algorithm.
    /// </summary>
    /// <param name="path">Path to the encoded file.</param>
    public static void Decode(string path)
    {
        var dictionary = new Dictionary<int, List<byte>>();
        for (int i = 0; i < 256; i++)
        {
            dictionary.Add(i, new List<byte> { (byte)i });
        }

        var result = new List<byte>();
        var allBytes = File.ReadAllBytes(path);
        result.Add(allBytes[0]);
        var previousBytes = new List<byte>(new[] { allBytes[0] });
        int byteAmount = 2;
        int currentByte = 1;
        while (currentByte < allBytes.Length)
        {
            var currentBytes = new List<byte>();
            for (int j = 0; j < byteAmount; j++)
            {
                currentBytes.Add(allBytes[currentByte++]);
            }

            currentByte--;
            var numberInDictionary = ByteListIntoInt(currentBytes);
            if (dictionary.ContainsKey(numberInDictionary))
            {
                currentBytes = dictionary[numberInDictionary].ToList();
            }
            else
            {
                currentBytes = previousBytes.ToList();
                currentBytes.Add(previousBytes[0]);
            }

            result.AddRange(currentBytes);
            previousBytes.Add(currentBytes[0]);
            dictionary.Add(dictionary.Count, previousBytes);
            previousBytes = currentBytes.ToList();
            if (dictionary.Count >= Math.Pow(2, byteAmount * 8) - 1)
            {
                byteAmount++;
            }

            currentByte++;
        }

        var resultPath = new string(path.ToCharArray(), 0, path.Length - 7);
        resultPath = resultPath.Insert(resultPath.Length - Path.GetExtension(resultPath).Length, "-unzipped");
        File.WriteAllBytes(resultPath, result.ToArray());
    }

    private static byte[] TransformToBytes(int number, int byteAmount)
    {
        var bytes = new List<byte>(byteAmount);
        byte oneByte = 0;
        byte currentBit = 1;
        while (number > 0)
        {
            if (number % 2 != 0)
            {
                oneByte |= currentBit;
            }

            number >>= 1;
            if (currentBit < 128)
            {
                currentBit <<= 1;
            }
            else
            {
                bytes.Insert(0, oneByte);
                oneByte = 0;
                currentBit = 1;
            }
        }

        if (currentBit > 1)
        {
            bytes.Insert(0, oneByte);
        }

        while (bytes.Count < byteAmount)
        {
            bytes.Insert(0, 0);
        }

        return bytes.ToArray();
    }

    private static int ByteListIntoInt(List<byte> list)
    {
        int result = 0;
        for (int i = 0; i < list.Count; i++)
        {
            result += list[list.Count - i - 1] * (int)Math.Pow(256, i);
        }

        return result;
    }
}