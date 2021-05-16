using System;
using System.Collections.Generic;
using System.Text;

namespace Hw5Routers
{
    /// <summary>
    /// Класс, реализующий алгоритм Прима
    /// </summary>
    public static class AlgorithmPrima
    {
        private static bool CheckGraph(int[,] matrix)
        {
            var vertexStatus = new int[matrix.GetLength(0)];
            int number = 1;
            vertexStatus[0] = number;
            int count = 0;
            while (count < matrix.GetLength(0) && !Check(vertexStatus))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (vertexStatus[i] == number)
                    {
                        for (int j = 0; j < matrix.GetLength(0); j++)
                        {
                            if (matrix[i, j] != 0 && vertexStatus[j] == 0)
                            {
                                vertexStatus[j] = number + 1;
                            }
                        }
                    }
                }
                number++;
                count++;
            }
            return Check(vertexStatus);
        }

        private static bool Check(int[] vertexStatus)
        {
            for (int i = 0; i < vertexStatus.Length; i++)
            {
                if (vertexStatus[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static int MaxKey(int[] key, bool[] isConsist)
        {
            int max = int.MinValue;
            int indexMax = -1;
            for (int i = 0; i < key.Length; i++)
            {
                if (!isConsist[i] && key[i] > max)
                {
                    max = key[i];
                    indexMax = i;
                }
            }
            return indexMax;
        }

        /// <summary>
        /// алгоритм Прима
        /// </summary>
        /// <returns>новую матрицу</returns>
        public static int[,] Algorithm(int[,] matrix)
        {
            if (!CheckGraph(matrix))
            {
                throw new GraphDisconnectedException();
            }
            int size = matrix.GetLength(0);
            int[] parent = new int[size]; 
            int[] key = new int[size];
            bool[] isConsist = new bool[size];
            for (int i = 0; i < size; i++)
            {
                key[i] = int.MinValue;
            }
            key[0] = 0;
            parent[0] = -1;
            for (int count = 0; count < size - 1; count++)
            {
                int indexFirst = MaxKey(key, isConsist);
                isConsist[indexFirst] = true;
                for (int indexSecond = 0; indexSecond < size; indexSecond++)
                {
                    if (matrix[indexFirst, indexSecond] != 0 && isConsist[indexSecond] == false && matrix[indexFirst, indexSecond] > key[indexSecond])
                    {
                        parent[indexSecond] = indexFirst;
                        key[indexSecond] = matrix[indexFirst, indexSecond];
                    }
                }
            }
            return CreateMatrix(parent, matrix);
        }

        private static int[,] CreateMatrix(int[] parent, int[,] matrix)
        {
            var newMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            for (int i = 1; i < matrix.GetLength(0); ++i)
            {
                newMatrix[parent[i], i] = newMatrix[i, parent[i]] = matrix[i, parent[i]];
            }
            return newMatrix;
        }
    }
}