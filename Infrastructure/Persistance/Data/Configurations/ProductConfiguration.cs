using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.Brand)
                .WithMany(B => B.Products)
                .HasForeignKey(p => p.BrandId);
            builder.HasOne(P => P.Type)
                .WithMany(T => T.Products)
                .HasForeignKey(p => p.TypeId);
            builder.Property(P => P.Price)
                .HasColumnType("decimal(10,3)");
        }
    }
}
