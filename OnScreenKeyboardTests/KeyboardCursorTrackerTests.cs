using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnScreenKeyboard;

namespace OnScreenKeyboardTests
{
    [TestClass]
    public class KeyboardCursorTrackerTests
    {
        [TestMethod]
        public void GetKeyLocation_Returns_0_0_For_A()
        {
            var character = 'A';
            var expectedPosition = (0, 0);

            var actualPosition = Keyboard.GetKeyLocation(character);

            Assert.AreEqual(actualPosition, expectedPosition);
        }

        [TestMethod]
        public void GetKeyLocation_Returns_3_4_For_W()
        {
            var character = 'W';
            var expectedPosition = (3, 4);

            var actualPosition = Keyboard.GetKeyLocation(character);

            Assert.AreEqual(actualPosition, expectedPosition);
        }

        [TestMethod]
        public void GetKeyLocation_Returns_Minus_1_Minus_1_For_SpaceSymbol()
        {
            var character = ' ';
            var expectedPosition = (-1, -1);

            var actualPosition = Keyboard.GetKeyLocation(character);

            Assert.AreEqual(actualPosition, expectedPosition);
        }

        [TestMethod]
        public void GetKeyLocation_Returns_Minus_1_Minus_1_For_NonKeyboardSymbol()
        {
            var character = '<';
            var expectedPosition = (-1, -1);

            var actualPosition = Keyboard.GetKeyLocation(character);

            Assert.AreEqual(actualPosition, expectedPosition);
        }

        [DataTestMethod]
        [DataRow("", "")]
        [DataRow("A", "#")]
        [DataRow("Aa", "#,#")]
        [DataRow("Aa Bb", "#,#,S,R,#,#")]
        [DataRow("D", "R,R,R,#")]
        [DataRow("S", "D,D,D,#")]
        [DataRow("P", "D,D,R,R,R,#")]
        [DataRow("an apple", "#,D,D,R,#,S,U,U,L,#,D,D,R,R,R,#,#,U,R,R,#,U,L,#")]
        [DataRow("?miss, 1", "S,D,D,#,U,R,R,#,D,D,L,L,#,#,S,S,D,R,R,#")]
        [DataRow("Mr. Smith", "D,D,#,R,R,R,R,R,#,S,S,D,L,L,L,L,L,#,U,#,U,R,R,#,D,D,L,#,U,U,#")]
        public void GetCursorPathScriptTest(string inputString, string expectedPathScript)
        {
            var actualPathScript = CursorTracker.GetCursorPathScript(inputString);

            Assert.AreEqual(actualPathScript, expectedPathScript);
        }
    }
}
