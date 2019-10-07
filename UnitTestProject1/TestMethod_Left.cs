using OnScreenKeyboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestMethod_Left
    {
        [TestMethod]
        public void InitialValues_Left()
        {
            Keyboard kb = new Keyboard();
            var result = kb.Left();
            Assert.AreEqual(null, result.output, "Output is " + kb.Output + " but should be null");
            Assert.AreEqual(0, result.currentposy, "CurrentPosY is " + kb.CurrentPosY + " but should be 0");
        }

        [TestMethod]
        public void MinIsZero_Left()
        {
            Keyboard kb = new Keyboard();
            var result = kb.Left();
            Assert.AreEqual(0, result.currentposy, "CurrentPosY is " + kb.CurrentPosY + " but should be 0");
        }
    }
}
