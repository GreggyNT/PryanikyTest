namespace Core.DTO_s.Product.Request;

public record UpdateProductRequest(  
    long Id,
    string Name,
    double Price,
    string Description);