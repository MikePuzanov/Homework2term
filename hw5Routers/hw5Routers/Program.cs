using System;
using System.IO;

namespace hw5Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileFunctions.WriteInFile(AlgorithmPrima.Algorithm(FileFunctions.CreateGraph("..\\..\\..\\Routers2.txt")), "RoutersTestResult.txt");
            }
            catch (GraphDisconnectedException)
            {
                Console.Error.WriteLine("Граф несвязный!");
            }
            //Routers.WriteInFile(AlgorithmPrima.Algorithm(Routers.CreateGraph(args[0])), args[1]);
        }
    }
}
