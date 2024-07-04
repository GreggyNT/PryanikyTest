namespace DataAccess.Models;

public class OrderItem
{
    public long ProductId { get; set; }
    
    public long OrderId { get; set; }
    
    public int Quantity { get; set; }
    
    public Order Order { get; set; }
    
    public Product Product { get; set; }
}