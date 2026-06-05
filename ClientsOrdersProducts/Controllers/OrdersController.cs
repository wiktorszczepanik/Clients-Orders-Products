using ClientsOrdersProducts.Exceptions;
using ClientsOrdersProducts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClientsOrdersProducts.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase {

    private readonly IDbService _dbService;

    public OrdersController(IDbService dbService) {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) {
        try {
            var order = await _dbService.GetOrderById(id);
            return Ok(order);
        }
        catch (NotFoundException ignore) {
            return NotFound();
        }
    }
    
}