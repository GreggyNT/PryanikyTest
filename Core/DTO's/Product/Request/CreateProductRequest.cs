namespace Core.DTO_s.Product.Request;

public record CreateProductRequest(
    string Name,
    double Price,
    string Description);