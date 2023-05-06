using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Parts;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Parts
{
    public class PartRepository : BaseRepository<long, Part>, IPartRepository
    {
        private readonly ClaemContext _context;
        public PartRepository(ClaemContext context) : base(context)
        {
        }
    }
}
