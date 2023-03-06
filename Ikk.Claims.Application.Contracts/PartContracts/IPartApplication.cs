using Ikk.Claims.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.PartContracts
{
    public interface IPartApplication
    {
        List<GetPartViewModel> List(RequestDto request);
        void Create(RegisterPartViewModel command);
        void Edit(EditPartViewModel command);
        GetPartViewModel Get(long id);
        void Remove(long id);
        void ChangeStatus(long id);
    }

}
