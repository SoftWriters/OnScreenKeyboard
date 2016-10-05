using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    public class VoiceKeyboard
    {
        private string _title;


        private string[,] _keyboard =
        {
            {
                "ABCDEF"
            },
            {
                "GHIJKL"
            },
            {
                "MNOPQR"
            },
            {
                "STUVWX"
            },
            {
                "YZ1234"
            },
            {
                "567890"
            }

        };

        private int startingPosition = 0;


        public string GetKeyStrokes(string title)
        {
            _title = title;

            string returnValue = "";
            int currentX = 0;
            int currentY = 0;
            bool done = false;


            title = title.ToLower();





        }

        private GetCords(char c)
        {
            for (var i = 0; _keyboard.Length; i++)
            {
                


























    }
}
