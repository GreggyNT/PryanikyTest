namespace Core.DTO.Order.Requests;

public record CreateOrderRequest(
    double OrderSum,
    DateTime OrderDate,
    int Status
);