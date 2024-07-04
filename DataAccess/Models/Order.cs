namespace DataAccess.Models;

public class Order:BaseModel
{
    public double OrderSum { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public string Status { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
}