![diagram.png](assets/diagram.png)

#### 1. New Solution
- git
- SDK 9.0
- Web API

#### 2. appsettings.json
note: change Database name in connection string
```json
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost,1433;Database=Orders;User Id=sa;Password=EducationalPurposesPassword1!;TrustServerCertificate=True;Encrypt=False"
  }
```

#### 3. NuGet packages:
- [EF] `Microsoft.EntityFrameworkCore.Design` 9.0.16
- [EF] `Microsoft.EntityFrameworkCore.SqlServer` 9.0.16

#### 4. **Data/**AppDbContext.cs 

Db context init example
```C#
public class AppDbContext : DbContext {
    
    protected AppDbContext() {}

    public AppDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    ...
    
}
```

#### 5. **Entities/** SomeEntity.cs

##### Model fields example
```C#
private int Id { get; set; }
private string FirstName { get; set; } = string.Empty;
public Order Order { get; set; }
public ICollection<Order> Orders { get; set; } = [];
```

##### Adnotations
- Table name -> [Table("XYZ")]
```C#
[Table("Product_Order")]
public class ProductOrder {...}
```

- PK -> [Key]
```C#
[Key]
public int Id { get; set; }
```

- PK * 2 -> [PrimaryKey(nameof(ProductId), nameof(OrderId))]
```C#
[PrimaryKey(nameof(ProductId), nameof(OrderId))]
public class ProductOrder {...}
```

- FK -> [ForeignKey(nameof(ClientId))]
```C#
public int ProductId { get; set; }

[ForeignKey(nameof(ProductId))]
public Product Product { get; set; }
```

- nvarchar(50) -> [MaxLength(50)]
```C#
[MaxLength(50)]
private string FirstName { get; set; } = string.Empty;
```

- numeric(10, 2) -> [Column(TypeName = "decimal(10, 2)")]
```C#
[Column(TypeName = "numeric(10, 2)")]
public decimal Price { get; set; }
```

- datetime N
```
[Column(TypeName = "datetime")]
public DateTime? FulfilledAt { get; set; }
```

#### 6. Use Db context in Program.cs

Example for SQL server
```C#
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
```

#### 7. Generate instruction for entities in **Migrations/** directory
`(if dotnet is missing = "$ dotnet tool install --global dotnet-ef")`

Init without seed data
```bash
$ cd ProjectName/ProjectName/
$ dotnet ef migrations add Init
$ dotnet ef database update
```

Backup commands
```
Done. To undo this action, use 'ef migrations remove'
```

#### 8. Add seed data

App db context update
```C#
protected override void OnModelCreating(ModelBuilder modelBuilder) {
    // base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Client>().HasData(new List<Client>() {
        new() {Id = 1, FirstName = "John", LastName = "Doe"},
        new() {Id = 2, FirstName = "Bob", LastName = "Smith"},
        new() {Id = 3, FirstName = "Alice", LastName = "Been"}
    });
    ...
}
```

#### 9. Generate seed data in **Migrations/**

Seed data
```
$ cd ProjectName/ProjectName/
$ dotnet ef migrations add Seed
$ dotnet ef database update
```

#### 10. DTOs


#### 11. Setup IDbService + DbService in **Services/**


#### 12. **Conrollers/** creation

```C#
[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase {...}
```

