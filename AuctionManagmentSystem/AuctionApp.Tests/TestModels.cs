using AuctionApp.Models;
using AuctionApp.Models.Repositories;
using System;
using System.Text.RegularExpressions;
using Xunit;

namespace AuctionApp.Tests
{
    public class TestModels
    {
        private readonly MockInventoryRepository inventoryRepository;
        private readonly MockCategoryRepository categoryRepository;
        private readonly Inventory inventory;
        public TestModels()
        {
            inventoryRepository = new MockInventoryRepository();
            categoryRepository = new MockCategoryRepository();
            inventory = new Inventory();
        }
        [Fact]
        public void Id_Regex_ReturnsTrue()
        {
            inventory.Id = "aaa111111";

            var pattern = @"[A-Za-z]{3}[0-9]{6}";
            
            Regex.IsMatch(inventory.Id, pattern);
        }
        [Fact]
        public void Test_Should_Retrun_InventoryById()
        {
            inventory.Id = "aaa111111";

            var result = inventoryRepository.GetInventoryById(inventory.Id);

            Assert.NotNull(result);
        }
        [Fact]
        public void Test_Should_Retrun_AllInventory()
        {
            var data = inventoryRepository.GetAll();

            Assert.NotEmpty(data);
        }
        [Fact]
        public void Test_Should_Check_If_Price_Is_Less_Than_Cost()
        {
            inventory.Cost = 18.55M;
            inventory.Price = 20.55M;

            Assert.True(inventory.Cost < inventory.Price);
        }
    }
}
