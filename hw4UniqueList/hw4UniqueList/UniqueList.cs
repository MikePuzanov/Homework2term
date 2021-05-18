 using System;
using System.Collections.Generic;
using System.Text;

namespace Hw4UniqueList
{
    /// <summary>
    /// Список без повторяющихся значений
    /// </summary>
    public class UniqueList : List
    {
        public override void Insert(int position, int value)
        {
            if (Contains(value))
            {
                throw new ValueIsAlreadyInListException("Такое значение уже есть в списке!");
            }    
            base.Insert(position, value);
        }

        public override void ChangeByIndex(int position, int value)
        {
            if (GetValueByIndex(position) == value)
            {
                return;
            }
            if (Contains(value))
            {
                throw new ValueIsAlreadyInListException("Такое значение уже есть в списке!");
            }
            base.ChangeByIndex(position, value);
        }
    }
}
