using System;
using System.IO;
using System.Collections.Generic;

namespace Hw5Routers
{
    /// <summary>
    /// класс для работы с файлами
    /// </summary>
    public static class FileFunctions
    {
        /// <summary>
        /// создает граф по файлу
        /// </summary>
        /// <returns>матрицу графа</returns>
        public static int[,] CreateGraph(string filePath)
        {
            if (filePath == "")
            {
                throw new NoParametersException();
            }
            int vertices = CountVertexes(filePath);
            var matrix = new int[vertices, vertices];
            using var file = new StreamReader(filePath);
            string stringLine = file.ReadLine();
            while (stringLine != null)
            {
                string[] split = new string[] { " ", ",", ":" };
                string[] lineDrop = stringLine.Split(split, StringSplitOptions.RemoveEmptyEntries);
                var numberFirst = Int32.Parse(lineDrop[0]) - 1;
                for (int i = 1; i < lineDrop.Length - 1; i += 2)
                {
                    var numberSecond = Int32.Parse(lineDrop[i]) - 1;
                    var distance = Int32.Parse(lineDrop[i + 1].Substring(1, lineDrop[i + 1].Length - 2));
                    matrix[numberFirst, numberSecond] = matrix[numberSecond, numberFirst];
                    matrix[numberFirst, numberSecond] = distance;
                }
                stringLine = file.ReadLine();
            }
            return matrix;
        }

        private static int CountVertexes(string path)
        {
            using var file = new StreamReader(path);
            string stringLine = file.ReadLine();
            var list = new List<int>();
            int vertice = 0;
            while (stringLine != null)
            {
                stringLine = stringLine.Replace(':', ' ');
                stringLine = stringLine.Replace(',', ' ');
                string[] lineDrop = stringLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var number = Int32.Parse(lineDrop[0]) - 1;
                if (!list.Contains(number))
                {
                    list.Add(number);
                    vertice++;
                }
                for (int i = 0; i < lineDrop.Length / 2; ++i)
                {
                    number = Int32.Parse(lineDrop[2 * i + 1]) - 1;
                    if (!list.Contains(number))
                    {
                        list.Add(number);
                        vertice++;
                    }
                }
                stringLine = file.ReadLine();
            }
            return vertice;
        }

        /// <summary>
        /// записывает итогую матрицу в файл
        /// </summary>
        public static void WriteInFile(int[,] matrix, string filePath)
        {
            if (filePath == "")
            {
                throw new NoParametersException();
            }
            var fileOut = new FileInfo(filePath);
            if (fileOut.Exists)
            {
                fileOut.Delete();
            }
            using var newFile = new FileStream(filePath, FileMode.Create);
            var file = new StreamWriter(newFile);
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                var line = $"{i + 1}: ";
                for (int j = i + 1; j < matrix.GetLength(0); ++j)
                {
                    if (matrix[i, j] != 0)
                    {
                        line += $"{j + 1} ({matrix[i, j]}), ";
                    }
                }
                if (line != $"{i + 1}: ")
                {
                    file.WriteLine(line.Substring(0, line.Length - 2));
                }
            }
            file.Close();
            if (fileOut.Exists)
            {
                fileOut.MoveTo(filePath);
            }
        }
    }
}
