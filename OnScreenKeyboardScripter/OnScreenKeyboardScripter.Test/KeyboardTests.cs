using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnScreenKeyboardScripter.Test
{
    [TestClass]
    public class KeyboardTests
    {
        [TestMethod]
        public void GetCursorPath_fromKeyNotRecognized_Fail_NotImplementedException()
        {
            Assert.ThrowsException<NotImplementedException>(
                () =>
                {
                    new OnScreenKeyboardScripter.Lib.Keyboard().GetCursorPath('\0', 'A');
                });
        }
        [TestMethod]
        public void GetCursorPath_toKeyNotRecognized_Fail_NotImplementedException()
        {
            Assert.ThrowsException<NotImplementedException>(
                () =>
                {
                    new OnScreenKeyboardScripter.Lib.Keyboard().GetCursorPath('A', '\0');
                });
        }
        [TestMethod]
        public void GetCursorPath_fromGtoA_Success_Up()
        {
            var path = new OnScreenKeyboardScripter.Lib.Keyboard()
                .GetCursorPath('G', 'A');

            var expected = new List<OnScreenKeyboardScripter.Lib.MoveCursor>()
            { Lib.MoveCursor.Up };
            Assert.IsTrue(expected.SequenceEqual(path));
        }
        [TestMethod]
        public void GetCursorPath_fromAto4_Success_Up()
        {
            var path = new OnScreenKeyboardScripter.Lib.Keyboard()
                .GetCursorPath('A', '4');

            var expected = new List<OnScreenKeyboardScripter.Lib.MoveCursor>()
            { Lib.MoveCursor.Up };
            Assert.IsTrue(expected.SequenceEqual(path));
        }
        [TestMethod]
        public void GetCursorPath_from5toB_Success_Down()
        {
            var path = new OnScreenKeyboardScripter.Lib.Keyboard()
                .GetCursorPath('5', 'B');

            var expected = new List<OnScreenKeyboardScripter.Lib.MoveCursor>()
            { Lib.MoveCursor.Down };
            Assert.IsTrue(expected.SequenceEqual(path));
        }
        [TestMethod]
        public void GetCursorPath_fromBtoH_Success_Down()
        {
            var path = new OnScreenKeyboardScripter.Lib.Keyboard()
                .GetCursorPath('B', 'H');

            var expected = new List<OnScreenKeyboardScripter.Lib.MoveCursor>()
            { Lib.MoveCursor.Down };
            Assert.IsTrue(expected.SequenceEqual(path));
        }

        [TestMethod]
        public void GetCursorPath_fromGtoL_Success_Left()
        {
            var path = new OnScreenKeyboardScripter.Lib.Keyboard()
                .GetCursorPath('G', 'L');

            var expected = new List<OnScreenKeyboardScripter.Lib.MoveCursor>()
            { Lib.MoveCursor.Left };
            Assert.IsTrue(expected.SequenceEqual(path));
        }
        [TestMethod]
        public void GetCursorPath_fromLtoK_Success_Left()
        {
            var path = new OnScreenKeyboardScripter.Lib.Keyboard()
                .GetCursorPath('L', 'K');

            var expected = new List<OnScreenKeyboardScripter.Lib.MoveCursor>()
            { Lib.MoveCursor.Left };
            Assert.IsTrue(expected.SequenceEqual(path));
        }
        [TestMethod]
        public void GetCursorPath_fromRtoM_Success_Right()
        {
            var path = new OnScreenKeyboardScripter.Lib.Keyboard()
                .GetCursorPath('R', 'M');

            var expected = new List<OnScreenKeyboardScripter.Lib.MoveCursor>()
            { Lib.MoveCursor.Right };
            Assert.IsTrue(expected.SequenceEqual(path));
        }
        [TestMethod]
        public void GetCursorPath_fromMtoN_Success_Right()
        {
            var path = new OnScreenKeyboardScripter.Lib.Keyboard()
                .GetCursorPath('M', 'N');

            var expected = new List<OnScreenKeyboardScripter.Lib.MoveCursor>()
            { Lib.MoveCursor.Right };
            Assert.IsTrue(expected.SequenceEqual(path));
        }
    }
}
