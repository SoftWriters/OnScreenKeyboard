using System;
using System.Collections.Generic;
using System.IO;


namespace OnscreenKeyboardTranslation
{
    public class ScreenTranslator
        //!!! This class is my solution, so that the dll could be dropped into .NET projects for use or used as a Reference in another dll.
        //!!! Written for job search, by Chris Ream, 2018.
    {
        private List<string> fileLines = new List<string>();
        private List<string> _linesTranslated = new List<string>();
        private bool _unknownChars = false;
        static char[][] _constTranslationKey = new char[][] {
                                                               new char[] { 'A', 'B', 'C', 'D','E', 'F' }, new char[] { 'G','H','I','J','K','L' },
                                                               new char[] { 'M', 'N', 'O', 'P', 'Q', 'R'}, new char[] {'S','T','U','V','W','X'},
                                                               new char[]  { 'Y','Z','1','2','3','4' }, new char[] { '5','6','7','8','9','0' }
                                                            };


        /// <summary>
        /// flag for whether current obj contained char not recognized in _constTranslationKey; unrecognized char will be skipped in translation
        /// </summary>
        /// <returns>bool</returns>
        public bool GetContainsUnknownChars()
        {
            return _unknownChars;
        }
        private void SetContainsUnknownChars(bool isTrue)
        {
            _unknownChars = isTrue == true ? true : _unknownChars;
        }


        /// <summary>
        /// return translation key
        /// </summary>
        public static char[][] ConstTranslationKey
        {
            get
            {
                return _constTranslationKey;
            }
        }


        public void AddFileLine(string strInput)
        {
            fileLines.Add(strInput.ToUpper());
        }
        public List<string> GetFileLines()
        {
            return fileLines;
        }


        /// <summary>
        /// Returns information requested for project; use in service, website, winform, etc. Feed filepath of flat file as string param.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>List containing translated characters; each file line is contained at an index</returns>
        public List<string> TranslateLines(string filePath)
        {
            string[] text = File.ReadAllLines(@filePath);
            if (text.Length > 0)
            {
                Action<string> action = new Action<string>(TranslateALine);
                Action<string> action2 = new Action<string>(AddFileLine);
                Array.ForEach(text, action);
                Array.ForEach(text, action2);
            }
            return _linesTranslated;
        }


        /// <summary>
        /// translates and adds to _linesTranslated
        /// </summary>
        /// <param name="line"></param>
        private void TranslateALine(string line)
        {
            //this.AddFileLine(line);
            char[] chars = line.ToCharArray();
            List<char> translated = new List<char>();
            int vertPrevious = 0, horzPrevious = 0;
            for (int x = 0; x < chars.Length; x++)
            {
                int currentVert = 0, currentHorz = 0;
                int vertMoves = 0, horzMoves = 0;
                //find which char[] holds the char we are looking for
                for (int v = 0; v < _constTranslationKey.Length; v++)
                {
                    if (Array.IndexOf<char>(_constTranslationKey[v], chars[x]) >= 0)
                    {
                        currentVert = v;
                        break;
                    }
                }
                // check if the char is even in the _constTranslationKey and then convert into the directional chars.
                if (chars[x] == ' ')
                {
                    translated.Add('S');
                    continue;
                }
                else if (currentVert >= 0)
                {
                    char[] arrayContainingChar = (char[])_constTranslationKey.GetValue(currentVert);
                    vertMoves = vertPrevious - currentVert;
                    vertPrevious = currentVert;
                    //vert
                    if (vertMoves >= 0)
                    {
                        for (int v = 0; v < vertMoves; v++)
                        {
                            translated.Add('U');
                        }
                    }
                    else
                    {
                        for (int v = 0; v > vertMoves; v--)
                        {
                            translated.Add('D');
                        }
                    }
                    //horiz
                    currentHorz = Array.IndexOf(arrayContainingChar, chars[x]);
                    horzMoves = horzPrevious - currentHorz;
                    horzPrevious = currentHorz;
                    if (horzMoves >= 0)
                    {
                        for (int h = 0; h < horzMoves; h++)
                        {
                            translated.Add('L');
                        }
                    }
                    else
                    {
                        for (int h = 0; h > horzMoves; h--)
                        {
                            translated.Add('R');
                        }
                    }
                    translated.Add('#');
                }
                else
                {
                    this.SetContainsUnknownChars(true);
                    continue;
                }
            }
            this._linesTranslated.Add(String.Join("", translated));
        }

    }

}
