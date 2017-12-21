using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace DVRVoiceToKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //get the settings
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                //Elegant simplicity over clever complexity
                CommandBuilder convert = new CommandBuilder();
                convert.VoiceInputFile(configuration["inputFile"]).ToKeyboardCommand(configuration["outputFile"]);
            }
            catch (FileNotFoundException fileException)
            {
                Console.WriteLine("File not found: " + fileException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
