
using Clothing.DataAccess.Data;
using Clothing.DataAccess.Repository;

using Clothing.DataAccess.Repository.IRepository;
using Clothing.Models;
using Clothing.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Channels;

namespace ClothingWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;     
        }
        public IActionResult Index()
        {
            List<Product> objProductList= _unitOfWork.Product.GetAll().ToList();
            
            return View(objProductList);
        }
        public IActionResult Upsert(int? productid)
        {
            
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
               
                Product = new Product()
            };
            if (productid == null || productid == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfWork.Product.Get(u =>u.ProductId==productid);

                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
           
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created successfully";
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

            Product? productFromDb = _unitOfWork.Product.Get(u => u.ProductId == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.ProductId == id);
            if (obj== null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);//remove obj from db
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
