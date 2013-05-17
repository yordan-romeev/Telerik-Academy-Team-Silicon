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
    }
}
