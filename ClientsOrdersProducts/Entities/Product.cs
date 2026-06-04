using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientsOrdersProducts.Entities;

public class Product {

    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "numeric(10, 2)")]
    public decimal Price { get; set; }

    public ICollection<ProductOrder> ProductOrders { get; set; } = [];

}