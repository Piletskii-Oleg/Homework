using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace LZWCompress;

internal class LZW
{
    public static List<int> Encode(string input)
    {
        var trie = new Trie();
        var result = new List<int>();
        var dictionarySize = 0;

        for (int i = 0; i < 256; i++)
        {
            trie.Add(((char)i).ToString(), dictionarySize++);
        }

        string previousElement = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            string currentElement = previousElement + input[i].ToString();
            if (trie.Contains(currentElement))
            {
                previousElement = currentElement;
            }
            else
            {
                trie.Add(currentElement, dictionarySize++);
                result.Add(trie.getNumber(previousElement));
                previousElement = input[i].ToString();
            }
        }

        if (!string.IsNullOrEmpty(previousElement))
        {
            result.Add(trie.getNumber(previousElement));
        }
        return result;
    }

    public static void Compress(string path)
    {
        using (var openFile = File.OpenRead(path))
        {
            var buffer = new byte[openFile.Length];
            openFile.Read(buffer, 0, buffer.Length);
            string text = Encoding.UTF8.GetString(buffer);
            var toPut = Encode(text);
            var bytes = toPut.SelectMany<int, byte>(BitConverter.GetBytes).ToArray();
            using (var writeFile = File.OpenWrite(path + ".zipped"))
            {
                writeFile.Write(bytes);
            }
            
        }

    }

    public static string Decode(List<int> encodedText)
    {
        var trie = new Trie();
        var dictionarySize = 0;
        for (int i = 0; i < 256; i++)
        {
            trie.Add(((char)i).ToString(), dictionarySize++);
        }

        string character = ((char)encodedText[0]).ToString();
        encodedText.RemoveAt(0);
        var decodedText = new StringBuilder(character);
        foreach (int item in encodedText)
        {
            
        }
        return "";
    }
}
