 using System;
using System.Collections.Generic;
using System.Text;

namespace hw4UniqueList
{
    /// <summary>
    /// Список без повторяющихся значений
    /// </summary>
    public class UniqueList : List
    {
        public override void Insert(int possition, int value)
        {
            if (Contains(value))
            {
                throw new ValueIsAlreadyInListException("Такое значение уже есть в списке!");
            }    
            base.Insert(possition, value);
        }

        public override int DeleteByIndex(int possition)
        {
            return base.DeleteByIndex(possition);
        }

        public override void DeleteByValue(int value)
        {
            base.DeleteByValue(value);
        }

        public override void ChangeByIndex(int possition, int value)
        {
            if (GetValueByIndex(possition) == value)
            {
                return;
            }
            if (Contains(value))
            {
                throw new ValueIsAlreadyInListException("Такое значение уже есть в списке!");
            }
            base.ChangeByIndex(possition, value);
        }
    }
}
