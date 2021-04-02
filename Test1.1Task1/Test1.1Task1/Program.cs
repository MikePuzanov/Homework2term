using System;

namespace Test1._1Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var vectorCoor2 = new (int, int)[3];
            vectorCoor2[0] = (3, 1);
            vectorCoor2[1] = (6, 1);
            vectorCoor2[2] = (9, 1);
            var vector2 = new Vectors(10, vectorCoor2);
            var vectorCoor1 = new (int, int)[4];
            vectorCoor1[0] = (0, 1);
            vectorCoor1[1] = (2, 1);
            vectorCoor1[2] = (5, 1);
            vectorCoor1[3] = (9, 1);
            var vector1 = new Vectors(10, vectorCoor1);
            var vector = new (int, int)[6];
            vector[0] = (0, 1);
            vector[1] = (2, 1);
            vector[2] = (3, 1);
            vector[3] = (5, 1);
            vector[4] = (6, 1);
            vector[5] = (9, 2);
            vector = vector1.Addition(vector1, vector2);
        }
    }
}
