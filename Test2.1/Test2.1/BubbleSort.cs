using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2._1
{
    /// <summary>
    /// класс с сортировкой пызырьком
    /// </summary>
    public static class BubbleSort
    {
        /// <summary>
        /// сортировка пузырьком
        /// </summary>
        /// <typeparam name="T">тип класса</typeparam>
        /// <param name="list">лист значений</param>
        /// <param name="compare">компаратор</param>
        public static void Sort<T>(List<T> list, Comparer<T> compare)
        {
            var lenght = list.Count;
            for (var i = 0; i < lenght; i++)
            {
                for (var j = lenght - 1; j > i; j--)
                {
                    if (compare.Compare(list[j - 1], list[j]) >= 0)
                    {
                        //Swap(ref list[j], list[j + 1]);
                        var helper = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = helper;
                    }
                }
            }
        }
    }
}