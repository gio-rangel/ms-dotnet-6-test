using Shared;

namespace ProductsApi.Services;

public interface IProductsService 
{
    Task AddProduct (Product product);
    Task DeleteProduct (int id); 
}