using ConsoleApp1.files;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Test_Prop_CurrentPosY
    {
        [TestMethod]
        public void InitialValues_CurrentPosY()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(kb.CurrentPosY, 0, "CurrentPosY should initialize to 0");
        }

    }
}
