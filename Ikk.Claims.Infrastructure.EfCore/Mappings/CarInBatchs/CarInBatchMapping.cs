using Ikk.Claims.Domain.Enities.CarInBaches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.CarInBatchs
{
    public class CarInBatchMapping : IEntityTypeConfiguration<CarInBatch>
    {
        public void Configure(EntityTypeBuilder<CarInBatch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Typecar).WithMany(x => x.CarInBatches).HasForeignKey(x => x.TypeCarId);
            builder.HasOne(x => x.Batch).WithMany(x => x.CarInBatchs).HasForeignKey(x => x.BatchId);
        }
    }
}
