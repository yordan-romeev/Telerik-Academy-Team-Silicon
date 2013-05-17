using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPops;

namespace TestBalloonPops
{
    [TestClass]
    public class TestScoreManager
    {
        [TestMethod]
        public void TestIsTopScore()
        {
            ScoreManager scoreManager = new ScoreManager();

            bool actual = scoreManager.IsTopScore(new Person(0));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestIsTopScoreFalseCase()
        {
            ScoreManager scoreManager = new ScoreManager();

            bool actual = scoreManager.IsTopScore(new Person(1000));

            Assert.IsFalse(actual);
        }
    }
}
