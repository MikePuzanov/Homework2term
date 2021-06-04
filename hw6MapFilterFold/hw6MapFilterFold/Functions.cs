using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6MapFilterFold
{
    /// <summary>
    /// класс с функциями для списка
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Возвращается список, полученный применением переданной функции к каждому элементу переданного списка
        /// </summary>
        /// <param name="list">список</param>
        /// <param name="function">переданная функция</param>
        /// <returns>новый список</returns>
        public static List<TResult> Map<TValue, TResult>(List<TValue> list, Func<TValue, TResult> function)
        {
            var resultList = new List<TResult>();
            foreach (var node in list)
            {
                resultList.Add(function(node));
            }
            return resultList;
        }

        /// <summary>
        /// Возвращается список из элементов переданного списка, для которых переданная функция вернула true
        /// </summary>
        /// <param name="list">список</param>
        /// <param name="function">булевая функция</param>
        /// <returns>новый список</returns>
        public static List<TValue> Filter<TValue>(List<TValue> list, Func<TValue, bool> function)
        {
            var returnList = new List<TValue>();
            foreach (var node in list)
            {
                if (function(node))
                {
                    returnList.Add(node);
                }
            }
            return returnList;
        }

        /// <summary>
        ///  возвращает накопленное значение, получившееся после всего прохода списка
        /// </summary>
        /// <param name="list">список</param>
        /// <param name="startValue">начальное значение</param>
        /// <param name="function">функция</param>
        /// <returns>накопленное значение</returns>
        public static TResult Fold<TValue, TResult>(List<TValue> list, TResult startValue,Func<TResult, TValue, TResult> function)
        {
            foreach (var node in list)
            {
                startValue = function(startValue, node);
            }
            return startValue;
        }
    }
}