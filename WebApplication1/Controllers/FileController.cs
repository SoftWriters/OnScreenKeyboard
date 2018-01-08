using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return Redirect("Index");
        }

        public ActionResult UpLoadFile(HttpPostedFileBase file)
        {
            IOnScreenKeyboard service = new OnScreenKeyboardService();
            KeyboardViewModel vm = service.ProcessInputFile(file);
            return PartialView("_KeyboardResult", vm);
        }
    }
}