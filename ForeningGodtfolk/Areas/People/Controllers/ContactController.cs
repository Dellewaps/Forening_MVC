using Microsoft.AspNetCore.Mvc;

namespace ForeningGodtfolk.Areas.People.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
