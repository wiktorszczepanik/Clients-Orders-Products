namespace ClientsOrdersProducts.DTOs;

public class GetOrderDto {
    
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    
}