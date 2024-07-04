using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.ToTable("Products");
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        
        builder.HasIndex(p => p.Name).IsUnique();
        builder.HasIndex(p => p.Price);


        builder.HasMany(p => p.OrderItems).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);

        /*
        builder.HasData
        (
          new Product
          {
            Id = 1, CategoryId = 1, Name = "", Description = "", ImageUrls = ["", ""], Price = 0.00, Rating = 0.00, YearProduced = 2024 
          },
          new Product
          {
            Id = 2,
            CategoryId = 1,
            Name = "",
            Description = "",
            ImageUrls = ["", ""],
            Price = 0.00,
            Rating = 0.00,
            YearProduced = 2024
          }
        );*/

  }
}