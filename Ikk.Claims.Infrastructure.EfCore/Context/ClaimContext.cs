using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.Parts;
using Ikk.Claims.Domain.Enities.TypeCars;
using Ikk.Claims.Domain.Enities.Users;
using Ikk.Claims.Domain.Entities.Users;
using Ikk.Claims.Infrastructure.EfCore.Mappings.Batchs;
using Ikk.Claims.Infrastructure.EfCore.Mappings.Parts;
using Ikk.Claims.Infrastructure.EfCore.Mappings.TypeCars;
using Ikk.Claims.Infrastructure.EfCore.Mappings.Users;
using Microsoft.EntityFrameworkCore;

namespace Ikk.Claims.Infrastructure.EfCore.Context
{
    public class ClaimContext : DbContext
    {
        public ClaimContext(DbContextOptions<ClaimContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Part> Parts{ get; set; }
        public DbSet<TypeCar> TypeCars{ get; set; }
        public DbSet<Batch> Batchs{ get; set; }
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
        }
    }
}
