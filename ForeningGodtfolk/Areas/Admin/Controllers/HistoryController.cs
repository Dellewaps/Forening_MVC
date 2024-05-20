using ForeningGodtfolk.DataAccess.Repository.IRepository;
using ForeningGodtfolk.Models;
using ForeningGodtfolk.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForeningGodtfolk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HistoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HistoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<History> objHistoryList = _unitOfWork.History.GetAll(includeProperties: "Category").ToList();
            return View(objHistoryList);
        }

        public IActionResult Upsert(int? id)
        {
            HistoryVM historyVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().
                Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                History = new History()
            };
            if(id == null || id == 0)
            {
                return View(historyVM);
            }
            else
            {
                historyVM.History = _unitOfWork.History.Get(u => u.Id == id);
                return View(historyVM);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(HistoryVM historyVM, IFormFile? file)
        {
            //if (obj.Name == obj.DisplayOrder.ToString() 
            //{
            //    ModelState.AddModelError("name", "The Display Order cannot exacly match the Name.");
            //}
            //if (obj.Name != null && obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError("", "Test is an invalid value.");
            //}
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null) 
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string historyPath = Path.Combine(wwwRootPath, @"images\history");

                    if(!string.IsNullOrEmpty(historyVM.History.ImageUrl)) 
                    {
                        //delete old image
                        var oldImagePath = Path.Combine(wwwRootPath, historyVM.History.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using ( var fileSream = new FileStream(Path.Combine(historyPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileSream);
                    }

                    historyVM.History.ImageUrl = @"\images\history\" + fileName;
                }

                if(historyVM.History.Id == 0)
                {
                    _unitOfWork.History.Add(historyVM.History);
                }
                else
                {
                    _unitOfWork.History.Update(historyVM.History);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "Dit historie opslag oprettet";
                return RedirectToAction("Index");
            }
            else
            {
                historyVM.CategoryList = _unitOfWork.Category.GetAll().
                Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(historyVM);
            }
            
        }


        

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            History? historyFromDb = _unitOfWork.History.Get(u => u.Id == id);
            if (historyFromDb == null)
            {
                return NotFound();
            }
            return View(historyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            History? obj = _unitOfWork.History.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.History.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Historie opslag er nu slettet";
            return RedirectToAction("Index");

        }
    }
}
