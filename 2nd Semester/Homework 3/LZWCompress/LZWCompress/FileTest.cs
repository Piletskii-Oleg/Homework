using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZWCompress
{
    internal static class FileTest
    {
        public static void CopyStuff(string path, string resultPath)
        {
            using (var reader = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
            {
                using (var writer = new BinaryWriter(new FileStream(resultPath, FileMode.Create, FileAccess.Write), Encoding.Unicode))
                {
                    while (true)
                    {
                        try
                        {
                            writer.Write(reader.ReadInt32());
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
//using (var writeFile = File.OpenWrite(path + ".zipped"))
//{
//    string input = "ewrwer";
//    var trie = new Trie();
//    var result = new List<int>();
//    var dictionarySize = 0;
//    string previousElement = string.Empty;
//    for (int i = 0; i < input.Length; i++)
//    {
//        string currentElement = previousElement + input[i].ToString();
//        if (trie.Contains(currentElement))
//        {
//            previousElement = currentElement;
//        }
//        else
//        {
//            trie.Add(currentElement, dictionarySize++);
//            int toPut = trie.getNumber(previousElement);
//            var bytes = Encoding.UTF8.GetBytes(toPut.ToString());
//            writeFile.Write(bytes);
//            previousElement = input[i].ToString();
//        }
//    }

//    if (!string.IsNullOrEmpty(previousElement))
//    {
//        result.Add(trie.getNumber(previousElement));
//    }
//}
