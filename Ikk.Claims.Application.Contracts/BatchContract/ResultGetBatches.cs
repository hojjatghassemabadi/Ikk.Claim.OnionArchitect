using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.BatchContract
{
    public class ResultGetBatches
    {
        public int RowCount { get; set; }
        public List<GetBatchViewModel> batches { get; set; }
    }
}
