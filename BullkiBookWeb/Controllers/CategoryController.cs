﻿using BullkyBookWeb.Data;
using BullkyBookWeb.Models;
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
    }
}
    