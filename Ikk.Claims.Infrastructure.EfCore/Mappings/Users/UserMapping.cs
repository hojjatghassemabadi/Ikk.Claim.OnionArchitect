using Ikk.Claims.Domain.Enities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.Users
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Famil);
            builder.Property(x => x.UserName);
            builder.Property(x => x.DateCreated);
            builder.Property(x => x.Status);
            
            builder.HasMany(x => x.UserInRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        }
    }
}
