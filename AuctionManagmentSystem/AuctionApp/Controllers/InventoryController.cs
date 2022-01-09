using AuctionApp.Models;
using AuctionApp.Models.Repositories;
using AuctionApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Controllers
{
    
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly ICategoryRepository categoryRepository;

        public InventoryController(IInventoryRepository inventoryRepository, ICategoryRepository categoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Inventory> inventorys = inventoryRepository.GetAll();

            return View(inventorys);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = categoryRepository.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            ModelState.Remove("Category");
            if (ModelState.IsValid)
            {
                if (inventory.Sold)
                {
                    inventoryRepository.Add(inventory);
                    return RedirectToAction("Index");
                }
                else
                {
                    inventoryRepository.Add(inventory);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Categories = categoryRepository.GetAll();
            return View();
        }
        public IActionResult Edit(string id)
        {
            ViewBag.Categories = categoryRepository.GetAll();
            Inventory inventory = inventoryRepository.GetInventoryById(id);

            return View("Create", inventory);
        }
        [HttpPost]
        public IActionResult Edit(Inventory inventory)
        {
            ModelState.Remove("Category");

            if (ModelState.IsValid)
            {
                if(inventory.Sold)
                {
                    inventoryRepository.Update(inventory);
                    return RedirectToAction("Index");
                }
                else
                {
                    inventoryRepository.Update(inventory);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Categories = categoryRepository.GetAll();
            return View("Create", inventory);
        }

        public IActionResult Delete(string id)
        {
            inventoryRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
