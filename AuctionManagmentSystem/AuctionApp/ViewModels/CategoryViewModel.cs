using AuctionApp.Models;
using System.Collections.Generic;

namespace AuctionApp.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
