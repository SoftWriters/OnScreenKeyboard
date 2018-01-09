using System;
using System.IO;
using System.Threading.Tasks;

namespace MapToKeyboardInput
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var stdin = Console.OpenStandardInput())
            using (var stdout = Console.OpenStandardOutput())
                await ProcessAsync(stdin, stdout);
        }

        /// <summary>
        /// Read lines from the input stream and write the cursor instructions to the output stream.
        /// </summary>
        private static async Task ProcessAsync(Stream stdin, Stream stdout)
        {
            var processor = new OnScreenKeyboard.Logic.InputProcessor(new OnScreenKeyboard.Logic.SixBySixKeyboardLayout());

            using (var reader = new StreamReader(stdin))
            using (var writer = new StreamWriter(stdout))
            {
                string input = null;
                while ((input = await reader.ReadLineAsync()) != null)
                    writer.WriteLine(processor.ToCursorInstructions(input));
            }

        }
    }
}
