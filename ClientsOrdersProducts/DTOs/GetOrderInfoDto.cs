namespace ClientsOrdersProducts.DTOs;

public class GetOrderInfoDto {
    
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string Status { get; set; } = null!;
    public GetClientDto Client { get; set; } = null!;
    public List<GetProductDto> Products { get; set; } = null!;

}

public class GetClientDto {

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
}

public class GetProductDto {

    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Amount { get; set; }
    
}

// GET.json
// {
//     "id": 2,
//     "createdAt": "2025-05-02T00:00:00",
//     "fulfilledAt": null,
//     "status": "Ongoing",
//     "client": {
//         "firstName": "John",
//         "lastName": "Doe"
//     },
//     "products": [
//         {
//             "name": "Bananas",
//             "price": 5.55,
//             "amount": 2
//         },
//         {
//         "name": "Orange",
//         "price": 12.37,
//         "amount": 1
//         }
//     ]
// }