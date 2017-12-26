using OnScreenKeyboard.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard.Keyboards
{
    public class Example : IKeyboard
    {

        private Location[] _letterMap;
        private char _currentLetter;
        private Location _currentLocation;

        #region Constructors....

        public Example()
        {
            loadLetterMap();
            _currentLetter = 'A';
            _currentLocation = _letterMap[_currentLetter];
        }

        private void loadLetterMap()
        {
            _letterMap = new Location[256];

            // ABCDEF
            // GHIJKL
            // MNOPQR
            // STUVWX
            // YZ1234
            // 567890

            _letterMap['A'] = new Location(0, 0);
            _letterMap['B'] = new Location(0, 1);
            _letterMap['C'] = new Location(0, 2);
            _letterMap['D'] = new Location(0, 3);
            _letterMap['E'] = new Location(0, 4);
            _letterMap['F'] = new Location(0, 5);
            _letterMap['G'] = new Location(1, 0);
            _letterMap['H'] = new Location(1, 1);
            _letterMap['I'] = new Location(1, 2);
            _letterMap['J'] = new Location(1, 3);
            _letterMap['K'] = new Location(1, 4);
            _letterMap['L'] = new Location(1, 5);
            _letterMap['M'] = new Location(2, 0);
            _letterMap['N'] = new Location(2, 1);
            _letterMap['O'] = new Location(2, 2);
            _letterMap['P'] = new Location(2, 3);
            _letterMap['Q'] = new Location(2, 4);
            _letterMap['R'] = new Location(2, 5);
            _letterMap['S'] = new Location(3, 0);
            _letterMap['T'] = new Location(3, 1);
            _letterMap['U'] = new Location(3, 2);
            _letterMap['V'] = new Location(3, 3);
            _letterMap['W'] = new Location(3, 4);
            _letterMap['X'] = new Location(3, 5);
            _letterMap['Y'] = new Location(4, 0);
            _letterMap['Z'] = new Location(4, 1);
            _letterMap['1'] = new Location(4, 2);
            _letterMap['2'] = new Location(4, 3);
            _letterMap['3'] = new Location(4, 4);
            _letterMap['4'] = new Location(4, 5);
            _letterMap['5'] = new Location(5, 0);
            _letterMap['6'] = new Location(5, 1);
            _letterMap['7'] = new Location(5, 2);
            _letterMap['8'] = new Location(5, 3);
            _letterMap['9'] = new Location(5, 4);
            _letterMap['0'] = new Location(5, 5);
        }

        #endregion

        #region IKeyboard implementation....

        public string Search(string searchTerm)
        {
            var cursorPath = new List<string>();
            var letters = searchTerm.ToCharArray();
            foreach (char letter in letters)
            {
                var pathToLetter = Navigate(letter);
                cursorPath.AddRange(pathToLetter);
            }  // next letter

            return String.Join(",", cursorPath);
        }

        public IEnumerable<string> Navigate(char target)
        {
            //todo: look into making return type char[]
            target = Char.ToUpper(target);

            // no navigation necessary if the cursor is already on the target character, so just select it
            if (target.Equals(_currentLetter))
                return new string[] { NavigationConstants.Select };

            // this keyboard does not have a mapping for space, so no need to navigate to it
            if (target.Equals(' '))
                return new string[] { NavigationConstants.Space };

            // get the coordinates of the target letter. error if target letter is not mapped
            var targetLocation = _letterMap[target];
            if (targetLocation == null)
            {
                throw new LetterNotMappedException()
                {
                    Letter = target
                };
            }

            // build the path to the letter from the current cursor location

            var path = new List<string>();

            // navigate up or down
            if (_currentLocation.Row < targetLocation.Row)
            {
                while (_currentLocation.Row != targetLocation.Row)
                {
                    path.Add(NavigationConstants.Down);
                    _currentLocation.Row++;
                }  // end while
            }
            else if (_currentLocation.Row > targetLocation.Row)
            {
                while (_currentLocation.Row != targetLocation.Row)
                {
                    path.Add(NavigationConstants.Up);
                    _currentLocation.Row--;
                }  // end while
            }

            // navigate left or right
            if (_currentLocation.Column < targetLocation.Column)
            {
                while (_currentLocation.Column != targetLocation.Column)
                {
                    path.Add(NavigationConstants.Right);
                    _currentLocation.Column++;
                }  // end while
            }
            else if (_currentLocation.Column > targetLocation.Column)
            {
                while (_currentLocation.Column != targetLocation.Column)
                {
                    path.Add(NavigationConstants.Left);
                    _currentLocation.Column--;
                }  // end while
            }

            // current location should now be the target character, so select and save it
            path.Add(NavigationConstants.Select);
            _currentLetter = target;

            return path;
        }

        #endregion

    }  // end class
}  // end namespace
