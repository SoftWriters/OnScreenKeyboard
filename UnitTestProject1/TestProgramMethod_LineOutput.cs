using OnScreenKeyboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    [TestClass]

    public class TestProgramMethod_LineOutput
    {

        Keyboard kb;
        ProgramMethods pm;

        [TestInitialize]
        public void TestInitialize()
        {
            kb = new Keyboard();
            pm = new ProgramMethods();
        }

        [TestMethod]
        public void LineOutput_BasicTest_Hello()
        {
            var hello = pm.LineOutput("hello", kb);
            Assert.AreEqual(hello, "D,R,#,U,R,R,R,#,D,R,#,#,D,L,L,L,#", "string does not match");
        }

        [TestMethod]
        public void LineOutput_RecognizesSpaces()
        {
            var spacedhello = pm.LineOutput("h e l l o", kb);
            Assert.AreEqual(spacedhello, "D,R,#,S,U,R,R,R,#,S,D,R,#,S,#,S,D,L,L,L,#", "string does not match");
        }

        [TestMethod]

        public void LineOutput_IfNullReturnsEmpty()
        {
            var empty = pm.LineOutput(null, kb);
            Assert.AreEqual(empty, "", "should return empty string");

        }
    }
}
