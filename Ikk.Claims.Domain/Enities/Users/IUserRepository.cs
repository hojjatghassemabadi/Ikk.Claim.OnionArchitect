using Ikk.Claims.Application.Contracts.UserContracts;
using Ikk.Claims.Common.Infrastructure;

namespace Ikk.Claims.Domain.Enities.Users
{
    public interface IUserRepository:IRepository<long,User>
    {
        List<UsersViewModel> GetAll();
        User GetBy(string username);
    }
}
