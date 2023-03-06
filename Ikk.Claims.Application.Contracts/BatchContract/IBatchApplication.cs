using Ikk.Claims.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.BatchContract
{
    public interface IBatchApplication
    {
        List<GetBatchViewModel> List(RequestDto request);
        void Create(RegisterBatchViewModel command);
        void Edit(EditBatchViewModel command);
        GetBatchViewModel Get(long id);
        void Remove(long id);
        void ChangeStatus(long id);
    }
}
