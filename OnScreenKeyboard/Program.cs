// Written by Robert C. Ryniak, July 27, 2016 for SoftWriters.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OnScreenKeyboard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new testOnScreenKeyboard());
        }
    }
}
