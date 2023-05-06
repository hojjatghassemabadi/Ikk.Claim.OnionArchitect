using Ikk.Claims.Domain.Enities.Claems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.Claems
{
    public class ClaemInCkdqrMapping: IEntityTypeConfiguration<ClaemInCkdqr>
    {
        
        public void Configure(EntityTypeBuilder<ClaemInCkdqr> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Claem).WithMany(x => x.claemInCkdqrs).HasForeignKey(x => x.ClaemId);
            builder.HasOne(x => x.CKDQR).WithMany(x => x.claemInCkdqrs).HasForeignKey(x => x.CkdqrId);
        }
    }
}
