namespace Core.DTO_s.Product.Response;

public record ProductResponse(
    long Id,
    string Name,
    double Price,
    string Description);