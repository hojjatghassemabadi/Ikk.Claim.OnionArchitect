using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.TypeCars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.Batchs
{
    public class BatchMapping : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.TypeCar).WithOne(x => x.Batch).HasForeignKey<TypeCar>(x => x.BatchId);
        }
    }
}
