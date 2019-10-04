using ConsoleApp1.files;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitialValues_CurrentPosX()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(kb.CurrentPosX, 1, "CurrentPosX should initialize to 1");
        }
        [TestMethod]
        public void InitialValues_CurrentPosY()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(kb.CurrentPosY, 0, "CurrentPosY should initialize to 0");
        }
        [TestMethod]
        public void InitialValues_DesiredPosX()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(kb.DesiredPosX, 1, "DesiredPosX should initialize to 1");
        }
        [TestMethod]
        public void InitialValues_DesiredPosY()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(kb.DesiredPosY, 0, "DesiredPosY should initialize to 0");
        }
        [TestMethod]
        public void InitialValues_Output()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(null, kb.Output, "Output is " + kb.Output + " but should be null");
        }

        //TODO the upper limit on this method should be 1, should not be able to go above the first row
        [TestMethod]
        public void InitialValues_Up()
        {
            Keyboard kb = new Keyboard();
            kb.Up();
            Assert.AreEqual("U", kb.Output, "Output is " + kb.Output + " but should be U");
            kb.Up();
            Assert.AreEqual(-1, kb.CurrentPosX, "CurrentPosX is " + kb.CurrentPosX + " but should be -1");
        }
        [TestMethod]
        public void InitialValues_Down()
        {
            Keyboard kb = new Keyboard();
            kb.Down();
            Assert.AreEqual("D", kb.Output, "Output is " + kb.Output + " but should be D");
            kb.Down();
            Assert.AreEqual(3, kb.CurrentPosX, "CurrentPosX is " + kb.CurrentPosX + " but should be 3");
        }

        [TestMethod]
        public void InitialValues_Left()
        {
            Keyboard kb = new Keyboard();
            kb.Left();
            Assert.AreEqual("L", kb.Output, "Output is " + kb.Output + " but should be L");
            kb.Left();
            Assert.AreEqual(-2, kb.CurrentPosY, "CurrentPosY is " + kb.CurrentPosY + " but should be -2");
        }
        [TestMethod]
        public void InitialValues_Right()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(null, kb.Output, "Output is " + kb.Output + " but should be null");
        }

        [TestMethod]
        public void InitialValues_Select()
        {
            Keyboard kb = new Keyboard();
            Assert.AreEqual(null, kb.Output, "Output is " + kb.Output + " but should be null");
        }


        //    public Dictionary<int, string[]> keys = new Dictionary<int, string[]>()
        //        {
        //            { 1, new string[]{ "A", "B", "C", "D", "E", "F"} },
        //            { 2, new string[]{ "G", "H", "I", "J", "K", "L"} },
        //            { 3, new string[]{ "M", "N", "O", "P", "Q", "R"} },
        //            { 4, new string[]{ "S", "T", "U", "V", "W", "X"} },
        //            { 5, new string[]{ "Y", "Z", "1", "2", "3", "4"} },
        //            { 6, new string[]{ "5", "6", "7", "8", "9", "0"} }
        //        };

        //    public void Up()
        //    {
        //        this.Output += "U";
        //        this.CurrentPosX--;
        //    }
        //    public void Down()
        //    {
        //        this.Output += "D";
        //        this.CurrentPosX++;
        //    }
        //    public void Right()
        //    {
        //        this.Output += "R";
        //        this.CurrentPosY++;
        //    }
        //    public void Left()
        //    {
        //        this.Output += "L";
        //        this.CurrentPosY--;
        //    }

        //    internal void Select() => this.Output += "#";
        //}
    }
}
