
using Clothing.DataAccess.Data;
using Clothing.DataAccess.Repository;

using Clothing.DataAccess.Repository.IRepository;
using Clothing.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace ClothingWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;     
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList= _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");// server side validation
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");// Redirects to Index action so  we see whats added
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id==null|| id==0)// not a valid id
            {
                return NotFound();
            }//if valid 
            
            //Category? categoryFromDb = _db.Categories.Find(id); now changing to
            Category? categoryFromDb= _unitOfWork.Category.Get(u=>u.Id== id);
            if(categoryFromDb==null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");// Redirects to Index action so  we see whats added
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)// not a valid id
            {
                return NotFound();
            }//if valid 

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj== null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);//remove obj from db
            _unitOfWork.Save();
            TempData["success"] = "Category Deletedted successfully";
            return RedirectToAction("Index");
        }

    }
}
