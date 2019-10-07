using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnScreenKeyboard;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestProgramMethods_TrackPathAndSelect
    {
        [TestMethod]
        public void TrackPathAndSelect_Initial()
        {
            var pm = new ProgramMethods();
            var kb = new Keyboard();

            kb.DesiredPosX = 6;
            kb.DesiredPosY = 5;

            bool didExecutePath = pm.TrackPathAndSelect(kb);

            Assert.AreEqual(true, didExecutePath, "Path was not executed properly");
        }
    }
}
