using NUnit.Framework;

namespace hw5Routers.Test
{
    public class Tests
    {
        [Test]
        public void AlgorithmTest()
        {
            int[,] graphFirst =
            {
                {0, 2, 4, 6 },
                {2, 0, 0, 8 },
                {4, 0, 0, 9 },
                {6, 8, 9, 0 }
            };
            int[,] graphFirstResult =
            {
                {0, 0, 0, 6 },
                {0, 0, 0, 8 },
                {0, 0, 0, 9 },
                {6, 8, 9, 0 }
            };
            Assert.AreEqual(AlgorithmPrima.Algorithm(graphFirst), graphFirstResult);
            int[,] graphSecond =
            {
                {0, 0, 0, 3 },
                {0, 0, 0, 6 },
                {0, 0, 0, 9 },
                {3, 6, 9, 0 }
            }; 
            int[,] graphSecondResult =
             {
                {0, 0, 0, 3 },
                {0, 0, 0, 6 },
                {0, 0, 0, 9 },
                {3, 6, 9, 0 }
            };
            Assert.AreEqual(AlgorithmPrima.Algorithm(graphSecond), graphSecondResult);
        }

        [Test]
        public void AlgorithmExceptionTest()
        {
            int[,] graph =
            {
                {0, 3, 0, 0},
                {3, 0, 0, 0},
                {0, 0, 0, 2},
                {0, 0, 2, 0}
            };
            Assert.Throws<GraphDisconnectedException>(() => AlgorithmPrima.Algorithm(graph));
        }

    }
}