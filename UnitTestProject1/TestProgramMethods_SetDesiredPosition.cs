using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnScreenKeyboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestProgramMethods_SetDesiredPosition
    {
        [TestMethod]
        public void SetDesiredPosition_Initial()
        {
            var pm = new ProgramMethods();
            var kb = new Keyboard();

            var ACoordinates = pm.SetDesiredPosition("A", kb);

            Assert.AreEqual(ACoordinates.x, 1, "x coordinate of 'A' should be 1");
            Assert.AreEqual(ACoordinates.y, 0, "y coordinate of 'A' should be 0");

                
        }
        [TestMethod]
        public void SetDesiredPosition_NonExistentValueReturnsFalse()
        {
            var pm = new ProgramMethods();
            var kb = new Keyboard();

            var TenCoordinates = pm.SetDesiredPosition("10", kb);
            Assert.AreEqual(TenCoordinates.letterExists, false, "letter 10 should not be found on keyboard");
        }
    }
}
