using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Collections;

namespace LZWCompress
{
    internal class LZW
    {
        public static void Encode(string path)
        {
            var trie = new Trie();
            for (int i = 0; i < 256; i++)
            {
                trie.Add(new byte[] { (byte)i }, i);
            }

            using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                int maxCodeLength = 8;
                int byteAmount = 1;
                using (var writer = new BinaryWriter(File.Open(path + ".zipped", FileMode.Create)))
                {
                    var previousBytes = new List<byte>();
                    while (true)
                    {
                        try
                        {
                            var currentBytes = previousBytes.ToList();
                            currentBytes.Add(reader.ReadByte());
                            if (trie.Contains(currentBytes.ToArray()))
                            {
                                previousBytes = currentBytes.ToList();
                            }
                            else
                            {
                                trie.Add(currentBytes.ToArray(), trie.Size);
                                int currentNumber = trie.GetNumberInDictionary(previousBytes.ToArray());
                                previousBytes.Clear();
                                previousBytes.Add(currentBytes[currentBytes.Count - 1]);

                                var bitArray = new BitArray(new int[] { currentNumber });
                                var iterations = byteAmount;
                                while (iterations > 0)
                                {
                                    var byteToWrite = new byte[1];
                                    var oneByte = new BitArray(8);
                                    for (int i = 0; i < 8; i++)
                                    {
                                        oneByte[i] = bitArray[i];
                                    }
                                    oneByte.CopyTo(byteToWrite, 0);
                                    var byteToFile = byteToWrite[0];
                                    writer.Write(byteToFile);
                                    bitArray.RightShift(8);
                                    iterations--;
                                }

                                if (trie.Size >= Math.Pow(2, maxCodeLength) - 1)
                                {
                                    maxCodeLength++;
                                    byteAmount = (int)Math.Ceiling((double)maxCodeLength / 8.0);
                                }
                            }

                            
                        }
                        catch (EndOfStreamException)
                        {
                            if (previousBytes.Any())
                            {
                                int currentNumber = trie.GetNumberInDictionary(previousBytes.ToArray());
                                var bitArray = new BitArray(new int[] { currentNumber });
                                var iterations = (int)Math.Ceiling((double)maxCodeLength / 8.0);
                                while (iterations > 0)
                                {
                                    var byteToWrite = new byte[1];
                                    var oneByte = new BitArray(8);
                                    for (int i = 0; i < 8; i++)
                                    {
                                        oneByte[i] = bitArray[i];
                                    }
                                    oneByte.CopyTo(byteToWrite, 0);
                                    writer.Write(byteToWrite);
                                    bitArray.RightShift(8);
                                    iterations--;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        public static void Decode(string path)
        {
            using (var reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                var dictionary = new Dictionary<int, List<byte>>();
                for (int i = 0; i < 256; i++)
                {
                    dictionary.Add(i, new List<byte> { (byte)i });
                }

                using (var writer = new BinaryWriter(File.Open(path + ".txt", FileMode.Create)))
                {
                    var previousBytes = new List<byte>();
                    previousBytes.Add(reader.ReadByte());
                    writer.Write(previousBytes.ToArray());
                    int byteAmount = 2;
                    int bitAmount = 9;

                    while (true)
                    {
                        try
                        {
                            var currentBytes = new List<byte>();
                            for (int i = 0; i < byteAmount; i++)
                            {
                                currentBytes.Add(reader.ReadByte());
                            }
                            for (int i = 0; i < currentBytes.Count; i++)
                            {
                                if (currentBytes[i] == 0)
                                {
                                    currentBytes.RemoveAt(0);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var bitArray = new BitArray(currentBytes.ToArray());
                            var numberInDictionary = new int[1];
                            bitArray.CopyTo(numberInDictionary, 0);

                            if (dictionary.ContainsKey(numberInDictionary[0]))
                            {
                                currentBytes = dictionary[numberInDictionary[0]].ToList();
                            }
                            else
                            {
                                currentBytes = previousBytes.ToList();
                                currentBytes.Add(previousBytes[0]);
                            }
                            writer.Write(currentBytes.ToArray());
                            previousBytes.Add(currentBytes[0]);
                            dictionary.Add(dictionary.Count, previousBytes);
                            previousBytes = currentBytes.ToList();
                            if (dictionary.Count >= Math.Pow(2, bitAmount) - 1)
                            {
                                bitAmount++;
                                byteAmount = (int)Math.Ceiling((double)bitAmount / 8.0);
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
    }
}
