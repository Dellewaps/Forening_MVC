using Microsoft.AspNetCore.Mvc;

namespace ForeningGodtfolk.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
