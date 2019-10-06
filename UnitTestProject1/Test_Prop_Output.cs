using ConsoleApp1.files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class Test_Prop_Output
    {
        [TestMethod]
        public void InitialValues_Output()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(null, kb.Output, "Output is " + kb.Output + " but should be null");
        }
    }
}
