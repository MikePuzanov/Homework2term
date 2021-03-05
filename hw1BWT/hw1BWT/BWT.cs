using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace hw1BWT
{
    class BWT
    {
        static void SwapStrings(char[,] transpositionTable, int i, int j)
        {
            int size = transpositionTable.GetLength(0);
            for (int t = 0; t < size; ++t)
            {
                char swapHelper = transpositionTable[i, t];
                transpositionTable[i, t] = transpositionTable[j, t];
                transpositionTable[j, t] = swapHelper;
            }
        }

        private static bool CompareStrs(char[,] table, int i, int j)
        {
            for (int l = 0; l < table.GetLength(0); ++l)
            {
                if (table[i, l] > (table[j, l]))
                {
                    return true;
                }
                else if (table[i, l] < (table[j, l]))
                {
                    return false;
                }
            }
            return false;
        }

        static void SortTable(char[,] table)
        {
            int size = table.GetLength(0);
            for (int i = 0; i < size; ++i)
            {
                for (int j = size - 1; j > i; --j)
                {
                    if (CompareStrs(table, i, j))
                    {
                        SwapStrings(table, i, j);
                    }
                }
            }
        }

        public static Tuple<string, int> BWTransform(string str)
        {
            int size = str.Length;
            char[,] table = new char[size, size];
            for (int i = 0; i < size; ++i)
            {
                table[0, i] = str[i];
            }
            for (int i = 1; i < size; ++i)
            {
                table[i, 0] = table[i - 1, size - 1];
                for (int j = 1; j < size; ++j)
                {
                    table[i, j] = table[i - 1, j - 1];
                }
            }
            SortTable(table);
            int numberOfStr = 0;
            for (int i = 0; i < size; ++i)
            {
                int count = 0;
                if (table[i, 0] != str[0])
                {
                    continue;
                }
                for (int j = 0; j < size; ++j)
                {
                    if (table[i, j] != str[j])
                    {
                        break;
                    }
                    count++;
                }
                if (count == size)
                {
                    numberOfStr = i;
                    break;
                }
            }

            var resultString = new char[size];
            for (int i = 0; i < size; i++)
            {
                resultString[i] = table[i, size - 1];
            }
            var result = new String(resultString);
            return new Tuple<string, int>(result, numberOfStr);
        }
    }
}
