using ClientsOrdersProducts.Data;
using ClientsOrdersProducts.DTOs;
using ClientsOrdersProducts.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ClientsOrdersProducts.Services;

public class DbService : IDbService {

    private readonly AppDbContext _context;

    public DbService(AppDbContext context) {
        _context = context;
    }

    public async Task<GetOrderInfoDto> GetOrderById(int id) {
        var order = await _context.Orders
            .Select(order => new GetOrderInfoDto() {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                FulfilledAt = order.FulfilledAt,
                Client = new GetClientDto() {
                    FirstName = order.Client.FirstName,
                    LastName = order.Client.LastName,
                },
                Products = order.ProductOrders.Select(order => new GetProductDto() {
                    Name = order.Product.Name,
                    Price = order.Product.Price,
                    Amount = order.Amount
                }).ToList()
            })
            .FirstOrDefaultAsync(order => order.Id == id);
        if (order is null) throw new NotFoundException();
        return order;
    }
    
}