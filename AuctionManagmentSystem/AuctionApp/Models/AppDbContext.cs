using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
        public DbSet<IdentityUser> IdentityUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, CategoryName = "transport", Description = "Some Description"},
                new Category { Id = 2, CategoryName = "HouseHold", Description = "Some Description" },
                new Category { Id = 3, CategoryName = "Decoration", Description = "Some Description" }
                );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole 
                { 
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Admin"
                },
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                    Name = "User"
                });

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "Admin22!"),
                EmailConfirmed = true,
            },
            new IdentityUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb5", // primary key
                Email = "user@user.com",
                NormalizedEmail = "USER@USER.COM",
                UserName = "user@user.com",
                NormalizedUserName = "USER@USER.COM",
                PasswordHash = hasher.HashPassword(null, "User22!"),
                EmailConfirmed = true,
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            });
        }
    }
}
