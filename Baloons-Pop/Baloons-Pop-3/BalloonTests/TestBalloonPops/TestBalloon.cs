using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BalloonsPops;

namespace TestBalloonPops
{
    [TestClass]
    public class TestBalloon
    {
        [TestMethod]
        public void TestPop()
        {
            Balloon balloon = new Balloon(4);
            balloon.Pop();

            Assert.AreEqual(0, balloon.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSettingInvalidValue()
        {
            Balloon balloon = new Balloon(6);
        }

        [TestMethod]
        public void TestSettingAndGettingValidValue()
        {
            Balloon balloon = new Balloon(3);
            balloon.Value = 4;

            Assert.AreEqual(4, balloon.Value);
        }
    }
}
