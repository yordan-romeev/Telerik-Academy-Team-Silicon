using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPops;

namespace TestBalloonPops
{
    [TestClass]
    public class TestEngine
    {
        [TestMethod]
        public void TestEngineConstructor()
        {
            Engine gameEngine = new Engine(4, 5);

            Assert.AreEqual(4, gameEngine.BoardWidth);
            Assert.AreEqual(5, gameEngine.BoardHeight);
        }

        [TestMethod]
        public void TestEngineConstructorTwo()
        {
            Balloon[,] ballons = new Balloon[1, 2];
            ballons[0, 0] = new Balloon(1);
            ballons[0, 1] = new Balloon(2);

            Engine gameEngine = new Engine(ballons);

            Assert.AreEqual(gameEngine.BoardHeight, ballons.GetLength(0));
            Assert.AreEqual(gameEngine.BoardWidth, ballons.GetLength(1));
        }
    }
}
