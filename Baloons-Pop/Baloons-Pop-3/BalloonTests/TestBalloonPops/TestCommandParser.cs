using System;
using BalloonsPops;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBalloonPops
{
    [TestClass]
    public class TestCommandParser
    {
        [TestMethod]
        public void TestGetCommandTypeWithExit()
        {
            CommandType commandType = CommandParser.GetCommandType("exit");

            Assert.AreEqual(CommandType.Exit, commandType);
        }

        [TestMethod]
        public void TestGetCommandTypeWithExitWhiteSpaces()
        {
            CommandType commandType = CommandParser.GetCommandType("  exit  ");

            Assert.AreEqual(CommandType.Exit, commandType);
        }

        [TestMethod]
        public void TestGetCommandTypeWithRestart()
        {
            CommandType commandType = CommandParser.GetCommandType("restart");

            Assert.AreEqual(CommandType.Restart, commandType);
        }

        [TestMethod]
        public void TestValidCoordinates()
        {
            CommandType commandType = CommandParser.GetCommandType("2 3");

            Assert.AreEqual(CommandType.Coordinates, commandType);
        }

        [TestMethod]
        public void TestIsValidCoordinatesY()
        {
            CommandType commandType = CommandParser.GetCommandType("2 a3");

            Assert.AreEqual(CommandType.Invalid, commandType);
        }

        [TestMethod]
        public void TestIsValidCoordinatesX()
        {
            CommandType commandType = CommandParser.GetCommandType("2v 3");

            Assert.AreEqual(CommandType.Invalid, commandType);
        }

        [TestMethod]
        public void TestGetCommandTypeWithRestartWhiteSpaces()
        {
            CommandType commandType = CommandParser.GetCommandType("  restart  ");

            Assert.AreEqual(CommandType.Restart, commandType);
        }

        [TestMethod]
        public void TestGetCommandTypeWithTop()
        {
            CommandType commandType = CommandParser.GetCommandType("top");

            Assert.AreEqual(CommandType.TopScore, commandType);
        }

        [TestMethod]
        public void TestGetCommandTypeWithTopWhiteSpaces()
        {
            CommandType commandType = CommandParser.GetCommandType("  top  ");

            Assert.AreEqual(CommandType.TopScore, commandType);
        }

        [TestMethod]
        public void TestParseCoordinates()
        {
            string coordinatesAsString = "2 3";
            Coordinates expected = new Coordinates(2, 3);
            Coordinates actual = CommandParser.ParseCoordinates(coordinatesAsString);

            Assert.AreEqual(expected.Row, actual.Row);
            Assert.AreEqual(expected.Column, actual.Column);
        }

    }
}
