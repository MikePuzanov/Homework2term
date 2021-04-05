using System;
using System.Linq;

namespace hw1BWT
{
    static class BWT
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
            return oldString1 == string1;
        }

        private static int[] WriteSuffixArray(string str)
        {
            var suffixArray = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                suffixArray[i] = i;
            }
            return suffixArray;
        }

        public static Tuple<string, int> BWTtransform(string str)
        {
            var suffixArray = WriteSuffixArray(str);
            for (int i = 1; i < suffixArray.Length; i++)
            {
                for (int j = 0; j < suffixArray.Length - i; j++)
                {
                    string str1 = str.Substring(suffixArray[j]) + str.Substring(0, suffixArray[j]);
                    string str2 = str.Substring(suffixArray[j + 1]) + str.Substring(0, suffixArray[j + 1]);
                    if (String.Compare(str1, str2) > 0)
                    {
                        int swaper = suffixArray[j];
                        suffixArray[j] = suffixArray[j + 1];
                        suffixArray[j + 1] = swaper;
                    }
                }
            }
            string result = "";
            var strSize = str.Length;
            for (int i = 0; i < suffixArray.Length; i++)
            {
                if (suffixArray[i] == 0)
                {
                    result += str[strSize - 1];
                }
                else
                {
                    result += str[suffixArray[i] - 1];
                }
            }
            return new Tuple<string, int>(result, Array.IndexOf(suffixArray, 0));
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
            char[] alphabetArray = alphabet.ToCharArray(0, alphabet.Length);
            Array.Sort(alphabetArray);
            return alphabetArray;
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