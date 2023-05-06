using Ikk.Claims.Domain.Enities.Claems;
using Ikk.Claims.Domain.Enities.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.Claems
{
    public class ClaemPicMapping : IEntityTypeConfiguration<ClaemPic>
    {
        public void Configure(EntityTypeBuilder<ClaemPic> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Claem).WithMany(x => x.Pics).HasForeignKey(x=>x.ClaemId);

        }
    }
}

