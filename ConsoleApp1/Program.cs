using OnScreenKeyboard.files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnScreenKeyboard
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramMethods pm = new ProgramMethods();
           

            while (true)
            {
                Console.WriteLine("Please create a text file on your desktop and write the file name or type exit to leave!");
                var filename = Console.ReadLine();
                if (filename.ToLower().Equals("exit")) pm.Exit();
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
                if (File.Exists(path) && Path.GetExtension(path).Equals(".txt")) pm.Write(path); else Console.WriteLine("file does not exist! Try again!");
            }
        }
    }
}
