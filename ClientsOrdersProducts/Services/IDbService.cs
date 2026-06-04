using ClientsOrdersProducts.DTOs;

namespace ClientsOrdersProducts.Services;

public interface IDbService {

    Task<IEnumerable<GetOrderDto>> GetUserById(int id);
    
}