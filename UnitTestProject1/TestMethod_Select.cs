using OnScreenKeyboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestMethod_Select
    {
        [TestMethod]
        public void InitialValues_Select()
        {
            Keyboard kb = new Keyboard();
            kb.Select();
            Assert.AreEqual("#", kb.Output, "Output is " + kb.Output + " but should be #");
        }
    }
}
