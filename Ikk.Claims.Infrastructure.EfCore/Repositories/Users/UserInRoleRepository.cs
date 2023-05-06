using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Users;
using Ikk.Claims.Domain.Entities.Users;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Users
{
    public class UserInRoleRepository :BaseRepository<long,UserInRole>, IUserInRoleRepository
    {
        private readonly ClaemContext _context;

        public UserInRoleRepository(ClaemContext context) : base(context)
        {
            _context = context;
        }

        public List<UserInRole> GetWithUser(long userId)
        {
            return _context.UserInRoles.Where(x => x.UserId == userId).ToList();
        }
        public void RemoveAll(long userId, long roleId)
        {
            _context.Remove(GetWithRoleAndUser(userId,roleId));
           
        }
        public UserInRole GetWithRoleAndUser(long userId, long roleId)
        {
            return _context.UserInRoles.FirstOrDefault(x => x.RoleId == roleId && x.UserId == userId);
        }
    }
}
