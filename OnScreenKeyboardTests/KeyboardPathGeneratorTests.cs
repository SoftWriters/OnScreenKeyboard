using Microsoft.VisualStudio.TestTools.UnitTesting;

using SoftWriters;

namespace OnScreenKeyboardTests {
    [TestClass]
    public class KeyboardPathGeneratorTests {
        KeyboardPathGenerator generator = new KeyboardPathGenerator();


        [TestMethod]
        //Degenerate case
        public void EmptyString() {
            var shorthand = generator.GenerateShorthandFrom("");
            var expected = "";
            Assert.AreEqual(expected, shorthand);
        }

        [TestMethod]
        public void ShorthandFor_() {
            var shorthand = generator.GenerateShorthandFrom(" ");
            var expected = "S";
            Assert.AreEqual(expected, shorthand);
        }
        [TestMethod]
        public void ShorthandForA() {
            var shorthand = generator.GenerateShorthandFrom("A");
            var expected = "#";
            Assert.AreEqual(expected, shorthand);
        }

        [TestMethod]
        public void SimpleRight() {
            var shorthand = generator.GenerateShorthandFrom("ABC");
            var expected = "#,R,#,R,#";
            Assert.AreEqual(expected, shorthand);
        }

        [TestMethod]
        public void SimpleDown() {
            var shorthand = generator.GenerateShorthandFrom("AGM");
            var expected = "#,D,#,D,#";
            Assert.AreEqual(expected, shorthand);
        }

        [TestMethod]
        public void OptimizedWrapping() {
            var shorthand = generator.GenerateShorthandFrom("A50FA");
            var expected = "#,U,#,L,#,D,#,R,#";
            Assert.AreEqual(expected, shorthand);
        }

        [TestMethod]
        public void CaseDoesNotMatter() {
            var shorthand = generator.GenerateShorthandFrom("Aa");
            var expected = "#,#";
            Assert.AreEqual(expected, shorthand);
        }

        [TestMethod]
        public void ShorthandForA_A() {
            var shorthand = generator.GenerateShorthandFrom("A A");
            var expected = "#,S,#";
            Assert.AreEqual(expected, shorthand);
        }

        [TestMethod]
        public void InvalidInput() {
            var shorthand = generator.GenerateShorthandFrom("!");
            var expected = "Invalid input: !";
            Assert.AreEqual(expected, shorthand);
        }


        [TestMethod]
        public void ExampleTest() {
            var shorthand = generator.GenerateShorthandFrom("IT Crowd");
            var expected = "D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#";
            Assert.AreEqual(expected, shorthand);
        }
    }
}
