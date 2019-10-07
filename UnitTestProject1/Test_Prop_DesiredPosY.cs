using OnScreenKeyboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class Test_Prop
    {
        [TestMethod]
        public void InitialValues_DesiredPosY()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(kb.DesiredPosY, 0, "DesiredPosY should initialize to 0");
        }
    }
}
