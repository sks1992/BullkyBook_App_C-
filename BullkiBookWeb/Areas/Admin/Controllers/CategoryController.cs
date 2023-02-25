using BullkyBook.DataAccess.Repository.IRepository;
using BullkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BullkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var  categoryFromDb = _db.Category.Find(id);
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            //var categoryFromDbSingle = _db.Category.SingleOrDefault(x => x.Id == id);

            if (categoryFromDbFirst == null)
            {

                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Category.Find(id);
            var categoryFromDbFirst = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            //var categoryFromDbSingle = _db.Category.SingleOrDefault(x => x.Id == id);

            if (categoryFromDbFirst == null)
            {

                return NotFound();
            }
            return View(categoryFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Removed Successfully";
            return RedirectToAction("Index");
        }
    }
}
