// Written by Robert C. Ryniak, July 27, 2016 for SoftWriters.
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OnScreenKeyboard
{
    public partial class testOnScreenKeyboard : Form
    {
        // This is the object that'll do all the REAL work... note that we can configure the 
        // "layout" of the "keyboard" by passing in arguments to the constructor.
        private OnScreenKeyMapper keyMapper = new OnScreenKeyMapper("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890", 6);
        private string _selectedFileToParse = null;

        public testOnScreenKeyboard()
        {
            InitializeComponent();
        }

        private void textInputFile_TextChanged(object sender, EventArgs e)
        {
            if (optionAsFile.Checked)
            {
                // "Treat as File"
                string currentFileToParse = File.Exists(textInput.Text) ? textInput.Text : null;
                if ((currentFileToParse != null) && (currentFileToParse != _selectedFileToParse))
                {
                    _selectedFileToParse = currentFileToParse;
                    List<string> outputLines = keyMapper.TranslateFile(currentFileToParse);
                    if (outputLines != null)
                    {
                        //populate the translated lines of data.
                        textOutput.Text = "";
                        foreach (string outputLine in outputLines)
                        {
                            textOutput.AppendText(outputLine + "\n");
                        }
                    }
                }
            }
            else
            {
                // "Treat as Text"
                textOutput.Text = keyMapper.Translate(textInput.Text);
            }
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(openFileDlg.FileName)) textInput.Text = openFileDlg.FileName;
            }
        }

        private void option_CheckedChanged(object sender, EventArgs e)
        {
            buttonSelectFile.Enabled = optionAsFile.Checked;
            labelInput.Text = optionAsFile.Checked ? "Input File:" : "Input Text:";
            
            //re-call the changed event, since that event is handled differently, based the choice of "As File" or "As Text".
            textInputFile_TextChanged(sender, e);
        }
    }
}
