using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnScreenKeyboard.Logic;

namespace LogicTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var inputProcessor = new InputProcessor(new SixBySixKeyboardLayout());

            string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Assert.AreEqual(
                "#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#,L,L,L,L,L,D,#,R,#,R,#,R,#,R,#,R,#", 
                inputProcessor.ToCursorInstructions(input));
        }
    }
}
