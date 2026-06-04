using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientsOrdersProducts.Entities;

public class Order {

    [Key]
    public int Id { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? FulfilledAt { get; set; }
    
    public int ClientId { get; set; }
    public int StatusId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
    public ICollection<ProductOrder> ProductOrders { get; set; } = [];

}