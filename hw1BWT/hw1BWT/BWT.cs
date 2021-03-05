using System;
using System.Linq;

namespace hw1BWT
{
    class BWT
    {
        public static bool Test()
        {
            string string1 = "abcab";
            var (result, numberOfString) = BWTtransform(string1);
            if (result != "cbaab")
            {
                return false;
            }
            string oldString1 = ReverseBWT("cbaab", numberOfString);
            return (oldString1 == string1);
        }
        private static void SwapStrings(char[,] transpositionTable, int i, int j)
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

        private static void SortTable(char[,] table)
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

        public static Tuple<string, int> BWTtransform(string str)
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

        private static char[] GetAlphabet(char[] str)
        {
            string alphabet = "";
            for (int i = 0; i < str.Length; ++i)
            {
                if (!alphabet.Contains(str[i]))
                {
                    alphabet += str[i];
                }
            }
            char[] alphaberArray = alphabet.ToCharArray(0, alphabet.Length);
            Array.Sort(alphaberArray);
            return alphaberArray;
        }

        public static string ReverseBWT(string str, int numberOfStr)
        {
            char[] line = str.ToCharArray(0, str.Length);
            char[] alphabetOfString = GetAlphabet(line);
            var countSymbolsInStr = new int[alphabetOfString.Length];
            for (int i = 0; i < alphabetOfString.Length; ++i)
            {
                countSymbolsInStr[i] = line.Where(x => x == alphabetOfString[i]).Count();
            }
            var numerationSymbols = new int[alphabetOfString.Length];
            int sumSymbols = 0;
            for (int i = 0; i < countSymbolsInStr.Length; ++i)
            {
                sumSymbols += countSymbolsInStr[i];
                if (i == 0)
                {
                    numerationSymbols[i] = 0;
                }
                else
                {
                    numerationSymbols[i] = sumSymbols - countSymbolsInStr[i];
                }
            }
            var helper = new int[line.Length];
            for (int i = 0; i < line.Length; i++)
            {
                for (int j = 0; j < alphabetOfString.Length; j++)
                {
                    if (line[i] == alphabetOfString[j])
                    {
                        helper[i] = numerationSymbols[j];
                        numerationSymbols[j]++;
                    }
                }
            }
            var answer = new char[line.Length];
            for (int i = line.Length - 1; i > -1; i--)
            {
                answer[i] = line[numberOfStr];
                numberOfStr = helper[numberOfStr];
            }
            var result = new String(answer);
            result = result.Substring(0, result.Length);
            return result;
        }
    }
}