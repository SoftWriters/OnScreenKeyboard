using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    class ViewModel : INotifyPropertyChanged
    {
        private Dictionary<char, Coordinate> _keyboard;
        private string _keyboardTB;
        private string _textBlockTxt;
        private string _lineToPrintTB;
        private string _inputFileName;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            this.Keyboard = new Dictionary<char, Coordinate>();
            this.KeyboardTB = "ABCDEF\nGHIJKL\nMNOPQR\nSTUVWX\nYZ1234\n567890";
            this.TextBlockTxt = "Nothing Processed";
            this.LineToPrintTB = "Hello";
            this.InputFileName = "";
            this.createKeyboardDict(KeyboardTB);
        }

        #region Member Accessors 
        public Dictionary<char, Coordinate> Keyboard
        {
            get { return _keyboard; }
            set { _keyboard = value; }
        }

        public string KeyboardTB
        {
            get { return _keyboardTB; }
            set { _keyboardTB = value; }
        }

        public string TextBlockTxt
        {
            get { return _textBlockTxt; }
            set { _textBlockTxt = value; }
        }

        public string LineToPrintTB
        {
            get { return _lineToPrintTB; }
            set { _lineToPrintTB = value; }
        }

        public string InputFileName
        {
            get { return _inputFileName; }
            set { _inputFileName = value; }
        }

        #endregion

        #region Public Functions
        public string ProcessString(string line)
        {
            if (line != "")
            {
                /* always begin in the top left */
                Coordinate currCoordinate = new Coordinate(0, 0);
                TextBlockTxt = "";
                line = line.ToUpper();

                for (int currIndex = 0; currIndex < line.Length; ++currIndex)
                {
                    char currChar = line.ElementAt(currIndex);
                    if (currChar != ' ')
                    {
                        Coordinate targetCoord = Keyboard[currChar];
                        //todo: verify that the currChar is in the dictionary

                        TextBlockTxt += currCoordinate.GetMovesTo(targetCoord);
                        currCoordinate = targetCoord;
                    }
                    else
                    {
                        TextBlockTxt += "S,";
                    }
                }
            }
            TextBlockTxt = TextBlockTxt.TrimEnd(',');
            OnPropertyChanged("TextBlockTxt");

            return TextBlockTxt;
        }

        public void UpdateKeyboard()
        {
            this.Keyboard.Clear();
            this.createKeyboardDict(KeyboardTB);
        }

        public void ProcessFile()
        {
            if (this.InputFileName != "")
            {
                string line;

                //todo: handle file doesn't exist exception  
                System.IO.StreamReader inputFile =
                    new System.IO.StreamReader(this.InputFileName);
                System.IO.StreamWriter outputFile =
                    new System.IO.StreamWriter("outputFile.txt");
                while ((line = inputFile.ReadLine()) != null)
                {
                    string outputString = this.ProcessString(line);
                    outputFile.WriteLine(outputString);
                }

                inputFile.Close();
                outputFile.Close();
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Private Functions
        private void createKeyboardDict(string keyboard)
        {
            int row = 0;
            int column = 0;
            string[] splitKeyboard = keyboard.Split('\n');

            //todo: ensure all rows are the same length
            while (row < splitKeyboard.Count())
            {
                while (column < splitKeyboard[row].Count())
                {
                    char letter = splitKeyboard[row].ElementAt(column);
                    //todo: handle case where the same letter is in the keyboard more than once
                    this.Keyboard.Add(letter, new Coordinate(row, column));
                    ++column;
                }
                ++row;
                column = 0;
            }
        }
        #endregion

    }
}
