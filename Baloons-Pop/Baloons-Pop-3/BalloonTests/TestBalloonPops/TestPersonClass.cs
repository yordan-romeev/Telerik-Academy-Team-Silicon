using System;
using BalloonsPops;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBalloonPops
{
    [TestClass]
    public class TestPersonClass
    {
        [TestMethod]
        public void TestCreatingPersonWithEmptyConstructor()
        {
            Person person = new Person();
            string name = person.Name;
            int score = person.Score;

            Assert.AreEqual("Unknown player", name);
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void TestCreatingPersonWithScoe()
        {
            Person person = new Person(15);
            string name = person.Name;
            int score = person.Score;

            Assert.AreEqual("Unknown player", name);
            Assert.AreEqual(15, score);
        }

        [TestMethod]
        public void TestCreatingPersonWithNameAndScore()
        {
            Person person = new Person("Marija",15);
            string name = person.Name;
            int score = person.Score;

            Assert.AreEqual("Marija", name);
            Assert.AreEqual(15, score);
        }

        [TestMethod]
        public void TestCreatingPersonWithEmptyString()
        {
            Person person = new Person("", 15);

            Assert.AreEqual("Unknown player", person.Name);

        }

        [TestMethod]
        public void TestPersonOperatorBiggerWhenTheFirstPersonIsBigger()
        {
            Person personOne = new Person("Mariya", 18);
            Person personTwo = new Person("Mariya", 15);

            bool isBigger = personOne > personTwo;

            Assert.IsTrue(isBigger);
        }

        [TestMethod]
        public void TestPersonOperatorBiggerWhenTheSecondPersonIsBigger()
        {
            Person personOne = new Person("Mariya", 18);
            Person personTwo = new Person("Mariya", 25);

            bool isBigger = personOne > personTwo;

            Assert.IsFalse(isBigger);
        }

        [TestMethod]
        public void TestPersonOperatorBiggerWhenTheyAreEqual()
        {
            Person personOne = new Person("Mariya", 18);
            Person personTwo = new Person("Mariya", 18);

            bool isBigger = personOne > personTwo;

            Assert.IsFalse(isBigger);
        }

        [TestMethod]
        public void TestPersonOperatorSmallerWhenTheyAreEqual()
        {
            Person personOne = new Person("Mariya", 18);
            Person personTwo = new Person("Mariya", 18);

            bool isBigger = personTwo < personOne;

            Assert.IsFalse(isBigger);
        }

        [TestMethod]
        public void TestPersonOperatorLessWhenTheFirstPersonIsSmaller()
        {
            Person personOne = new Person("Mariya", 10);
            Person personTwo = new Person("Mariya", 18);

            bool isBigger = personOne < personTwo;

            Assert.IsTrue(isBigger);
        }


        [TestMethod]
        public void TestPersonOperatorLessWhenTheFirstPersonIsSmallerTheSecondTime()
        {
            Person personOne = new Person("Mariya", 10);
            Person personTwo = new Person("Mariya", 18);

            bool isBigger = personTwo < personOne;

            Assert.IsFalse(isBigger);
        }

        [TestMethod]
        public void TestPersonOperatorLessWhenTheSecondPersonIsSmaller()
        {
            Person personOne = new Person("Mariya", 100);
            Person personTwo = new Person("Mariya", 18);

            bool isBigger = personTwo < personOne;

            Assert.IsTrue(isBigger);
        }

        [TestMethod]
        public void TestPersonOperatorLessWhenTheSecondPersonIsSmallerTheSecondTime()
        {
            Person personOne = new Person("Mariya", 100);
            Person personTwo = new Person("Mariya", 18);

            bool isBigger = personOne < personTwo;

            Assert.IsFalse(isBigger);
        }
    }
}
