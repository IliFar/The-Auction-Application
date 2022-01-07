using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AuctionApp.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(Category category)
        {
            var add = appDbContext.Categories.Add(category);
            appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var delete = GetCategoryById(id);
            if (delete != null)
            {
                appDbContext.Categories.Remove(delete);
                appDbContext.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return appDbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return appDbContext.Categories.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Category category)
        {
            var update = appDbContext.Categories.Update(category);
            appDbContext.SaveChanges();

            //return appDbContext.Products.Include(c => c.Category).Where(p => p.Id == id).FirstOrDefault();

        }
    }
}
