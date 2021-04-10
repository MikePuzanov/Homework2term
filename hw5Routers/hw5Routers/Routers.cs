using System;
using System.IO;
using System.Collections.Generic;

namespace hw5Routers
{
    public class Routers
    {
        public int[,] CreateGraph(string filePath)
        {
            int vertices = CountsVertices(filePath);
            var matrix = new int[vertices, vertices];
            var file = new StreamReader(filePath);
            string stringLine = file.ReadLine();
            while (stringLine != null)
            {
                stringLine = stringLine.Replace(':', ' ');
                stringLine = stringLine.Replace(',', ' ');
                string[] lineDrop = stringLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var numberFirst = Int32.Parse(lineDrop[0]);
                for (int i = 1; i < lineDrop.Length; ++i)
                {
                    var numberSecond = Int32.Parse(lineDrop[i]);
                    var distance = Int32.Parse(lineDrop[i + 1].Substring(1, lineDrop.Length - 2));
                    matrix[numberFirst, numberSecond] = matrix[numberSecond, numberFirst] = distance;
                }
            }
            return matrix;
        }

        public int CountsVertices(string path)
        {
            var file = new StreamReader(path);
            string stringLine = file.ReadLine();
            var list = new List<int>();
            int vertice = 0;
            while (stringLine != null)
            {
                stringLine = stringLine.Replace(':', ' ');
                stringLine = stringLine.Replace(',', ' ');
                string[] lineDrop = stringLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var number = Int32.Parse(lineDrop[0]);
                if (!list.Contains(number))
                {
                    list.Add(number);
                    vertice++;
                }
                for (int i = 0; i < lineDrop.Length / 2; ++i)
                {
                    number = Int32.Parse(lineDrop[2 * i + 1]);
                    if (!list.Contains(number))
                    {
                        list.Add(number);
                        vertice++;
                    }
                }
            }
            return vertice;
        }

        public void WriteInFile(int[,] matrix, string filePath)
        {
            FileInfo fileOut = new FileInfo(filePath);
            if (fileOut.Exists)
            {
                fileOut.Delete();
            }
            FileStream currentFile = new FileStream(filePath, FileMode.Create);
            StreamWriter writer = new StreamWriter(currentFile);


        }
    }
}
