using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnScreenKeyboard.Keyboards;
using OnScreenKeyboard.Exceptions;

namespace OnScreenKeyboard.UnitTests
{
    [TestClass]
    public class exampleKeyboard_SearchValidations
    {
        [TestMethod]
        public void navigate_A()
        {
            // test with search for initial character
            var kb = new Example();
            string path = kb.Search("A");

            Assert.AreEqual("#", path);
        }

        [TestMethod]
        public void navigate_AAA()
        {
            // test with search for multiple occurences of initial character
            var kb = new Example();
            string path = kb.Search("AAA");

            Assert.AreEqual("#,#,#", path);
        }

        [TestMethod]
        public void navigate_F()
        {
            // search for character at end of same line as initial character
            var kb = new Example();
            string path = kb.Search("F");

            Assert.AreEqual("R,R,R,R,R,#", path);
        }

        [TestMethod]
        public void navigate_0()
        {
            // search for numeric character on last line/column
            var kb = new Example();
            string path = kb.Search("0");

            Assert.AreEqual("D,D,D,D,D,R,R,R,R,R,#", path);
        }

        [TestMethod]
        public void navigate_AJB()
        {
            // search for initial character, then one on next line, then one back on first line
            var kb = new Example();
            string path = kb.Search("AJB");

            Assert.AreEqual("#,D,R,R,R,#,U,L,L,#", path);
        }

        [TestMethod]
        public void navigate_space()
        {
            // search for a space
            var kb = new Example();
            string path = kb.Search(" ");

            Assert.AreEqual("S", path);
        }

        [TestMethod]
        public void navigate_leadingSpace()
        {
            // search for a string with a space at the beginning
            var kb = new Example();
            string path = kb.Search(" A");

            Assert.AreEqual("S,#", path);
        }

        [TestMethod]
        public void navigate_trailingSpace()
        {
            // search for a string with a space at the beginning
            var kb = new Example();
            string path = kb.Search("A ");

            Assert.AreEqual("#,S", path);
        }

        [TestMethod]
        public void navigate_embeddedSpace()
        {
            // search for a string with a space at the beginning
            var kb = new Example();
            string path = kb.Search("A B");

            Assert.AreEqual("#,S,R,#", path);
        }

        [TestMethod]
        public void navigate_specsSampleInput()
        {
            // search for the string that was provided as an example in the specs doc
            var kb = new Example();
            string path = kb.Search("IT Crowd");

            Assert.AreEqual("D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#", path);
        }

        [TestMethod]
        public void navigate_specsSampleInputDuplicatedCharacters()
        {
            // search for the string that was provided as an example in the specs doc with each char duplicated
            var kb = new Example();
            string path = kb.Search("IiTt  CcrRoOwWdD");

            Assert.AreEqual("D,R,R,#,#,D,D,L,#,#,S,S,U,U,U,R,#,#,D,D,R,R,R,#,#,L,L,L,#,#,D,R,R,#,#,U,U,U,L,#,#", path);
        }

        [TestMethod]
        [ExpectedException(typeof(LetterNotMappedException))]
        public void navigate_unmappedCharacter()
        {
            // search a string with a character that is not mapped to a keyboard character
            var kb = new Example();
            string path = kb.Search("A*JB");
        }

    }
}
