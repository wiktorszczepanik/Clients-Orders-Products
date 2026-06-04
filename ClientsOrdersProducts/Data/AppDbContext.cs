using ClientsOrdersProducts.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsOrdersProducts.Data;

public class AppDbContext : DbContext {
    
    protected AppDbContext() {}

    public AppDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Client> Clients { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductOrder> ProductOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>().HasData(new List<Client>() {
            new() {Id = 1, FirstName = "John", LastName = "Doe"},
            new() {Id = 2, FirstName = "Bob", LastName = "Smith"},
            new() {Id = 3, FirstName = "Alice", LastName = "Been"}
        });
        
        modelBuilder.Entity<Status>().HasData(new List<Status>() {
            new() {Id = 1, Name = "Approved"},
            new() {Id = 2, Name = "Pending"}
        });

        modelBuilder.Entity<Product>().HasData(new List<Product>() {
            new() {Id = 1, Name = "TV", Price = 3000},
            new() {Id = 2, Name = "DVD", Price = 1000},
            new() {Id = 3, Name = "PC", Price = 2000},
        });

        modelBuilder.Entity<Order>().HasData(new List<Order>() {
            new() {Id = 1, CreatedAt = new DateTime(2026, 2, 1), FulfilledAt = new DateTime(2026, 2, 2), ClientId = 1, StatusId = 1},
            new() {Id = 2, CreatedAt = new DateTime(2026, 2, 2), FulfilledAt = new DateTime(2026, 2, 3), ClientId = 2, StatusId = 2},
            new() {Id = 3, CreatedAt = new DateTime(2026, 2, 3), FulfilledAt = new DateTime(2026, 2, 4), ClientId = 1, StatusId = 1}
        });
        
        modelBuilder.Entity<ProductOrder>().HasData(new List<ProductOrder>() {
            new() {Amount = 1, OrderId = 1, ProductId = 1},
            new() {Amount = 2, OrderId = 2, ProductId = 2},
            new() {Amount = 3, OrderId = 3, ProductId = 3}
        });
    }
}