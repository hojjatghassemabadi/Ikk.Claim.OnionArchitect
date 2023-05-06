using Ikk.Claims.Domain.Enities.Claems;
using Ikk.Claims.Domain.Enities.Parts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.Parts
{
    public class PartMapping : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status);
            builder.Property(x => x.PartName);
            builder.Property(x => x.PartNumber);
            builder.HasMany(x => x.ClaemInParts).WithOne(x => x.Part).HasForeignKey(x => x.PartId);
        }
    }
}
