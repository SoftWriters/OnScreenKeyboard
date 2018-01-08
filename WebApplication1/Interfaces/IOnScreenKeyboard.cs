using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IOnScreenKeyboard
    {
        KeyboardViewModel ProcessInputFile(HttpPostedFileBase file);
    }
}
