
using Ikk.Claims.Domain.Enities.CKDQRs;
using Ikk.Claims.Domain.Enities.Claems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.CKDQRMapping
{
    public class CKDQRMapping : IEntityTypeConfiguration<CKDQR>
    {
        public void Configure(EntityTypeBuilder<CKDQR> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReportNumber);
            builder.Property(x => x.OverSeasFactory);
            builder.Property(x => x.CountainerNo);
            builder.Property(x => x.caseNo);
            builder.Property(x => x.PackingStatus);
            builder.Property(x => x.OverSeasePlantAction);
            builder.Property(x => x.Responsibility);
            builder.Property(x => x.URgencyClassification);
            builder.Property(x => x.Attachment);
            builder.Property(x => x.Warranty);
            builder.Property(x => x.Problemtype);
            builder.Property(x => x.Details);

            builder.HasMany(x => x.Pics).WithOne(x => x.CKDQR).HasForeignKey(x => x.CkdqrId);
            builder.HasMany(x => x.claemInCkdqrs).WithOne(x => x.CKDQR).HasForeignKey(x => x.CkdqrId);

        }
    }
}
