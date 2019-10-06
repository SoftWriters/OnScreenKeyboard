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
        [TestMethod]
        public void MaxIsSix_Down()
        {
            Keyboard kb = new Keyboard();
            var results = kb.Down();
            for (var i = 0; i < 100; i++) { results = kb.Down(); }
            Assert.AreEqual(results.Item2, 6, "CurrentPosX is " + results.Item2 + " but should be 6");
        }

    }
}
