using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.PartInClaim
{
    public class GetPartInClaimViewModel
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public long ClaemId { get; set; }
    }
}
