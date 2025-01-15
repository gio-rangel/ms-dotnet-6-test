using System.Text.Json;
using Confluent.Kafka;
using Shared;

namespace ProductsApi.Services;

public class ProductsService : IProductsService
{
    public ProductsService(IProducer<Null, string> producer)
    {
        _producer = producer;
    }

    private readonly IProducer<Null, string> _producer; 
    private readonly List<Product> Products = new() { };
    public async Task AddProduct(Product product)
    {
        try {
            Products.Add(product);

            var results = await _producer.ProduceAsync(
                "add-product-topic", 
                new Message<Null, string> { Value = JsonSerializer.Serialize(product) }
            ); 

            // The broker return Persisted state when the message was recieved without inconviniences
            if(results.Status != PersistenceStatus.Persisted)
            {
                // If there was a issue we have to rollback 
                var lastProduct = Products.Last();
                // Remove the last product
                Products.Remove(lastProduct);
            }
        } catch (Exception ex)
        {
            Console.Error.WriteLine($"Error adding product: {ex.Message}");
            throw; 
        }
    }

    public async Task DeleteProduct(int id)
    {
        Products.Remove(Products.FirstOrDefault(p => p.Id == id)!);

        await _producer.ProduceAsync(
            "delete-product-topic", 
            new Message<Null, string> { Value = id.ToString() }
        ); 
    }
} 