using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2._1
{
    /// <summary>
    /// сравнивает int, обратное обычное Compare
    /// </summary>
    public class CompareIntInDescendingOrder : Comparer<int>
    {
        public override int Compare(int value1, int value2)
        {
            return value1 <= value2 ? 1 : -1 ;
        }
    }
}
