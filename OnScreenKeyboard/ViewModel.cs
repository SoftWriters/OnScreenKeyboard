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
        private string _selectedFileTB;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            this.Keyboard = new Dictionary<char, Coordinate>();
            this.KeyboardTB = "ABCDEF\nGHIJKL\nMNOPQR\nSTUVWX\nYZ1234\n567890";
            this.TextBlockTxt = "Nothing Processed";
            this.LineToPrintTB = "Hello";
            this.InputFileName = "";
            this.SelectedFileTB = "No File Selected";
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
            set
            {
                _inputFileName = value;
                this.SelectedFileTB = "File selected. Click Process File Button";
                OnPropertyChanged("SelectedFileTB");
            }
        }

        public string SelectedFileTB
        {
            get { return _selectedFileTB; }
            set { _selectedFileTB = value; }
        }

        #endregion

        #region Public Functions
        /// <summary>
        /// Clears the current dictionary and constructs the new keyboard dictionary
        /// </summary>
        public void UpdateKeyboard()
        {
            this.Keyboard.Clear();
            this.createKeyboardDict(KeyboardTB);
        }

        /// <summary>
        /// Takes the input string and determines the path required on the keyboard
        /// </summary>
        public void ProcessInputString()
        {
            TextBlockTxt = this.processString(this.LineToPrintTB);
            OnPropertyChanged("TextBlockTxt");
        }

        /// <summary>
        /// Reads in the specified file and determines the paths taken to print them with the keyboard.
        /// 
        /// Note that this does not handle any exceptions that could be raise. If the file doesn't
        /// exist, the program will crash.
        /// </summary>
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
                    string outputString = this.processString(line);
                    outputFile.WriteLine(outputString);
                }

                inputFile.Close();
                outputFile.Close();
            }
        }

        /// <summary>
        /// Communicates events to the view in order to update the desired fields
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Private Functions
        /// <summary>
        /// Takes in the keyboard string and creates a dictionary out of the letters. Searching for
        /// a given key in the dictionary is very quick which was why it was chosen.
        /// 
        /// Note that there are exceptions that could easily be raised. Todos note they should be handled
        /// </summary>
        /// <param name="keyboard"></param>
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

        /// <summary>
        /// Takes a string and returns the keyboard path to print it
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string processString(string line)
        {
            string text = "";
            if (line != "")
            {
                /* always begin in the top left */
                Coordinate currCoordinate = new Coordinate(0, 0);

                line = line.ToUpper();

                for (int currIndex = 0; currIndex < line.Length; ++currIndex)
                {
                    char currChar = line.ElementAt(currIndex);
                    if (currChar != ' ')
                    {
                        Coordinate targetCoord = Keyboard[currChar];
                        //todo: verify that the currChar is in the dictionary

                        text += currCoordinate.GetMovesTo(targetCoord);
                        currCoordinate = targetCoord;
                    }
                    else
                    {
                        text += "S,";
                    }
                }
            }
            text = text.TrimEnd(',');
            return text;
        }
        #endregion
    }
}
