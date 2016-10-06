using NUnit.Framework;
using OnScreenKeyboard;



namespace Tests.OnScreenKeyboard
{
    [TestFixture]
    public class DvrTest
    {

        [Test]
        public void DoesVoiceControlPass()
        {
            var vk = new VoiceKeyboard();
            var testValue = vk.GetKeyStrokes("IT Crowd");
            Assert.That(testValue, Is.EqualTo("D,R,R,#,D,D,L,#,S,R,U,U,U,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,L,U,U,U,#"));

        }


    

    }
}
