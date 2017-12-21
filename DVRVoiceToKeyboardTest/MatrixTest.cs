using Microsoft.VisualStudio.TestTools.UnitTesting;
using DVRVoiceToKeyboard;

namespace DVRVoiceToKeyboardTest
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void Matrix_Navigation_Start()
        {
            string commandString = "";
            TheMatrixKeyboard keyboard = new TheMatrixKeyboard();
            commandString = keyboard.To('I');
            Assert.AreEqual("D,R,R,#", commandString);
        }

        [TestMethod]
        public void Matrix_Navigation_From_And_To_Character()
        {
            string commandString = "";
            TheMatrixKeyboard keyboard = new TheMatrixKeyboard();
            commandString = keyboard.IsNavigatingFrom('I').To('T');
            Assert.AreEqual("D,D,L,#", commandString);
        }
    }
}
