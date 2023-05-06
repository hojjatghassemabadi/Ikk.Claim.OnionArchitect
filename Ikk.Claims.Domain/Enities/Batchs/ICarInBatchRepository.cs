using Ikk.Claims.Application.Contracts.CarInBatchContracts;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.CarInBaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Batchs
{
    public interface ICarInBatchRepository : IRepository<long, CarInBatch>
    {
        void RemoveAll(long batchId, long typeCarId);
        GetBatchWithCarViewModel GetWithBatch(long batchId);
        CarInBatch GetWithTypeCarAndBatch(long batchId, long typeCarId);
    }
}
