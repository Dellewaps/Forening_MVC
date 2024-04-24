using Microsoft.AspNetCore.Mvc;

namespace ForeningGodtfolk.Controllers
{
    public class CalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
