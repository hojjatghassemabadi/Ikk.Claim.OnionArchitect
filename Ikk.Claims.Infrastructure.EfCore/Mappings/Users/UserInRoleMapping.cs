using Ikk.Claims.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.Users
{
    public class UserInRoleMapping : IEntityTypeConfiguration<UserInRole>
    {
        public void Configure(EntityTypeBuilder<UserInRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.UserInRoles).HasForeignKey(x=>x.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.UserInRoles).HasForeignKey(x=>x.RoleId);

        }
    }
}
