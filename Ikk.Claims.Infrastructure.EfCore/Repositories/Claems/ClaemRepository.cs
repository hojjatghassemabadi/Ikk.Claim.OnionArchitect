using Ikk.Claims.Application.Contracts.ClaemContracts;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Claems;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Claems
{
    public class ClaemRepository : BaseRepository<long, Claem>, IClaemRepository
    {
        private readonly ClaemContext _context;
        public ClaemRepository(ClaemContext context) : base(context)
        {
            this._context = context;
        }

        public int Counts()
        {
            var c=_context.Claems.Select(x => x.Id).ToList();

            return c.Count();
        }
        public GetClaemViewModel GetClaemWithClaemNumber(string claemNumber)
        {
            var result= _context.Claems.Select(p=>new GetClaemViewModel
            {
                Id=p.Id,
                BatchId = p.BatchId,
                BatchName=p.Batch.Name,
                ClaimNumber=p.ClaemNumber,
                Company=p.Company,
                CountPart=p.CountPart,  
                Country=p.Country,
                Desc=p.Desc,
                RegisterDate=p.RegisterDate
                
            }).Where(p=>p.ClaimNumber == claemNumber).FirstOrDefault();
            return result;
        }
        public ResultGetClaems ListWithoutCkdqr(RequestDto request)
        {
            var result=_context.Claems.Include(x => x.claemInCkdqrs).Select(x=>new GetClaemViewModel
            {
                
                BatchId = x.BatchId,
                ClaimNumber=x.ClaemNumber,
                Company=x.Company,
                CountPart=x.CountPart,
                Country=x.Country, 
                Desc=x.Desc,
                Id=x.Id
            }).ToList();
            return new ResultGetClaems
            {
                claims = result,
                RowCount = result.Count
            };
        }
    }
}
