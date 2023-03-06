using Ikk.Claims.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Batchs
{
    public interface IBatchRepository:IRepository<long,Batch>
    {
    }
}
