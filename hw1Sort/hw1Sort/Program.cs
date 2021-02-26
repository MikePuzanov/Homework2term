using System;

namespace hw1Sort
{
    class Program
    {
        static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int numberSwap;
                        numberSwap = array[i];
                        array[i] = array[j];
                        array[j] = numberSwap;
                    }
                }
            }
        }

        static bool Test()
        {
            int[] array = { 9, 3, 2, 5, 7, 8 };
            Sort(array);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            if (!Test())
            {
                Console.WriteLine("Тест не пройден!");
                return;
            }
            Console.WriteLine("Тест пройден!");
            Console.WriteLine("Введите числа для сортировки: ");
            string str = Console.ReadLine();
            string[] numbers = str.Split(' ');
            int[] array = new int[numbers.Length];
            int count = 0;
            foreach (var s in numbers)
            {
                array[count] = int.Parse(s);
                count++;
            }
            Sort(array);
            Console.WriteLine("Отсортированный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                Console.Write(" ");
            }
        }
    }
}