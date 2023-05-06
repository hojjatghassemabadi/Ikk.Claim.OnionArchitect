using Ikk.Claims.Application.Contracts.ClaemContracts;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Claems
{
    public interface IClaemRepository:IRepository<long,Claem>
    {
        ResultGetClaems ListWithoutCkdqr(RequestDto request);
        int Counts();
        GetClaemViewModel GetClaemWithClaemNumber(string claemNumber);
    }
}
