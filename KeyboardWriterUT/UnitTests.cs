using KeyboardWalker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyboardWriterUT
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void UT_FindPatternConstructor()
        {
            // Create default object and check valid
            FindPattern obj = new FindPattern();
            Assert.IsNotNull(obj, "Failed to create default FindPattern object");

            // Create object with custom keyboard and check valid
            string[,] keyboardLayout = new string[6, 6]
            {
                {"A", "B", "C", "D", "E", "F" },
                {"G", "H", "I", "J", "K", "L" },
                {"M", "N", "O", "P", "Q", "R" },
                {"S", "T", "U", "V", "W", "X" },
                {"Y", "Z", "0", "1", "2", "3" },
                {"4", "5", "6", "7", "8", "9" }
            };
            obj = new FindPattern(keyboardLayout);
            Assert.IsNotNull(obj, "Failed to create FindPattern object with custom keyboard layout");
        }
    }
}
