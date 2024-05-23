using ForeningGodtfolk.DataAccess.Repository.IRepository;
using ForeningGodtfolk.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForeningGodtfolk.Areas.People.Controllers
{
    [Area("People")]
    public class HistoryController : Controller
    {
        private readonly ILogger<HistoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HistoryController(ILogger<HistoryController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Category> calenderVM = _unitOfWork.Category.GetAll().ToList();


            List<History> historyList = _unitOfWork.History.GetAll(includeProperties: "Category").ToList();
            ViewBag.categoryList = calenderVM;

            return View(historyList);
        }

        public IActionResult Details(int Id)
        {
            List<Category> calenderVM = _unitOfWork.Category.GetAll().ToList();


            History history = _unitOfWork.History.Get(u => u.Id == Id, includeProperties: "Category");
            ViewBag.categoryList = calenderVM;

            return View(history);
        }
    }
}
