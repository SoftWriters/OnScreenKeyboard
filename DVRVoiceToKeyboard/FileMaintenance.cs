using System.IO;

namespace DVRVoiceToKeyboard
{
    public abstract class FileMaintenance
    {
        public FileMaintenance() { }

        public FileMaintenance(string[] injectedText) { InputTerms = injectedText; }

        protected void ReadInputFile(string inputFile)
        {
            InputTerms = File.ReadAllLines(inputFile);
        }

        protected void WriteToOutputFile(string outputFile, string[] outputStrings)
        {
            File.WriteAllLines(outputFile, outputStrings);
        }

        protected string[] InputTerms { get; set; }
    }
}
