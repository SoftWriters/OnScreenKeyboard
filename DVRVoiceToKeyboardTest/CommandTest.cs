using Microsoft.VisualStudio.TestTools.UnitTesting;
using DVRVoiceToKeyboard;
using System.Linq;

namespace DVRVoiceToKeyboardTest
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void Fluent_Test_Convert_Search_To_Command()
        {
            //inject text instead of read from the file
            CommandBuilder convert = new CommandBuilder(new string[] { "IT Crowd" });

            //empty file names will be ignored and injected text will be used
            convert.VoiceInputFile("").ToKeyboardCommand("");
                        
            Assert.AreEqual("D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#"
                , convert.BuiltCommands().FirstOrDefault());
        }
    }
}
