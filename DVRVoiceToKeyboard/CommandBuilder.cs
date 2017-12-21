using System.Collections.Generic;

namespace DVRVoiceToKeyboard
{
    //method chaining the programs story. A functional and object oriented way
    public class CommandBuilder : FileMaintenance
    {
        public CommandBuilder() { }

        public CommandBuilder(string[] injectedVoiceText) : base(injectedVoiceText) { }

        public CommandBuilder VoiceInputFile(string inputFile)
        {
            //reads the file into memory if file name exists
            if (inputFile != string.Empty) ReadInputFile(inputFile);
            return this;
        }

        public CommandBuilder ToKeyboardCommand(string outputFile)
        {
            //execute the coordinate driver
            builtCommands.AddRange(BuildCommands());

            //check if there is a file name present
            if (outputFile != string.Empty) WriteToOutputFile(outputFile, builtCommands.ToArray());
            return this;
        }

        private IEnumerable<string> BuildCommands()
        {
            List<string> result = new List<string>();

            foreach (string searchTerm in InputTerms)
            {
                string termUppercase = searchTerm.ToUpper();
                string commandString = "";
                TheMatrixKeyboard keyboard = new TheMatrixKeyboard();
                //need to determine index of characters for searchterm
                for (int index = 0; index <= searchTerm.Length - 1; index++)
                {
                    //don't touch the start index for first char or space
                    if (searchTerm.ToCharArray()[index] == ' ' || index == 0)
                        commandString += keyboard.To(termUppercase.ToCharArray()[index]);
                    //don't touch the start index if it's after a space
                    else if (searchTerm.ToCharArray()[index - 1] == ' ')
                        commandString += keyboard.IsNavigatingFrom(termUppercase.ToCharArray()[index - 2])
                            .To(termUppercase.ToCharArray()[index]);
                    //otherwise compare
                    else if (index <= searchTerm.Length - 1)
                        commandString += keyboard.IsNavigatingFrom(termUppercase.ToCharArray()[index - 1])
                            .To(termUppercase.ToCharArray()[index]);                    

                    //add a comma if its not the end
                    if (index != searchTerm.Length - 1)
                        commandString += ',';
                }

                result.Add(commandString);
            }

            return result;
        }

        public string[] BuiltCommands()
        {
            return builtCommands.ToArray();
        }

        private List<string> builtCommands = new List<string>();
    }
}
