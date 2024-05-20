using Microsoft.AspNetCore.Mvc;

namespace ForeningGodtfolk.Areas.People.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
