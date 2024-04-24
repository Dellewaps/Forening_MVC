using Microsoft.AspNetCore.Mvc;

namespace ForeningGodtfolk.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
