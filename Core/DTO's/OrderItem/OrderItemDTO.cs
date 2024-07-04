namespace Core.DTO.OrderItem.Requests;

public record OrderItemDTO(
    long ProductId,
    long OrderId,
    int Quantity
);