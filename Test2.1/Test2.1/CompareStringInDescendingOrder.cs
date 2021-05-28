using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2._1
{
    /// <summary>
    /// сравнивает string, обратное обычное Compare
    /// </summary>
    public class CompareStringInDescendingOrder : Comparer<string>
    {
        public override int Compare(string value1, string value2)
        {
            return value2.CompareTo(value1);
        }
    }
}
