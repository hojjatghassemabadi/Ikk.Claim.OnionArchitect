using Ikk.Claims.Application.Contracts.Rolecontract;
using Ikk.Claims.Application.Contracts.UserContracts;
using Ikk.Claims.Common.Infrastructure;

namespace Ikk.Claims.Domain.Enities.Users
{
    public interface IRoleRepository:IRepository<long,Role>
    {
        List<GetRolesWithIdViewModel> GetList();
    }
}
