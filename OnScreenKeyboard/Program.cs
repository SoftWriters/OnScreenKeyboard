using System.IO;
using System.Threading;

namespace SoftWriters {
    public class Program {
        static void Main(string[] args) {
            if(args.Length == 0) {
                System.Console.WriteLine("Usage: <path>");
            }

            var keyboardPathGenerator = new KeyboardPathGenerator();
            try {
                var testCases = File.ReadAllLines(args[0]);
                foreach(var testCase in testCases) {
                    var shorthand = keyboardPathGenerator.GenerateShorthandFrom(testCase);
                    System.Console.WriteLine(shorthand);
                }
            }
            catch(IOException e) {
                System.Console.Error.WriteLine("Error accessing path: " + args[0]);
                System.Console.Error.WriteLine(e.Message);
            }
        }
    }
}
