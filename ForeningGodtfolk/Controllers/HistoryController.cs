using Microsoft.AspNetCore.Mvc;

namespace ForeningGodtfolk.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
