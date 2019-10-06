using ConsoleApp1.files;
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
            Assert.AreEqual(null, kb.Output, "Output is " + kb.Output + " but should be null");
        }
    }
}
