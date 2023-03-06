using Ikk.Claims.Common;
using Ikk.Claims.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.UserContracts
{
    public interface IUsersApplication
    {
        ResultGetUsers List(RequestDto request);
        void Create(CreateUsersViewModel command);
        EditUserViewModel SignIn(string username, string password);
        void Edit(EditUserViewModel command);
        EditUserViewModel Get(long id);
        void Remove(long id);
        void ChangeStatus(long id);
        JwtAuthResponse Autentication(string username, string password);

    }
}
