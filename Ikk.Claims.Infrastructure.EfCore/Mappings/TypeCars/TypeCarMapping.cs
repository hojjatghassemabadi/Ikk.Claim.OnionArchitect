using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.TypeCars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Mappings.TypeCars
{
    public class TypeCarMapping : IEntityTypeConfiguration<TypeCar>
    {
        public void Configure(EntityTypeBuilder<TypeCar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Status);
            builder.HasOne(x => x.Batch).WithOne(x => x.TypeCar).HasForeignKey<Batch>(x => x.TypecarId);
        }
    }
}
