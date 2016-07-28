// Written by Robert C. Ryniak, July 27, 2016 for SoftWriters.
// -----------------------------------------------------------
/* Please note that this work isn't about showing you how well I know a particular
 * programming language, or the latest frameworks, or any of the things which seem
 * to be in constant flux in the world of software engineering.  It is the purpose
 * and goal of this code to demonstrate how I solve the problem in the "requirements"
 * as provided by the stakeholder(s). If you have any questions why I did things 
 * one particular way or another, please don't hesitate to ask me, thanks! */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace OnScreenKeyboard
{
    public class OnScreenKeyMapper
    {
        private string _keyMapList;
        private int _keysPerRow;

        // This constructor allows us to store the keysPermitted list of characters in string form, serving as a
        // lookup table.  It allows us to leverage the string method IndexOf to solve the searching aspects of the 
        // core algorithm.  When a character is positively found at a position in the _keyMapList, then the index 
        // of the given position divided by the _keysPerRow gives us an effective and precise X,Y coordinates value 
        // for the given character on the keyboard.  This allows us to track current and expected coordinates, 
        // differencing them for a quick and easy sequence of navigation steps.
        //*****************************************************************************************************************
        public OnScreenKeyMapper(string keysPermitted, int keysPerRow)
        {
            _keyMapList = keysPermitted.ToUpper(); //guarantees case insensitivity
            _keysPerRow = keysPerRow;
        }

        // This method is where all the REAL WORK is done.  It provides the text-to-key mapping translation.
        // IMPORTANT: Only the "legal" keyboard characters will be translated.  Any illegal characters contained
        // within a string that's passed into this method will be entirely ignored. This ensures that the keyboard 
        // automation routine works reliably in the presence of bad data.
        //*****************************************************************************************************************
        public string Translate(string inputText)
        {
            StringBuilder outputValue = new StringBuilder();
            string processText = inputText.ToUpper();
            
            // start a given translation at the top left most part of the keyboard (per the example in the req. doc)
            int currentX = 0;
            int currentY = 0;
            int newX = 0;
            int newY = 0;

            for (int charIndex = 0; charIndex < processText.Length; charIndex++)
            {
                string currentChar = processText.Substring(charIndex, 1);
                if (currentChar == " ")
                {
                    outputValue.AppendCommaDelimited("S");
                }
                else
                {
                    // Only process characters in the inputText if they're legitimately on our keyboard.
                    // ...if mappedCharIndex = -1 then the character should/can be ignored.
                    int mappedCharIndex = _keyMapList.IndexOf(currentChar);
                    if (mappedCharIndex >= 0)
                    {
                        newY = mappedCharIndex / _keysPerRow; // integer quotient is the row.
                        newX = mappedCharIndex % _keysPerRow; // remainder is the column.
                        
                        int diffY = newY - currentY;
                        if (diffY < 0)
                        { // This is UP command diffY times
                            for (int count = 0; count < Math.Abs(diffY); count++)
                            {
                                outputValue.AppendCommaDelimited("U");
                            }
                        }
                        else
                        { // This is DOWN command diffY times
                            for (int count = 0; count < Math.Abs(diffY); count++)
                            {
                                outputValue.AppendCommaDelimited("D");
                            }
                        }

                        int diffX = newX - currentX;
                        if (diffX < 0)
                        { // This is LEFT command diffX times
                            for (int count = 0; count < Math.Abs(diffX); count++)
                            {
                                outputValue.AppendCommaDelimited("L");
                            }
                        }
                        else
                        { // This is RIGHT command diffX times
                            for (int count = 0; count < Math.Abs(diffX); count++)
                            {
                                outputValue.AppendCommaDelimited("R");
                            }
                        }
                        // always finish the navigation with a "select" command
                        outputValue.AppendCommaDelimited("#");

                        // MAKE SURE to save the new position as current, since the next position is relative to the current one
                        currentX = newX;
                        currentY = newY;
                    }
                }
            }

            return outputValue.ToString();
        }        

        // This method is generally not useful for a DVR, which will need to only handle one on screen translation request
        // at a time.  However, in the interest of testing, the following "TranslateFile" method is provided that parses
        // and translates all lines in a file simultaneously. It would be expected that the DVR's production code would only
        // need to make use of the Translate method, above.
        //*****************************************************************************************************************
        public List<string> TranslateFile(string fileNameToTranslate)
        {
            // Sanity checking is cleaner than exception handling where possible - so if the return value is null, then it's not a valid file.
            if (File.Exists(fileNameToTranslate))
            {
                try
                {
                    List<string> convertedOutput = new List<string>();
                    StreamReader inputFile = File.OpenText(fileNameToTranslate);
                    if (inputFile != null)
                    {
                        string textInput;
                        //iterate through the file, line by line, and populate the output collection for each line.
                        do
                        {
                            textInput = inputFile.ReadLine();
                            if (textInput != null) convertedOutput.Add(Translate(textInput));
                        } while (textInput != null);
                        inputFile.Close();

                        // return with the collection (list) of strings in tow.  The caller can iterate through the list as needed.
                        return convertedOutput;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (OutOfMemoryException e)
                {
                    WriteToLog("Out of memory reading file '" + fileNameToTranslate + "'. " + e.Message);
                    return null; //if there was an error parsing the file, we return null. Callers should test the return value.
                }
                catch (IOException e)
                {
                    WriteToLog("IO exception reading file '" + fileNameToTranslate + "'. " + e.Message);
                    return null; //if there was an error parsing the file, we return null. Callers should test the return value.
                }
                catch
                {
                    WriteToLog("An unknown error occurred reading file '" + fileNameToTranslate + "'.");
                    return null; //if there was an error parsing the file, we return null. Callers should test the return value.
                }
            }
            else
            {
                return null;
            }
        }

        // Utility
        //*****************************************************************************************************************
        private void WriteToLog(string logMessage)
        {
            const string logFileSource = "OnScreenKeyMapper";
            if (!EventLog.SourceExists(logFileSource)) EventLog.CreateEventSource(logFileSource, "Application");
            EventLog.WriteEntry(logFileSource, logMessage, EventLogEntryType.Error);
        }
    }

    public static class ExtensionMethods
    {
        // Extension method for StringBuilders, allowing us to easily append with consideration for whether or not a comma is needed.
        public static void AppendCommaDelimited(this StringBuilder stringBuilderObject, string stringToAdd)
        {
            stringBuilderObject.Append(stringBuilderObject.Length > 0 ? "," + stringToAdd : stringToAdd);
        }
    }
}
