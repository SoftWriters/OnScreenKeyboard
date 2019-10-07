using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnScreenKeyboard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UnitTest
{
    [TestClass]
    public class TestProgramMethods_Output
    {
        [TestMethod]
        public void Output_Initial()
        {
            var pm = new ProgramMethods();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "OSKtest");
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                }
            }
            var list = pm.Output(path);
            Assert.AreEqual(list[0], "D,R,#,U,R,R,R,#,D,R,#,#,D,L,L,L,#");
     
        }
    }
}
