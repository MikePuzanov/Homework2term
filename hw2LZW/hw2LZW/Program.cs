using System;
using System.IO;

namespace hw2LZW
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }
            if (args[1] == "-c")
            {
                LZW.Compress(args[0]);
                var compressedFileSize = new FileInfo(args[0]);
                var decompressedFileSize = new FileInfo(args[0] + ".zipped");
                Console.WriteLine($"Коэффициент сжатия: x {(double)compressedFileSize.Length / decompressedFileSize.Length}");
            }
            else if (args[1] == "-u")
            {
                LZW.Decompress(args[0]);
                Console.WriteLine("Файл разжат!");
            }
            else
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }
        }
    }
}