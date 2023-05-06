using Ikk.Claims.Domain.Enities.Claems;
using Ikk.Claims.Domain.Enities.Claims;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.Claems
{
    public class ClaemMapping : IEntityTypeConfiguration<Claem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Claem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Desc);
            builder.Property(x => x.ClaemNumber);
            builder.Property(x => x.Company);
            builder.Property(x => x.Country);
            builder.HasMany(x => x.Pics).WithOne(x => x.Claem).HasForeignKey(x => x.ClaemId);
            
            builder.HasMany(x => x.claemInCkdqrs).WithOne(x => x.Claem).HasForeignKey(x => x.ClaemId);
            builder.HasMany(x => x.ClaemInParts).WithOne(x => x.claem).HasForeignKey(x => x.ClaemId);
        }
    }
}
