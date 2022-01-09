using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AuctionApp.Models.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext appDbContext;

        public InventoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(Inventory inventory)
        {
            appDbContext.Inventories.Add(inventory);
            appDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var delete = GetInventoryById(id);
            if (delete != null)
            {
                appDbContext.Inventories.Remove(delete);
                appDbContext.SaveChanges();
            }
        }

        public IEnumerable<Inventory> GetAll()
        {
            return appDbContext.Inventories.Include(c => c.Category).ToList();
        }

        public Inventory GetInventoryById(string id)
        {
            return appDbContext.Inventories.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Inventory inventory)
        {

            var update = appDbContext.Inventories.Update(inventory);
            appDbContext.SaveChanges();

            //return appDbContext.Products.Include(c => c.Category).Where(p => p.Id == id).FirstOrDefault();

        }

        
    }
}
