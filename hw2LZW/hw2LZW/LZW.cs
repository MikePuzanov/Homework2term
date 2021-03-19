using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace hw2LZW
{
    public static class LZW
    {
        private static int GetCountOfBytes(byte[] array)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] != 0)
                {
                    return i + 1;
                }
            }
            return 1;
        }

        public static void Compress(string pathFile)
        {
            using var readFile = new FileStream(pathFile, FileMode.Open);
            var trie = new Trie();
            var codes = new Queue<int>();
            for (int i = 0; i < readFile.Length; ++i)
            {
                var byter = (byte)readFile.ReadByte();
                var codeOfBytes = trie.IsAdd(byter);
                if (codeOfBytes != -1)
                {
                    codes.Enqueue(codeOfBytes);
                    trie.IsAdd(byter);
                }
            }
            codes.Enqueue(trie.GetCode());
            var countOfBytes = GetCountOfBytes(BitConverter.GetBytes(trie.CountCodes));
            using var writeFile = new FileStream(pathFile + ".zipped", FileMode.CreateNew);
            writeFile.WriteByte((byte)countOfBytes);
            for (int i = 0; i < codes.Count; i++)
            {
                var helpArray = BitConverter.GetBytes(codes.Dequeue());
                writeFile.Write(helpArray, 0, countOfBytes);
            }
        }

        private static Hashtable InitializeHashtable()
        {
            var hashtable = new Hashtable();
            for (int i = 0; i < 256; i++)
            {
                hashtable.Add(i, new byte[] { (byte)i });
            }
            return hashtable;
        }

        private static void AddLastSymbol(int code, Hashtable hashtable)
        {
            var bytes = (byte[])hashtable[code];
            var previous = (byte[])hashtable[hashtable.Count - 1];
            previous[previous.Length - 1] = bytes[0];
        }

        public static void Decompress(string pathFile)
        {
            var hashtable = InitializeHashtable();
            var codes = hashtable.Count;
            using var readFile = new FileStream(pathFile, FileMode.Open);
            using var writeFile = new FileStream(pathFile.Substring(0, pathFile.Length - 7), FileMode.OpenOrCreate);
            int maxLenght = readFile.ReadByte();
            for (int i = 0; i < readFile.Length - 1; i += maxLenght)
            {
                var codeInBytes = new byte[4];
                for (int j = 0; j < maxLenght; ++j)
                {
                    codeInBytes[j] = (byte)readFile.ReadByte();
                }
                var code = BitConverter.ToInt32(codeInBytes, 0);
                if (i != 0)
                {
                    AddLastSymbol(code, hashtable);
                }
                var bytesArray = (byte[])hashtable[code];
                var copyBytesArray = new byte[bytesArray.Length + 1];
                Array.Copy(bytesArray, copyBytesArray, bytesArray.Length);
                hashtable.Add(codes, copyBytesArray);
                codes++;
                writeFile.Write(bytesArray);
            }
        }
    }
}