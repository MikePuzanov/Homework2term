using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6MapFilterFold
{
    public static class Functions<T>
    {
        public static List<T> Map(List<T> list, Func<T, T> function)
        {
            int count = list.Count;
            var resultList = new List<T>();
            foreach (var node in list)
            {
                resultList.Add(function(node));
            }
            return resultList;
        }

        public static List<T> Filter(List<T> list, Func<T, bool> function)
        {
            var returnList = new List<T>();
            foreach (var node in list)
            {
                if (function(node))
                {
                    returnList.Add(node);
                }
            }
            return returnList;
        }

        public static T Fold(List<T> list, T startValue,Func<T, T, T> function)
        {
            foreach (var node in list)
            {
                startValue = function(startValue, node);
            }
            return startValue;
        }
    }
}