using KeyboardWalker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static KeyboardWalker.FindPath;

namespace KeyboardWriterUT
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void UT_FindPathConstructor()
        {
            // Create default object and check valid
            FindPath obj = new FindPath();
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
            obj = new FindPath(keyboardLayout);
            Assert.IsNotNull(obj.GetKeyboardLayout(), "Failed to create FindPattern object with custom keyboard layout");
        }

        [TestMethod]
        public void UT_FindCharacter()
        {
            // Create the object for testing (default keyboard)
            FindPath fp = new FindPath();
            Coordinate expected, test;

            // Find the first letter
            expected = new Coordinate(0, 0);
            test = fp.FindCharacter('A');
            Assert.AreEqual(expected, test, "Failed to find the first character on the keyboard");

            // Find the last letter
            expected = new Coordinate(5, 5);
            test = fp.FindCharacter('0');
            Assert.AreEqual(expected, test, "Failed to find the last character on the keyboard");

            // Find a lowercase letter
            expected = new Coordinate(3, 1);
            test = fp.FindCharacter('t');
            Assert.AreEqual(expected, test, "Failed to find T on the keyboard");

            // Find a number
            expected = new Coordinate(5, 0);
            test = fp.FindCharacter('5');
            Assert.AreEqual(expected, test, "Failed to find 5 on the keyboard");

            // Check non-existant character
            expected = new Coordinate();
            test = fp.FindCharacter('#');
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
            fp = new FindPath(keyboardLayout);
            expected = new Coordinate(4, 5);
            test = fp.FindCharacter('3');
            Assert.AreEqual(expected, test, "Failed to find last key on non-default keyboard");
        }

        [TestMethod]
        public void UT_GetCharacterPath()
        {
            string expectedPath, testPath;
            char startChar, endChar;
            FindPath fp = new FindPath();

            // Test special case of a space
            startChar = 'A';
            endChar = ' ';
            expectedPath = "S";
            testPath = fp.GetCharacterPath(startChar, endChar);
            Assert.AreEqual(expectedPath, testPath, "Failed to get correct path for special case of a space");

            // Test special case of same character
            startChar = 'A';
            endChar = 'A';
            expectedPath = "#";
            testPath = fp.GetCharacterPath(startChar, endChar);
            Assert.AreEqual(expectedPath, testPath, "Failed to get correct path for special case of same character");

            // Test character on same column, down
            startChar = 'G';
            endChar = 'Y';
            expectedPath = "D,D,D,#";
            testPath = fp.GetCharacterPath(startChar, endChar);
            Assert.AreEqual(expectedPath, testPath, "Failed to find path along the same column, down");

            // Test character on same column, up
            startChar = '9';
            endChar = 'E';
            expectedPath = "U,U,U,U,U,#";
            testPath = fp.GetCharacterPath(startChar, endChar);
            Assert.AreEqual(expectedPath, testPath, "Failed to find path along the same column, up");

            // Test character on same row, to the right
            startChar = 'G';
            endChar = 'J';
            expectedPath = "R,R,R,#";
            testPath = fp.GetCharacterPath(startChar, endChar);
            Assert.AreEqual(expectedPath, testPath, "Failed to find path along the same row, to the right");

            // Test character on same row, to the left
            startChar = '0';
            endChar = '5';
            expectedPath = "L,L,L,L,L,#";
            testPath = fp.GetCharacterPath(startChar, endChar);
            Assert.AreEqual(expectedPath, testPath, "Failed to find path along the same row, to the left");

            // Test character on different row and column
            startChar = 'I';
            endChar = 'T';
            expectedPath = "D,D,L,#";
            testPath = fp.GetCharacterPath(startChar, endChar);
            Assert.AreEqual(expectedPath, testPath, "Failed to find path from I to T");
        }

        [TestMethod]
        public void UT_GetSearchPath()
        {
            string searchTerm, expectedPath, testPath;
            FindPath fp = new FindPath();

            // Check given search term
            searchTerm = "IT Crowd";
            expectedPath = "D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#";
            testPath = fp.GetSearchPath(searchTerm);
            Assert.AreEqual(expectedPath, testPath, "Failed to get correct search path for 'IT Crowd'");

            // Check search path with non-default keyboard
            char[][] keyboardLayout = new char[5][]
            {
                new char[6] {'A', 'B', 'C', 'D', 'E', 'F' },
                new char[6] {'G', 'H', 'I', 'J', 'K', 'L' },
                new char[6] {'M', 'N', 'O', 'P', 'Q', 'R' },
                new char[6] {'S', 'T', 'U', 'V', 'W', 'X' },
                new char[6] {'Y', 'Z', '0', '1', '2', '3' }
            };
            fp = new FindPath(keyboardLayout);
            searchTerm = "James 122";
            expectedPath = "D,R,R,R,#,U,L,L,L,#,D,D,#,U,U,R,R,R,R,#,D,D,D,L,L,L,L,#,S,D,R,R,R,#,R,#,#";
            testPath = fp.GetSearchPath(searchTerm);
            Assert.AreEqual(expectedPath, testPath, "Failed to get correct search path for non-default keyboard");
        }
    }
}
