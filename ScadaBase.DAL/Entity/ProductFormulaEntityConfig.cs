using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScadaBase.DAL.Entity
{
    public class ProductFormulaEntityConfig : IEntityTypeConfiguration<ProductFormulaEntity>
    {
        public void Configure(EntityTypeBuilder<ProductFormulaEntity> builder)
        {
            builder.ToTable("tbProductFormula");
            builder.Property(r => r.ProductPLCNo).HasDefaultValue(0);
            builder.Property(r => r.ProductCode).HasMaxLength(50).IsRequired(false);
            builder.Property(r => r.ProductName).HasMaxLength(50).IsRequired(false);
            builder.Property(r => r.ProductType).HasMaxLength(50).IsRequired(false);
        }
    }
}
