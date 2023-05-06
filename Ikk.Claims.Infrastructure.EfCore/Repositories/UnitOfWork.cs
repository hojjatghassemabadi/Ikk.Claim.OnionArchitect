using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ClaemContext _context;
        public UnitOfWork(ClaemContext context)
        {
            _context = context;
        }
        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }
        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }
        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
