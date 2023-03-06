



using Ikk.Claims.Application.UserApplications;
using Ikk.Claims.Application.Contracts.UserContracts;
using Ikk.Claims.Domain.Enities.Users;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Ikk.Claims.Infrastructure.EfCore.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ikk.Claims.Application.RoleApplications;
using Ikk.Claims.Application.Contracts.Rolecontract;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Infrastructure.EfCore.Repositories;
using Ikk.Claims.Domain.Enities.Parts;
using Ikk.Claims.Infrastructure.EfCore.Repositories.Parts;
using Ikk.Claims.Application.PartApplication;
using Ikk.Claims.Application.Contracts.PartContracts;
using Ikk.Claims.Domain.Enities.TypeCars;
using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Infrastructure.EfCore.Repositories.Batchs;
using Ikk.Claims.Infrastructure.EfCore.Repositories.TypeCars;
using Ikk.Claims.Application.Contracts.TypeCarContract;
using Ikk.Claims.Application.Contracts.BatchContract;
using Ikk.Claims.Application.TypeCarApplication;
using Ikk.Claims.Application.BatchApplication;

namespace Ikk.Claims.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string ConnectionString)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<ClaimContext>(options => options.UseSqlServer(ConnectionString));
            services.AddTransient<IUsersApplication, UsersApplication>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPartRepository, PartRepository>();
            services.AddTransient<ITypeCarRepository, TypeCarRepository>();
            services.AddTransient<IBatchRepository, BatchRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IPartApplication, PartApplication>();
            services.AddTransient<ITypeCarApplication, TypeCarApplication>();
            services.AddTransient<IBatchApplication, BatchApplication>();

            services.AddTransient<IUserInRoleRepository, UserInRoleRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
