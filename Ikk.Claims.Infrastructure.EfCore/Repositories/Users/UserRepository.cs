using Ikk.Claims.Application.Contracts.Rolecontract;
using Ikk.Claims.Application.Contracts.UserContracts;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Users;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Users
{
    public class UserRepository : BaseRepository<long,User>, IUserRepository
    {
        private readonly ClaimContext _context;
        public UserRepository(ClaimContext context) : base(context)
        {
            _context = context;
        }

        public List<UsersViewModel> GetAll()
        {
            return _context.Users.Include(x=>x.UserInRoles).Select(x=>new UsersViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Famil = x.Famil,
                Status = x.Status,
                UserName = x.UserName,
                DateCreated = x.DateCreated.ToString(),
                Roles = x.UserInRoles.Select(x => new GetRolesWithIdViewModel { Id = x.Id, Name = x.Role.Name, Status = x.Role.Status }).ToList()
            }).ToList();
        }

        public User GetBy(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName.Equals(username));
        }
    }
}
