using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.ToTable("Orders");
        builder.Property(o => o.OrderDate).IsRequired().HasColumnType("TIMESTAMPTZ").HasDefaultValueSql("NOW()");
        builder.Property(o => o.Status).IsRequired().HasMaxLength(16);
        builder.Property(o => o.OrderSum).IsRequired();
        
        builder.HasMany(o => o.OrderItems).WithOne(oi => oi.Order).HasForeignKey(oi => oi.OrderId).OnDelete(DeleteBehavior.Cascade);

        builder.HasData
        (
            new Order
            {
                Id = 1, OrderDate = new DateTime(2024, 6, 30).ToUniversalTime(), OrderSum = 1000, Status ="Завершен"
            }
        );
    }
}