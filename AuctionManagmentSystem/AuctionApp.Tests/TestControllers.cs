using AuctionApp.Controllers;
using AuctionApp.Models;
using AuctionApp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AuctionApp.Tests
{
    public class TestControllers
    {
        private readonly Mock<IInventoryRepository> inventoryRepository;
        private readonly Mock<ICategoryRepository> categoryRepository;
        private readonly InventoryController inventoryController;

        public TestControllers()
        {
            inventoryRepository = new Mock<IInventoryRepository>();
            categoryRepository = new Mock<ICategoryRepository>();
            inventoryController = new InventoryController(inventoryRepository.Object, categoryRepository.Object);
        }

        [Fact]
        public void Index_Test_Should_Return_ViewForIndex()
        {
            var result = inventoryController.Index();

            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfInventories()
        {
            inventoryRepository.Setup(repo => repo.GetAll())
                .Returns(new List<Inventory>() { new Inventory(), new Inventory() });

            var result = inventoryController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var inventories = Assert.IsType<List<Inventory>>(viewResult.Model);
            Assert.Equal(2, inventories.Count);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = inventoryController.Create();

            Assert.IsType<ViewResult>(result);
        }
    }
}
