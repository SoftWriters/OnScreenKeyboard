using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    public interface IKeyboard
    {

        string Search(string searchTerm);
        IEnumerable<string> Navigate(char target);
        
    }  // end interface
}  // end namespace
