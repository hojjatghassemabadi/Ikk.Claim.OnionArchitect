using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.ClaemContracts
{
    public class GetClaemPicsViewModel
    {
        public long Id { get; set; }
        public string PicName { get; set; }
        public long ClaemId { get; set; }
    }
}
