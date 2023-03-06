using Ikk.Claims.Application.Contracts.Rolecontract;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain;
using Ikk.Claims.Domain.Enities.Users;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Users
{
    public class RoleRepository :BaseRepository<long,Role>, IRoleRepository
    {
        private readonly ClaimContext _context;
        public RoleRepository(ClaimContext context) : base(context)
        {
            _context = context;
        }

        public List<GetRolesWithIdViewModel> GetList()
        {
            return _context.Roles.Select(x => new GetRolesWithIdViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
            }).ToList();
        }

    }
}
