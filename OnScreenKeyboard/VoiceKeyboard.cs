using OnScreenKeyboard.Models;
using System;

namespace OnScreenKeyboard
{
    public class VoiceKeyboard
    {
        private string _title;


        private readonly string[] _keyboard = { "ABCDEF", "GHIJKL", "MNOPQR", "STUVWX", "YZ1234", "567890" };

        private Cords _currentCords = new Cords { x = 0, y = 0 };




        public string GetKeyStrokes(string title)
        {
            _title = title;

            string buttonPresses = "";






            title = title.ToLower();
            foreach (var c in title)
            {

                var charCords = GetCords(c.ToString().ToLower());
                if (c.ToString() == " ")
                {
                    buttonPresses += "S,";

                }
                else
                {
                    buttonPresses += GetButtons(_currentCords, charCords);
                }







            }

            buttonPresses = buttonPresses.Remove(buttonPresses.Length - 1);

            return buttonPresses;






        }

        private Cords GetCords(string c)
        {
            var cords = new Cords();

            for (var i = 0; i < _keyboard.Length; i++)
            {
                if (_keyboard[i].ToLower().Contains(c))
                {
                    cords.y = i;
                    cords.x = _keyboard[i].ToLower().IndexOf(c, StringComparison.Ordinal);


                }
            }
            return cords;

        }

        private string GetButtons(Cords lastCord, Cords newCord)
        {
            string returnString = "";
            if (lastCord.y < newCord.y)
            {
                for (var i = lastCord.y; i < newCord.y; i++)
                {
                    returnString += "D,";
                }


            }
            if (lastCord.x < newCord.x)
            {
                for (var i = lastCord.x; i < newCord.x; i++)
                {
                    returnString += "R,";
                }
            }

            if (lastCord.x > newCord.x)
            {
                for (var i = lastCord.x; i > newCord.x; i--)
                {
                    returnString += "L,";

                }
            }
            if (lastCord.y > newCord.y)
            {
                for (var i = lastCord.y; i > newCord.y; i--)
                {
                    returnString += "U,";

                }
            }
            _currentCords = newCord;

            returnString += "#,";

            return returnString;

        }
    }
}