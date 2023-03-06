using Ikk.Claims.Common.Entieties;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities
{
    public class Parts:BaseEntity
    {
        public string PartName { get;private set; }
        public string PartNumber { get;private set; }
        public bool Status { get; private set; }

    }
}
