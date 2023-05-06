using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.CarInBaches;
using Ikk.Claims.Domain.Enities.CKDQRs;
using Ikk.Claims.Domain.Enities.Claems;
using Ikk.Claims.Domain.Enities.Claims;
using Ikk.Claims.Domain.Enities.Parts;
using Ikk.Claims.Domain.Enities.TypeCars;
using Ikk.Claims.Domain.Enities.Users;
using Ikk.Claims.Domain.Entities.Users;
using Ikk.Claims.Infrastructure.EfCore.Mappings.Batchs;
using Ikk.Claims.Infrastructure.EfCore.Mappings.CarInBatchs;
using Ikk.Claims.Infrastructure.EfCore.Mappings.CKDQRMapping;
using Ikk.Claims.Infrastructure.EfCore.Mappings.Claems;
using Ikk.Claims.Infrastructure.EfCore.Mappings.Parts;
using Ikk.Claims.Infrastructure.EfCore.Mappings.TypeCars;
using Ikk.Claims.Infrastructure.EfCore.Mappings.Users;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ikk.Claims.Infrastructure.EfCore.Context
{
    public class ClaemContext : DbContext
    {
        public ClaemContext(DbContextOptions<ClaemContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Part> Parts{ get; set; }
        public DbSet<TypeCar> TypeCars{ get; set; }
        public DbSet<Batch> Batchs{ get; set; }
        public DbSet<CarInBatch> carInBatches{ get; set; }
        public DbSet<Claem> Claems { get; set; }
        public DbSet<ClaemPic> ClaemPics { get; set; }
        public DbSet<CKDQR> CKDQRs { get; set; }
        public DbSet<CKDQRPic> CKDQRPics { get; set; }
        public DbSet<ClaemInCkdqr> claemInCkdqrs { get; set; }
        public DbSet<ClaimInPart> claemInParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("clm");
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(u => !u.IsRemoved);
            //modelBuilder.Entity<Role>().HasData(new Role("Admin",true));
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new UserInRoleMapping());
            modelBuilder.ApplyConfiguration(new PartMapping());
            modelBuilder.ApplyConfiguration(new TypeCarMapping());
            modelBuilder.ApplyConfiguration(new BatchMapping());
            modelBuilder.ApplyConfiguration(new CarInBatchMapping());
            modelBuilder.ApplyConfiguration(new ClaemMapping());
            modelBuilder.ApplyConfiguration(new ClaemPicMapping());
            modelBuilder.ApplyConfiguration(new CKDQRMapping());
            modelBuilder.ApplyConfiguration(new CKDQRPicMapping());
            modelBuilder.ApplyConfiguration(new ClaemInCkdqrMapping());
            modelBuilder.ApplyConfiguration(new ClaimInPartMapping());


        }
    }
}
