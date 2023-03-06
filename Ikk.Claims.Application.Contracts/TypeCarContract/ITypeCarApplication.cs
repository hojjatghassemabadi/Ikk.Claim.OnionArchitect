using Ikk.Claims.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.TypeCarContract
{
    public interface ITypeCarApplication
    {
        List<GetTypeCarViewModel> List(RequestDto request);
        void Create(RegisterTypeCarViewModel command);
        void Edit(EditTypeCarViewModel command);
        GetTypeCarViewModel Get(long id);
        void Remove(long id);
        void ChangeStatus(long id);
    }
}
