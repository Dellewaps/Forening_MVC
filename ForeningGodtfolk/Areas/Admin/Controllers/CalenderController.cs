using ForeningGodtfolk.DataAccess.Repository.IRepository;
using ForeningGodtfolk.Models;
using ForeningGodtfolk.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;

namespace ForeningGodtfolk.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CalenderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CalenderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Calender> objCalenderList = _unitOfWork.Calender.GetAll(includeProperties:"Category").ToList();
            
            return View(objCalenderList);
        }

        public IActionResult Upsert(int? id)
        {
            CalenderVM calenderVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().
                Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Calender = new Calender()
            };
            if(id == null || id == 0)
            {
                //Create
                return View(calenderVM);
            }
            else
            {
                //update
                calenderVM.Calender = _unitOfWork.Calender.Get(u => u.Id == id);
                return View(calenderVM);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(CalenderVM calenderVM)
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
                _unitOfWork.Calender.Add(calenderVM.Calender);
                _unitOfWork.Save();
                TempData["success"] = "Dit kalender opslag oprettet";
                return RedirectToAction("Index");
            }
            else
            {

                calenderVM.CategoryList = _unitOfWork.Category.GetAll().
                Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(calenderVM);
            }
            
        }


        

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Calender? calenderFromDb = _unitOfWork.Calender.Get(u => u.Id == id);
            if (calenderFromDb == null)
            {
                return NotFound();
            }
            return View(calenderFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Calender? obj = _unitOfWork.Calender.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Calender.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kalender opslag er nu slettet";
            return RedirectToAction("Index");

        }
    }
}
