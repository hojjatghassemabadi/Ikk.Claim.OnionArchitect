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
    public class ClaimInPartMapping: IEntityTypeConfiguration<ClaimInPart>
    {

        public void Configure(EntityTypeBuilder<ClaimInPart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.claem).WithMany(x => x.ClaemInParts).HasForeignKey(x => x.ClaemId);
            builder.HasOne(x => x.Part).WithMany(x => x.ClaemInParts).HasForeignKey(x => x.PartId);
        }
    }
}
