using NUnit.Framework;
using System;

namespace hw6Game.Test
{
    public class Tests
    {
        private EventLoop eventLoop;

        private Game game;

        [SetUp]
        public void Setup()
        {
            eventLoop = new EventLoop();
            game = new Game("..//..//..//TestMap.txt");
        }

        [Test]
        public void MoveLeftTest()
        {
            (int, int) oldCoordinates = game.GetCoordinates();
            game.OnLeft(ConsoleKey.LeftArrow, EventArgs.Empty);
            (int, int) newCoordinates = game.GetCoordinates();
            Assert.AreEqual(oldCoordinates.Item1 + 1, newCoordinates.Item1);
            Assert.AreEqual(oldCoordinates.Item2, newCoordinates.Item2);
        }
    }
}