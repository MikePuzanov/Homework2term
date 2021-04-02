using System;
using System.Collections.Generic;
using System.Text;

namespace Test1._1Task1
{

    public class Vectors
    {
        public Dictionary<int, Vectors> VectorsDictionary { get; set; }

        public void Add(Vectors vector, int index)
        {
            VectorsDictionary.Add(index, vector);
        }

        public void delete(Vectors vector, int index)
        {
            VectorsDictionary.Add(index, vector);
        }

        public (int index, int number)[] Vector { get; set; }

        public int Size { get; set; }

        public Vectors(int size, (int index, int number)[] vector)
        {
            Size = size;
            Vector = new (int index, int number)[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                Vector[i] = vector[i];
            }
        }

        private bool CheckSize(int size1, int size2)
            => size1 == size2;

        /// <summary>
        /// сложение векторов
        /// </summary>
        /// <returns>вернет вектор сложения</returns>
        public (int index, int number)[] Addition(Vectors vector1, Vectors vector2)
        {
            if (!CheckSize(vector1.Size, vector2.Size))
            {
                //throw Exception;
            }
            int count1 = 0;
            int count2 = 0;
            int count = 0;
            var vector = new (int index, int number)[vector1.Vector.Length + vector2.Vector.Length];
            while (count1 < vector1.Vector.Length && count2 < vector2.Vector.Length)
            {
                var index1 = vector1.Vector[count1].index;
                var index2 = vector2.Vector[count2].index;
                if (index1 < index2)
                {
                    vector[count] = vector1.Vector[count1];
                    count++;
                    count1++;
                }
                else if (index1 > index2)
                {
                    vector[count] = vector2.Vector[count2];
                    count++;
                    count2++;
                }
                else
                {
                    vector[count].number = vector1.Vector[count1].number + vector2.Vector[count2].number;
                    vector[count].index = vector1.Vector[count1].index;
                    count++;
                    count1++;
                    count2++;
                }
            }
            if (count1 == vector1.Vector.Length && count2 != vector2.Vector.Length)
            {
                while (count2 < vector2.Vector.Length)
                {
                    vector[count] = vector2.Vector[count2];
                    count++;
                    count2++;
                }
            }
            else if (count2 == vector2.Vector.Length && count1 != vector1.Vector.Length)
            {
                while (count1 < vector1.Vector.Length)
                {
                    vector[count] = vector1.Vector[count2];
                    count++;
                    count1++;
                }
            }
            for (int i = vector.Length - 1; i >= 0; i--)
            {
                if (vector[i].index != 0 && vector[i].number != 0)
                {
                    Array.Resize(ref vector, i);
                    break;
                }
            }
            return vector;
        }

        /// <summary>
        /// вычитание выкторов
        /// </summary>
        /// <returns>вектор вычитания</returns>
        public (int index, int number)[] Substraction(Vectors vector1, Vectors vector2)
        {
            if (!CheckSize(vector1.Size, vector2.Size))
            {
                //throw Exception;
            }
            int count1 = 0;
            int count2 = 0;
            int count = 0;
            var vector = new (int index, int number)[vector1.Vector.Length + vector2.Vector.Length];
            while (count1 < vector1.Vector.Length && count2 < vector2.Vector.Length)
            {
                var index1 = vector1.Vector[count1].index;
                var index2 = vector2.Vector[count2].index;
                if (index1 < index2)
                {
                    vector[count] = vector1.Vector[count1];
                    count++;
                    count1++;
                }
                else if (index1 > index2)
                {
                    vector[count] = vector2.Vector[count2];
                    vector[count].number = vector2.Vector[count2].number * -1;
                    count++;
                    count2++;
                }
                else
                {
                    vector[count].number = vector1.Vector[count1].number - vector2.Vector[count2].number;
                    count++;
                    count1++;
                    count2++;
                }
            }
            if (count1 == vector1.Vector.Length && count2 != vector2.Vector.Length)
            {
                while (count2 < vector2.Vector.Length)
                {
                    vector[count] = vector2.Vector[count2];
                    count++;
                    count2++;
                }
            }
            else if (count2 == vector2.Vector.Length && count1 != vector1.Vector.Length)
            {
                while (count1 < vector1.Vector.Length)
                {
                    vector[count] = vector1.Vector[count2];
                    count++;
                    count1++;
                }
            }
            for (int i = vector.Length - 1; i >= 0; i--)
            {
                if (vector[i].index != 0 && vector[i].number != 0)
                {
                    Array.Resize(ref vector, i);
                    break;
                }
            }
            return vector;
        }

        /// <summary>
        /// проверка на нулевой вектор
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>вернет true если вектор нулевой</returns>
        public bool CheckZeroVector(Vectors vector)
            => vector.Vector.Length == 0;

        /// <summary>
        /// Скалярное умножение
        /// </summary>
        /// <returns></returns>
        public int ScalarMultiplication(Vectors vector1, Vectors vector2)
        {
            if (!CheckSize(vector1.Size, vector2.Size))
            {
                //throw Exception;
            }
            int result = 0;
            int count1 = 0;
            int count2 = 0;
            int count = 0;
            while (count1 < vector1.Vector.Length && count2 < vector2.Vector.Length)
            {
                var index1 = vector1.Vector[count1].index;
                var index2 = vector2.Vector[count2].index;
                if (index1 < index2)
                {
                    count++;
                    count1++;
                    index1 = vector1.Vector[count1].index;
                }
                else if (index1 > index2)
                {
                    count++;
                    count2++;
                }
                else
                {
                    result += vector1.Vector[count1].number * vector2.Vector[count2].number;
                    count++;
                    count1++;
                    count2++;
                }
            }
            return result;
        }
    }
}
