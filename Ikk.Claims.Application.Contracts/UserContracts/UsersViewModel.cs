using Ikk.Claims.Application.Contracts.Rolecontract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.UserContracts
{
    public class UsersViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Famil { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public string DateCreated { get; set; }
        public List<GetRolesWithIdViewModel> Roles { get; set; }
    }
}
