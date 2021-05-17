using NUnit.Framework;
using System;

namespace Hw6Game.Test
{
    public class Tests
    {
        private EventLoop eventLoop;

        private Map map;

        [SetUp]
        public void Setup()
        {
            map = new Map("..//..//..//TestMap.txt");
        }

        [Test]
        public void MoveLeftTest()
        {
            (int, int) oldCoordinates = map.GetPlayerCoordinates();
            map.Move("left");
            (int, int) newCoordinates = map.GetPlayerCoordinates();
            oldCoordinates.Item1--;
            Assert.AreEqual(oldCoordinates.Item1, newCoordinates.Item1);
            Assert.AreEqual(oldCoordinates.Item2, newCoordinates.Item2);
        }

        [Test]
        public void MoveRightTest()
        {
            (int, int) oldCoordinates = map.GetPlayerCoordinates();
            map.Move("right");
            (int, int) newCoordinates = map.GetPlayerCoordinates();
            oldCoordinates.Item1++;
            Assert.AreEqual(oldCoordinates.Item1, newCoordinates.Item1);
            Assert.AreEqual(oldCoordinates.Item2, newCoordinates.Item2);
        }

        [Test]
        public void MoveUpTest()
        {
            (int, int) oldCoordinates = map.GetPlayerCoordinates();
            map.Move("up");
            (int, int) newCoordinates = map.GetPlayerCoordinates();
            oldCoordinates.Item2--;
            Assert.AreEqual(oldCoordinates.Item1, newCoordinates.Item1);
            Assert.AreEqual(oldCoordinates.Item2, newCoordinates.Item2);
        }

        [Test]
        public void MoveDownTest()
        {
            (int, int) oldCoordinates = map.GetPlayerCoordinates();
            map.Move("down");
            (int, int) newCoordinates = map.GetPlayerCoordinates();
            oldCoordinates.Item2++;
            Assert.AreEqual(oldCoordinates.Item1, newCoordinates.Item1);
            Assert.AreEqual(oldCoordinates.Item2, newCoordinates.Item2);
        }

        [Test]
        public void MoveLeftToWallTest()
        {
            map.Move("left");
            (int, int) oldCoordinates = map.GetPlayerCoordinates();
            map.Move("left");
            (int, int) newCoordinates = map.GetPlayerCoordinates();
            Assert.AreEqual(oldCoordinates.Item1, newCoordinates.Item1);
            Assert.AreEqual(oldCoordinates.Item2, newCoordinates.Item2);
        }

        [Test]
        public void MoveUpToWallTest()
        {
            map.Move("up");
            (int, int) oldCoordinates = map.GetPlayerCoordinates();
            map.Move("up");
            (int, int) newCoordinates = map.GetPlayerCoordinates();
            Assert.AreEqual(oldCoordinates.Item1, newCoordinates.Item1);
            Assert.AreEqual(oldCoordinates.Item2, newCoordinates.Item2);
        }
    }
}