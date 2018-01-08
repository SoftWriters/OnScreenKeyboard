using System.Web;
using System.Web.Mvc;

using OnScreenKeyboard.Classes;

namespace OnScreenKeyboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase InputFile)
        {
            Keyboard thisKeyboard = new Keyboard(InputFile);

            ViewBag.Output = thisKeyboard.KeyboardPathOutput;

            return View();
        }
    }
}