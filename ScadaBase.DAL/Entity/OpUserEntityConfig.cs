using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ScadaBase.DAL.Entity
{
    public class OpUserEntityConfig : IEntityTypeConfiguration<OpUser>
    {
        public void Configure(EntityTypeBuilder<OpUser> builder)
        {
            builder.ToTable("tbOpUser");
            builder.Property(r => r.UserName).HasMaxLength(50);
            builder.Property(r => r.UserCode).HasMaxLength(50).IsRequired(true);
            builder.Property(r => r.Password).HasMaxLength(50).IsRequired(false);
        }
    }
}
