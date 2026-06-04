using System.ComponentModel.DataAnnotations;

namespace ClientsOrdersProducts.Entities;

public class Client {

    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = [];

}