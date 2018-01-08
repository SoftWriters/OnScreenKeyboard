using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnScreenKeyboard.Logic;

namespace LogicTests
{
    [TestClass]
    public class InputProcessorTests
    {
        [TestInitialize]
        public void Init()
        {
            _processor = new InputProcessor(new SixBySixKeyboardLayout());
        }

        InputProcessor _processor;

        [TestMethod]
        public void ScrubInput()
        {
            Assert.AreEqual(
                "TEST TEST 123",
                _processor.ScrubInput("Test \"Test\"  123 :';,.<>/?\\"));
        }

        [TestMethod]
        public void ToCursorInstructions()
        {

            Assert.AreEqual(
                "#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#",
                _processor.ToCursorInstructions("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"));

            Assert.AreEqual(
                "R,D,D,D,#,R,R,R,U,U,U,#,L,L,L,L,D,D,D,#,R,#,S,#,R,R,R,U,U,U,#,L,L,L,L,D,D,D,#,R,#",
                _processor.ToCursorInstructions("TEST TEST"));

            Assert.AreEqual(
                "R,D,D,D,#,R,R,R,U,U,U,#,L,L,L,L,D,D,D,#,R,#,S,#,R,R,R,U,U,U,#,L,L,L,L,D,D,D,#,R,#,S,R,D,#,R,#,R,#",
                _processor.ToCursorInstructions("Test \"Test\"  123 :';,.<>/?\\"));
        }
    }
}
