using ConsoleApp1.files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestMethod_Down
    {
        [TestMethod]
        public void InitialValues_Down()
        {
            Keyboard kb = new Keyboard();
            kb.Down();
            Assert.AreEqual("D", kb.Output, "Output is " + kb.Output + " but should be D");
            kb.Down();
            Assert.AreEqual(3, kb.CurrentPosX, "CurrentPosX is " + kb.CurrentPosX + " but should be 3");
        }

    }
}
