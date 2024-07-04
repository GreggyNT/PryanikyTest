namespace Core.DTO.Order.Responses;

public record OrderResponse(
    long Id,
    double OrderSum,
    DateTime OrderDate,
    string Status
);