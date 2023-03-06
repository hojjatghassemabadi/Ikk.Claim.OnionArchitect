using Ikk.Claims.Application.Contracts.Rolecontract;

namespace Ikk.Claims.Application.Contracts.UserContracts
{
    public class CreateUsersViewModel
    {
        public string name { get; set; }
        public string famil { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
        public List<RoleViewModel>? roles { get; set; }


    }
}
