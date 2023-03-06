using Ikk.Claims.Common.Entities;

namespace Ikk.Claims.Application.Contracts.Rolecontract
{
    public interface IRoleApplication
    {
        List<GetRolesWithIdViewModel> List(RequestDto request);
        void Create(RegisterRoleViewModel command);
        void Edit(EditRoleViewModel command);
        GetRolesWithIdViewModel Get(long id);
        void Remove(long id);
        void ChangeStatus(long id);

    }
}
