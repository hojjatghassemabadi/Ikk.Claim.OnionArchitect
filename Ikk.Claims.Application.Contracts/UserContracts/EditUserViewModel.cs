using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.UserContracts
{
    public class EditUserViewModel:CreateUsersViewModel
    {
        public long Id { get; set; }
    }
}
