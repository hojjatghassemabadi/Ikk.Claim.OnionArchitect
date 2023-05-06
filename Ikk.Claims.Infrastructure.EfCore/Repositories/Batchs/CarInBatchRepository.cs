using Ikk.Claims.Application.Contracts.CarInBatchContracts;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.CarInBaches;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Batchs
{
    public class CarInBatchRepository : BaseRepository<long, CarInBatch>, ICarInBatchRepository
    {
        private readonly ClaemContext _context;
        public CarInBatchRepository(ClaemContext context) : base(context)
        {
            _context=context;
        }

        public GetBatchWithCarViewModel GetWithBatch(long batchId)
        {
            return _context.carInBatches.Include(x=>x.Batch).Include(x=>x.Typecar).Where(x => x.BatchId == batchId).Select(x=>new GetBatchWithCarViewModel
            {
                BatchCode=x.Batch.Name,
                BatchId=x.BatchId,
                CarId=x.TypeCarId,
                CarModelName=x.Typecar.Name
            }).FirstOrDefault();
            
        }

        public CarInBatch GetWithTypeCarAndBatch(long batchId, long typeCarId)
        {
            return _context.carInBatches.FirstOrDefault(x => x.BatchId == batchId && x.TypeCarId == typeCarId);
        }

        public void RemoveAll(long batchId, long typeCarId)
        {
            _context.Remove(GetWithTypeCarAndBatch(batchId, typeCarId));
        }
    }
}
