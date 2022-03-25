using System.Text;
namespace LZWCompress;

internal class LZW
{
    public static void Encode(string path)
    {
        using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            var trie = new Trie();
            int dictionarySize = 0;
            for (int i = 0; i < 256; i++)
            {
                trie.Add(new byte[] { (byte)i }, dictionarySize++);
            }

            var previousElement = new List<byte>();
            using (var writer = new BinaryWriter(File.Open(path + ".zipped", FileMode.Create)))
            {
                int byteAmount = 1;
                while (true)
                {
                    try
                    {
                        var currentElement = new List<byte>(previousElement);
                        byte currentByte = reader.ReadByte();
                        currentElement.Add(currentByte);
                        if (trie.Contains(currentElement.ToArray()))
                        {
                            previousElement = new List<byte>(currentElement);
                        }
                        else
                        {
                            var toWrite = trie.GetNumberInDictionary(previousElement.ToArray());
                            //writer.Write(BitConverter.ToInt16(toWrite));

                            trie.Add(currentElement.ToArray(), dictionarySize++);
                            previousElement.Clear();
                            previousElement.Add(currentByte);
                        }

                        if (dictionarySize >= Math.Pow(256, byteAmount))
                        {
                            byteAmount++;
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        if (previousElement.Count > 0)
                        {
                            writer.Write(trie.GetNumberInDictionary(previousElement.ToArray()));
                        }
                        break;
                    }
                }
            }
        }
    }

    public static void Decode(string path)
    {
        var dictionary = new Dictionary<int, List<byte>>();
        for (int i = 0; i < 256; i++)
        {
            dictionary.Add(i, new List<byte> { (byte)i });
        }

        using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            using (var writer = new BinaryWriter(File.Open(path + ".txt", FileMode.Create)))
            {
                var byteAmount = 2;
                var previousElement = new List<byte>();
                previousElement.AddRange(reader.ReadBytes(2));
                writer.Write(previousElement.ToArray());
                while (true)
                {
                    try
                    {
                        var currentBytes = new List<byte>(reader.ReadBytes(2));
                        var currentNumber = BitConverter.ToInt16(currentBytes.ToArray());

                        var currentElement = new List<byte>();
                        if (dictionary.ContainsKey(currentNumber))
                        {
                            currentElement = dictionary[currentNumber];
                        }
                        else
                        {
                            currentElement = new List<byte>(previousElement);
                            currentElement.Add(previousElement[0]);
                        }

                        var toWrite = new List<byte>(currentElement);
                        while (toWrite.Count < 1)
                        {
                            toWrite.Add(0);
                        }
                        writer.Write(currentElement.ToArray());
                        previousElement.Add(currentElement[0]);
                        dictionary.Add(dictionary.Count, previousElement);
                        previousElement = new List<byte>(currentElement);

                        if (dictionary.Count >= Math.Pow(256, byteAmount))
                        {
                            byteAmount++;
                        }
                    }
                    catch (EndOfStreamException)
                    {
                        break;
                    }
                }
            }
        }
    }

    //public static string Decode(List<int> encodedText)
    //{
    //    var trie = new Trie();
    //    var dictionarySize = 0;
    //    for (int i = 0; i < 256; i++)
    //    {
    //        trie.Add(((char)i).ToString(), dictionarySize++);
    //    }

    //    string character = ((char)encodedText[0]).ToString();
    //    encodedText.RemoveAt(0);
    //    var decodedText = new StringBuilder(character);
    //    foreach (int item in encodedText)
    //    {
            
    //    }
    //    return "";
    //}
}
