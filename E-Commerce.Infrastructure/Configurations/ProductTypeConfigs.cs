using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Configurations
{
    public class ProductTypeConfigs : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
