using Ikk.Claims.Application.Contracts.TypeCarContract;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.TypeCars;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.TypeCars
{
    public class TypeCarRepository : BaseRepository<long, TypeCar>, ITypeCarRepository
    {
        private readonly ClaimContext _context;
        public TypeCarRepository(ClaimContext context) : base(context)
        {
            _context = context;
        }
        public List<GetTypeCarViewModel> GetList()
        {
            return _context.TypeCars.Select(x => new GetTypeCarViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
            }).ToList();
        }

    }
}
