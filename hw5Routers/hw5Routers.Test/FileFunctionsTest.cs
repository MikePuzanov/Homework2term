using NUnit.Framework;
using System.IO;

namespace hw5Routers.Test
{
    class FileFunctionsTest
    {
        [Test]
        public void FileTest()
        {
            string[] result =
            {
                "1: 2 (10), 3 (5)"
            };
            FileFunctions.WriteInFile(AlgorithmPrima.Algorithm(FileFunctions.CreateGraph("..\\..\\..\\RoutersTest.txt")), "..\\..\\RoutersTestResult.txt");
            var resultFromFile = File.ReadLines("..\\..\\RoutersTestResult.txt");
            Assert.AreEqual(result, resultFromFile);
        }
    }
}