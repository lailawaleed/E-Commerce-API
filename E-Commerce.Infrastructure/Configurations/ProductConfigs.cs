using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Infrastructure.Configurations
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
