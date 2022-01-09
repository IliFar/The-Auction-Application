using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AuctionApp.Models.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        IList<Category> categories;

        public MockCategoryRepository()
        {
            categories = new List<Category>()
            {
                new Category { Id = 1, CategoryName = "transport", Description = "Some Description"},
                new Category { Id = 2, CategoryName = "HouseHold", Description = "Some Description" },
                new Category { Id = 3, CategoryName = "Decoration", Description = "Some Description" }
            };
        }

        public void Add(Category category)
        {
            categories.Add(category);
        }

        public void Delete(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                categories.Remove(category);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            return categories.ToList();  
        }

        public Category GetCategoryById(int id)
        {
            return categories.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Category newCategory)
        {
            var category = GetCategoryById(newCategory.Id);

            category.Description = newCategory.Description;
            category.CategoryName = newCategory.CategoryName;
            
        }
    }
}
