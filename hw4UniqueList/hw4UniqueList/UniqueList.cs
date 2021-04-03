 using System;
using System.Collections.Generic;
using System.Text;

namespace hw4UniqueList
{
    public class UniqueList : List
    {
        public override void Insert(int possition, int value)
        {
            if (IsConsist(value))
            {
                throw new ValueIsAlreadyInListException("Такое значение уже есть в списке!");
            }    
            base.Insert(possition, value);
        }

        public override int DeleteByIndex(int possition)
        {
            if (possition > GetSize() || possition < 1)
            {
                throw new IndexOutOfRangeException();
            }
            return base.DeleteByIndex(possition);
        }

        public override void DeleteByValue(int value)
        {
            if (!IsConsist(value))
            {
                throw new ValueDoesNotExistException("Такого значения в списке не существует!");
            }
            base.DeleteByValue(value);
        }

        public override void ChangeByIndex(int possition, int value)
        {
            if (possition > GetSize() || possition < 1)
            {
                throw new IndexOutOfRangeException();
            }
            else if (IsConsist(value))
            {
                throw new ValueIsAlreadyInListException("Такое значение уже есть в списке!");
            }
            base.ChangeByIndex(possition, value);
        }
    }
}
