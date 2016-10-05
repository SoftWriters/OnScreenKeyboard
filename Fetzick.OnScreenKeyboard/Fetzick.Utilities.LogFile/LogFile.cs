using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Fetzick.Utilities.LogFile
{

    public class LogFile
    {
        // Log file name
        private string Name { get;  set; }
        
        public LogFile(string LogFilePath)
        {
            Name = LogFilePath;
        }

        public void WriteToLogFile(string Message)
        {
            // Write message to log file
            using (StreamWriter w = File.AppendText(Name))
            {
               w.WriteLine("{0} ({1}): {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), Message);
                
            }
        }
    }
}
