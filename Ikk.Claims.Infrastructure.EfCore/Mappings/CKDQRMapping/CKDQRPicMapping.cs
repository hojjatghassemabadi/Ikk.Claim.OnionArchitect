using Ikk.Claims.Domain.Enities.CKDQRs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.CKDQRMapping
{
    public class CKDQRPicMapping : IEntityTypeConfiguration<CKDQRPic>
    {
        public void Configure(EntityTypeBuilder<CKDQRPic> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CKDQR).WithMany(x => x.Pics).HasForeignKey(x => x.CkdqrId);

        }
    }
}
