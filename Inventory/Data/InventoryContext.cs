using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext (DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Location { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Inventory.db");

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    modelbuilder.Entity<Location>().ToTable("Location");
        //    modelbuilder.Entity<Category>().ToTable("Category");
        //    modelbuilder.Entity<Item>().ToTable("Item");
        //}
    }
}
