using Microsoft.VisualStudio.TestTools.UnitTesting;

using SoftWriters;
using System;
using System.Collections.Generic;

namespace OnScreenKeyboardTests {
    [TestClass]
    public class KeyboardTests {
        Keyboard keyboard = new Keyboard();

        [TestInitialize]
        public void Initialize() {
            keyboard.Reset();
        }

        [TestMethod]
        public void StartsAtA() {
            triggerFromShorthand("#");
            Assert.AreEqual("A", keyboard.Text);
        }

        [TestMethod]
        public void AddingASpace() {
            triggerFromShorthand("#,S,#");
            Assert.AreEqual("A A", keyboard.Text);
        }

        [TestMethod]
        public void MoveRightForB() {
            triggerFromShorthand("R,#");
            Assert.AreEqual("B", keyboard.Text);
        }

        [TestMethod]
        public void MoveLeftForF() {
            triggerFromShorthand("L,#");
            Assert.AreEqual("F", keyboard.Text);
        }

        [TestMethod]
        public void MoveDownForG() {
            triggerFromShorthand("D,#");
            Assert.AreEqual("G", keyboard.Text);
        }

        [TestMethod]
        public void MoveUpFor5() {
            triggerFromShorthand("U,#");
            Assert.AreEqual("5", keyboard.Text);
        }

        [TestMethod]
        public void MovingWithoutSelecting() {
            triggerFromShorthand("U,D,D,L,L,R,R,R,R");
            Assert.AreEqual("", keyboard.Text);
        }

        [TestMethod]
        public void ExampleTest() {
            var shorthand = "D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#";
            triggerFromShorthand(shorthand);
            Assert.AreEqual("IT CROWD", keyboard.Text);
        }

        private Dictionary<string, Action<Keyboard>> shorthandLookup = new Dictionary<string, Action<Keyboard>>() {
            {"U", keyboard => Input.UP.Trigger(keyboard) },
            {"D", keyboard => Input.DOWN.Trigger(keyboard) },
            {"L", keyboard => Input.LEFT.Trigger(keyboard) },
            {"R", keyboard => Input.RIGHT.Trigger(keyboard) },
            {"#", keyboard => Input.SELECT.Trigger(keyboard) },
            {"S", keyboard => Input.SPACE.Trigger(keyboard) },
        };

        private void triggerFromShorthand(string shorthand) {
            var items = shorthand.Split(',');
            foreach(var item in items) {
                shorthandLookup[item](keyboard);
            }
        }
    }
}
