using System;

namespace hw3B_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BTree(2);
            Console.WriteLine("Меню словаря");
            Console.WriteLine("0 - добавить слово в словарь.");
            Console.WriteLine("1 - вернуть слово по ключу.");
            Console.WriteLine("2 - проверка на наличия ключа в словаре.");
            Console.WriteLine("3 - изменение слова по ключу.");
            Console.WriteLine("4 - удаление слова по ключу.");
            while (true)
            {
                Console.WriteLine("Ваш выбор.");
                var str = Console.ReadLine();
                if (!int.TryParse(str, out int choice))
                {
                    Console.WriteLine("Ошибка ввода!");
                    Console.WriteLine("Попробуйте еще раз!");
                    continue;
                }
                var key = "";
                var value = "";
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Введите ключ.");
                        key = Console.ReadLine();
                        Console.WriteLine("Введите слово.");
                        value = Console.ReadLine();
                        tree.Insert(key, value);
                        break;
                    case 1:
                        Console.WriteLine("Введите ключ.");
                        key = Console.ReadLine();
                        str = tree.GetValue(key);
                        if (str != null)
                        {
                            Console.WriteLine("Ваше слово -", str);
                        }
                        else
                        {
                            Console.WriteLine("Слова с таким ключом нет.");
                        }
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    default:
                        Console.WriteLine("Ошибка ввода!");
                        Console.WriteLine("Попробуйте еще раз!");
                        break;
                }
            }
        }
    }
}
