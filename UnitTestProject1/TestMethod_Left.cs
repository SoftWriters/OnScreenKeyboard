using ConsoleApp1.files;
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
            kb.Left();
            Assert.AreEqual("L", kb.Output, "Output is " + kb.Output + " but should be L");
            kb.Left();
            Assert.AreEqual(-2, kb.CurrentPosY, "CurrentPosY is " + kb.CurrentPosY + " but should be -2");
        }
    }
}
