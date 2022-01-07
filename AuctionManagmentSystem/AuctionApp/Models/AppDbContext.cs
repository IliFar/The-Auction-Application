using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, CategoryName = "Tables", Description = "All The Tables"},
                new Category { Id = 2, CategoryName = "Chairs", Description = "All The Tables"},
                new Category { Id = 3, CategoryName = "Knives", Description = "All The Tables"},
                new Category { Id = 4, CategoryName = "Lamps", Description = "All The Tables"}
                );

            //modelBuilder.Entity<Product>()
            //    .HasData(
            //    new Product { Id = 1, ProductName = "First", Description = "Test Description", CategoryId = 1, Cost = 15.88M, Price = 16.88M, Image = "" },
            //    new Product { Id = 2, ProductName = "Second", Description = "All The Tables", CategoryId = 2, Cost = 15.88M, Price = 16.88M, Image = "" },
            //    new Product { Id = 3, ProductName = "Third", Description = "All The Tables", CategoryId = 3, Cost = 15.88M, Price = 16.88M, Image = "" },
            //    new Product { Id = 4, ProductName = "Fourth", Description = "All The Tables", CategoryId = 4, Cost = 15.88M, Price = 16.88M, Image = "" }
            //    );
        }
    }
}
