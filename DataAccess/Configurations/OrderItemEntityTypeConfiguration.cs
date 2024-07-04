using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => new {oi.ProductId, oi.OrderId});
        builder.ToTable("OrderItems");
        builder.Property(oi => oi.Quantity).IsRequired();
        builder.Property(oi => oi.OrderId).IsRequired();
        builder.Property(oi => oi.ProductId).IsRequired();

        builder.HasOne(oi => oi.Order).WithMany(o => o.OrderItems).HasForeignKey(oi => oi.OrderId);
        builder.HasOne(oi => oi.Product).WithMany(p => p.OrderItems).HasForeignKey(oi => oi.ProductId);

        builder.HasData
        (
            new OrderItem
            {
                
                OrderId = 1,
                ProductId = 1,
                Quantity = 10
            },
            new OrderItem
            {
                OrderId = 1,
                ProductId = 2,
                Quantity = 10
            },
            new OrderItem
            {
                OrderId = 1,
                ProductId = 1,
                Quantity = 10
            }
        );
    }
}