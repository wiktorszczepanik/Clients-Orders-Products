using ClientsOrdersProducts.DTOs;

namespace ClientsOrdersProducts.Services;

public interface IDbService {

    Task<GetOrderInfoDto> GetOrderById(int id);
    
}