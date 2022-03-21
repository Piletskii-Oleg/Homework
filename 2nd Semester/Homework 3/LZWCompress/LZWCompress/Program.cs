namespace LZWCompress;
using System.Collections;
class Program
{
    static void Main(string[] args)
    {
        string testPath = "C:\\Users\\Oleg\\Documents\\GitHub\\Homework\\2nd Semester\\Homework 3\\LZWCompress\\LZWCompress\\test2.txt";
        string programPath = "C:\\Users\\Oleg\\Documents\\GitHub\\Homework\\2nd Semester\\Homework 3\\LZWCompress\\LZWCompress.Tests\\torigoth.mp3";
        string resultPath = "C:\\Users\\Oleg\\Documents\\GitHub\\Homework\\2nd Semester\\Homework 3\\LZWCompress\\LZWCompress.Tests\\Cat2.mp4";
        var arr1 = new BitArray(new int[] { 30665 });
        var arr2 = new BitArray(new byte[] { 0, 201, 119 });
        var arr3 = new BitArray(new byte[] { 201, 119 });
        int[] array = new int[1];
        int[] array2 = new int[1];
        arr2.CopyTo(array, 0);
        arr3.CopyTo(array2, 0);
        LZW2.Encode(testPath);
        LZW2.Decode(testPath + ".zipped");

        //using (var reader = new BinaryReader(File.Open(testPath, FileMode.Open)))
        //{

        //    using (var writer = new BinaryWriter(File.Open(testPath + ".txt", FileMode.Create)))
        //    {
        //        int count = 1;
        //        var buffer = new List<byte>();
        //        while (true)
        //        {
        //            try
        //            {
        //                for (int i = 0; i < count; i++)
        //                {
        //                    buffer.Add(reader.ReadByte());
        //                }
        //                var bitArray = new BitArray(buffer.ToArray());
        //                var iterations = count;
        //                while (iterations > 0)
        //                {
        //                    var byteToWrite = new byte[1];
        //                    var oneByte = new BitArray(8);
        //                    for (int i = 0; i < 8; i++)
        //                    {
        //                        oneByte[i] = bitArray[i];
        //                    }
        //                    oneByte.CopyTo(byteToWrite, 0);
        //                    writer.Write(byteToWrite);
        //                    bitArray.RightShift(8);
        //                    iterations--;
        //                }
        //                buffer.Clear();
        //                count++;
        //            }
        //            catch (EndOfStreamException)
        //            {
        //                if (buffer.Any())
        //                {
        //                    var bitArray = new BitArray(buffer.ToArray());
        //                    var iterations = count;
        //                    while (iterations > 0)
        //                    {
        //                        var byteToWrite = new byte[1];
        //                        var oneByte = new BitArray(8);
        //                        for (int i = 0; i < 8; i++)
        //                        {
        //                            oneByte[i] = bitArray[i];
        //                        }
        //                        oneByte.CopyTo(byteToWrite, 0);
        //                        writer.Write(byteToWrite);
        //                        bitArray.RightShift(8);
        //                        iterations--;
        //                    }
        //                }
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}