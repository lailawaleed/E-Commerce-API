using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Configurations
{
    public class ProductConfigs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.Property(product => product.Name)
                .IsRequired()
                .HasMaxLength(100);

            product.Property(product => product.Price)
                .HasColumnType("decimal(18,2)");

            // Relationships
            product.HasOne(p => p.Brand)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BrandId);

            product.HasOne(p => p.Type)
                   .WithMany(t => t.Products)
                   .HasForeignKey(p => p.TypeId);
        }
    }
}
