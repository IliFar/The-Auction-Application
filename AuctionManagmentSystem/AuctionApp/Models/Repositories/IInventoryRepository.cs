using System.Collections;
using System.Collections.Generic;

namespace AuctionApp.Models.Repositories
{
    public interface IInventoryRepository
    {
        IEnumerable<Inventory> GetAll();
        Inventory GetInventoryById(string id);
        void Add(Inventory inventory);
        void Update (Inventory inventory);
        void Delete(string id);
    }
}
