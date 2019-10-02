using System;
using System.IO;
using System.Windows.Forms;

namespace OnScreenKeyboardApplication
{
    public class OnScreenKeyboard
    {
        private static OpenFileDialog openFileDialog;
        private static StreamReader inputReader;
        private static string inputLines;
        private static KeyboardConverter converter;
        private static string convertedLines;

        [STAThread]
        static void Main()
        {
            CreateOpenFileDialogObject();

            SetDialogAttributes();

            // Only convert text file if one is successfully selected
            if (OpenFileSuccess())
            {
                SetupFileReader();

                ReadInputLines();

                CreateKeyboardConverterObject();

                ConvertInputTextToKeyboard();

                WriteConvertedLines();

                CloseReaderStream();
            }
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
            // Ensure that only text files are selected
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

        private static void ReadInputLines()
        {
            // Read all input at once to avoid slowness of multiple reads
            inputLines = inputReader.ReadToEnd();
        }

        private static void CreateKeyboardConverterObject()
        {
            converter = new KeyboardConverter();
        }

        private static void ConvertInputTextToKeyboard()
        {
            convertedLines = converter.ConvertLines(inputLines);
        }

        private static void WriteConvertedLines()
        {
            // Write all lines at once to avoid slowness of multiple writes
            Console.WriteLine(convertedLines);
        }

        private static void CloseReaderStream()
        {
            inputReader.Close();
        }
    }
}