using System.Collections.Generic;
using System.Linq;

namespace AuctionApp.Models.Repositories
{
    public class MockInventoryRepository : IInventoryRepository
    {
        IList<Inventory> inventories;

        public MockInventoryRepository()
        {
            inventories = new List<Inventory>()
            {
                new Inventory { Id = "aaa111111", InventoryName = "First", Description = "Test Description", CategoryId = 1, Cost = 15.88M, Price = 16.88M, Image = "", DecadeMade = "2020", Sold = true, FinalPrice = 20.15M},
                new Inventory { Id = "aaa111112", InventoryName = "Second", Description = "Test Description", CategoryId = 2, Cost = 15.88M, Price = 16.88M, Image = "", DecadeMade = "2020", Sold = false, FinalPrice = 20.15M},
                new Inventory { Id = "aaa111113", InventoryName = "Third", Description = "Test Description", CategoryId = 3, Cost = 15.88M, Price = 16.88M, Image = "", DecadeMade = "2020", Sold = true, FinalPrice = 20.15M},
                new Inventory { Id = "aaa111114", InventoryName = "Fourth", Description = "Test Description", CategoryId = 4, Cost = 15.88M, Price = 16.88M, Image = "", DecadeMade = "2020", Sold = false, FinalPrice = 20.15M}
            };
        }

        public void Add(Inventory inventory)
        {
            inventories.Add(inventory);
        }

        public void Delete(string id)
        {
            var category = GetInventoryById(id);
            if (category != null)
            {
                inventories.Remove(category);
            }
        }

        public IEnumerable<Inventory> GetAll()
        {
            return inventories.ToList();
        }

        public Inventory GetInventoryById(string id)
        {
            return inventories.FirstOrDefault(i => i.Id == id);
        }

        public void Update(Inventory newInventory)
        {
            var inventory = GetInventoryById(newInventory.Id);

            inventory.InventoryName = newInventory.InventoryName;
            inventory.Image = newInventory.Image;
            inventory.Description = newInventory.Description;
            inventory.CategoryId = newInventory.CategoryId;
            inventory.Price = newInventory.Price;
            inventory.Cost = newInventory.Cost;
            inventory.Id = newInventory.Id;
            inventory.DecadeMade = newInventory.DecadeMade;
            inventory.Sold = newInventory.Sold;
            inventory.FinalPrice = newInventory.FinalPrice;
        }
    }
}
