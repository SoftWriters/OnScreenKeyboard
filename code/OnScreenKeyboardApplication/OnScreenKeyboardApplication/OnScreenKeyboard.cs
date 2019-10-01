using System;
using System.IO;
using System.Windows.Forms;

namespace OnScreenKeyboardApplication
{
    public class OnScreenKeyboard
    {
        private static OpenFileDialog openFileDialog;
        private static StreamReader inputReader;
        private static string currentLine;
        private static KeyboardConverter converter;

        [STAThread]
        static void Main()
        {
            CreateOpenFileDialogObject();

            SetDialogAttributes();

            while (!OpenFileSuccess()) ;

            SetupFileReader();

            ReadInputLine();

            CreateKeyboardConverterObject();

            while (currentLine != null)
            {
                WriteConvertedLine();
                ReadInputLine();
            }

            CloseReaderStream();
        }

        private static void CreateOpenFileDialogObject()
        {
            openFileDialog = new OpenFileDialog();
        }

        private static void SetDialogAttributes()
        {
            openFileDialog.Title = "Select a text file to convert";

            SetDialogSelectableFileTypes();

            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
        }

        private static void SetDialogSelectableFileTypes()
        {
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
        }

        private static bool OpenFileSuccess()
        {
            return openFileDialog.ShowDialog() == DialogResult.OK;
        }

        private static void SetupFileReader()
        {
            var inputFileStream = openFileDialog.OpenFile();

            inputReader = new StreamReader(inputFileStream);
        }

        private static void ReadInputLine()
        {
            currentLine = inputReader.ReadLine();
        }

        private static void CreateKeyboardConverterObject()
        {
            converter = new KeyboardConverter();
        }

        private static void WriteConvertedLine()
        {
            string convertedLine = converter.ConvertLine(currentLine);
            Console.WriteLine(convertedLine);
        }

        private static void CloseReaderStream()
        {
            inputReader.Close();
        }
    }
}