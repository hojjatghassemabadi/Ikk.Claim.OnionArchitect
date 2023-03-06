using Ikk.Claims.Application.Contracts.BatchContract;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Batchs
{
    public class BatchRepository : BaseRepository<long, Batch>, IBatchRepository
    {
        private readonly ClaimContext _context;
        public BatchRepository(ClaimContext context) : base(context)
        {
            _context=context;
        }
        public List<GetBatchViewModel> GetList()
        {
            return _context.TypeCars.Select(x => new GetBatchViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
            }).ToList();
        }
    }
}
