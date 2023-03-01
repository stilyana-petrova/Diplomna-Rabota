using ArtShop.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ArtShop.Models.Product;
using ArtShop.Models.Order;

namespace ArtShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ArtShop.Models.Product.ProductCreateVM> ProductCreateVM { get; set; }
        public DbSet<ArtShop.Models.Product.ProductIndexVM> ProductIndexVM { get; set; }
        public DbSet<ArtShop.Models.Product.ProductEditVM> ProductEditVM { get; set; }
        public DbSet<ArtShop.Models.Product.ProductDetailsVM> ProductDetailsVM { get; set; }
        public DbSet<ArtShop.Models.Product.ProductDeleteVM> ProductDeleteVM { get; set; }
        public DbSet<ArtShop.Models.Order.OrderConfirmVM> OrderConfirmVM { get; set; }
        public DbSet<ArtShop.Models.Order.OrderIndexVM> OrderIndexVM { get; set; }
    }
}
