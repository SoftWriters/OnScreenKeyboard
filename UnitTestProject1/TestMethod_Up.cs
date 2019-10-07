using OnScreenKeyboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestMethod_Up
    {
        //TODO the upper limit on this method should be 1, should not be able to go above the first row
        [TestMethod]
        public void InitialValues_Up()
        {
            Keyboard kb = new Keyboard();
            var upresult = kb.Up();
            Assert.AreEqual(null, upresult.output, "output should be null if CurrentPosX is at initial which is 1");
            Assert.AreEqual(1, upresult.currentposx, "CurrentPosX should not decrement if is at 1");
        }
    }
}
