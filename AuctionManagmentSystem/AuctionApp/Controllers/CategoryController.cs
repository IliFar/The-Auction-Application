using AuctionApp.Models;
using AuctionApp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuctionApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = categoryRepository.GetAll();

            return View(categories);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = categoryRepository.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                categoryRepository.Add(category);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = categoryRepository.GetAll();
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = categoryRepository.GetAll();
            Category category = categoryRepository.GetCategoryById(id);

            return View("Create", category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                categoryRepository.Update(category);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = categoryRepository.GetAll();
            return View("Create", category);
        }

        public IActionResult Delete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
