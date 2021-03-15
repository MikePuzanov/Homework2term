using System;
using System.Collections.Generic;
using System.IO;

namespace hw2LZW
{
    class LZW
    {
        public static void Compress(string file)
        {
            using var readFile = new FileStream(file, FileMode.Open);
            file += ".zipped";
            using var writeFile = new FileStream(file, FileMode.CreateNew);
            var root = new Trie();
            var byter = readFile.ReadByte();
            for (int i = 0; i < readFile.Length; ++i)
            {

                if (i == readFile.Length - 1)
                {

                }
            }
        }

        public static void Decompress()
        {

        }
    }
}
