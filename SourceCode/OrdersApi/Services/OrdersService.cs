using System.Text.Json;
using Confluent.Kafka;
using Shared;

namespace OrdersApi.Services;

public class OrdersService : IOrdersService
{
    public OrdersService(IConsumer<Null, string> consumer)
    {
        _consumer = consumer;
        Products = new List<Product>();
        Orders = new List<Order>();
        OrdersSummary = new List<OrderSummary>();
    }

    private readonly IConsumer<Null, string> _consumer; 
    private const string _addProducttopic = "add-product-topic";
    private const string _deleteProducttopic = "delete-product-topic";
    private List<Product> Products { get; set; }
    private List<Order> Orders { get; set; }
    private List<OrderSummary> OrdersSummary { get; set; }

    public void AddOrder(Order order) => Orders.Add(order);

    public List<OrderSummary> GetOrdersSummary() 
    {
        var OrderSummary = new List<OrderSummary>();

        foreach (var order in Orders)
        {
            OrderSummary.Add(new OrderSummary(){
                OrderId = order.Id,
                ProductId = order.ProductId,
                ProductName = Products.FirstOrDefault(p => p.Id == order.ProductId)!.Name,
                ProductPrice = Products.FirstOrDefault(p => p.Id == order.ProductId)!.Price,
                OrderedAmount = order.Amount
            });
        }

        return OrderSummary;
    }

    public List<Product> GetProducts() => Products; 

    public async Task StartConsumingService()
    {
        await Task.Delay(10);
        _consumer.Subscribe(new[] {_addProducttopic, _deleteProducttopic});
        while(true)
        {
            var response = _consumer.Consume();

            if(!string.IsNullOrEmpty(response.Message.Value))
            {
                // check if topic == add product topic
                if(response.Topic == _addProducttopic)
                {
                    var product = JsonSerializer.Deserialize<Product>(response.Message.Value);

                    Products.Add(product!);
                }
                else
                {
                    Products.Remove(Products.FirstOrDefault(p => p.Id == int.Parse(response.Message.Value))!);
                }

                ConsoleProduct();
            }
        }
    }

    private void ConsoleProduct()
    {
        Console.Clear();

        foreach(var item in Products) 
        {
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Price: {item.Price}");
        }
    }
}