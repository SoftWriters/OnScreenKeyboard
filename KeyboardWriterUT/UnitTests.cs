using KeyboardWalker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KeyboardWalker.FindPattern;

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
            Assert.IsNotNull(obj.GetKeyboardLayout(), "Failed to create default FindPattern object");

            // Create object with custom keyboard and check valid
            char[][] keyboardLayout = new char[5][]
            {
                new char[6] {'A', 'B', 'C', 'D', 'E', 'F' },
                new char[6] {'G', 'H', 'I', 'J', 'K', 'L' },
                new char[6] {'M', 'N', 'O', 'P', 'Q', 'R' },
                new char[6] {'S', 'T', 'U', 'V', 'W', 'X' },
                new char[6] {'Y', 'Z', '0', '1', '2', '3' }
            };
            obj = new FindPattern(keyboardLayout);
            Assert.IsNotNull(obj.GetKeyboardLayout(), "Failed to create FindPattern object with custom keyboard layout");
        }

        [TestMethod]
        public void UT_FindKey()
        {
            // Create the object for testing (default keyboard)
            FindPattern fp = new FindPattern();
            Coordinate expected, test;

            // Find the first letter
            expected = new Coordinate(0, 0);
            test = fp.FindKey('A');
            Assert.AreEqual(expected, test, "Failed to find the first character on the keyboard");

            // Find the last letter
            expected = new Coordinate(5, 5);
            test = fp.FindKey('0');
            Assert.AreEqual(expected, test, "Failed to find the last character on the keyboard");

            // Find some middle letters
            expected = new Coordinate(3, 1);
            test = fp.FindKey('T');
            Assert.AreEqual(expected, test, "Failed to find T on the keyboard");

            expected = new Coordinate(5, 0);
            test = fp.FindKey('5');
            Assert.AreEqual(expected, test, "Failed to find 5 on the keyboard");

            // Check non-existant character
            expected = new Coordinate();
            test = fp.FindKey('#');
            Assert.AreEqual(expected, test, "Failed to return emtpy coordinate on non-existant character");

            // Check with non-default keyboard
            char[][] keyboardLayout = new char[5][]
            {
                new char[6] {'A', 'B', 'C', 'D', 'E', 'F' },
                new char[6] {'G', 'H', 'I', 'J', 'K', 'L' },
                new char[6] {'M', 'N', 'O', 'P', 'Q', 'R' },
                new char[6] {'S', 'T', 'U', 'V', 'W', 'X' },
                new char[6] {'Y', 'Z', '0', '1', '2', '3' }
            };
            fp = new FindPattern(keyboardLayout);
            expected = new Coordinate(4, 5);
            test = fp.FindKey('3');
            Assert.AreEqual(expected, test, "Failed to find last key on non-default keyboard");
        }
    }
}
