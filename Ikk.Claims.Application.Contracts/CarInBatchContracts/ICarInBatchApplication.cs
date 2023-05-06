using Ikk.Claims.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.CarInBatchContracts
{
    public interface ICarInBatchApplication
    {
        GetBatchWithCarViewModel Get(long batchId);
        void Remove(long id);
    }
}
