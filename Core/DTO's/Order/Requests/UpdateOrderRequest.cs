namespace Core.DTO.Order.Requests;

public record UpdateOrderRequest(
    long Id,
    double OrderSum,
    DateTime OrderDate,
    int Status
);