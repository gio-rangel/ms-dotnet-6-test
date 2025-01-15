using Shared;

namespace OrdersApi.Services;

public interface IOrdersService 
{
    Task StartConsumingService();
    void AddOrder(Order order);
    List<Product> GetProducts();
    List<OrderSummary> GetOrdersSummary();
}