

using ConsoleApp1.files;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class Test_Prop_DesiredPosX
    {
        [TestMethod]
        public void InitialValues_DesiredPosX()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(kb.DesiredPosX, 1, "DesiredPosX should initialize to 1");
        }
    }
}
