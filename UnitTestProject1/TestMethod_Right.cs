using OnScreenKeyboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestMethod_Right
    {
        [TestMethod]
        public void InitialValues_Right()
        {
            Keyboard kb = new Keyboard();
            var result = kb.Right();
            Assert.AreEqual(result.currentposy, 1, "Y coordinate should be 1 after moving Right once");
        }
    }
}
