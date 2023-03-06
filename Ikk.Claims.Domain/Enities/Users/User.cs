using Ikk.Claims.Common.Entieties;

using Ikk.Claims.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Users
{
    public class User:BaseEntity
    {
        public string Name { get; private set; }
        public string Famil { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Status { get; private set; } = true;

        public ICollection<UserInRole> UserInRoles { get; set; }

        protected User()
        {

        }
        public User(string name, string famil, string userName, string password, bool status,long CreateBy)
        {
            Name = name;
            Famil = famil;
            UserName = userName;
            Password = password;
            Status = status;
            Create(CreateBy);
        }
        public void EditUser(string name, string famil, string userName, string password, bool status,long editedBy)
        {
            Name = name;
            Famil = famil;
            UserName = userName;
            Password = password;
            Status = status;
            Edit(editedBy);
        }
        public void ChangeStatus(bool status)
        {
            Status = status;
            
        }
    }

}
