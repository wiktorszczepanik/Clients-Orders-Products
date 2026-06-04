using System.ComponentModel.DataAnnotations;

namespace ClientsOrdersProducts.Entities;

public class Status {

    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = [];

}