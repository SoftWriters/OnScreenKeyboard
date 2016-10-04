using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fetzick.OnScreenKeyboard.OnScreenCommand;

namespace Fetzick.OnScreenKeyboard.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string test = OnScreenKeyboard.OnScreenCommand.OnScreenCommand.GetCommand("TEST");
        }

        [TestMethod]
        public void TestMethodNum()
        {
            string test = OnScreenKeyboard.OnScreenCommand.OnScreenCommand.GetCommand("1138");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodLower()
        {
            string test = OnScreenKeyboard.OnScreenCommand.OnScreenCommand.GetCommand("Test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethodSpecialChar()
        {
            string test = OnScreenKeyboard.OnScreenCommand.OnScreenCommand.GetCommand("TEST!!!");
        }

        [TestMethod]
        public void TestMethodOutput()
        {
            string test = OnScreenKeyboard.OnScreenCommand.OnScreenCommand.GetCommand("IT CROWD");
            string expected = "D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#";

            Assert.AreEqual(expected, test);

        }
    }
}
