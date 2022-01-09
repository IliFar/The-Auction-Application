using System.Collections.Generic;

namespace AuctionApp.Models.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetCategoryById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}