using System;
using System.Collections.Generic;
using System.Text;

namespace hw5Routers
{
    class AlgorithmPrima
    {
        static int maxKey(int[] key, bool[] mstSet)
        {
            int max = int.MinValue;
            int indexMax = -1;
            for (int i = 0; i < key.Length; i++)
                if (mstSet[i] == false && key[i] > max)
                {
                    max = key[i];
                    indexMax = i;
                }
            return indexMax;
        }

        static void Algorithm(int[,] matrix)
        {
            int size = matrix.Length;
            int[] parent = new int[size]; 
            int[] key = new int[size];
            bool[] isConsist = new bool[size];
            for (int i = 0; i < size; i++)
            {
                key[i] = int.MaxValue;
                isConsist[i] = false;
            }
            key[0] = 0;
            parent[0] = -1;
            for (int count = 0; count < size - 1; count++)
            {
                int u = maxKey(key, isConsist);
                isConsist[u] = true;
                for (int v = 0; v < size; v++)
                {
                    if (matrix[u, v] != 0 && isConsist[v] == false && matrix[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = matrix[u, v];
                    }
                }
            }
            ///
            ///
            ///
        }
    }
}