using BullkyBook.DataAccess;
using BullkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BullkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
                _db= db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Category;
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
            if(category.Name == category.DisplayOrder.ToString()) {
                ModelState.AddModelError("CustomError", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Add(category);
                _db.SaveChanges();
                TempData["success"]="Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //Get
        public IActionResult Edit(int? id)  
        {
            if(id == null) {
                return NotFound();
            }
            var  categoryFromDb = _db.Category.Find(id);
            //var categoryFromDbFirst = _db.Category.FirstOrDefault(x => x.Id == id);
            //var categoryFromDbSingle = _db.Category.SingleOrDefault(x => x.Id == id);

            if(categoryFromDb == null)
            {

                return NotFound();
            }
            return View(categoryFromDb);
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
                _db.Category.Update(category);
                _db.SaveChanges();
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
            var categoryFromDb = _db.Category.Find(id);
            //var categoryFromDbFirst = _db.Category.FirstOrDefault(x => x.Id == id);
            //var categoryFromDbSingle = _db.Category.SingleOrDefault(x => x.Id == id);

            if (categoryFromDb == null)
            {

                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var category = _db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
           _db.Category.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category Removed Successfully";
            return RedirectToAction("Index");
        }   
    }
}
        