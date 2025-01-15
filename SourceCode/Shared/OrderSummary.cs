namespace Shared;
public class OrderSummary
{
    public OrderSummary(){}

    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int OrderedAmount { get; set; }
    public decimal TotalPrice => OrderedAmount * ProductPrice; 
}