



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
            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IUserInRoleRepository, UserInRoleRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
