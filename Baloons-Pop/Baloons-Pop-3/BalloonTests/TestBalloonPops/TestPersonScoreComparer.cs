using System;
using BalloonsPops;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBalloonPops
{
    [TestClass]
    public class TestPersonScoreComparer
    {
        [TestMethod]
        public void TestCompareTwoPersonWithDifferentScore()
        {
            Person firstPerson = new Person("Pesho", 15);
            Person secondPerson = new Person("Vanya", 10);

            int result = PersonScoreComparer.Compare(firstPerson, secondPerson);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestCompareTwoPersonWithTheSameScore()
        {
            Person firstPerson = new Person("Pesho", 15);
            Person secondPerson = new Person("Vanya", 15);

            int result = PersonScoreComparer.Compare(firstPerson, secondPerson);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestCompareTwoPersonFirstOneWithTheSmallerScore()
        {
            Person firstPerson = new Person("Pesho", 5);
            Person secondPerson = new Person("Vanya", 15);

            int result = PersonScoreComparer.Compare(firstPerson, secondPerson);

            Assert.AreEqual(-1, result);
        }
    }
}
