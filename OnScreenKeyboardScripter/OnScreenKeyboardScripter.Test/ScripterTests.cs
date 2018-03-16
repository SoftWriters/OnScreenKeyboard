using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnScreenKeyboardScripter.Test
{
    [TestClass]
    public class ScripterTests
    {
        [TestMethod]
        public void GetPath_keyboardParamNull_Fail_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    new OnScreenKeyboardScripter.Lib.Scripter().GetPath(null, "splat");
                });
        }

        [TestMethod]
        public void GetPath_inputNullOrEmpty_Success_EmptyString()
        {
            var moqKeyboard = new Moq.Mock<OnScreenKeyboardScripter.Lib.IKeyboard>();
            var result = new OnScreenKeyboardScripter.Lib.Scripter().GetPath(moqKeyboard.Object, "");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetPath_keyboardGetCursorPathException_Fail_AllowExceptionToBubbleThrough()
        {
            var moqKeyboard = new Moq.Mock<OnScreenKeyboardScripter.Lib.IKeyboard>();

            // pick and exception that won't be thrown from library
            moqKeyboard.Setup(fn => fn.GetCursorPath(Moq.It.IsAny<char>(), Moq.It.IsAny<char>()))
                       .Throws(new DuplicateWaitObjectException("splat"));

            // make sure we get THAT exception
            Assert.ThrowsException<DuplicateWaitObjectException>(
                () =>
                {
                    new OnScreenKeyboardScripter.Lib.Scripter().GetPath(moqKeyboard.Object, "splat");
                });
        }
    }
}
