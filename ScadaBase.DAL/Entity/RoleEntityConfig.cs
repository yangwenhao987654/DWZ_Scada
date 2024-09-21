using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBase.DAL.Entity
{
    public class RoleEntityConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("tbRole");
            builder.Property(r => r.RoleName).HasMaxLength(50);
            builder.HasData(
                new Role()
                {
                    Id = 1,
                    RoleName = "操作员",
                    RoleType = 1
                },
                new Role()
                {
                    Id = 2,
                    RoleName = "管理员",
                    RoleType = 10
                }
                );
        }
    }
}
