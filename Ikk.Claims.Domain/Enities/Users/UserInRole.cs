
using Ikk.Claims.Domain.Enities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ikk.Claims.Domain.Entities.Users
{

    public class UserInRole {
        
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public virtual User User { get; set; }
        public long RoleId { get; private set; }
        public virtual Role Role { get; set; }

        protected UserInRole()
        {

        }
        public UserInRole(long userId,User user, long roleId,Role role)
        {
            UserId = userId;
            User = user;
            RoleId = roleId;
            Role = role;

        }
    }
}
