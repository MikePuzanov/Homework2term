﻿using System;
using System.IO;

namespace Hw5Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileFunctions.WriteInFile(AlgorithmPrima.Algorithm(FileFunctions.CreateGraph(args[0])), args[1]);
            }
            catch (GraphDisconnectedException)
            {
                Console.Error.WriteLine("Граф несвязный!");
            }
            catch (NoParametersException)
            {
                Console.Error.WriteLine("Введите параметры: путь до входного файла и путь до выходного файла.");
            }
        }
    }
}
