using OnScreenKeyboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Test_Prop_CurrentPosX
    {
        [TestMethod]
        public void InitialValues_CurrentPosX()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(kb.CurrentPosX, 1, "CurrentPosX should initialize to 1");
        }     
    }
}
