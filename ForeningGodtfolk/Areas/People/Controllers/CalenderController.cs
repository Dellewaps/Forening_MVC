using ForeningGodtfolk.DataAccess.Repository.IRepository;
using ForeningGodtfolk.Models;
using ForeningGodtfolk.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ForeningGodtfolk.Areas.People.Controllers
{
    [Area("People")]
    public class CalenderController : Controller
    {

        private readonly ILogger<CalenderController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CalenderController(ILogger<CalenderController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Category> calenderVM = _unitOfWork.Category.GetAll().ToList();


            List<Calender> calenderList = _unitOfWork.Calender.GetAll(includeProperties: "Category").ToList();
            ViewBag.categoryList = calenderVM;
            
            return View(calenderList);
        }

        public IActionResult Details(int Id)
        {
            List<Category> calenderVM = _unitOfWork.Category.GetAll().ToList();


            Calender calender = _unitOfWork.Calender.Get(u => u.Id == Id, includeProperties: "Category");
            ViewBag.categoryList = calenderVM;

            return View(calender);
        }
    }
}
