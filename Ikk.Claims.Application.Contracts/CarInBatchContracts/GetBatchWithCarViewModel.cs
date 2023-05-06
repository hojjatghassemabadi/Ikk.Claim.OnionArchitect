using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.CarInBatchContracts
{
    public class GetBatchWithCarViewModel
    {
        public long BatchId { get; set; }
        public string BatchCode { get; set; }
        public long CarId { get; set; }
        public string CarModelName { get; set; }
    }
}
